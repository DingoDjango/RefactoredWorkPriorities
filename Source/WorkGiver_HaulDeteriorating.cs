using System.Collections.Generic;
using System.Linq;
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

			return tHealthPercent >= Settings.DeterioratableMinHealthPercent && base.HasJobOnThing(pawn, t);
		}

		public override IEnumerable<Thing> PotentialWorkThingsGlobal(Pawn pawn) //Finds all actively deteriorating items
		{
			return pawn.Map.listerHaulables.ThingsPotentiallyNeedingHauling().Where(t => t.GetStatValue(StatDefOf.DeteriorationRate, true) > 0f && GridsUtility.GetRoof(t.Position, t.Map) == null);
		}

		public override float GetPriority(Pawn pawn, TargetInfo t)
		{
			Thing thing = t.Thing;

			return thing.GetStatValue(StatDefOf.DeteriorationRate, true) / (float)thing.HitPoints;
		}
	}
}