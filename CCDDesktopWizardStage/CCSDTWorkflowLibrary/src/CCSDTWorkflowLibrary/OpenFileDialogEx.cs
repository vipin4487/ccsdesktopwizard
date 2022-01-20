namespace CCSDTWorkflowLibrary
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;

    public class OpenFileDialogEx : UserControl
    {
        private SetWindowPosFlags UFLAGSHIDE = (SetWindowPosFlags.SWP_NOOWNERZORDER | SetWindowPosFlags.SWP_HIDEWINDOW | SetWindowPosFlags.SWP_NOACTIVATE | SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOSIZE);
        private AddonWindowLocation mStartLocation = AddonWindowLocation.Right;
        private FolderViewMode mDefaultViewMode = FolderViewMode.Default;
        private IContainer components = null;
        protected OpenFileDialog dlgOpen;

        public event EventHandler ClosingDialog;

        public event FileNameChangedHandler FileNameChanged;

        public event FileNameChangedHandler FolderNameChanged;

        public OpenFileDialogEx()
        {
            this.InitializeComponent();
        }

        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern IntPtr BeginDeferWindowPos(int nNumWindows);
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern IntPtr ChildWindowFromPointEx(IntPtr hParent, POINT pt, ChildFromPointFlags flags);
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern IntPtr DeferWindowPos(IntPtr hWinPosInfo, IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int Width, int Height, SetWindowPosFlags flags);
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern bool EndDeferWindowPos(IntPtr hWinPosInfo);
        [DllImport("user32.Dll")]
        public static extern bool EnumChildWindows(IntPtr hWndParent, EnumWindowsCallBack lpEnumFunc, int lParam);
        [DllImport("user32.Dll")]
        public static extern bool EnumWindows(EnumWindowsCallBack lpEnumFunc, int lParam);
        [DllImport("user32.dll", EntryPoint="FindWindowExA", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Ansi)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("User32.Dll")]
        public static extern void GetClassName(IntPtr hWnd, StringBuilder param, int length);
        [DllImport("user32.dll")]
        public static extern bool GetClientRect(IntPtr hwnd, ref RECT rect);
        [DllImport("User32.Dll")]
        public static extern int GetDlgCtrlID(IntPtr hWndCtl);
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern IntPtr GetParent(IntPtr hWnd);
        [DllImport("user32.dll", SetLastError=true)]
        public static extern bool GetWindowInfo(IntPtr hwnd, out WINDOWINFO pwi);
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref RECT rect);
        [DllImport("User32.Dll")]
        public static extern void GetWindowText(IntPtr hWnd, StringBuilder param, int length);
        private void InitializeComponent()
        {
            this.dlgOpen = new OpenFileDialog();
            base.SuspendLayout();
            base.Name = "OpenFileDialogEx";
            base.Size = new Size(0xff, 0xf6);
            base.ResumeLayout(false);
        }

        [DllImport("user32.dll", CharSet=CharSet.Auto, ExactSpelling=true)]
        public static extern int MapWindowPoints(IntPtr hWnd, IntPtr hWndTo, ref POINT pt, int cPoints);
        public virtual void OnClosingDialog()
        {
            if (this.ClosingDialog != null)
            {
                this.ClosingDialog(this, new EventArgs());
            }
        }

        public virtual void OnFileNameChanged(string fileName)
        {
            if (this.FileNameChanged != null)
            {
                this.FileNameChanged(this, fileName);
            }
        }

        public virtual void OnFolderNameChanged(string folderName)
        {
            if (this.FolderNameChanged != null)
            {
                this.FolderNameChanged(this, folderName);
            }
        }

        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern int PostMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern int PostMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
        [DllImport("User32.dll", CharSet=CharSet.Auto)]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, StringBuilder param);
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, char[] chars);
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern IntPtr SetCapture(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int Width, int Height, SetWindowPosFlags flags);
        public void ShowDialog()
        {
            this.ShowDialog(null);
        }

        public void ShowDialog(IWin32Window owner)
        {
            DummyForm form = new DummyForm(this);
            form.Show(owner);
            SetWindowPos(form.Handle, IntPtr.Zero, 0, 0, 0, 0, this.UFLAGSHIDE);
            form.WatchForActivate = true;
            try
            {
                this.dlgOpen.ShowDialog(form);
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
            form.Dispose();
            form.Close();
        }

        public OpenFileDialog OpenDialog =>
            this.dlgOpen;

        [DefaultValue(1)]
        public AddonWindowLocation StartLocation
        {
            get => 
                this.mStartLocation;
            set => 
                this.mStartLocation = value;
        }

        [DefaultValue(0x7028)]
        public FolderViewMode DefaultViewMode
        {
            get => 
                this.mDefaultViewMode;
            set => 
                this.mDefaultViewMode = value;
        }

        private class BaseDialogNative : NativeWindow, IDisposable
        {
            private IntPtr mhandle;

            public event FileNameChangedHandler FileNameChanged;

            public event FileNameChangedHandler FolderNameChanged;

            public BaseDialogNative(IntPtr handle)
            {
                this.mhandle = handle;
                base.AssignHandle(handle);
            }

            public void Dispose()
            {
                this.ReleaseHandle();
            }

            protected override void WndProc(ref Message m)
            {
                if (m.Msg == 0x4e)
                {
                    OFNOTIFY ofnotify = (OFNOTIFY) Marshal.PtrToStructure(m.LParam, typeof(OFNOTIFY));
                    if (ofnotify.hdr.code == 0xfffffda6)
                    {
                        StringBuilder param = new StringBuilder(0x100);
                        OpenFileDialogEx.SendMessage(OpenFileDialogEx.GetParent(this.mhandle), 0x465, 0x100, param);
                        if (this.FileNameChanged != null)
                        {
                            this.FileNameChanged(this, param.ToString());
                        }
                    }
                    else if (ofnotify.hdr.code == 0xfffffda5)
                    {
                        StringBuilder param = new StringBuilder(0x100);
                        OpenFileDialogEx.SendMessage(OpenFileDialogEx.GetParent(this.mhandle), 0x466, 0x100, param);
                        if (this.FolderNameChanged != null)
                        {
                            this.FolderNameChanged(this, param.ToString());
                        }
                    }
                }
                base.WndProc(ref m);
            }

            public delegate void FileNameChangedHandler(OpenFileDialogEx.BaseDialogNative sender, string filePath);
        }

        private class DummyForm : Form
        {
            private OpenFileDialogEx.OpenDialogNative mNativeDialog = null;
            private OpenFileDialogEx mFileDialogEx = null;
            private bool mWatchForActivate = false;
            private IntPtr mOpenDialogHandle = IntPtr.Zero;

            public DummyForm(OpenFileDialogEx fileDialogEx)
            {
                this.mFileDialogEx = fileDialogEx;
                this.Text = "";
                base.StartPosition = FormStartPosition.Manual;
                base.Location = new Point(-32000, -32000);
                base.ShowInTaskbar = false;
            }

            protected override void OnClosing(CancelEventArgs e)
            {
                if (this.mNativeDialog != null)
                {
                    this.mNativeDialog.Dispose();
                }
                base.OnClosing(e);
            }

            protected override void WndProc(ref Message m)
            {
                if (this.mWatchForActivate && (m.Msg == 6))
                {
                    this.mWatchForActivate = false;
                    this.mOpenDialogHandle = m.LParam;
                    this.mNativeDialog = new OpenFileDialogEx.OpenDialogNative(m.LParam, this.mFileDialogEx);
                }
                base.WndProc(ref m);
            }

            public bool WatchForActivate
            {
                get => 
                    this.mWatchForActivate;
                set => 
                    this.mWatchForActivate = value;
            }
        }

        public delegate bool EnumWindowsCallBack(IntPtr hWnd, int lParam);

        public delegate void FileNameChangedHandler(OpenFileDialogEx sender, string filePath);

        private class OpenDialogNative : NativeWindow, IDisposable
        {
            private SetWindowPosFlags UFLAGSSIZE = (SetWindowPosFlags.SWP_NOOWNERZORDER | SetWindowPosFlags.SWP_NOACTIVATE | SetWindowPosFlags.SWP_NOMOVE);
            private SetWindowPosFlags UFLAGSHIDE = (SetWindowPosFlags.SWP_NOOWNERZORDER | SetWindowPosFlags.SWP_HIDEWINDOW | SetWindowPosFlags.SWP_NOACTIVATE | SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOSIZE);
            private SetWindowPosFlags UFLAGSZORDER = (SetWindowPosFlags.SWP_NOACTIVATE | SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOSIZE);
            private Size mOriginalSize;
            private IntPtr mOpenDialogHandle;
            private IntPtr mListViewPtr;
            private WINDOWINFO mListViewInfo;
            private OpenFileDialogEx.BaseDialogNative mBaseDialogNative;
            private IntPtr mComboFolders;
            private WINDOWINFO mComboFoldersInfo;
            private IntPtr mGroupButtons;
            private WINDOWINFO mGroupButtonsInfo;
            private IntPtr mComboFileName;
            private WINDOWINFO mComboFileNameInfo;
            private IntPtr mComboExtensions;
            private WINDOWINFO mComboExtensionsInfo;
            private IntPtr mOpenButton;
            private WINDOWINFO mOpenButtonInfo;
            private IntPtr mCancelButton;
            private WINDOWINFO mCancelButtonInfo;
            private IntPtr mHelpButton;
            private WINDOWINFO mHelpButtonInfo;
            private OpenFileDialogEx mSourceControl;
            private IntPtr mToolBarFolders;
            private WINDOWINFO mToolBarFoldersInfo;
            private IntPtr mLabelFileName;
            private WINDOWINFO mLabelFileNameInfo;
            private IntPtr mLabelFileType;
            private WINDOWINFO mLabelFileTypeInfo;
            private IntPtr mChkReadOnly;
            private WINDOWINFO mChkReadOnlyInfo;
            private bool mIsClosing = false;
            private bool mInitializated = false;
            private RECT mOpenDialogWindowRect = new RECT();
            private RECT mOpenDialogClientRect = new RECT();

            public OpenDialogNative(IntPtr handle, OpenFileDialogEx sourceControl)
            {
                this.mOpenDialogHandle = handle;
                this.mSourceControl = sourceControl;
                base.AssignHandle(this.mOpenDialogHandle);
            }

            private void BaseDialogNative_FileNameChanged(OpenFileDialogEx.BaseDialogNative sender, string filePath)
            {
                if (this.mSourceControl != null)
                {
                    this.mSourceControl.OnFileNameChanged(filePath);
                }
            }

            private void BaseDialogNative_FolderNameChanged(OpenFileDialogEx.BaseDialogNative sender, string folderName)
            {
                if (this.mSourceControl != null)
                {
                    this.mSourceControl.OnFolderNameChanged(folderName);
                }
            }

            public void Dispose()
            {
                this.ReleaseHandle();
                if (this.mBaseDialogNative != null)
                {
                    this.mBaseDialogNative.FileNameChanged -= new OpenFileDialogEx.BaseDialogNative.FileNameChangedHandler(this.BaseDialogNative_FileNameChanged);
                    this.mBaseDialogNative.FolderNameChanged -= new OpenFileDialogEx.BaseDialogNative.FileNameChangedHandler(this.BaseDialogNative_FolderNameChanged);
                    this.mBaseDialogNative.Dispose();
                }
            }

            private void InitControls()
            {
                this.mInitializated = true;
                OpenFileDialogEx.GetClientRect(this.mOpenDialogHandle, ref this.mOpenDialogClientRect);
                OpenFileDialogEx.GetWindowRect(this.mOpenDialogHandle, ref this.mOpenDialogWindowRect);
                this.PopulateWindowsHandlers();
                switch (this.mSourceControl.StartLocation)
                {
                    case AddonWindowLocation.None:
                        OpenFileDialogEx.SetParent(this.mSourceControl.Handle, this.mOpenDialogHandle);
                        OpenFileDialogEx.SetWindowPos(this.mSourceControl.Handle, (IntPtr) 1, 0, 0, 0, 0, this.UFLAGSZORDER);
                        break;

                    case AddonWindowLocation.Right:
                        this.mSourceControl.Location = new Point(((int) this.mOpenDialogClientRect.Width) - this.mSourceControl.Width, 0);
                        OpenFileDialogEx.SetParent(this.mSourceControl.Handle, this.mOpenDialogHandle);
                        OpenFileDialogEx.SetWindowPos(this.mSourceControl.Handle, (IntPtr) 1, 0, 0, 0, 0, this.UFLAGSZORDER);
                        break;

                    case AddonWindowLocation.Bottom:
                        this.mSourceControl.Location = new Point(0, ((int) this.mOpenDialogClientRect.Height) - this.mSourceControl.Height);
                        OpenFileDialogEx.SetParent(this.mSourceControl.Handle, this.mOpenDialogHandle);
                        OpenFileDialogEx.SetWindowPos(this.mSourceControl.Handle, (IntPtr) 1, 0, 0, 0, 0, this.UFLAGSZORDER);
                        break;

                    default:
                        break;
                }
            }

            private bool OpenFileDialogEnumWindowCallBack(IntPtr hwnd, int lParam)
            {
                WINDOWINFO windowinfo;
                bool flag2;
                StringBuilder param = new StringBuilder(0x100);
                OpenFileDialogEx.GetClassName(hwnd, param, param.Capacity);
                int dlgCtrlID = OpenFileDialogEx.GetDlgCtrlID(hwnd);
                OpenFileDialogEx.GetWindowInfo(hwnd, out windowinfo);
                if (param.ToString().StartsWith("#32770"))
                {
                    this.mBaseDialogNative = new OpenFileDialogEx.BaseDialogNative(hwnd);
                    this.mBaseDialogNative.FileNameChanged += new OpenFileDialogEx.BaseDialogNative.FileNameChangedHandler(this.BaseDialogNative_FileNameChanged);
                    this.mBaseDialogNative.FolderNameChanged += new OpenFileDialogEx.BaseDialogNative.FileNameChangedHandler(this.BaseDialogNative_FolderNameChanged);
                    flag2 = true;
                }
                else
                {
                    ControlsID sid = (ControlsID) dlgCtrlID;
                    if (sid > ControlsID.LabelFileName)
                    {
                        if (sid <= ControlsID.ComboFileType)
                        {
                            if (sid != ControlsID.DefaultView)
                            {
                                if (sid == ControlsID.ComboFileType)
                                {
                                    this.mComboExtensions = hwnd;
                                    this.mComboExtensionsInfo = windowinfo;
                                }
                            }
                            else
                            {
                                this.mListViewPtr = hwnd;
                                OpenFileDialogEx.GetWindowInfo(hwnd, out this.mListViewInfo);
                                if (this.mSourceControl.DefaultViewMode != FolderViewMode.Default)
                                {
                                    OpenFileDialogEx.SendMessage(this.mListViewPtr, 0x111, (int) this.mSourceControl.DefaultViewMode, 0);
                                }
                            }
                        }
                        else if (sid == ControlsID.ComboFolder)
                        {
                            this.mComboFolders = hwnd;
                            this.mComboFoldersInfo = windowinfo;
                        }
                        else if (sid != ControlsID.ComboFileName)
                        {
                            if (sid == ControlsID.LeftToolBar)
                            {
                                this.mToolBarFolders = hwnd;
                                this.mToolBarFoldersInfo = windowinfo;
                            }
                        }
                        else if (param.ToString().ToLower() == "comboboxex32")
                        {
                            this.mComboFileName = hwnd;
                            this.mComboFileNameInfo = windowinfo;
                        }
                    }
                    else if (sid <= ControlsID.ButtonCancel)
                    {
                        if (sid == ControlsID.ButtonOpen)
                        {
                            this.mOpenButton = hwnd;
                            this.mOpenButtonInfo = windowinfo;
                        }
                        else if (sid == ControlsID.ButtonCancel)
                        {
                            this.mCancelButton = hwnd;
                            this.mCancelButtonInfo = windowinfo;
                        }
                    }
                    else if (sid == ControlsID.ButtonHelp)
                    {
                        this.mHelpButton = hwnd;
                        this.mHelpButtonInfo = windowinfo;
                    }
                    else if (sid == ControlsID.CheckBoxReadOnly)
                    {
                        this.mChkReadOnly = hwnd;
                        this.mChkReadOnlyInfo = windowinfo;
                    }
                    else
                    {
                        switch (sid)
                        {
                            case ControlsID.GroupFolder:
                                this.mGroupButtons = hwnd;
                                this.mGroupButtonsInfo = windowinfo;
                                break;

                            case ControlsID.LabelFileType:
                                this.mLabelFileType = hwnd;
                                this.mLabelFileTypeInfo = windowinfo;
                                break;

                            case ControlsID.LabelFileName:
                                this.mLabelFileName = hwnd;
                                this.mLabelFileNameInfo = windowinfo;
                                break;

                            default:
                                break;
                        }
                    }
                    flag2 = true;
                }
                return flag2;
            }

            private void PopulateWindowsHandlers()
            {
                OpenFileDialogEx.EnumChildWindows(this.mOpenDialogHandle, new OpenFileDialogEx.EnumWindowsCallBack(this.OpenFileDialogEnumWindowCallBack), 0);
            }

            protected override unsafe void WndProc(ref Message m)
            {
                int msg = m.Msg;
                if (msg == 0x18)
                {
                    this.mInitializated = true;
                    this.InitControls();
                }
                else if (msg != 70)
                {
                    if ((msg == 0x282) && (m.WParam == ((IntPtr) 1)))
                    {
                        this.mIsClosing = true;
                        this.mSourceControl.OnClosingDialog();
                        OpenFileDialogEx.SetWindowPos(this.mOpenDialogHandle, IntPtr.Zero, 0, 0, 0, 0, this.UFLAGSHIDE);
                        OpenFileDialogEx.GetWindowRect(this.mOpenDialogHandle, ref this.mOpenDialogWindowRect);
                        OpenFileDialogEx.SetWindowPos(this.mOpenDialogHandle, IntPtr.Zero, (int) this.mOpenDialogWindowRect.left, (int) this.mOpenDialogWindowRect.top, this.mOriginalSize.Width, this.mOriginalSize.Height, this.UFLAGSSIZE);
                    }
                }
                else if (!this.mIsClosing)
                {
                    RECT rect;
                    if (!this.mInitializated)
                    {
                        WINDOWPOS structure = (WINDOWPOS) Marshal.PtrToStructure(m.LParam, typeof(WINDOWPOS));
                        if ((this.mSourceControl.StartLocation == AddonWindowLocation.Right) && ((structure.flags != 0) && ((structure.flags & 1) != 1)))
                        {
                            this.mOriginalSize = new Size(structure.cx, structure.cy);
                            int* numPtr1 = &structure.cx;
                            numPtr1[0] += this.mSourceControl.Width;
                            Marshal.StructureToPtr(structure, m.LParam, true);
                        }
                        if ((this.mSourceControl.StartLocation == AddonWindowLocation.Bottom) && ((structure.flags != 0) && ((structure.flags & 1) != 1)))
                        {
                            this.mOriginalSize = new Size(structure.cx, structure.cy);
                            int* numPtr2 = &structure.cy;
                            numPtr2[0] += this.mSourceControl.Height;
                            Marshal.StructureToPtr(structure, m.LParam, true);
                        }
                    }
                    switch (this.mSourceControl.StartLocation)
                    {
                        case AddonWindowLocation.None:
                            rect = new RECT();
                            OpenFileDialogEx.GetClientRect(this.mOpenDialogHandle, ref rect);
                            this.mSourceControl.Width = (int) rect.Width;
                            this.mSourceControl.Height = (int) rect.Height;
                            break;

                        case AddonWindowLocation.Right:
                            rect = new RECT();
                            OpenFileDialogEx.GetClientRect(this.mOpenDialogHandle, ref rect);
                            this.mSourceControl.Height = (int) rect.Height;
                            break;

                        case AddonWindowLocation.Bottom:
                            rect = new RECT();
                            OpenFileDialogEx.GetClientRect(this.mOpenDialogHandle, ref rect);
                            this.mSourceControl.Width = (int) rect.Width;
                            break;

                        default:
                            break;
                    }
                }
                base.WndProc(ref m);
            }

            public bool IsClosing
            {
                get => 
                    this.mIsClosing;
                set => 
                    this.mIsClosing = value;
            }
        }
    }
}

