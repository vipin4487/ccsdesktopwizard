namespace CCSDTWorkflowWizard
{
    using System;
    using System.Workflow.ComponentModel.Compiler;

    internal class WorkflowCompilerOptionsService : IWorkflowCompilerOptionsService
    {
        string IWorkflowCompilerOptionsService.RootNamespace
        {
            get
            {
                return string.Empty;
            }
        }

        string IWorkflowCompilerOptionsService.Language
        {
            get
            {
                return "CSharp";
            }
        }

        public bool CheckTypes
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }
    }
}

