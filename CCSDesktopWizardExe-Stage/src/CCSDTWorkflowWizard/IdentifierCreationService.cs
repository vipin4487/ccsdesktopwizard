namespace CCSDTWorkflowWizard
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using System.Workflow.ComponentModel;
    using System.Workflow.ComponentModel.Design;

    internal sealed class IdentifierCreationService : IIdentifierCreationService
    {
        private IServiceProvider serviceProvider = null;

        internal IdentifierCreationService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        private static Activity[] GetAllNestedActivities(CompositeActivity compositeActivity)
        {
            if (compositeActivity == null)
            {
                throw new ArgumentNullException("compositeActivity");
            }
            ArrayList list = new ArrayList();
            Queue queue = new Queue();
            queue.Enqueue(compositeActivity);
            while (queue.Count > 0)
            {
                CompositeActivity activity = (CompositeActivity) queue.Dequeue();
                foreach (Activity activity2 in activity.Activities)
                {
                    list.Add(activity2);
                    if (activity2 is CompositeActivity)
                    {
                        queue.Enqueue(activity2);
                    }
                }
                foreach (Activity activity3 in activity.EnabledActivities)
                {
                    if (!list.Contains(activity3))
                    {
                        list.Add(activity3);
                        if (activity3 is CompositeActivity)
                        {
                            queue.Enqueue(activity3);
                        }
                    }
                }
            }
            return (Activity[]) list.ToArray(typeof(Activity));
        }

        private static string GetBaseIdentifier(Activity activity)
        {
            string name = activity.GetType().Name;
            StringBuilder builder = new StringBuilder(name.Length);
            for (int i = 0; i < name.Length; i++)
            {
                if (char.IsUpper(name[i]) && (((i == 0) || (i == (name.Length - 1))) || char.IsUpper(name[i + 1])))
                {
                    builder.Append(char.ToLower(name[i]));
                }
                else
                {
                    builder.Append(name.Substring(i));
                    break;
                }
            }
            return builder.ToString();
        }

        private static IList GetIdentifiersInCompositeActivity(CompositeActivity compositeActivity)
        {
            ArrayList list = new ArrayList();
            if (compositeActivity > null)
            {
                list.Add(compositeActivity.Name);
                IList<Activity> allNestedActivities = GetAllNestedActivities(compositeActivity);
                foreach (Activity activity in allNestedActivities)
                {
                    list.Add(activity.Name);
                }
            }
            return ArrayList.ReadOnly(list);
        }

        private static Activity GetRootActivity(Activity activity)
        {
            if (activity == null)
            {
                throw new ArgumentException("activity");
            }
            while (activity.Parent > null)
            {
                activity = activity.Parent;
            }
            return activity;
        }

        void IIdentifierCreationService.EnsureUniqueIdentifiers(CompositeActivity parentActivity, ICollection childActivities)
        {
            if (parentActivity == null)
            {
                throw new ArgumentNullException("parentActivity");
            }
            if (childActivities == null)
            {
                throw new ArgumentNullException("childActivities");
            }
            ArrayList list = new ArrayList();
            Queue queue = new Queue(childActivities);
            while (queue.Count > 0)
            {
                Activity activity2 = (Activity) queue.Dequeue();
                if (activity2 is CompositeActivity)
                {
                    foreach (Activity activity3 in ((CompositeActivity) activity2).Activities)
                    {
                        queue.Enqueue(activity3);
                    }
                }
                if (activity2.Site <= null)
                {
                    list.Add(activity2);
                }
            }
            CompositeActivity rootActivity = GetRootActivity(parentActivity) as CompositeActivity;
            ArrayList list2 = new ArrayList();
            list2.AddRange(GetIdentifiersInCompositeActivity(rootActivity));
            foreach (Activity activity4 in list)
            {
                string name = activity4.Name;
                string baseIdentifier = GetBaseIdentifier(activity4);
                int num = 0;
                list2.Sort();
                while (((name == null) || (name.Length == 0)) || (list2.BinarySearch(name.ToLower(), StringComparer.OrdinalIgnoreCase) >= 0))
                {
                    name = $"{baseIdentifier}{++num}";
                }
                list2.Add(name);
                activity4.Name = name;
            }
        }

        void IIdentifierCreationService.ValidateIdentifier(Activity activity, string identifier)
        {
            if (identifier == null)
            {
                throw new ArgumentNullException("identifier");
            }
            if (activity == null)
            {
                throw new ArgumentNullException("activity");
            }
            if (!activity.Name.ToLower().Equals(identifier.ToLower()))
            {
                ArrayList list = new ArrayList();
                Activity rootActivity = GetRootActivity(activity);
                list.AddRange(GetIdentifiersInCompositeActivity(rootActivity as CompositeActivity));
                list.Sort();
                if (list.BinarySearch(identifier.ToLower(), StringComparer.OrdinalIgnoreCase) >= 0)
                {
                    throw new ArgumentException($"Duplicate Component Identifier {identifier}");
                }
            }
        }
    }
}

