using HugsLib;
using HugsLib.Settings;
using HugsLib.Utils;
using RimWorld.Planet;
using System;
using UnityEngine;
using Verse;

namespace ShowMeWhere
{
    public class Main : ModBase
    {
        public bool ShowingBuildableArea;

        public bool ShowingFertileArea;

        private ShowBuildableArea _showBuildableArea;

        private ShowFertileSoil _showFertileSoil;

        internal new ModLogger Logger
        {
            get
            {
                return base.Logger;
            }
        }

        internal static Main Instance
        {
            get;
            private set;
        }

        public override string ModIdentifier
        {
            get
            {
                return "ShowMeWhere";
            }
        }

        public Main()
        {
            Main.Instance = this;
        }

        public void UpdateMap()
        {
            if (this._showBuildableArea == null)
            {
                this._showBuildableArea = new ShowBuildableArea();
            }
            if (this._showFertileSoil == null)
            {
                this._showFertileSoil = new ShowFertileSoil();
            }
            this._showFertileSoil.Update();
            this._showBuildableArea.Update();
        }

        public override void OnGUI()
        {
            if (Current.ProgramState != ProgramState.MapInitializing || Event.current.type != EventType.KeyDown || Event.current.keyCode == KeyCode.None || Find.VisibleMap == null)
            {
                return;
            }            
        }

        public override void WorldLoaded()
        {
            ShowBuildableArea showBuild = this._showBuildableArea;
            ShowFertileSoil showFert = this._showFertileSoil;
            if (showBuild == null)
            {
                return;
            } else
            {
                showBuild.Reset();
            }
            if (showFert == null)
            {
                return;
            } else
            {
                showFert.Reset();
            }                 
        }     
    }
}
