namespace CCSDTWorkflowLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Workflow.ComponentModel;
    using System.Workflow.ComponentModel.Design;

    internal sealed class IfElseDesigner : ParallelActivityDesigner
    {
        public override bool CanInsertActivities(HitTestInfo insertLocation, ReadOnlyCollection<Activity> activitiesToInsert)
        {
            using (IEnumerator<Activity> enumerator = activitiesToInsert.GetEnumerator())
            {
                while (true)
                {
                    if (!enumerator.MoveNext())
                    {
                        break;
                    }
                    Activity current = enumerator.Current;
                    if (!(current is IfElseBranch))
                    {
                        return false;
                    }
                }
            }
            return base.CanInsertActivities(insertLocation, activitiesToInsert);
        }

        public override bool CanMoveActivities(HitTestInfo moveLocation, ReadOnlyCollection<Activity> activitiesToMove) => 
            (((this.ContainedDesigners.Count - activitiesToMove.Count) >= 1) || (moveLocation == null)) || ReferenceEquals(moveLocation.AssociatedDesigner, this);

        public override bool CanRemoveActivities(ReadOnlyCollection<Activity> activitiesToRemove) => 
            (this.ContainedDesigners.Count - activitiesToRemove.Count) >= 1;

        protected override CompositeActivity OnCreateNewBranch() => 
            new IfElseBranch();

        public override ReadOnlyCollection<DesignerView> Views
        {
            get
            {
                DesignerView[] list = new DesignerView[] { base.Views[0] };
                return new ReadOnlyCollection<DesignerView>(list);
            }
        }
    }
}

