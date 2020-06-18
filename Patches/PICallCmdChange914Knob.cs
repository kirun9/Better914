using Harmony;
using Scp914;
using Utf8Json;

namespace Better914.Patches
{
	[HarmonyPatch(typeof(PlayerInteract), nameof(PlayerInteract.CallCmdChange914Knob))]
	public class PICallCmdChange914Knob
	{
		public static bool Prefix(PlayerInteract __instance)
		{
			if (!PluginConfig.Cfg.Enabled) return true;

			if (!__instance._playerInteractRateLimit.CanExecute(true)
				|| (__instance._hc.CufferId > 0
					&& !(PluginConfig.Cfg.OverrideHandcuffConfig ? PluginConfig.Cfg.CanDisarmedInteract : __instance.CanDisarmedInteract))
				) return false;

			if (!PluginConfig.Cfg.CanChangeKnobWhileWorking && Scp914Machine.singleton.working || !__instance.ChckDis(Scp914Machine.singleton.knob.position)) return false;

			//if (Plugin.KnobBlockade) return false;

			Scp914Machine.singleton.ChangeKnobStatus();
			Plugin.LastPlayerHub = ReferenceHub.GetHub(__instance.gameObject);
			__instance.OnInteract();
			return false;
		}
	}
}
