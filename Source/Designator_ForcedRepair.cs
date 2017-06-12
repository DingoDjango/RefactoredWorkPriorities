using System.Linq;
using RimWorld;
using UnityEngine;
using Verse;

namespace RWP
{
	public class Designator_ForcedRepair : Designator
	{
		public Designator_ForcedRepair()
		{
			this.defaultLabel = "Designator_ForcedRepair".Translate();
			this.defaultDesc = "Designator_ForcedRepairDesc".Translate();
			this.icon = ContentFinder<Texture2D>.Get("Designations/ForcedRepair", true);
			this.soundDragSustain = SoundDefOf.DesignateDragStandard;
			this.soundDragChanged = SoundDefOf.DesignateDragStandardChanged;
			this.useMouseIcon = true;
			this.soundSucceeded = SoundDefOf.DesignateHaul; //???
			this.hotKey = KeyBindingDef.Named("DesignatorForcedRepair");
		}

		public override AcceptanceReport CanDesignateCell(IntVec3 c)
		{
			if (!c.InBounds(base.Map))
			{
				return false;
			}

			if (c.Fogged(base.Map))
			{
				return false;
			}

			var thingList = base.Map.thingGrid.ThingsAt(c);

			if (!(thingList.Any(t => CanDesignateThing(t).Accepted)))
			{
				return false;
			}

			return true;
		}

		public override void DesignateSingleCell(IntVec3 loc)
		{
			foreach (Thing building in base.Map.thingGrid.ThingsAt(loc))
			{
				if (this.CanDesignateThing(building).Accepted)
				{
					this.DesignateThing(building);
				}
			}
		}

		public override void DesignateThing(Thing t)
		{
			base.Map.designationManager.AddDesignation(new Designation(t, Controller.DefOf_RWP_ForcedRepair));
		}

		public override AcceptanceReport CanDesignateThing(Thing t)
		{
			if (!(base.Map.listerBuildingsRepairable.RepairableBuildings(Faction.OfPlayer).Contains(t)))
			{
				return false;
			}

			if (!(t.HitPoints < t.MaxHitPoints))
			{
				return false;
			}

			if (base.Map.designationManager.DesignationOn(t, DesignationDefOf.Deconstruct) != null)
			{
				return false;
			}

			if (base.Map.designationManager.DesignationOn(t, DesignationDefOf.Uninstall) != null)
			{
				return false;
			}

			if (base.Map.designationManager.DesignationOn(t, Controller.DefOf_RWP_ForcedRepair) != null)
			{
				return false;
			}

			return true;
		}

		public override int DraggableDimensions
		{
			get
			{
				return 2;
			}
		}

		public override void SelectedUpdate()
		{
			GenUI.RenderMouseoverBracket();
		}
	}
}
