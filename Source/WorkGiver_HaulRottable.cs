using RimWorld;
using System.Collections.Generic;
using System.Linq;
using Verse;
using Verse.AI;

namespace RWP
{
	public class WorkGiver_HaulRottable : WorkGiver_Scanner
	{
		public override IEnumerable<Thing> PotentialWorkThingsGlobal(Pawn pawn) //Lists all items with the rottable comp and sorts by fastest rotting to slowest
		{
			return ListerHaulables.ThingsPotentiallyNeedingHauling().Where(t => t.def.comps.Exists(tc => tc.compClass == typeof(CompRottable))).OrderBy(t => t.def.GetCompProperties<CompProperties_Rottable>().daysToRotStart);
		}

		public override Job JobOnThing(Pawn pawn, Thing t)
		{
			if (!HaulAIUtility.PawnCanAutomaticallyHaulFast(pawn, t))
			{
				return null;
			}

			return HaulAIUtility.HaulToStorageJob(pawn, t);
		}
	}
}