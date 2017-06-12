using RimWorld;
using UnityEngine;
using Verse;

namespace RWP
{
	public class Controller : Mod
	{
		public Controller(ModContentPack content) : base(content)
		{
			GetSettings<Settings>();
		}

		public static WorkGiverDef DefOf_HaulRottable => DefDatabase<WorkGiverDef>.GetNamed("HaulRottable");
		public static WorkGiverDef DefOf_HaulDeteriorating => DefDatabase<WorkGiverDef>.GetNamed("HaulDeteriorating");
		public static DesignationDef DefOf_RWP_ForcedRepair => DefDatabase<DesignationDef>.GetNamed("RWP_ForcedRepair");

		public override void WriteSettings()
		{
			base.WriteSettings();
			DefOf_HaulRottable.scanThings = Settings.PrioritizeRottable;
			DefOf_HaulDeteriorating.scanThings = Settings.PrioritizeDeteriorating;
		}

		public override void DoSettingsWindowContents(Rect inRect)
		{
			Listing_Standard list = new Listing_Standard();
			list.ColumnWidth = inRect.width;
			list.Begin(inRect);

			list.Gap(20f);

			// Repair threshold slider.
			{
				Rect currentRect = list.GetRect(Text.LineHeight);
				Rect currentRectLeft = currentRect.LeftHalf().Rounded();
				Rect currentRectRight = currentRect.RightHalf().Rounded();
				string RepairThreshold_label = "RWP_setting_repairThresholdInt_label".Translate(new object[] { Settings.RepairThreshold });

				//Text label for repair threshold, translated, with tooltip.
				Widgets.Label(currentRectLeft, RepairThreshold_label);
				if (Mouse.IsOver(currentRectLeft))
				{
					Widgets.DrawHighlight(currentRectLeft);
				}
				TooltipHandler.TipRegion(currentRectLeft, "RWP_setting_repairThresholdInt_desc".Translate());

				//Increment value by -1 (button).
				if (Widgets.ButtonText(new Rect(currentRectRight.xMin, currentRectRight.y, currentRectRight.height, currentRectRight.height), "-", true, false, true))
				{
					if (Settings.RepairThreshold <= 100 && Settings.RepairThreshold > 0)
					{
						Settings.RepairThreshold--;
					}
				}

				//Set value (slider).
				Settings.RepairThreshold = Mathf.RoundToInt(Widgets.HorizontalSlider(new Rect(currentRectRight.xMin + currentRectRight.height + 10f, currentRectRight.y, currentRectRight.width - (currentRectRight.height * 2 + 20f), currentRectRight.height), Settings.RepairThreshold, 0, 100, true));

				//Increment value by +1 (button).
				if (Widgets.ButtonText(new Rect(currentRectRight.xMax - currentRectRight.height, currentRectRight.y, currentRectRight.height, currentRectRight.height), "+", true, false, true))
				{
					if (Settings.RepairThreshold < 100 && Settings.RepairThreshold >= 0)
					{
						Settings.RepairThreshold++;
					}
				}
			}

			list.Gap(20f);

			list.CheckboxLabeled("RWP_setting_haulRottables_label".Translate(), ref Settings.PrioritizeRottable, "RWP_setting_haulRottables_desc".Translate());

			list.Gap(20f);

			list.CheckboxLabeled("RWP_setting_haulDeterioratables_label".Translate(), ref Settings.PrioritizeDeteriorating, "RWP_setting_haulDeterioratables_desc".Translate());

			list.Gap(20f);

			//Deterioratables minimum HP threshold slider.
			{
				Rect currentRect = list.GetRect(Text.LineHeight);
				Rect currentRectLeft = currentRect.LeftHalf().Rounded();
				Rect currentRectRight = currentRect.RightHalf().Rounded();
				string DeterioratableMinHealthPercent_label = "RWP_setting_haulDeterioratables_HealthThresholdInt".Translate(new object[] { Settings.DeterioratableMinHealthPercent });

				//Text label for repair threshold, translated, with tooltip.
				Widgets.Label(currentRectLeft, DeterioratableMinHealthPercent_label);
				if (Mouse.IsOver(currentRectLeft))
				{
					Widgets.DrawHighlight(currentRectLeft);
				}
				TooltipHandler.TipRegion(currentRectLeft, "RWP_setting_haulDeterioratables_HealthThresholdInt_desc".Translate());

				//Increment value by -1 (button).
				if (Widgets.ButtonText(new Rect(currentRectRight.xMin, currentRectRight.y, currentRectRight.height, currentRectRight.height), "-", true, false, true))
				{
					if (Settings.DeterioratableMinHealthPercent <= 100 && Settings.DeterioratableMinHealthPercent > 0)
					{
						Settings.DeterioratableMinHealthPercent--;
					}
				}

				//Set value (slider).
				Settings.DeterioratableMinHealthPercent = Mathf.RoundToInt(Widgets.HorizontalSlider(new Rect(currentRectRight.xMin + currentRectRight.height + 10f, currentRectRight.y, currentRectRight.width - (currentRectRight.height * 2 + 20f), currentRectRight.height), Settings.DeterioratableMinHealthPercent, 0, 100, true));

				//Increment value by +1 (button).
				if (Widgets.ButtonText(new Rect(currentRectRight.xMax - currentRectRight.height, currentRectRight.y, currentRectRight.height, currentRectRight.height), "+", true, false, true))
				{
					if (Settings.DeterioratableMinHealthPercent < 100 && Settings.DeterioratableMinHealthPercent >= 0)
					{
						Settings.DeterioratableMinHealthPercent++;
					}
				}
			}

			list.End();
		}

		public override string SettingsCategory()
		{
			return "RWP".Translate();
		}
	}
}
