using RimWorld;
using Verse;
using UnityEngine;
using System.Globalization;

namespace PassiveResearch
{
    public class PassiveResearchWindow : Window
    {
        private string speedValue;
        private PassiveProgress progress;

        private Vector2 Scrollbar;
        public PassiveResearchWindow()
        {
            var map = Find.CurrentMap;
            progress = map.GetComponent<PassiveProgress>();
            draggable = true;
            closeOnCancel = false;
            closeOnAccept = false;
            preventCameraMotion = false;
            focusWhenOpened = false;
            speedValue = progress.PassiveResearchSpeed.ToString();
        }
        public override void PostOpen()
        {
            base.PostOpen();

            windowRect = new Rect(0, 0, 160, 130);
        }
        public override void DoWindowContents(Rect inRect)
        {
            speedValue = Widgets.TextField(new Rect(0, 0, 40, 20), speedValue, 20);
            if (Widgets.ButtonText(new Rect(0, 20, 80, 20), "Apply"))
            {
                try
                {
                    progress.PassiveResearchSpeed = float.Parse(speedValue, CultureInfo.InvariantCulture);
                } catch
                {
                    Messages.Message("Value is invalid!", MessageTypeDefOf.RejectInput, false);
                }
            }
            Widgets.LabelScrollable(new Rect(0, 60, 80, 20), "Current value: " + progress.PassiveResearchSpeed, ref Scrollbar);
        }

        public void RefreshValue()
        {
            speedValue = progress.PassiveResearchSpeed.ToString();
        }
    }
}
