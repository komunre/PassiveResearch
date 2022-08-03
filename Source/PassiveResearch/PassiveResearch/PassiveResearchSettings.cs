using Verse;

namespace PassiveResearch
{
    public class PassiveResearchSettings : ModSettings
    {
        public float PassiveResearchSpeed = 0.7f;

        public override void ExposeData()
        {
            Scribe_Values.Look(ref PassiveResearchSpeed, "passiveResearchSpeed", 0.7f);
            base.ExposeData();
        }
    }
}
