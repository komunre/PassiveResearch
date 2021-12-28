using Verse;

namespace PassiveResearch
{
    public class PassiveProgress : MapComponent
    {
        public float PassiveResearchSpeed = 0.1f;
        protected PassiveResearchWindow window = null;
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

            if (window == null)
            {
                window = new PassiveResearchWindow();
                Find.WindowStack.Add(window);
            }
        }

        public override void ExposeData()
        {
            base.ExposeData();

            Scribe_Values.Look(ref PassiveResearchSpeed, "passiveResearchSpeed");
        }
    }
}
