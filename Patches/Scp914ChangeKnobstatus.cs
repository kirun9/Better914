using Harmony;
using Scp914;
using System;

namespace Better914.Patches
{
	[HarmonyPatch(typeof(Scp914Machine), nameof(Scp914Machine.ChangeKnobStatus))]
	public class Scp914ChangeKnobstatus
	{
		public static bool Prefix(Scp914Machine __instance)
		{
			if (!PluginConfig.Cfg.Enabled) return true;

			if (!PluginConfig.Cfg.CanChangeKnobWhileWorking && __instance.working || Math.Abs(__instance.curKnobCooldown) > 0.001f) return false;

			//if (Plugin.KnobBlockade) return false;

			__instance.curKnobCooldown = __instance.knobCooldown;
			Scp914Knob knob = __instance.knobState + 1;
			if (knob > Scp914Machine.knobStateMax) knob = Scp914Machine.knobStateMin;
			__instance.NetworkknobState = knob;
			return false;
		}
	}
}
