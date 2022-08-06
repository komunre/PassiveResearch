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
            if (manager.currentProj == null) return;

            manager.ResearchPerformed(settings.PassiveResearchSpeed, null);
        }
    }
}
