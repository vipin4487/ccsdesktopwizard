namespace CCSDTWorkflowLibrary
{
    using System;
    using System.Collections.ObjectModel;
    using System.Workflow.ComponentModel;
    using System.Workflow.ComponentModel.Design;

    internal sealed class IfElseDesigner : ParallelActivityDesigner
    {
        public override bool CanInsertActivities(HitTestInfo insertLocation, ReadOnlyCollection<Activity> activitiesToInsert)
        {
            foreach (Activity activity in activitiesToInsert)
            {
                if (!(activity is IfElseBranch))
                {
                    return false;
                }
            }
            return base.CanInsertActivities(insertLocation, activitiesToInsert);
        }

        public override bool CanMoveActivities(HitTestInfo moveLocation, ReadOnlyCollection<Activity> activitiesToMove)
        {
            if ((((this.ContainedDesigners.Count - activitiesToMove.Count) < 1) && (moveLocation != null)) && (moveLocation.AssociatedDesigner != this))
            {
                return false;
            }
            return true;
        }

        public override bool CanRemoveActivities(ReadOnlyCollection<Activity> activitiesToRemove)
        {
            if ((this.ContainedDesigners.Count - activitiesToRemove.Count) < 1)
            {
                return false;
            }
            return true;
        }

        protected override CompositeActivity OnCreateNewBranch()
        {
            return new IfElseBranch();
        }

        public override ReadOnlyCollection<DesignerView> Views
        {
            get
            {
                return new ReadOnlyCollection<DesignerView>(new DesignerView[] { base.Views[0] });
            }
        }
    }
}

