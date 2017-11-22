using System;
using UnityEngine;
using Verse;

namespace ShowMeWhere
{
    [StaticConstructorOnStartup]
    public class Resources
    {
        public static Texture2D Icon = ContentFinder<Texture2D>.Get("ShowBuildIcon", true);
        public static Texture2D Icon2 = ContentFinder<Texture2D>.Get("ShowFertileIcon", true);
    }
}
