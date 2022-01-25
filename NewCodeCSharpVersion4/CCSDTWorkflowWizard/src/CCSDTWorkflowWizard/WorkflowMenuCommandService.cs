namespace CCSDTWorkflowWizard
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.Design;
    using System.Drawing;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    using System.Workflow.ComponentModel;
    using System.Workflow.ComponentModel.Design;

    internal sealed class WorkflowMenuCommandService : MenuCommandService
    {
        private const string DESIGNER_ACTION_GUID = "3bd4a275-fccd-49f0-b617-765ce63b4340";
        private IServiceProvider myServiceProvider;
        private WorkflowLoader myLoader;
        private string cutString;
        private string copyString;
        private string pasteString;
        private string deleteString;
        public Bitmap bmpCut;
        public Bitmap bmpCopy;
        public Bitmap bmpPaste;
        public Bitmap bmpDelete;
        private Bitmap bmpZoomIn;
        private Bitmap bmpZoomOut;
        private Bitmap bmpPan;
        private Bitmap bmpSelect;

        public WorkflowMenuCommandService(IServiceProvider serviceProvider, WorkflowLoader loader) : base(serviceProvider)
        {
            this.myServiceProvider = serviceProvider;
            this.myLoader = loader;
            ResourceManager manager = new ResourceManager("System.Design", typeof(ControlDesigner).Assembly);
            ResourceManager manager2 = new ResourceManager("System.Workflow.ComponentModel.Design.DesignerResources", typeof(WorkflowView).Assembly);
            this.cutString = manager.GetString("ContextMenuCut", CultureInfo.CurrentUICulture);
            this.copyString = manager.GetString("ContextMenuCopy", CultureInfo.CurrentUICulture);
            this.pasteString = manager.GetString("ContextMenuPaste", CultureInfo.CurrentUICulture);
            this.deleteString = manager.GetString("ContextMenuDelete", CultureInfo.CurrentUICulture);
            this.bmpCut = new Bitmap(typeof(Form).Assembly.GetManifestResourceStream("System.Windows.Forms.cut.bmp"));
            this.bmpCut.MakeTransparent(Color.Magenta);
            this.bmpCopy = new Bitmap(typeof(Form).Assembly.GetManifestResourceStream("System.Windows.Forms.copy.bmp"));
            this.bmpCopy.MakeTransparent(Color.Magenta);
            this.bmpPaste = new Bitmap(typeof(Form).Assembly.GetManifestResourceStream("System.Windows.Forms.paste.bmp"));
            this.bmpPaste.MakeTransparent(Color.Magenta);
            this.bmpDelete = new Bitmap(typeof(Form).Assembly.GetManifestResourceStream("System.Windows.Forms.delete.bmp"));
            this.bmpDelete.MakeTransparent(Color.Magenta);
            this.bmpZoomIn = manager2.GetObject("ZoomIn") as Bitmap;
            this.bmpZoomIn.MakeTransparent(Color.Magenta);
            this.bmpZoomOut = manager2.GetObject("ZoomOut") as Bitmap;
            this.bmpZoomOut.MakeTransparent(Color.Magenta);
            this.bmpPan = manager2.GetObject("PanOpenedHand") as Bitmap;
            this.bmpPan.MakeTransparent(Color.Magenta);
            this.bmpSelect = null;
        }

        private void AddWorkflowMenuCommand(ContextMenuStrip context, DesignerVerb verb)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(verb.Text, null, new EventHandler(this.OnMenuClicked)) {
                Enabled = verb.Enabled,
                Visible = verb.Visible,
                Checked = verb.Checked,
                Tag = verb
            };
            context.Items.Add(item);
        }

        private void AddWorkflowMenuCommand(ContextMenuStrip context, CommandID commandID, string text, Image icon)
        {
            MenuCommand command = base.FindCommand(commandID);
            ToolStripMenuItem item = new ToolStripMenuItem(text, icon, new EventHandler(this.OnMenuClicked)) {
                Enabled = command.Enabled,
                Visible = command.Visible,
                Checked = command.Checked,
                Tag = command
            };
            context.Items.Add(item);
        }

        private void DesignerActionsMenuClickHandler(object sender, EventArgs e)
        {
            DesignerAction tag = ((ToolStripMenuItem) sender).Tag as DesignerAction;
            if (tag != null)
            {
                tag.Invoke();
                if (!string.IsNullOrEmpty(tag.PropertyName))
                {
                    GridItem selectedGridItem = this.myLoader.propGridToUpdate.SelectedGridItem;
                    while (selectedGridItem.Parent > null)
                    {
                        selectedGridItem = selectedGridItem.Parent;
                    }
                    GridItem item2 = FindGridItem(selectedGridItem, tag.PropertyName);
                    if (item2 > null)
                    {
                        this.myLoader.propGridToUpdate.SelectedGridItem = item2;
                        this.myLoader.propGridToUpdate.Focus();
                    }
                }
            }
        }

        private static GridItem FindGridItem(GridItem gridItem, string name)
        {
            foreach (GridItem item in gridItem.GridItems)
            {
                if (item.Label == name)
                {
                    return item;
                }
                GridItem item2 = FindGridItem(item, name);
                if (item2 > null)
                {
                    return item2;
                }
            }
            return null;
        }

        private ToolStripMenuItem[] GetSelectionMenuItems()
        {
            List<ToolStripMenuItem> list = new List<ToolStripMenuItem>();
            bool flag = true;
            ISelectionService service = base.GetService(typeof(ISelectionService)) as ISelectionService;
            if (service > null)
            {
                foreach (object obj2 in service.GetSelectedComponents())
                {
                    if (!(obj2 is Activity))
                    {
                        flag = false;
                        break;
                    }
                }
            }
            if (flag)
            {
                bool enabled = false;
                Activity[] activityArray = CompositeActivityDesigner.DeserializeActivitiesFromDataObject(this.myServiceProvider, Clipboard.GetDataObject());
                if ((activityArray != null) && (activityArray.Length != 0))
                {
                    enabled = true;
                }
                Dictionary<CommandID, TextImage> dictionary = new Dictionary<CommandID, TextImage> {
                    { 
                        StandardCommands.Cut,
                        new TextImage(this.cutString, this.bmpCut, true)
                    },
                    { 
                        StandardCommands.Copy,
                        new TextImage(this.copyString, this.bmpCopy, true)
                    },
                    { 
                        StandardCommands.Paste,
                        new TextImage(this.pasteString, this.bmpPaste, enabled)
                    },
                    { 
                        StandardCommands.Delete,
                        new TextImage(this.deleteString, this.bmpDelete, true)
                    }
                };
                foreach (CommandID did in dictionary.Keys)
                {
                    MenuCommand command = base.FindCommand(did);
                    if (command > null)
                    {
                        ToolStripMenuItem item = new ToolStripMenuItem(dictionary[did].Text, dictionary[did].Image, new EventHandler(this.OnMenuClicked)) {
                            Tag = command
                        };
                        if (did == StandardCommands.Cut)
                        {
                            item.ShortcutKeys = Keys.Control | Keys.X;
                        }
                        if (did == StandardCommands.Copy)
                        {
                            item.ShortcutKeys = Keys.Control | Keys.C;
                        }
                        if (did == StandardCommands.Paste)
                        {
                            item.ShortcutKeys = Keys.Control | Keys.V;
                        }
                        item.Enabled = dictionary[did].Enabled;
                        item.Checked = command.Checked;
                        item.Visible = command.Visible;
                        list.Add(item);
                    }
                }
            }
            return list.ToArray();
        }

        private void OnMenuClicked(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if ((item != null) && (item.Tag is MenuCommand))
            {
                (item.Tag as MenuCommand).Invoke();
            }
        }

        public override void ShowContextMenu(CommandID menuID, int x, int y)
        {
            ContextMenuStrip contextMenu = null;
            if (menuID == WorkflowMenuCommands.DesignerActionsMenu)
            {
                Guid guid = new Guid("3bd4a275-fccd-49f0-b617-765ce63b4340");
                ICollection commandList = base.GetCommandList(menuID.Guid);
                foreach (MenuCommand command in commandList)
                {
                    if ((command.CommandID.ID == 0x2096) || (command.CommandID.ID == 0x2097))
                    {
                        if (contextMenu == null)
                        {
                            contextMenu = new ContextMenuStrip {
                                AutoClose = true
                            };
                        }
                        ToolStripMenuItem item = new ToolStripMenuItem(command.Properties["Text"].ToString());
                        item.Click += new EventHandler(this.DesignerActionsMenuClickHandler);
                        item.Image = ((DesignerAction) command.Properties[guid]).Image;
                        item.Tag = command.Properties[guid];
                        contextMenu.Items.Add(item);
                    }
                }
                if (contextMenu > null)
                {
                    EventHandler d = null;
                    d = delegate (object o, EventArgs e) {
                        contextMenu.MouseLeave -= d;
                        contextMenu.Close();
                    };
                    contextMenu.MouseLeave += d;
                    WorkflowView service = base.GetService(typeof(WorkflowView)) as WorkflowView;
                    if (service > null)
                    {
                        contextMenu.Show(service, service.PointToClient(new Point(x, y)));
                    }
                }
            }
            else if (menuID == WorkflowMenuCommands.SelectionMenu)
            {
                contextMenu = new ContextMenuStrip();
                foreach (DesignerVerb verb in this.Verbs)
                {
                    if (((verb.Text != "&Generate Handlers") && (verb.Text != "Promote Bin&dable Properties")) && (verb.Text != "&Bind Selected Property..."))
                    {
                        this.AddWorkflowMenuCommand(contextMenu, verb);
                    }
                }
                ToolStripItem[] selectionMenuItems = this.GetSelectionMenuItems();
                if (selectionMenuItems.Length != 0)
                {
                    if (contextMenu.Items.Count > 0)
                    {
                        contextMenu.Items.Add(new ToolStripSeparator());
                    }
                    contextMenu.Items.AddRange(selectionMenuItems);
                }
            }
            else if (menuID == WorkflowMenuCommands.PageLayoutMenu)
            {
                contextMenu = new ContextMenuStrip();
                this.AddWorkflowMenuCommand(contextMenu, WorkflowMenuCommands.DefaultPage, "Default View", null);
                this.AddWorkflowMenuCommand(contextMenu, WorkflowMenuCommands.PrintPreviewPage, "Print Preview", null);
            }
            else if (menuID == WorkflowMenuCommands.ZoomMenu)
            {
                contextMenu = new ContextMenuStrip();
                this.AddWorkflowMenuCommand(contextMenu, WorkflowMenuCommands.Zoom400Mode, "400%", null);
                this.AddWorkflowMenuCommand(contextMenu, WorkflowMenuCommands.Zoom300Mode, "300%", null);
                this.AddWorkflowMenuCommand(contextMenu, WorkflowMenuCommands.Zoom200Mode, "200%", null);
                this.AddWorkflowMenuCommand(contextMenu, WorkflowMenuCommands.Zoom150Mode, "150%", null);
                this.AddWorkflowMenuCommand(contextMenu, WorkflowMenuCommands.Zoom100Mode, "100%", null);
                this.AddWorkflowMenuCommand(contextMenu, WorkflowMenuCommands.Zoom75Mode, "75%", null);
                this.AddWorkflowMenuCommand(contextMenu, WorkflowMenuCommands.Zoom50Mode, "50%", null);
                contextMenu.Items.Add(new ToolStripSeparator());
                this.AddWorkflowMenuCommand(contextMenu, WorkflowMenuCommands.ShowAll, "Show All", null);
            }
            else if (menuID == WorkflowMenuCommands.PanMenu)
            {
                contextMenu = new ContextMenuStrip();
                this.AddWorkflowMenuCommand(contextMenu, WorkflowMenuCommands.ZoomIn, "Zoom In", this.bmpZoomIn);
                this.AddWorkflowMenuCommand(contextMenu, WorkflowMenuCommands.ZoomOut, "Zoom Out", this.bmpZoomOut);
                this.AddWorkflowMenuCommand(contextMenu, WorkflowMenuCommands.Pan, "Navigation Tool", this.bmpPan);
                this.AddWorkflowMenuCommand(contextMenu, WorkflowMenuCommands.DefaultFilter, "Default", this.bmpSelect);
            }
            if ((contextMenu != null) && (contextMenu.Items.Count > 0))
            {
                WorkflowView service = base.GetService(typeof(WorkflowView)) as WorkflowView;
                if (service > null)
                {
                    contextMenu.Show(service, service.PointToClient(new Point(x, y)));
                }
            }
        }

        private class TextImage
        {
            public TextImage(string text, System.Drawing.Image img, bool enabled)
            {
                this.Text = text;
                this.Image = img;
                this.Enabled = enabled;
            }

            public string Text { get; set; }

            public System.Drawing.Image Image { get; set; }

            public bool Enabled { get; set; }
        }
    }
}

