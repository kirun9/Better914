using EXILED;
using Harmony;
using RemoteAdmin;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Better914
{
    public partial class Plugin : EXILED.Plugin
    {
        public override string getName { get; } = "Better 914";

       // public static bool KnobBlockade { get; set; } = false;
        public static IEnumerable<MEC.CoroutineHandle> Coroutines { get; set; }

        public static string LastPlayer
        {
            get
            {
                if (LastPlayerHub != null) return LastPlayerHub.GetComponent<NicknameSync>().MyNick;
                else return PlayerManager.localPlayer.GetComponent<NicknameSync>().MyNick;
            }
        }

        public static int LastPlayerId
        {
            get
            {
                if (LastPlayerHub != null) return LastPlayerHub.GetComponent<QueryProcessor>().PlayerId;
                else return PlayerManager.localPlayer.GetComponent<QueryProcessor>().PlayerId;
            }
        }

        public static ReferenceHub LastPlayerHub { get; set; }

        public static List<Scp914Recipe> Recipes { get; private set; }

        public static DamageType Scp914DamageType { get; } = new DamageType("SCP-914", "Cała energia życiowa została zabrana przez SCP-914", false, true, -1);

        public static HarmonyInstance HarmonyInstance { get; private set; }
        public static int HarmonyCounter;

        public override void OnEnable()
        {
            LoadConfig();
            if (PluginConfig.Cfg.Enabled)
            {
                EventPlugin.RegisterDamageType(Scp914DamageType);

                EventPlugin.Scp914KnobChangeEventPatchDisable = true;
                EventPlugin.Scp914ActivationEventPatchDisabled = true;
                EventPlugin.Scp914UpgradeEventPatchDisable = true;

                Events.PlayerDeathEvent += OnPlayerDeath;
                Events.PlayerJoinEvent += OnPlayerJoin;
                Events.PlayerLeaveEvent += OnPlayerLeave;
                Events.RemoteAdminCommandEvent += CommandHandler;

                try
                {
                    var recipesPath = Path.Combine(PluginManager.ExiledDirectory, $"Better914Recipes-{ServerStatic.ServerPort}.json");
                    if (File.Exists(recipesPath))
                        Recipes = Utf8Json.JsonSerializer.Deserialize<List<Scp914Recipe>>(File.ReadAllBytes(Path.Combine()));
                    else
                        Recipes = Plugin.CreateDefaultList();
                    HarmonyInstance = HarmonyInstance.Create("kirun9.b914." + ++HarmonyCounter);
                    HarmonyInstance.PatchAll();
                }
                catch (System.Exception ex)
                {
                    Log.Error(ex.ToString());
                }
            }
        }

        public override void OnDisable()
        {
            if (PluginConfig.Cfg.Enabled)
            {
                Events.PlayerDeathEvent -= OnPlayerDeath;
                Events.PlayerJoinEvent -= OnPlayerJoin;
                Events.PlayerLeaveEvent -= OnPlayerLeave;
                Events.RemoteAdminCommandEvent -= CommandHandler;
            }
            if (HarmonyInstance != null)
            {
                HarmonyInstance.UnpatchAll();
            }
        }

        public void CommandHandler(ref RACommandEvent ev)
        {
            if (ev.Command.ToUpper().StartsWith("B914") )
            {
                var args = ev.Command.Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
                args = args.Select(arg => arg.ToUpper()).ToArray();
                if (args[0] == "B914_DUMPRECIPES" || (args.Length == 2 && args[1] == "DUMPRECIPES"))
                {
                    ev.Allow = false;
                    File.WriteAllBytes(Path.Combine(PluginManager.ExiledDirectory, "Better914Recipes-default.json"), Utf8Json.JsonSerializer.Serialize(Plugin.CreateDefaultList()));
                    ev.Sender.RaReply("Default recipes file dumpedsuccessfully.", true, false, "");
                }
            }
        }

        private void LoadConfig()
        {
            PluginConfig.Cfg = new PluginConfig()
            {
                Enabled                     = Config.GetBool (  "b914_enabled"                      , true  ),
                CanChangeKnobWhileWorking   = Config.GetBool (  "b914_knob_while_working"           , true  ),
                CanDisarmedInteract         = Config.GetBool (  "b914_disarmed_interact"            , true  ),
                OverrideHandcuffConfig      = Config.GetBool (  "b914_override_handcuff_config"     , true  ),
                UseNewRecipeSystem          = Config.GetBool (  "b914_use_new_recipe_system"        , true  ),
                Level_4Chance               = Config.GetFloat(  "b914_level-4_chance"               , 5f    ),
                Level_3Chance               = Config.GetFloat(  "b914_level-3_chance"               , 10f   ),
                Level_2Chance               = Config.GetFloat(  "b914_level-2_chance"               , 20f   ),
                Level2Chance                = Config.GetFloat(  "b914_level2_chance"                , 20f   ),
                Level3Chance                = Config.GetFloat(  "b914_level3_chance"                , 10f   ),
                Level4Chance                = Config.GetFloat(  "b914_level4_chance"                , 5f    ),
                SameItemChance              = Config.GetFloat(  "b914_same_item_chance"             , 20f   ),
                InvUpgradeChance            = Config.GetFloat(  "b914_inv_upgrade_chance"           , 20f   ),
                ChangePlayerHealth          = Config.GetBool (  "b914_change_player_health"         , true  ),
                RoughDamageChance           = Config.GetFloat(  "b914_rough_damage_chance"          , 60f   ),
                CoarseDamageChance          = Config.GetFloat(  "b914_coarse_damage_chance"         , 50f   ),
                FineHealChance              = Config.GetFloat(  "b914_fine_heal_chance"             , 40f   ),
                VeryFineHealChance          = Config.GetFloat(  "b914_veryfine_heal_chance"         , 30f   ),
                RoughDamageAmmout           = Config.GetFloat(  "b914_rough_damage_amount"          , 100f  ),
                CoarseDamageAmmout          = Config.GetFloat(  "b914_coarse_damage_amount"         , 50f   ),
                FineHealAmmout              = Config.GetFloat(  "b914_fine_heal_amount"             , 25f   ),
                VeryFineHealAmmout          = Config.GetFloat(  "b914_veryfine_heal_amount"         , 50f   ),
                RoughCoarseDamageSCP        = Config.GetBool (  "b914_rough_coarse_damage_SCPs"     , true  ),
                SCPDamageChanceMultiplier   = Config.GetFloat(  "b914_SCP_Damage_chance_multiplier" , 0.5f  ),
                SwapPlayersRoles            = Config.GetBool (  "b914_swap_players_roles"           , true  ),
                SwapRoleChance              = Config.GetFloat(  "b914_swap_role_chance"             , 20f   ),
            };
        }

        private void SaveConfig()
        {
            Config.SetString("b914_enabled"                     , PluginConfig.Cfg.Enabled                  .ToString().ToLower());
            Config.SetString("b914_knob_while_working"          , PluginConfig.Cfg.CanChangeKnobWhileWorking.ToString().ToLower());
            Config.SetString("b914_disarmed_interact"           , PluginConfig.Cfg.CanDisarmedInteract      .ToString().ToLower());
            Config.SetString("b914_override_handcuff_config"    , PluginConfig.Cfg.OverrideHandcuffConfig   .ToString().ToLower());
            Config.SetString("b914_use_new_recipe_system"       , PluginConfig.Cfg.UseNewRecipeSystem       .ToString().ToLower());
            Config.SetString("b914_level-4_chance"              , PluginConfig.Cfg.Level_4Chance            .ToString().ToLower());
            Config.SetString("b914_level-3_chance"              , PluginConfig.Cfg.Level_3Chance            .ToString().ToLower());
            Config.SetString("b914_level-2_chance"              , PluginConfig.Cfg.Level_2Chance            .ToString().ToLower());
            Config.SetString("b914_level2_chance"               , PluginConfig.Cfg.Level2Chance             .ToString().ToLower());
            Config.SetString("b914_level3_chance"               , PluginConfig.Cfg.Level3Chance             .ToString().ToLower());
            Config.SetString("b914_level4_chance"               , PluginConfig.Cfg.Level4Chance             .ToString().ToLower());
            Config.SetString("b914_same_item_chance"            , PluginConfig.Cfg.SameItemChance           .ToString().ToLower());
            Config.SetString("b914_inv_upgrade_chance"          , PluginConfig.Cfg.InvUpgradeChance         .ToString().ToLower());
            Config.SetString("b914_change_player_health"        , PluginConfig.Cfg.ChangePlayerHealth       .ToString().ToLower());
            Config.SetString("b914_rough_damage_chance"         , PluginConfig.Cfg.RoughDamageChance        .ToString().ToLower());
            Config.SetString("b914_coarse_damage_chance"        , PluginConfig.Cfg.CoarseDamageChance       .ToString().ToLower());
            Config.SetString("b914_fine_heal_chance"            , PluginConfig.Cfg.FineHealChance           .ToString().ToLower());
            Config.SetString("b914_veryfine_heal_chance"        , PluginConfig.Cfg.VeryFineHealChance       .ToString().ToLower());
            Config.SetString("b914_rough_damage_amount"         , PluginConfig.Cfg.RoughDamageAmmout        .ToString().ToLower());
            Config.SetString("b914_coarse_damage_amount"        , PluginConfig.Cfg.CoarseDamageAmmout       .ToString().ToLower());
            Config.SetString("b914_fine_heal_amount"            , PluginConfig.Cfg.FineHealAmmout           .ToString().ToLower());
            Config.SetString("b914_veryfine_heal_amount"        , PluginConfig.Cfg.VeryFineHealAmmout       .ToString().ToLower());
            Config.SetString("b914_rough_coarse_damage_SCPs"    , PluginConfig.Cfg.RoughCoarseDamageSCP     .ToString().ToLower());
            Config.SetString("b914_SCP_Damage_chance_multiplier", PluginConfig.Cfg.SCPDamageChanceMultiplier.ToString().ToLower());
            Config.SetString("b914_swap_players_roles"          , PluginConfig.Cfg.SwapPlayersRoles         .ToString().ToLower());
            Config.SetString("b914_swap_role_chance"            , PluginConfig.Cfg.SwapRoleChance           .ToString().ToLower());
        }

        public void RemoveComponent(ReferenceHub player)
        {
            var c = player.gameObject.GetComponent<HealthChangedComponent>();
            if (c != null)
            {
                UnityEngine.Object.Destroy(c);
            }
        }

        public void OnPlayerDeath(ref PlayerDeathEvent ev) => RemoveComponent(ev.Player);
        public void OnPlayerJoin(PlayerJoinEvent ev) => RemoveComponent(ev.Player);
        public void OnPlayerLeave(PlayerLeaveEvent ev) => RemoveComponent(ev.Player);

        public override void OnReload()
        {

        }
    }
}
