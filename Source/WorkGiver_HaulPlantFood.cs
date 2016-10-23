using RimWorld;
using Verse;
using Verse.AI;

namespace RWP
{
	public class WorkGiver_HaulPlantFood : WorkGiver_HaulGeneral
	{
		public override Job JobOnThing(Pawn pawn, Thing t)
		{
			if (!(t.def.thingCategories.Exists(td => td.defName == "PlantFoodRaw")))
			{
				return null;
			}

			if (t.def.defName == "Hay" || t.def.defName == "RawHops" || t.def.defName == "PsychoidLeaves" || t.def.defName == "SmokeleafLeaves")
			{
				return null;
			}

			if (!HaulAIUtility.PawnCanAutomaticallyHaulFast(pawn, t))
			{
				return null;
			}

			return HaulAIUtility.HaulToStorageJob(pawn, t);
		}
	}
}