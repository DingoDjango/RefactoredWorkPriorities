using Verse;

namespace RWP
{
	public static class LanguageStrings
	{
		public static string labelRepairThreshold = "RWP_RepairThreshold_Label".Translate(new object[] { Settings.RepairThreshold });
		public static string descRepairThreshold = "RWP_RepairThreshold_Desc".Translate();

		public static string labelPrioritizeRottable = "RWP_PrioritizeRottable_Label".Translate();
		public static string descPrioritizeRottable = "RWP_PrioritizeRottable_Desc".Translate();

		public static string labelPrioritizeDeteriorating = "RWP_PrioritizeDeteriorating_Label".Translate();
		public static string descPrioritizeDeteriorating = "RWP_PrioritizeDeteriorating_Desc".Translate();

		public static string labelDeterioratableMinHealth = "RWP_DeterioratableMinHealthPercent_Label".Translate(new object[] { Settings.DeterioratableMinHealthPercent });
		public static string descDeterioratableMinHealth = "RWP_DeterioratableMinHealthPercent_Label_Desc".Translate();

		public static string labelForcedRepair = "Designator_ForcedRepair".Translate();
		public static string descForcedRepair = "Designator_ForcedRepairDesc".Translate();
	}
}
