using Verse;

namespace RWP
{
	public class Settings : ModSettings
	{
		public static int RepairThreshold = 100;

		public static bool PrioritizeRottable = true;

		public static bool PrioritizeDeteriorating = true;

		public static int DeterioratableMinHealthPercent = 35;

		public static DesignationDef DefOf_RWP_ForcedRepair => DefDatabase<DesignationDef>.GetNamed("RWP_ForcedRepair");

		public override void ExposeData()
		{
			base.ExposeData();
			Scribe_Values.Look(ref RepairThreshold, "RepairThreshold", 100);
			Scribe_Values.Look(ref PrioritizeRottable, "PrioritizeRottable", true);
			Scribe_Values.Look(ref PrioritizeDeteriorating, "PrioritizeDeteriorating", true);
			Scribe_Values.Look(ref DeterioratableMinHealthPercent, "DeterioratableMinHealthPercent", 35);
		}
	}
}
