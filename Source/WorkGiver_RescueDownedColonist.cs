using RimWorld;
using Verse;
using Verse.AI;

namespace RWP
{
	public class WorkGiver_RescueDownedColonist : WorkGiver_RescueDowned
    {
        public override bool HasJobOnThing(Pawn pawn, Thing t)
        {
            Pawn pawn2 = t as Pawn;
            if (pawn2 == null || !pawn2.Downed || pawn2.Faction != pawn.Faction || !pawn2.IsColonist || pawn2.InBed() || !pawn.CanReserve(pawn2, 1) || GenAI.EnemyIsNear(pawn2, 40f))
            {
                return false;
            }
            Thing thing = base.FindBed(pawn, pawn2);
            return thing != null && pawn2.CanReserve(thing, 1);
        }
	}
}
