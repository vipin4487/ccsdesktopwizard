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
                Type baseType = type1.BaseType;
                while (true)
                {
                    if (baseType == null)
                    {
                        break;
                    }
                    if (!(baseType == type2))
                    {
                        baseType = baseType.BaseType;
                        continue;
                    }
                    return true;
                }
            }
            return false;
        }

        bool ITypeFilterProvider.CanFilterType(Type type, bool throwOnError) => 
            IsSubclassOf(type, typeof(ActivityCondition));

        string ITypeFilterProvider.FilterDescription =>
            "Please select a class which derives from the ActivityCondition class.";
    }
}

