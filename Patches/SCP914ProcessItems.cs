using Harmony;
using Scp914;
using System.Collections.Generic;
using UnityEngine;
using EXILED;
using Mirror;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;
using System.Linq;
using System;
using RemoteAdmin;

namespace Better914.Patches
{
	[HarmonyPatch(typeof(Scp914Machine), nameof(Scp914Machine.ProcessItems))]
	public class SCP914ProcessItems
	{
		public static bool Prefix(Scp914Machine __instance)
		{
			try
			{
				if (!PluginConfig.Cfg.Enabled) return true;
				if (!PluginConfig.Cfg.UseNewRecipeSystem) return true;

				if (!NetworkServer.active) return false;
				Collider[] array = Physics.OverlapBox(__instance.intake.position, __instance.inputSize / 2f);
				__instance.players.Clear();
				__instance.items.Clear();
				foreach (var collider in array)
				{
					var ccm = collider.GetComponent<CharacterClassManager>();
					if (ccm != null)
					{
						__instance.players.Add(ccm);
					}
					else
					{
						var pickup = collider.GetComponent<Pickup>();
						if (pickup != null)
						{
							__instance.items.Add(pickup);
						}
					}
				}

				return Upgrade(__instance, __instance.items, __instance.players);
			}
			catch (Exception ex)
			{
				Log.Error(ex.ToString());
				return true;
			}
		}

		public static bool Upgrade(Scp914Machine instance, IEnumerable<Pickup> items, IEnumerable<CharacterClassManager> players)
		{
			if (!NetworkServer.active) return true;
			foreach (var pickup in items)
			{
				UpgradeItem(instance, pickup, true);
				Scp914Machine.TryFriendshipAchievement(pickup.ItemId, pickup.info.ownerPlayer.GetComponent<CharacterClassManager>(), players);
			}

			TrySwitchPlayers(instance, players.ToList());

			foreach (var ccm in players)
			{
				UpgradePlayer(instance, ccm, players);
			}


			return false;
		}

		public static void UpgradeItem(Scp914Machine instance, Pickup pickup, bool dropped)
		{
			var selectedItem = GetItem(instance.knobState, pickup.ItemId);

			if (selectedItem < 0)
			{
				pickup.Delete();
				return;
			}
			pickup.SetIDFull(selectedItem);

			if (dropped)
			{
				Vector3 b = instance.output.position - instance.intake.position;
				pickup.transform.position += b;
			}
		}

		public static ItemType GetItem(Scp914Knob knobStateRaw, ItemType item)
		{
			var recipe = Plugin.Recipes.Where(e => e.item == item).FirstOrDefault();
			if (recipe == null || recipe == default) recipe = Plugin.CreateDefaultRecipe(item);

			int knobState = (int)knobStateRaw - 2;
			var upgradeLevel = knobState;
			int v = 0;
			if (knobState == -2)
			{
				v = GetRandomItem(
					new float[] { 
						0,
						0,
						0,
						100 - (PluginConfig.Cfg.Level_3Chance + PluginConfig.Cfg.Level_4Chance),
						PluginConfig.Cfg.Level_3Chance,
						PluginConfig.Cfg.Level_4Chance
					} ) - 1;
			}
			else if (knobState == -1)
			{
				v = GetRandomItem(
					new float[] { 
						PluginConfig.Cfg.SameItemChance,
						0,
						100 - (PluginConfig.Cfg.SameItemChance + PluginConfig.Cfg.Level_2Chance),
						PluginConfig.Cfg.Level_2Chance
					} ) - 1;
			}
			else if (knobState == 0)
			{
				v = GetRandomItem(
					new float[] { 
						PluginConfig.Cfg.SameItemChance,
						100 - PluginConfig.Cfg.SameItemChance
					} ) - 1;
			}
			else if (knobState == 1)
			{
				v = GetRandomItem(
					new float[] { 
						PluginConfig.Cfg.SameItemChance,
						0,
						100 - (PluginConfig.Cfg.SameItemChance + PluginConfig.Cfg.Level2Chance),
						PluginConfig.Cfg.Level2Chance
					} ) - 1;
			}
			else if (knobState == 2)
			{
				v = GetRandomItem(
					new float[] { 
						PluginConfig.Cfg.SameItemChance,
						0,
						0,
						100 - (PluginConfig.Cfg.Level3Chance + PluginConfig.Cfg.Level4Chance),
						PluginConfig.Cfg.Level3Chance,
						PluginConfig.Cfg.Level4Chance
					} ) - 1;
			}
			
			if (v == -1) return item; //-1 = the same item
			else {
				upgradeLevel = v;
				var options =	(upgradeLevel == -4) ? recipe.level__4 :
								(upgradeLevel == -3) ? recipe.level__3 :
								(upgradeLevel == -2) ? recipe.level__2 :
								(upgradeLevel == -1) ? recipe.level__1 :
								(upgradeLevel == 0)  ? recipe.level_0  :
								(upgradeLevel == 1)  ? recipe.level_1  :
								(upgradeLevel == 2)  ? recipe.level_2  :
								(upgradeLevel == 3)  ? recipe.level_3  :
								(upgradeLevel == 4)  ? recipe.level_4  : new ItemType[] { };

				if (options.Length > 0)
				{
					return options[options.Length > 1 ? Random.Range(0, options.Length - 1) : 0];
				}
				else return item;
			}
		}

