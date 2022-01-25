namespace CCSDTWorkflowLibrary
{
    using System.ComponentModel;
    using System.ComponentModel.Design;

    [Designer(typeof(CustomWorkflowDesigner), typeof(IRootDesigner)), Description("Allows selection of controls displayed on a screen pop.")]
    public class AuxCodePopWorkflow : ScreenPopWorkflow
    {
    }
}

