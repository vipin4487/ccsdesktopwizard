namespace CCSDTWorkflowLibrary
{
    using System;
    using System.Workflow.ComponentModel;
    using System.Workflow.ComponentModel.Design;

    internal class ActivityConditionTypeFilterProvider : ITypeFilterProvider
    {
        private IServiceProvider _serviceProvider;

        public ActivityConditionTypeFilterProvider(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        private static bool IsSubclassOf(Type type1, Type type2)
        {
            if (type1 != type2)
            {
                for (Type type = type1.BaseType; type != null; type = type.BaseType)
                {
                    if (type == type2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        bool ITypeFilterProvider.CanFilterType(Type type, bool throwOnError)
        {
            return IsSubclassOf(type, typeof(ActivityCondition));
        }

        string ITypeFilterProvider.FilterDescription
        {
            get
            {
                return "Please select a class which derives from the ActivityCondition class.";
            }
        }
    }
}

