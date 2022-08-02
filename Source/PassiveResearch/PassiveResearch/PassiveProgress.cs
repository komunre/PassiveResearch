using Verse;

namespace PassiveResearch
{
    public class PassiveProgress : MapComponent
    {
        public float PassiveResearchSpeed = 0.7f;
        protected PassiveResearchWindow window = null;
        private bool addedWindowToStack = false;
        public PassiveProgress(Map map) : base(map)
        {
        }

        public override void MapComponentTick()
        {
            base.MapComponentTick();

            if (!map.IsPlayerHome) return;

            var manager = Find.ResearchManager;
            if (manager.currentProj == null) return;

            manager.ResearchPerformed(PassiveResearchSpeed, null);
        }

        public override void MapComponentOnGUI()
        {
            base.MapComponentOnGUI();

            CreateWindow();
            if (!addedWindowToStack)
            {
                Find.WindowStack.Add(window);
                window.RefreshValue();
                addedWindowToStack = true;
            }
        }

        public override void ExposeData()
        {
            base.ExposeData();

            Scribe_Values.Look(ref PassiveResearchSpeed, "passiveResearchSpeed", 0.7f);
        }

        private void CreateWindow()
        {
            if (window == null)
            {
                window = new PassiveResearchWindow();
            }
        }
    }
}
