using Verse;

namespace PassiveResearch
{
    public class PassiveProgress : GameComponent
    {
        private PassiveResearchSettings settings;
        public PassiveProgress(Game game)
        {
            settings = LoadedModManager.GetMod<PassiveResearchMod>().GetSettings<PassiveResearchSettings>();
        }

        public override void GameComponentTick()
        {
            base.GameComponentTick();

            var manager = Find.ResearchManager;
#if v1_5
            if (manager.GetProject() == null) return;
#else
            if (manager.currentProj == null) return;
#endif

            manager.ResearchPerformed(settings.PassiveResearchSpeed, null);
        }
    }
}
