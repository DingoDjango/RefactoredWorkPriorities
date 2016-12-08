using HugsLib;
using RimWorld;
using Verse;

namespace RWP
{
	[DefOf]
	public static class RWPDefs
	{
		public static WorkGiverDef DoctorRescueHumanColonist;
		public static WorkGiverDef DoctorTreatHumanColonist;
		public static WorkGiverDef HaulRottable;
		public static WorkGiverDef HaulDeteriorating;
	}

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
			UpdateDefs();
		}

		public override void SettingsChanged()
		{
			UpdateDefs();
		}

		private void UpdateDefs()
		{
			var doctorRescueColonist = Settings.GetHandle<bool>("DoctorRescueColonist", "setting_doctorRescueColonist_label".Translate(), "setting_doctorRescueColonist_desc".Translate(), true);
			RWPDefs.DoctorRescueHumanColonist.scanThings = doctorRescueColonist.Value;

			var doctorTreatColonist = Settings.GetHandle<bool>("DoctorTreatColonist", "setting_doctorTreatColonist_label".Translate(), "setting_doctorTreatColonist_desc".Translate(), true);
			RWPDefs.DoctorTreatHumanColonist.scanThings = doctorTreatColonist.Value;

			var haulRottables = Settings.GetHandle<bool>("HaulRottables", "setting_haulRottables_label".Translate(), "setting_haulRottables_desc".Translate(), true);
			RWPDefs.HaulRottable.scanThings = haulRottables.Value;

			var haulDeterioratables = Settings.GetHandle<bool>("HaulDeterioratables", "setting_haulDeterioratables_label".Translate(), "setting_haulDeterioratables_desc".Translate(), true);
			RWPDefs.HaulDeteriorating.scanThings = haulDeterioratables.Value;
		}
	}
}