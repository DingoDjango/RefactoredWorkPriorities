using System;
using System.Collections.Generic;
using RimWorld;
using Verse;
using Verse.AI;

namespace RWP
{
	public class JobDriver_RepairCustom : JobDriver_Repair
	{
		protected override IEnumerable<Toil> MakeNewToils()
		{
			/* The final "repair" Toil ends the current job after it's done. 
			 This means that we have to somehow intervene with our designator removal.
			 To do this we add a designator removal action to the cleanup FinishActions list. */

			Action RemoveRepairDesignator = delegate
			{
				Pawn pawn = this.GetActor();
				Job job = pawn.jobs.curJob;

				if (job.targetA.Thing.HitPoints == job.targetA.Thing.MaxHitPoints)
				{
					pawn.Map.designationManager.RemoveAllDesignationsOn(job.targetA.Thing, false);
				}
			};

			this.AddFinishAction(RemoveRepairDesignator);

			foreach (Toil toil in base.MakeNewToils())
			{
				yield return toil;
			}
		}
	}
}
