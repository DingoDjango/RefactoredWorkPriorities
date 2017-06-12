using RimWorld;
using Verse;

namespace RWP
{
	public class WorkGiver_RepairCustom : WorkGiver_Repair
	{
		public override bool HasJobOnThing(Pawn pawn, Thing t, bool forced)
		{
			if (forced == true)
			{
				return base.HasJobOnThing(pawn, t, true);
			}

			if (pawn.Map.designationManager.DesignationOn(t, Controller.DefOf_RWP_ForcedRepair) != null)
			{
				return base.HasJobOnThing(pawn, t, false);
			}

			float hitPointPercentage = 100f * (float)t.HitPoints / (float)t.MaxHitPoints;

			return base.HasJobOnThing(pawn, t, false) && hitPointPercentage <= Settings.RepairThreshold;
		}
	}
}