		public static void UpgradePlayer(Scp914Machine instance, CharacterClassManager player, IEnumerable<CharacterClassManager> players)
		{
			var c = PluginConfig.Cfg;

			if (!c.RoughCoarseDamageSCP && player.IsScpButNotZombie())
			{
				TeleportPlayer(instance, player);
				return;
			}

			if (CheckPercent(c.InvUpgradeChance) && !player.IsAnyScp())
			{
				Inventory inv = player.GetComponent<Inventory>();
				if (inv.items.Count > 0)
				{
					var index = inv.items.Count > 1 ? Random.Range(0, inv.items.Count - 1) : 0;
					var itemInfo = inv.items[index];
					var item = GetItem(instance.knobState, itemInfo.id);
					if (item < 0)
					{
						inv.items.RemoveAt(index);
					}
					else
					{
						itemInfo.id = item;
						inv.items[index] = itemInfo;
						Scp914Machine.TryFriendshipAchievement(item, player, players);
					}
				}
			}

			if (c.ChangePlayerHealth)
			{
				if (!player.GodMode && player.CurClass != RoleType.Spectator)
				{
					HealthChangedComponent component = player.GetComponent<HealthChangedComponent>();
					var stats = player.GetComponent<PlayerStats>();
					if (component == null)
					{
						component = player.gameObject.AddComponent<HealthChangedComponent>();
						component.OriginalHealthAmmount = stats.maxHP;
						component.ActualHealthPercentage = 100;
					}
					var newPercent = component.ActualHealthPercentage;

					if (instance.knobState == Scp914Knob.Rough)
					{
						if (CheckPercent(c.RoughDamageChance) || (CheckPercent(c.RoughDamageChance * c.SCPDamageChanceMultiplier) && player.IsScpButNotZombie()))
						{
							if (player.IsScpButNotZombie())
							{
								stats.HurtPlayer(new PlayerStats.HitInfo(stats.maxHP * ((c.RoughDamageAmmout / 2) / 100), Plugin.LastPlayer, Plugin.Scp914DamageType, Plugin.LastPlayerId), player.gameObject);
							}
							else
							{
								newPercent -= c.RoughDamageAmmout;
							}
						}
					}
					else if (instance.knobState == Scp914Knob.Coarse)
					{
						if (CheckPercent(c.CoarseDamageChance) || (CheckPercent(c.CoarseDamageChance * c.SCPDamageChanceMultiplier) && player.IsScpButNotZombie()))
						{
							if (player.IsScpButNotZombie())
							{
								stats.HurtPlayer(new PlayerStats.HitInfo(stats.maxHP * ((c.CoarseDamageAmmout / 2) / 100), Plugin.LastPlayer, Plugin.Scp914DamageType, Plugin.LastPlayerId), player.gameObject);
							}
							else
							{
								newPercent -= c.CoarseDamageAmmout;
							}
						}
					}
					else if (instance.knobState == Scp914Knob.Fine && !player.IsScpButNotZombie())
					{
						if (CheckPercent(c.FineHealChance))
						{
							newPercent += c.FineHealAmmout;
						}
					}
					else if (instance.knobState == Scp914Knob.VeryFine && !player.IsScpButNotZombie())
					{
						if (CheckPercent(c.VeryFineHealChance))
						{
							newPercent += c.VeryFineHealAmmout;
						}
					}
					newPercent = Constrain(newPercent, 100 - c.RoughDamageAmmout, 100 + c.VeryFineHealAmmout);
					Log.Info("newPercent: " + newPercent + "%");
					if (newPercent <= 0)
					{
						stats.HurtPlayer(new PlayerStats.HitInfo(stats.maxHP + 100f, Plugin.LastPlayer, Plugin.Scp914DamageType, Plugin.LastPlayerId), player.gameObject);
						Object.Destroy(component);
					}
					else if (newPercent >= 100)
					{
						var prev = stats.maxHP;
						stats.maxHP = Mathf.RoundToInt(component.OriginalHealthAmmount * (newPercent / 100));
						if (prev > stats.maxHP)
						{
							stats.health = stats.maxHP < stats.health ? stats.maxHP : stats.health;
						}
						else if (!player.IsScpButNotZombie())
						{
							stats.HealHPAmount(999999f);
						}
					}
					component.ActualHealthPercentage = newPercent;
					Log.Info(component.ActualHealthPercentage + "% " + stats.maxHP + "HP " + stats.health + "health");
				}
			}
			TeleportPlayer(instance, player);
		}

