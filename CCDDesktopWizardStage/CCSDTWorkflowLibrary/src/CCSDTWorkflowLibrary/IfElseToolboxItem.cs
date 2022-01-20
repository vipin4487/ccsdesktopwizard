namespace CCSDTWorkflowLibrary
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Workflow.ComponentModel;
    using System.Workflow.ComponentModel.Design;

    [Serializable]
    internal sealed class IfElseToolboxItem : ActivityToolboxItem
    {
        public IfElseToolboxItem(Type type) : base(type)
        {
        }

        protected override IComponent[] CreateComponentsCore(IDesignerHost designerHost)
        {
            CompositeActivity activity = new IfElseTest {
                Activities = { new IfElseBranch() }
            };
            return new IComponent[] { activity };
        }
    }
}

