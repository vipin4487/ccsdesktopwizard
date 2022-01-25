namespace CCSDTWorkflowWizard
{
    using CCSDTWorkflowLibrary;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing;
    using System.Drawing.Design;
    using System.Drawing.Text;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using System.Workflow.ComponentModel;
    using System.Workflow.ComponentModel.Design;

    [ToolboxItem(false)]
    public class Toolbox : Panel, IToolboxService
    {
        private const string CF_DESIGNER = "CF_WINOEDESIGNERCOMPONENTS";
        private IServiceProvider provider;
        private Hashtable customCreators;
        private Type currentSelection;
        private ListBox listBox = new ListBox();

        public Toolbox(IServiceProvider provider)
        {
            this.provider = provider;
            this.Text = "Toolbox";
            base.Size = new Size(0xe0, 350);
            this.listBox.Dock = DockStyle.Fill;
            this.listBox.IntegralHeight = false;
            this.listBox.ItemHeight = 20;
            this.listBox.DrawMode = DrawMode.OwnerDrawFixed;
            this.listBox.BorderStyle = BorderStyle.None;
            this.listBox.BackColor = SystemColors.Window;
            this.listBox.ForeColor = SystemColors.ControlText;
            this.listBox.MouseMove += new MouseEventHandler(this.OnListBoxMouseMove);
            base.Controls.Add(this.listBox);
            this.listBox.DrawItem += new DrawItemEventHandler(this.OnDrawItem);
            this.listBox.SelectedIndexChanged += new EventHandler(this.OnListBoxClick);
            this.AddToolboxEntries(this.listBox);
        }

        public void AddCreator(ToolboxItemCreatorCallback creator, string format)
        {
            this.AddCreator(creator, format, null);
        }

        public void AddCreator(ToolboxItemCreatorCallback creator, string format, IDesignerHost host)
        {
            if ((creator == null) || (format == null))
            {
                throw new ArgumentNullException((creator == null) ? "creator" : "format");
            }
            if (this.customCreators == null)
            {
                this.customCreators = new Hashtable();
            }
            else
            {
                string key = format;
                if (host > null)
                {
                    key = key + ", " + host.GetHashCode().ToString();
                }
                if (this.customCreators.ContainsKey(key))
                {
                    throw new Exception("There is already a creator registered for the format '" + format + "'.");
                }
            }
            this.customCreators[format] = creator;
        }

        public void AddLinkedToolboxItem(ToolboxItem toolboxItem, IDesignerHost host)
        {
        }

        public void AddLinkedToolboxItem(ToolboxItem toolboxItem, string category, IDesignerHost host)
        {
        }

        private void AddToolboxEntries(ListBox lb)
        {
            try
            {
                SortedList list = new SortedList();
                Assembly assembly = typeof(IfElseTest).Assembly;
                foreach (Type type in assembly.GetTypes())
                {
                    if (type.IsSubclassOf(typeof(Activity)) && ((type.Name != "SequentialWorkflowActivity") && (type.Name != "StateMachineWorkflowActivity")))
                    {
                        list.Add(type.Name, type.FullName);
                    }
                }
                foreach (string str in list.Values)
                {
                    SelfHostToolboxItem item = new SelfHostToolboxItem(str);
                    if (((item != null) && (item.ComponentClass != null)) && (GetToolboxItem(item.ComponentClass) > null))
                    {
                        lb.Items.Add(new SelfHostToolboxItem(str));
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error loading assembly for typeof(IfElseTest).");
            }
        }

        public virtual void AddToolboxItem(ToolboxItem toolboxItem)
        {
        }

        public virtual void AddToolboxItem(ToolboxItem toolboxItem, IDesignerHost host)
        {
        }

        public virtual void AddToolboxItem(ToolboxItem toolboxItem, string category)
        {
        }

        public virtual void AddToolboxItem(ToolboxItem toolboxItem, string category, IDesignerHost host)
        {
        }

        public void AddType(Type t)
        {
            this.listBox.Items.Add(new SelfHostToolboxItem(t.AssemblyQualifiedName));
        }

        public ToolboxItem DeserializeToolboxItem(object dataObject)
        {
            return this.DeserializeToolboxItem(dataObject, null);
        }

        public ToolboxItem DeserializeToolboxItem(object data, IDesignerHost host)
        {
            IDataObject dataObj = data as IDataObject;
            if (dataObj == null)
            {
                return null;
            }
            ToolboxItem item = (ToolboxItem) dataObj.GetData(typeof(ToolboxItem));
            if (item == null)
            {
                string str;
                ToolboxItemCreatorCallback callback = this.FindToolboxItemCreator(dataObj, host, out str);
                if (callback > null)
                {
                    return callback(dataObj, str);
                }
            }
            return item;
        }

        private ToolboxItemCreatorCallback FindToolboxItemCreator(IDataObject dataObj, IDesignerHost host, out string foundFormat)
        {
            foundFormat = string.Empty;
            ToolboxItemCreatorCallback callback = null;
            if (this.customCreators > null)
            {
                foreach (string str in this.customCreators.Keys)
                {
                    char[] separator = new char[] { ',' };
                    string[] strArray = str.Split(separator);
                    string format = strArray[0];
                    if (dataObj.GetDataPresent(format) && ((strArray.Length == 1) || ((host != null) && host.GetHashCode().ToString().Equals(strArray[1]))))
                    {
                        callback = (ToolboxItemCreatorCallback) this.customCreators[format];
                        foundFormat = format;
                        return callback;
                    }
                }
            }
            return callback;
        }

        public Attribute[] GetEnabledAttributes()
        {
            return null;
        }

        public virtual ToolboxItem GetSelectedToolboxItem()
        {
            ToolboxItem toolboxItem = null;
            if (this.currentSelection != null)
            {
                try
                {
                    toolboxItem = GetToolboxItem(this.currentSelection);
                }
                catch (TypeLoadException)
                {
                }
            }
            return toolboxItem;
        }

        public virtual ToolboxItem GetSelectedToolboxItem(IDesignerHost host)
        {
            return this.GetSelectedToolboxItem();
        }

        internal static ToolboxItem GetToolboxItem(Type toolType)
        {
            if (toolType == null)
            {
                throw new ArgumentNullException("toolType");
            }
            ToolboxItem item = null;
            if (((toolType.IsPublic || toolType.IsNestedPublic) && typeof(IComponent).IsAssignableFrom(toolType)) && !toolType.IsAbstract)
            {
                ToolboxItemAttribute attribute = (ToolboxItemAttribute) TypeDescriptor.GetAttributes(toolType)[typeof(ToolboxItemAttribute)];
                if ((attribute != null) && !attribute.IsDefaultAttribute())
                {
                    Type toolboxItemType = attribute.ToolboxItemType;
                    if (toolboxItemType != null)
                    {
                        Type[] types = new Type[] { typeof(Type) };
                        ConstructorInfo constructor = toolboxItemType.GetConstructor(types);
                        if (constructor != null)
                        {
                            object[] parameters = new object[] { toolType };
                            return (ToolboxItem) constructor.Invoke(parameters);
                        }
                        constructor = toolboxItemType.GetConstructor(new Type[0]);
                        if (constructor != null)
                        {
                            item = (ToolboxItem) constructor.Invoke(new object[0]);
                            item.Initialize(toolType);
                        }
                    }
                    return item;
                }
                if (!attribute.Equals(ToolboxItemAttribute.None))
                {
                    item = new ToolboxItem(toolType);
                }
                return item;
            }
            if (typeof(ToolboxItem).IsAssignableFrom(toolType))
            {
                try
                {
                    item = (ToolboxItem) Activator.CreateInstance(toolType, true);
                }
                catch
                {
                }
            }
            return item;
        }

        public ToolboxItemCollection GetToolboxItems()
        {
            return new ToolboxItemCollection(new ToolboxItem[0]);
        }

        public ToolboxItemCollection GetToolboxItems(IDesignerHost host)
        {
            return new ToolboxItemCollection(new ToolboxItem[0]);
        }

        public ToolboxItemCollection GetToolboxItems(string category)
        {
            return new ToolboxItemCollection(new ToolboxItem[0]);
        }

        public ToolboxItemCollection GetToolboxItems(string category, IDesignerHost host)
        {
            return new ToolboxItemCollection(new ToolboxItem[0]);
        }

        public bool IsSupported(object serializedObject, ICollection filterAttributes)
        {
            return true;
        }

        public bool IsSupported(object data, IDesignerHost host)
        {
            return true;
        }

        public bool IsToolboxItem(object dataObject)
        {
            return this.IsToolboxItem(dataObject, null);
        }

        public bool IsToolboxItem(object data, IDesignerHost host)
        {
            string str;
            IDataObject dataObj = data as IDataObject;
            if (dataObj == null)
            {
                return false;
            }
            return (dataObj.GetDataPresent(typeof(ToolboxItem)) || (this.FindToolboxItemCreator(dataObj, host, out str) > null));
        }

        private void OnDrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics graphics = e.Graphics;
            ListBox box = (ListBox) sender;
            object obj2 = box.Items[e.Index];
            SelfHostToolboxItem item = null;
            Bitmap image = null;
            string s = null;
            if (obj2 is string)
            {
                image = null;
                s = (string) obj2;
            }
            else
            {
                item = (SelfHostToolboxItem) obj2;
                image = (Bitmap) item.Glyph;
                s = item.Name;
            }
            bool flag = false;
            bool flag2 = false;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                flag = true;
            }
            if ((e.State & (DrawItemState.Inactive | DrawItemState.Disabled | DrawItemState.Grayed)) > DrawItemState.None)
            {
                flag2 = true;
            }
            StringFormat format = new StringFormat {
                HotkeyPrefix = HotkeyPrefix.Show
            };
            int num = e.Bounds.X + 4;
            num += 20;
            if (flag)
            {
                Rectangle bounds = e.Bounds;
                bounds.Width--;
                bounds.Height--;
                graphics.DrawRectangle(SystemPens.ActiveCaption, bounds);
            }
            else
            {
                graphics.FillRectangle(SystemBrushes.Menu, e.Bounds);
                using (Brush brush2 = new SolidBrush(Color.FromArgb(Math.Min(SystemColors.Menu.R + 15, 0xff), Math.Min(SystemColors.Menu.G + 15, 0xff), Math.Min(SystemColors.Menu.B + 15, 0xff))))
                {
                    graphics.FillRectangle(brush2, new Rectangle(e.Bounds.X, e.Bounds.Y, 20, e.Bounds.Height));
                }
            }
            if (image > null)
            {
                graphics.DrawImage(image, e.Bounds.X + 2, e.Bounds.Y + 2, image.Width, image.Height);
            }
            Brush brush = flag2 ? new SolidBrush(Color.FromArgb(120, SystemColors.MenuText)) : SystemBrushes.FromSystemColor(SystemColors.MenuText);
            graphics.DrawString(s, this.Font, brush, (float) num, (float) (e.Bounds.Y + 2), format);
            if (flag2)
            {
                brush.Dispose();
            }
            format.Dispose();
        }

        private void OnListBoxClick(object sender, EventArgs eevent)
        {
            SelfHostToolboxItem selectedItem = this.listBox.SelectedItem as SelfHostToolboxItem;
            if (selectedItem > null)
            {
                this.currentSelection = selectedItem.ComponentClass;
            }
            else if (this.currentSelection != null)
            {
                int index = this.listBox.Items.IndexOf(this.currentSelection);
                if (index >= 0)
                {
                    this.listBox.SelectedIndex = index;
                }
            }
        }

        private void OnListBoxMouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) && (this.listBox.SelectedItem > null))
            {
                SelfHostToolboxItem selectedItem = this.listBox.SelectedItem as SelfHostToolboxItem;
                if ((selectedItem != null) && (selectedItem.ComponentClass != null))
                {
                    ToolboxItem toolboxItem = GetToolboxItem(selectedItem.ComponentClass);
                    if (toolboxItem > null)
                    {
                        IDataObject data = this.SerializeToolboxItem(toolboxItem) as IDataObject;
                        DragDropEffects effects = base.DoDragDrop(data, DragDropEffects.Move | DragDropEffects.Copy);
                    }
                }
            }
        }

        public void Refresh()
        {
        }

        public void RemoveCreator(string format)
        {
            this.RemoveCreator(format, null);
        }

        public void RemoveCreator(string format, IDesignerHost host)
        {
            if (format == null)
            {
                throw new ArgumentNullException("format");
            }
            if (this.customCreators > null)
            {
                string key = format;
                if (host > null)
                {
                    key = key + ", " + host.GetHashCode().ToString();
                }
                this.customCreators.Remove(key);
            }
        }

        public virtual void RemoveToolboxItem(ToolboxItem toolComponentClass)
        {
        }

        public virtual void RemoveToolboxItem(ToolboxItem componentClass, string category)
        {
        }

        public void SelectedToolboxItemUsed()
        {
            this.SetSelectedToolboxItem(null);
        }

        public object SerializeToolboxItem(ToolboxItem toolboxItem)
        {
            IComponent[] componentArray = toolboxItem.CreateComponents();
            Activity[] array = new Activity[componentArray.Length];
            componentArray.CopyTo(array, 0);
            return CompositeActivityDesigner.SerializeActivitiesToDataObject(this.provider, array);
        }

        public virtual bool SetCursor()
        {
            if (this.currentSelection != null)
            {
                Cursor.Current = Cursors.Cross;
                return true;
            }
            return false;
        }

        public void SetEnabledAttributes(Attribute[] attrs)
        {
        }

        public virtual void SetSelectedToolboxItem(ToolboxItem selectedToolClass)
        {
            if (selectedToolClass == null)
            {
                this.listBox.SelectedIndex = 0;
                this.OnListBoxClick(null, EventArgs.Empty);
            }
        }

        public CategoryNameCollection CategoryNames
        {
            get
            {
                return new CategoryNameCollection(new string[] { "Workflow" });
            }
        }

        public string SelectedCategory
        {
            get
            {
                return "Workflow";
            }
            set
            {
            }
        }
    }
}

