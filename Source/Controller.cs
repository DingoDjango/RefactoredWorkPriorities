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

		public override void DoSettingsWindowContents(Rect inRect)
		{
			#region Translation Keys
			string labelRepairThreshold = "RWP_RepairThreshold_Label".Translate(new object[] { Settings.RepairThreshold });
			string descRepairThreshold = "RWP_RepairThreshold_Desc".Translate();

			string labelPrioritizeRottable = "RWP_PrioritizeRottable_Label".Translate();
			string descPrioritizeRottable = "RWP_PrioritizeRottable_Desc".Translate();

			string labelPrioritizeDeteriorating = "RWP_PrioritizeDeteriorating_Label".Translate();
			string descPrioritizeDeteriorating = "RWP_PrioritizeDeteriorating_Desc".Translate();

			string labelDeterioratableMinHealth = "RWP_DeterioratableMinHealthPercent_Label".Translate(new object[] { Settings.DeterioratableMinHealthPercent });
			string descDeterioratableMinHealth = "RWP_DeterioratableMinHealthPercent_Label_Desc".Translate();
			#endregion

			Listing_Standard list = new Listing_Standard();
			list.ColumnWidth = inRect.width;
			list.Begin(inRect);

			list.Gap(20f);

			// Repair threshold slider.
			{
				Rect currentRect = list.GetRect(Text.LineHeight);
				Rect currentRectLeft = currentRect.LeftHalf().Rounded();
				Rect currentRectRight = currentRect.RightHalf().Rounded();

				//Text label for repair threshold, translated, with tooltip.
				Widgets.Label(currentRectLeft, labelRepairThreshold);
				if (Mouse.IsOver(currentRectLeft))
				{
					Widgets.DrawHighlight(currentRectLeft);
				}
				TooltipHandler.TipRegion(currentRectLeft, descRepairThreshold);

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

			list.CheckboxLabeled(labelPrioritizeRottable, ref Settings.PrioritizeRottable, descPrioritizeRottable);

			list.Gap(20f);

			list.CheckboxLabeled(labelPrioritizeDeteriorating, ref Settings.PrioritizeDeteriorating, descPrioritizeDeteriorating);

			list.Gap(20f);

			//Deterioratables minimum HP threshold slider.
			{
				Rect currentRect = list.GetRect(Text.LineHeight);
				Rect currentRectLeft = currentRect.LeftHalf().Rounded();
				Rect currentRectRight = currentRect.RightHalf().Rounded();

				//Text label for item haul threshold, translated, with tooltip.
				Widgets.Label(currentRectLeft, labelDeterioratableMinHealth);
				if (Mouse.IsOver(currentRectLeft))
				{
					Widgets.DrawHighlight(currentRectLeft);
				}
				TooltipHandler.TipRegion(currentRectLeft, descDeterioratableMinHealth);

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
			return "Refactored Work Priorities";
		}
	}
}
