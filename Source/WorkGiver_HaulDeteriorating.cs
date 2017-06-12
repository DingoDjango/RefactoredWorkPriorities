using System.Collections.Generic;
using RimWorld;
using Verse;

namespace RWP
{
	public class WorkGiver_HaulDeteriorating : WorkGiver_HaulGeneral
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
			return !Settings.PrioritizeDeteriorating;
		}

		public override bool HasJobOnThing(Pawn pawn, Thing t, bool forced = false)
		{
			float tHealthPercent = 100f * (float)t.HitPoints / (float)t.MaxHitPoints;

			return base.HasJobOnThing(pawn, t) && tHealthPercent >= Settings.DeterioratableMinHealthPercent;
		}

		public override IEnumerable<Thing> PotentialWorkThingsGlobal(Pawn pawn) //Lists all items with DeteriorationRate above 0 that aren't under a roof
		{
			return pawn.Map.listerHaulables.ThingsPotentiallyNeedingHauling().FindAll(t => GridsUtility.GetRoof(t.Position, t.Map) == null && t.GetStatValue(StatDefOf.DeteriorationRate, true) > 0f);
		}

		public override float GetPriority(Pawn pawn, TargetInfo t)
		{
			Thing thing = t.Thing;
			float deteriorationRate = thing.HitPoints / thing.GetStatValue(StatDefOf.DeteriorationRate, true);

			return 1f / deteriorationRate;
		}
	}
}