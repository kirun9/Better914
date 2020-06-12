namespace Better914
{
	public class PluginConfig
    {
        public static PluginConfig Cfg { get; internal set; }

        public bool Enabled { get; set; }
        public bool OverrideHandcuffConfig { get; set; }
        public bool CanDisarmedInteract { get; set; }
        public bool CanChangeKnobWhileWorking { get; set; }
        public bool UseNewRecipeSystem { get; set; }

        public float SameItemChance { get; set; }

        public float Level_2Chance { get; set; }
        public float Level_3Chance { get; set; }
        public float Level_4Chance { get; set; }
        public float Level2Chance { get; set; }
        public float Level3Chance { get; set; }
        public float Level4Chance { get; set; }
        
        public float InvUpgradeChance { get; set; }

        public bool ChangePlayerHealth { get; set; }

        public float FineHealChance { get; set; }
        public float FineHealAmmout { get; set; }
        public float VeryFineHealChance { get; set; }
        public float VeryFineHealAmmout { get; set; }
        public float CoarseDamageChance { get; set; }
        public float CoarseDamageAmmout { get; set; }
        public float RoughDamageChance { get; set; }
        public float RoughDamageAmmout { get; set; }
        public bool RoughCoarseDamageSCP { get; set; }
        public float SCPDamageChanceMultiplier { get; set; }

        public bool SwapPlayersRoles { get; set; }
        public float SwapRoleChance { get; set; }

        public static bool TryChangeVariable(string valueName, string value, out string reason)
        {
            reason = "";
            value = value.ToLower();
            foreach (var property in typeof(PluginConfig).GetProperties())
            {
                if (property.Name.ToUpper().Equals(valueName))
                {
                    if (property.PropertyType == typeof(bool))
                    {
                        bool val;
                        if (!bool.TryParse(value, out val))
                        {
                            reason = "#Cannot parse " + value + " as boolean";
                            return false;
                        }
                        property.SetValue("", val);
                        return true;
                    }
                    else if (property.PropertyType == typeof(float))
                    {
                        float val;
                        if (!float.TryParse(value, out val))
                        {
                            reason = "#Cannot parse " + value + " as float number";
                            return false;
                        }
                        property.SetValue("", val);
                        return true;
                    }
                }
            }
            reason = "#Better914 config variable \"" + valueName + "\" was not found";
            return false;
        }

        public static bool TryGetVariable(string valueName, out string value, out string reason)
        {
            reason = "";
            value = null;
            foreach (var property in typeof(PluginConfig).GetProperties())
            {
                if (property.Name.ToUpper().Equals(valueName))
                {
                    value = property.GetValue(null).ToString();
                    return true;
                }
            }
            reason = "#Better914 config variable \"" + valueName + "\" was not found";
            return false;
        }
    }
}
