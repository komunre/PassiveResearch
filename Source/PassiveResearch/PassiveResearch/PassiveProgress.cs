using Verse;

namespace PassiveResearch
{
    public class PassiveProgress : MapComponent
    {
        private PassiveResearchSettings settings;
        public PassiveProgress(Map map) : base(map)
        {
            settings = LoadedModManager.GetMod<PassiveResearchMod>().GetSettings<PassiveResearchSettings>();
        }

        public override void MapComponentTick()
        {
            base.MapComponentTick();

            if (!map.IsPlayerHome) return;

            var manager = Find.ResearchManager;
            if (manager.currentProj == null) return;

            manager.ResearchPerformed(settings.PassiveResearchSpeed, null);
        }
    }
}
