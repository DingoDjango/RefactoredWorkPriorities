using HugsLib;
using RimWorld;

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
			var doctorRescueColonist = Settings.GetHandle<bool>("DoctorRescueColonist", "[Doctor] Prioritise rescuing colonists", "Doctors will rescue allied colonists before rescuing animals or outsiders.", true);
			RWPDefs.DoctorRescueHumanColonist.scanThings = doctorRescueColonist.Value;

			var doctorTreatColonist = Settings.GetHandle<bool>("DoctorTreatColonist", "[Doctor] Prioritise treating colonists", "Doctors will treat colonist injuries before treating animals or outsiders.", true);
			RWPDefs.DoctorTreatHumanColonist.scanThings = doctorTreatColonist.Value;

			var haulRottables = Settings.GetHandle<bool>("HaulRottables", "[Haul] Prioritise hauling rottables", "Haulers will haul rottable items (corn, meals etc.) before generic things.", true);
			RWPDefs.HaulRottable.scanThings = haulRottables.Value;

			var haulDeterioratables = Settings.GetHandle<bool>("HaulDeterioratables", "[Haul] Prioritise hauling deterioratables", "Haulers will haul items which deteriorate over time (weapons, wood etc.) before generic things.", true);
			RWPDefs.HaulDeteriorating.scanThings = haulDeterioratables.Value;
		}
	}
}