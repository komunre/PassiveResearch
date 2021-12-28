using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;
using UnityEngine;
using System.Globalization;

namespace PassiveResearch
{
    public class PassiveResearchWindow : Window
    {
        private string speedValue;
        public PassiveResearchWindow()
        {
            draggable = true;
            closeOnCancel = false;
            closeOnAccept = false;
            preventCameraMotion = false;
            focusWhenOpened = false;
            speedValue = "0.1";
        }
        public override void PostOpen()
        {
            base.PostOpen();

            windowRect = new Rect(0, 0, 160, 90);
        }
        public override void DoWindowContents(Rect inRect)
        {
            speedValue = Widgets.TextField(new Rect(0, 0, 40, 20), speedValue, 20);
            if (Widgets.ButtonText(new Rect(0, 20, 80, 20), "Apply"))
            {
                var map = Find.CurrentMap;
                try
                {
                    map.GetComponent<PassiveProgress>().PassiveResearchSpeed = float.Parse(speedValue, CultureInfo.InvariantCulture);
                } catch
                {
                    
                }
            }
        }
    }
}
