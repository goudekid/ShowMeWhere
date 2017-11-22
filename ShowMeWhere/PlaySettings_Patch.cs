using Harmony;
using RimWorld;
using System;
using Verse;

namespace ShowMeWhere
{
    [HarmonyPatch(typeof(PlaySettings), "DoPlaySettingsGlobalControls", null)]
    public static class PlaySettings_Patch
    {
        [HarmonyPostfix]
        private static void PostFix(WidgetRow row, bool worldView)
        {
            if (worldView)
            {
                return;
            }
            if (row == null || Resources.Icon == null)
            {
                return;
            }
            row.ToggleableIcon(ref Main.Instance.ShowingBuildableArea, Resources.Icon, "Show Buildable Area", SoundDefOf.MouseoverToggle, null);
            row.ToggleableIcon(ref Main.Instance.ShowingFertileArea, Resources.Icon2, "Show Fertile Soil", SoundDefOf.MouseoverToggle, null);
        }
    }
}
