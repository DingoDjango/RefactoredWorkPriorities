using RimWorld;
using UnityEngine;
using Verse;

namespace RWP
{
	public class WorkGiver_RepairCustom : WorkGiver_Repair
	{
		public override bool HasJobOnThing(Pawn pawn, Thing t, bool forced = false)
		{
			float hitPointPercentage = 100f * (float)t.HitPoints / (float)t.MaxHitPoints;

			return base.HasJobOnThing(pawn, t) && hitPointPercentage <= Settings.RepairThreshold;
		}
	}
}