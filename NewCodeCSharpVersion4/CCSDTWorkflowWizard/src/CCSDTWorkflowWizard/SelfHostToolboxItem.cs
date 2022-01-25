namespace CCSDTWorkflowWizard
{
    using CCSDTWorkflowLibrary;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Reflection;
    using System.Workflow.Activities;

    internal class SelfHostToolboxItem
    {
        private string componentClassName;
        private Type componentClass;
        private string name = null;
        private string className = null;
        private Image glyph = null;

        public SelfHostToolboxItem(string componentClassName)
        {
            this.componentClassName = componentClassName;
        }

        public override string ToString()
        {
            return this.componentClassName;
        }

        public string ClassName
        {
            get
            {
                if (this.className == null)
                {
                    this.className = this.ComponentClass.FullName;
                }
                return this.className;
            }
        }

        public Type ComponentClass
        {
            get
            {
                if (this.componentClass == null)
                {
                    this.componentClass = Type.GetType(this.componentClassName);
                    if (this.componentClass == null)
                    {
                        int index = this.componentClassName.IndexOf(",");
                        if (index >= 0)
                        {
                            this.componentClassName = this.componentClassName.Substring(0, index);
                        }
                        foreach (AssemblyName name in Assembly.GetExecutingAssembly().GetReferencedAssemblies())
                        {
                            Assembly assembly = Assembly.Load(name);
                            if (assembly != null)
                            {
                                this.componentClass = assembly.GetType(this.componentClassName);
                                if (this.componentClass != null)
                                {
                                    break;
                                }
                            }
                        }
                        this.componentClass = typeof(IfElseTest).Assembly.GetType(this.componentClassName);
                        if (this.componentClass == null)
                        {
                            this.componentClass = typeof(SequentialWorkflowActivity).Assembly.GetType(this.componentClassName);
                        }
                    }
                }
                return this.componentClass;
            }
        }

        public string Name
        {
            get
            {
                if (this.name == null)
                {
                    if (this.ComponentClass != null)
                    {
                        this.name = this.ComponentClass.Name;
                    }
                    else
                    {
                        this.name = "Unknown Item";
                    }
                }
                return this.name;
            }
        }

        public virtual Image Glyph
        {
            get
            {
                if (this.glyph == null)
                {
                    Type componentClass = this.ComponentClass;
                    if (componentClass == null)
                    {
                        componentClass = typeof(Component);
                    }
                    ToolboxBitmapAttribute attribute = (ToolboxBitmapAttribute) TypeDescriptor.GetAttributes(componentClass)[typeof(ToolboxBitmapAttribute)];
                    if (attribute > null)
                    {
                        this.glyph = attribute.GetImage(componentClass, false);
                    }
                }
                return this.glyph;
            }
        }
    }
}

