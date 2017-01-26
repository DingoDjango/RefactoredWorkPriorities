﻿using HugsLib;
using HugsLib.Settings;
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

			var repairThresholdInt = Settings.GetHandle<int>("RWP_Repair_RepairThresholdInt", "RWP_setting_repairThresholdInt_label".Translate(), "RWP_setting_repairThresholdInt_desc".Translate(), 100, Validators.IntRangeValidator(0, 100));
			WorkGiver_RepairCustom.RepairThreshold = repairThresholdInt.Value;

			var haulRottables = Settings.GetHandle<bool>("RWP_Haul_HaulRottables", "RWP_setting_haulRottables_label".Translate(), "RWP_setting_haulRottables_desc".Translate(), true);
			WorkGiver_HaulRottable.PrioritizeRottable = haulRottables.Value;

			var haulRottablesSkipDessicated = Settings.GetHandle<bool>("RWP_Haul_HaulRottablesSkipDessicated", "RWP_setting_haulRottablesSkipDessicated_label".Translate(), "RWP_setting_haulRottablesSkipDessicated_desc".Translate(), true);
			WorkGiver_HaulRottable.SkipDessicated = haulRottablesSkipDessicated.Value;

			var haulDeterioratables = Settings.GetHandle<bool>("RWP_Haul_HaulDeterioratables", "RWP_setting_haulDeterioratables_label".Translate(), "RWP_setting_haulDeterioratables_desc".Translate(), true);
			WorkGiver_HaulDeteriorating.PrioritizeDeteriorating = haulDeterioratables.Value;

			var haulDeterioratables_HealthThresholdInt = Settings.GetHandle<int>("RWP_Haul_HaulDeterioratables_HealthThresholdInt", "RWP_setting_haulDeterioratables_HealthThresholdInt".Translate(), "RWP_setting_haulDeterioratables_HealthThresholdInt_desc".Translate(), 35);
			WorkGiver_HaulDeteriorating.DeterioratableMinHealthPercent = haulDeterioratables_HealthThresholdInt.Value;
		}
	}
}