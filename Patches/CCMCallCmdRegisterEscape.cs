using GameCore;
using Harmony;
using UnityEngine;

namespace Better914.Patches
{
    [HarmonyPatch(typeof(CharacterClassManager), nameof(CharacterClassManager.CallCmdRegisterEscape))]
    public class CCMCallCmdRegisterEscape
    {
        public static bool Prefix(CharacterClassManager __instance)
        {
            if (!PluginConfig.Cfg.Enabled) return true;

            if (!__instance._interactRateLimit.CanExecute(true))
            {
                return false;
            }
            if (Vector3.Distance(__instance.transform.position, __instance.GetComponent<Escape>().worldPosition) >= (float)(Escape.radius * 2))
            {
                return false;
            }

            bool flag = false;
            Handcuffs component = __instance.GetComponent<Handcuffs>();
            if (component.CufferId >= 0 && ConfigFile.ServerConfig.GetBool("cuffed_escapee_change_team", true))
            {
                CharacterClassManager component2 = component.GetCuffer(component.CufferId).GetComponent<CharacterClassManager>();
                if (__instance.CurClass == RoleType.Scientist && (component2.CurClass == RoleType.ChaosInsurgency || component2.CurClass == RoleType.ClassD))
                {
                    flag = true;
                }
                if (__instance.CurClass == RoleType.ClassD && (component2.Classes.SafeGet(component2.CurClass).team == Team.MTF || component2.CurClass == RoleType.Scientist))
                {
                    flag = true;
                }
            }
            Team team = __instance.Classes.SafeGet(__instance.CurClass).team;
            if (team == Team.CDP)
            {
                if (flag)
                {
                    __instance.SetPlayersClass(RoleType.NtfCadet, __instance.gameObject, false, true);
                    RoundSummary.escaped_scientists++;
                    __instance.GetComponent<PlayerStats>().health = __instance.Classes.SafeGet(RoleType.NtfCadet).maxHP * ((__instance.GetComponent<HealthChangedComponent>()?.ActualHealthPercentage ?? 100) / 100);
                    __instance.GetComponent<PlayerStats>().maxHP = Mathf.RoundToInt(__instance.Classes.SafeGet(RoleType.NtfCadet).maxHP * ((__instance.GetComponent<HealthChangedComponent>()?.ActualHealthPercentage ?? 100) / 100));
                    return false;
                }
                __instance.SetPlayersClass(RoleType.ChaosInsurgency, __instance.gameObject, false, true);
                RoundSummary.escaped_ds++;
                __instance.GetComponent<PlayerStats>().health = __instance.Classes.SafeGet(RoleType.ChaosInsurgency).maxHP * ((__instance.GetComponent<HealthChangedComponent>()?.ActualHealthPercentage ?? 100) / 100);
                __instance.GetComponent<PlayerStats>().maxHP = Mathf.RoundToInt(__instance.Classes.SafeGet(RoleType.ChaosInsurgency).maxHP * ((__instance.GetComponent<HealthChangedComponent>()?.ActualHealthPercentage ?? 100) / 100));
                return false;
            }
            else if (team == Team.RSC)
            {
                if (flag)
                {
                    __instance.SetPlayersClass(RoleType.ChaosInsurgency, __instance.gameObject, false, true);
                    RoundSummary.escaped_ds++;
                    __instance.GetComponent<PlayerStats>().health = __instance.Classes.SafeGet(RoleType.ChaosInsurgency).maxHP * ((__instance.GetComponent<HealthChangedComponent>()?.ActualHealthPercentage ?? 100) / 100);
                    __instance.GetComponent<PlayerStats>().maxHP = Mathf.RoundToInt(__instance.Classes.SafeGet(RoleType.ChaosInsurgency).maxHP * ((__instance.GetComponent<HealthChangedComponent>()?.ActualHealthPercentage ?? 100) / 100));
                    return false;
                }
                __instance.SetPlayersClass(RoleType.NtfScientist, __instance.gameObject, false, true);
                RoundSummary.escaped_scientists++;
                __instance.GetComponent<PlayerStats>().health = __instance.Classes.SafeGet(RoleType.NtfScientist).maxHP * ((__instance.GetComponent<HealthChangedComponent>()?.ActualHealthPercentage ?? 100) / 100);
                __instance.GetComponent<PlayerStats>().maxHP = Mathf.RoundToInt(__instance.Classes.SafeGet(RoleType.NtfScientist).maxHP * ((__instance.GetComponent<HealthChangedComponent>()?.ActualHealthPercentage ?? 100) / 100));
                return false;
            }
            return false;
        }
    }
}
