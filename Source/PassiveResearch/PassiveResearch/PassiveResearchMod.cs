using UnityEngine;
using Verse;

namespace PassiveResearch
{
    public class PassiveResearchMod : Mod
    {
        PassiveResearchSettings settings;
        string buffer;

        public PassiveResearchMod(ModContentPack content) : base(content)
        {
            settings = GetSettings<PassiveResearchSettings>();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listing = new Listing_Standard();
            listing.Begin(inRect);
            listing.Label("PRS_RESEARCH_SPEED".Translate());
            listing.TextFieldNumeric<float>(ref settings.PassiveResearchSpeed, ref buffer);
            listing.End();

            base.DoSettingsWindowContents(inRect);
        }

        public override string SettingsCategory()
        {
            return "PassiveResearchName".Translate();
        }
    }
}
