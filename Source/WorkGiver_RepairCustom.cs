using RimWorld;
using Verse;

namespace RWP
{
	public class WorkGiver_RepairCustom : WorkGiver_Repair
	{
		public static int RepairThreshold = 100;

		public override bool HasJobOnThing(Pawn pawn, Thing t)
		{
			int hitPointPercentage = 100 * t.HitPoints / t.MaxHitPoints;

			return base.HasJobOnThing(pawn, t) && hitPointPercentage < RepairThreshold;
		}
	}
}