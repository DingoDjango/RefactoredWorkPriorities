using RimWorld;
using Verse;

namespace RWP
{
	public class WorkGiver_TendPrioritized : WorkGiver_Tend
	{
		public static bool TendColonistsFirst = true;

		public override bool Prioritized
		{
			get
			{
				return TendColonistsFirst;
			}
		}

		public override float GetPriority(Pawn pawn, TargetInfo t)
		{
			Pawn pawn2 = t.Thing as Pawn;

			if (pawn2.IsColonist)
			{
				return 100f;
			}

			else if (pawn2.Faction == Faction.OfPlayer)
			{
				return 50f;
			}

			return 1f;
		}
	}
}