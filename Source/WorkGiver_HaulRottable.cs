using RimWorld;
using System.Collections.Generic;
using Verse;

namespace RWP
{
	public class WorkGiver_HaulRottable : WorkGiver_HaulGeneral
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
			return !Settings.PrioritizeRottable;
		}

		public override IEnumerable<Thing> PotentialWorkThingsGlobal(Pawn pawn) //Lists all items which need hauling and have CompProperties_Rottable
		{
			return pawn.Map.listerHaulables.ThingsPotentiallyNeedingHauling().FindAll(t => t.def.comps.Exists(tc => tc.compClass == typeof(CompRottable)));
		}

		public override float GetPriority(Pawn pawn, TargetInfo t)
		{
			Thing thing = t.Thing;
			var rottability = thing.def.GetCompProperties<CompProperties_Rottable>().daysToRotStart;

			if (thing.TryGetComp<CompRottable>().RotProgressPct * 100f >= 90f)
			{
				return 0f;
			}

			return 1f / rottability;
		}
	}
}