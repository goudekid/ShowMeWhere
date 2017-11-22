using RimWorld;
using System;
using UnityEngine;
using Verse;

namespace ShowMeWhere
{
    public class ShowFertileSoil : ICellBoolGiver
    {
        private CellBoolDrawer _drawerInt;

        private Color _nextColor;

        private int _nextUpdateTick;

        public CellBoolDrawer Drawer
        {
            get
            {
                if (this._drawerInt == null)
                {
                    Map visibleMap = Find.VisibleMap;
                    this._drawerInt = new CellBoolDrawer(this, visibleMap.Size.x, visibleMap.Size.z, 30/100f);
                }
                return this._drawerInt;
            }
        }

        public Color Color
        {
            get
            {
                return Color.white;
            }
        }

        public ShowFertileSoil()
        {
        }

        public Color GetCellExtraColor(int index)
        {
            return this._nextColor;
        }

        public void Update()
        {
            if (Main.Instance.ShowingFertileArea)
            {
                this.Drawer.MarkForDraw();
                int ticksGame = Find.TickManager.TicksGame;
                if (this._nextUpdateTick == 0 || ticksGame >= this._nextUpdateTick)
                {
                    this.Drawer.SetDirty();
                    this._nextUpdateTick = ticksGame + 100;
                }
            }
            this.Drawer.CellBoolDrawerUpdate();
        }

        public void Reset()
        {
            this._drawerInt = null;
            this._nextUpdateTick = 0;
        }

        public bool GetCellBool(int index)
        {
            Map visibleMap = Find.VisibleMap;
            if (visibleMap.fogGrid.IsFogged(index))
            {
                return false;
            }
            if (visibleMap.fertilityGrid.FertilityAt(visibleMap.cellIndices.IndexToCell(index)) > 1.0)
            {
                this._nextColor = Color.green;
            } else if (visibleMap.fertilityGrid.FertilityAt(visibleMap.cellIndices.IndexToCell(index)) > 0.7)
            {
                this._nextColor = Color.yellow;
            } else if (visibleMap.fertilityGrid.FertilityAt(visibleMap.cellIndices.IndexToCell(index)) > 0.07)
            {
                this._nextColor = Color.Lerp(Color.red, Color.yellow, 0.5f);
            } else
            {
                this._nextColor = Color.red;
            }
            return true;

        }
    }
}

