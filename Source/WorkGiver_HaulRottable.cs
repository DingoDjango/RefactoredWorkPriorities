using RimWorld;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace RWP
{
	public class WorkGiver_HaulRottable : WorkGiver_HaulGeneral
    {
		public static bool PrioritizeRottable = true;

        public static bool SkipDessicated = true;

		public override bool Prioritized
		{
			get
			{
				return PrioritizeRottable;
			}
		}

		public override bool ShouldSkip(Pawn pawn)
		{
			return !PrioritizeRottable;
		}

        public override bool HasJobOnThing(Pawn pawn, Thing t)
        {
            if (t.IsDessicated() && SkipDessicated)
            {
                return false;
            }

            return base.HasJobOnThing(pawn, t);
        }

        public override IEnumerable<Thing> PotentialWorkThingsGlobal(Pawn pawn) //Lists all items which need hauling and have CompProperties_Rottable
		{
			return pawn.Map.listerHaulables.ThingsPotentiallyNeedingHauling().Where(t => t.def.comps.Exists(tc => tc.compClass == typeof(CompRottable)));
		}

		public override float GetPriority(Pawn pawn, TargetInfo t)
		{
			Thing thing = t.Thing;
			var rottability = thing.def.GetCompProperties<CompProperties_Rottable>().daysToRotStart;

			return (1f) / (rottability);
		}
	}
}