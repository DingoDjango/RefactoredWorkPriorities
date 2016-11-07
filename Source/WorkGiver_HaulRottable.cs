using RimWorld;
using System.Collections.Generic;
using System.Linq;
using Verse;
using Verse.AI;

namespace RWP
{
	public class WorkGiver_HaulRottable : WorkGiver_Scanner
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

		public override IEnumerable<Thing> PotentialWorkThingsGlobal(Pawn pawn) //Lists all items which need hauling and have CompProperties_Rottable
		{
			return ListerHaulables.ThingsPotentiallyNeedingHauling().Where(t => t.def.comps.Exists(tc => tc.compClass == typeof(CompRottable)));
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
			var rottability = thing.def.GetCompProperties<CompProperties_Rottable>().daysToRotStart;
			return (1f) / (rottability);
		}
	}
}