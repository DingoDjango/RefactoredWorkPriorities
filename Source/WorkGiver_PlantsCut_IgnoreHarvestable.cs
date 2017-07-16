using System.Collections.Generic;
using RimWorld;
using Verse;

namespace RWP
{
	public class WorkGiver_PlantsCut_IgnoreHarvestable : WorkGiver_PlantsCut
	{
		public override IEnumerable<Thing> PotentialWorkThingsGlobal(Pawn pawn)
		{
			var allDesignations = pawn.Map.designationManager.allDesignations;

			for (int i = 0; i < allDesignations.Count; i++)
			{
				var designation = allDesignations[i];

				if (designation.def == DesignationDefOf.CutPlant)
				{
					yield return designation.target.Thing;
				}

				else if (designation.def == DesignationDefOf.HarvestPlant)
				{
					var plant = designation.target.Thing as Plant;

					if (plant != null)
					{
						if (plant.def.plant.IsTree || plant.def.plant.harvestedThingDef == null)
						{
							yield return designation.target.Thing;
						}
					}
				}
			}
		}
	}
}
