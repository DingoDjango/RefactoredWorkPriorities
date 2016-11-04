using RimWorld;
using Verse;
using Verse.AI;

namespace RWP
{
	public class WorkGiver_TendHumanColonist : WorkGiver_Tend
	{
		public override bool HasJobOnThing(Pawn pawn, Thing t)
		{
			Pawn pawn2 = t as Pawn;
			return pawn2 != null && pawn2 != pawn && pawn2.IsColonist && pawn2.InBed() && pawn2.health.ShouldBeTendedNow && pawn.CanReserve(pawn2, 1);
		}
	}
}