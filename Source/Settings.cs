using Verse;

namespace RWP
{
	public class Settings : ModSettings
	{
		#region Values
		public static int RepairThreshold = 100;

		public static bool PrioritizeRottable = true;

		public static bool PrioritizeDeteriorating = true;

		public static int DeterioratableMinHealthPercent = 35;

		public static DesignationDef DefOf_RWP_ForcedRepair => DefDatabase<DesignationDef>.GetNamed("RWP_ForcedRepair");
		#endregion

		#region Translation Keys
		internal static string labelRepairThreshold = "RWP_RepairThreshold_Label".Translate(new object[] { RepairThreshold });
		internal static string descRepairThreshold = "RWP_RepairThreshold_Desc".Translate();

		internal static string labelPrioritizeRottable = "RWP_PrioritizeRottable_Label".Translate();
		internal static string descPrioritizeRottable = "RWP_PrioritizeRottable_Desc".Translate();

		internal static string labelPrioritizeDeteriorating = "RWP_PrioritizeDeteriorating_Label".Translate();
		internal static string descPrioritizeDeteriorating = "RWP_PrioritizeDeteriorating_Desc".Translate();

		internal static string labelDeterioratableMinHealth = "RWP_DeterioratableMinHealthPercent_Label".Translate(new object[] { DeterioratableMinHealthPercent });
		internal static string descDeterioratableMinHealth = "RWP_DeterioratableMinHealthPercent_Label_Desc".Translate();

		internal static string labelForcedRepair = "Designator_ForcedRepair".Translate();
		internal static string descForcedRepair = "Designator_ForcedRepairDesc".Translate();
		#endregion

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
