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
				Widgets.Label(currentRectLeft, Settings.labelRepairThreshold);
				if (Mouse.IsOver(currentRectLeft))
				{
					Widgets.DrawHighlight(currentRectLeft);
				}
				TooltipHandler.TipRegion(currentRectLeft, Settings.descRepairThreshold);

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

			list.CheckboxLabeled(Settings.labelPrioritizeRottable, ref Settings.PrioritizeRottable, Settings.descPrioritizeRottable);

			list.Gap(20f);

			list.CheckboxLabeled(Settings.labelPrioritizeDeteriorating, ref Settings.PrioritizeDeteriorating, Settings.descPrioritizeDeteriorating);

			list.Gap(20f);

			//Deterioratables minimum HP threshold slider.
			{
				Rect currentRect = list.GetRect(Text.LineHeight);
				Rect currentRectLeft = currentRect.LeftHalf().Rounded();
				Rect currentRectRight = currentRect.RightHalf().Rounded();

				//Text label for item haul threshold, translated, with tooltip.
				Widgets.Label(currentRectLeft, Settings.labelDeterioratableMinHealth);
				if (Mouse.IsOver(currentRectLeft))
				{
					Widgets.DrawHighlight(currentRectLeft);
				}
				TooltipHandler.TipRegion(currentRectLeft, Settings.descDeterioratableMinHealth);

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
