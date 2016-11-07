using RimWorld;
using System.Collections.Generic;
using System.Linq;
using Verse;
using Verse.AI;

namespace RWP
{
	public class WorkGiver_HaulDeteriorating : WorkGiver_Scanner
	{
		public override bool Prioritized
		{
			get
			{
				return true;
			}
		}

		public override bool ShouldSkip(Pawn pawn)
		{
			return ListerHaulables.ThingsPotentiallyNeedingHauling().Count == 0;
		}

		public override IEnumerable<Thing> PotentialWorkThingsGlobal(Pawn pawn) //Lists all items with DeteriorationRate above 0 that aren't under a roof
		{
			return ListerHaulables.ThingsPotentiallyNeedingHauling().Where(t => t.Position.GetRoof() == null && t.GetStatValue(StatDefOf.DeteriorationRate, true) > 0f);
		}

		public override Job JobOnThing(Pawn pawn, Thing t)
		{
			if (!HaulAIUtility.PawnCanAutomaticallyHaulFast(pawn, t))
			{
				return null;
			}

			return HaulAIUtility.HaulToStorageJob(pawn, t);
		}

		public override float GetPriority(Pawn pawn, TargetInfo t)
		{
			Thing thing = t.Thing;
			return thing.GetStatValue(StatDefOf.DeteriorationRate, true);
		}
	}
}