using RimWorld;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace RWP
{
	public class WorkGiver_HaulDeteriorating : WorkGiver_HaulGeneral
	{
		public static bool PrioritizeDeteriorating = true;

		public override bool Prioritized
		{
			get
			{
				return PrioritizeDeteriorating;
			}
		}

		public override bool ShouldSkip(Pawn pawn)
		{
			return !PrioritizeDeteriorating;
		}

		public override IEnumerable<Thing> PotentialWorkThingsGlobal(Pawn pawn) //Lists all items with DeteriorationRate above 0 that aren't under a roof
		{
			return pawn.Map.listerHaulables.ThingsPotentiallyNeedingHauling().Where(t => GridsUtility.GetRoof(t.Position, t.Map) == null && t.GetStatValue(StatDefOf.DeteriorationRate, true) > 0f);
		}

		public override float GetPriority(Pawn pawn, TargetInfo t)
		{
			Thing thing = t.Thing;

			float priority = (1f) / (thing.HitPoints / thing.GetStatValue(StatDefOf.DeteriorationRate, true));

			if (thing.HitPoints <= (thing.MaxHitPoints / 5))
			{
				priority *= 0.1f;
			}

			return priority;
		}
	}
}