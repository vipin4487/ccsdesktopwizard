namespace CCSDTWorkflowLibrary.Properties
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;

    [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"), DebuggerNonUserCode, CompilerGenerated]
    internal class Resources
    {
        private static System.Resources.ResourceManager resourceMan;
        private static CultureInfo resourceCulture;

        internal Resources()
        {
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (resourceMan == null)
                {
                    System.Resources.ResourceManager manager = new System.Resources.ResourceManager("CCSDTWorkflowLibrary.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = manager;
                }
                return resourceMan;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        internal static Bitmap CopyIcon16
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("CopyIcon16", resourceCulture);
            }
        }

        internal static Bitmap CopyIcon24
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("CopyIcon24", resourceCulture);
            }
        }

        internal static Bitmap CopyIcon32
        {
            get
            {
                return (Bitmap) ResourceManager.GetObject("CopyIcon32", resourceCulture);
            }
        }
    }
}

