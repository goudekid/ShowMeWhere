using Harmony;
using RimWorld;
using RimWorld.Planet;
using System;
using Verse;

namespace ShowMeWhere
{
    [HarmonyPatch(typeof(MapInterface), "MapInterfaceUpdate", null)]
    public static class MapInterface_Patch
    {
        [HarmonyPostfix]
        private static void Postfix()
        {
            if (Find.VisibleMap == null || WorldRendererUtility.WorldRenderedNow)
            {
                return;
            }
            Main.Instance.UpdateMap();
        }
    }
}