		public static void TeleportPlayer(Scp914Machine instance, CharacterClassManager player)
		{
			Vector3 b = instance.output.position - instance.intake.position;
			player.GetComponent<PlyMovementSync>().OverridePosition(player.transform.position + b, 0f, false);
		}

		public static void TrySwitchPlayers(Scp914Machine instance, List<CharacterClassManager> players)
		{
			if (instance.knobState == Scp914Knob.OneToOne)
			{
				if (players.Count < 2) return;

				if (CheckPercent(PluginConfig.Cfg.SwapRoleChance))
				{
					var player = players[Random.Range(0, players.Count - 1)];
					var player2 = SelectDifferentRole(player, players.Except(new CharacterClassManager[] { player }));
					var posTemp = player.transform.position;
					var roleTemp = player.CurClass;
					SetClass(player, player2.CurClass, player2.transform.position);
					SetClass(player2, roleTemp, posTemp);
				}
			}
		}

		public static void SetClass(CharacterClassManager player, RoleType role, Vector3 position)
		{
			player.NetworkCurClass = role;
			player.GetComponent<PlayerStats>().health = player.Classes.SafeGet(role).maxHP * (player.GetComponent<HealthChangedComponent>().ActualHealthPercentage / 100);
			player.GetComponent<PlayerStats>().maxHP = Mathf.RoundToInt(player.Classes.SafeGet(role).maxHP * (player.GetComponent<HealthChangedComponent>().ActualHealthPercentage / 100));
			player.GetComponent<PlyMovementSync>().OverridePosition(position, 0f, false);
		}

		public static CharacterClassManager SelectDifferentRole(CharacterClassManager player, IEnumerable<CharacterClassManager> players)
		{
			var different = players.Where(lPlayer => lPlayer.CurClass != player.CurClass && lPlayer.Classes.SafeGet(lPlayer.CurClass).team != player.Classes.SafeGet(player.CurClass).team && !lPlayer.IsAnyScp());
			if (different != null && different.Count() > 0) {
				return different.ElementAt((different.Count() == 1) ? 0 : Random.Range(0, different.Count() - 1));
			}
			return null;
		}

		public static float Constrain(float number, float min, float max)
		{
			return (number < min) ? min : (number > max) ? max : number;
		}

		public static int GetRandomItem(float[] chances) //chances[0] is chance for the same item
		{
			for(int i = 0; i < chances.Length; i++) 
			{
				chances[i] *= 0.1f;
			}
			var r = Random.Range(0, 10);
			float sum = 0;
			for(int i = 0; i < chances.Length; i++)
			{
				if (r + sum >= chances[i]) return i;
				else sum += chances[i];
			}
			return 0; //if total chances are < 100% this can occur, the item wont be upgraded
		}
		
		public static bool CheckPercent(float chance)
		{
			chance /= 10;
			var r = Random.Range(0, 10);
			return r <= chance;
		}
	}
}
