using HugsLib;
using Verse;

namespace RWP
{
	public class RWPMenu : ModBase
	{
		public override string ModIdentifier
		{
			get
			{
				return "RefactoredWorkPriorities";
			}
		}

		public override void DefsLoaded()
		{
			RWPDefs();
		}

		public override void SettingsChanged()
		{
			RWPDefs();
		}

		private void RWPDefs()
		{
			var prioritizeTreatingColonists = Settings.GetHandle<bool>("RWP_Doctor_PrioritizeTreatingColonists", "RWP_setting_doctorTreatColonist_label".Translate(), "RWP_setting_doctorTreatColonist_desc".Translate(), true);
			WorkGiver_TendPrioritized.TendColonistsFirst = prioritizeTreatingColonists.Value;

			var haulRottables = Settings.GetHandle<bool>("HaulRottables", "RWP_setting_haulRottables_label".Translate(), "RWP_setting_haulRottables_desc".Translate(), true);
			WorkGiver_HaulRottable.PrioritizeRottable = haulRottables.Value;

			var haulDeterioratables = Settings.GetHandle<bool>("HaulDeterioratables", "RWP_setting_haulDeterioratables_label".Translate(), "RWP_setting_haulDeterioratables_desc".Translate(), true);
			WorkGiver_HaulDeteriorating.PrioritizeDeteriorating = haulDeterioratables.Value;
		}
	}
}