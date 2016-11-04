using RimWorld;
using System.Collections.Generic;
using System.Linq;
using Verse;
using Verse.AI;

namespace RWP
{
	public class WorkGiver_HaulDeteriorating : WorkGiver_Scanner
	{
		public override IEnumerable<Thing> PotentialWorkThingsGlobal(Pawn pawn) //Lists all deteriorating items that aren't under a roof and sorts by highest DeteriorationRate to lowest
		{
			return ListerHaulables.ThingsPotentiallyNeedingHauling().Where(t => t.Position.GetRoof() == null && t.GetStatValue(StatDefOf.DeteriorationRate, true) > 0f).OrderByDescending(t => t.GetStatValue(StatDefOf.DeteriorationRate, true));
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