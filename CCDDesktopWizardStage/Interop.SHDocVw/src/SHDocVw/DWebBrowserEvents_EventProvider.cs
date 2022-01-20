namespace SHDocVw
{
    using System;
    using System.Collections;
    using System.Runtime.InteropServices;
    using System.Threading;

    internal sealed class DWebBrowserEvents_EventProvider : DWebBrowserEvents_Event, IDisposable
    {
        private UCOMIConnectionPointContainer m_ConnectionPointContainer;
        private ArrayList m_aEventSinkHelpers;
        private UCOMIConnectionPoint m_ConnectionPoint;

        public DWebBrowserEvents_EventProvider(object obj1)
        {
            this.m_ConnectionPointContainer = (UCOMIConnectionPointContainer) obj1;
        }

        public override void add_BeforeNavigate(DWebBrowserEvents_BeforeNavigateEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents_SinkHelper helper = new DWebBrowserEvents_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_BeforeNavigateDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_CommandStateChange(DWebBrowserEvents_CommandStateChangeEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents_SinkHelper helper = new DWebBrowserEvents_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_CommandStateChangeDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_DownloadBegin(DWebBrowserEvents_DownloadBeginEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents_SinkHelper helper = new DWebBrowserEvents_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_DownloadBeginDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_DownloadComplete(DWebBrowserEvents_DownloadCompleteEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents_SinkHelper helper = new DWebBrowserEvents_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_DownloadCompleteDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_FrameBeforeNavigate(DWebBrowserEvents_FrameBeforeNavigateEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents_SinkHelper helper = new DWebBrowserEvents_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_FrameBeforeNavigateDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_FrameNavigateComplete(DWebBrowserEvents_FrameNavigateCompleteEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents_SinkHelper helper = new DWebBrowserEvents_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_FrameNavigateCompleteDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_FrameNewWindow(DWebBrowserEvents_FrameNewWindowEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents_SinkHelper helper = new DWebBrowserEvents_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_FrameNewWindowDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_NavigateComplete(DWebBrowserEvents_NavigateCompleteEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents_SinkHelper helper = new DWebBrowserEvents_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_NavigateCompleteDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_NewWindow(DWebBrowserEvents_NewWindowEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents_SinkHelper helper = new DWebBrowserEvents_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_NewWindowDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_ProgressChange(DWebBrowserEvents_ProgressChangeEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents_SinkHelper helper = new DWebBrowserEvents_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_ProgressChangeDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_PropertyChange(DWebBrowserEvents_PropertyChangeEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents_SinkHelper helper = new DWebBrowserEvents_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_PropertyChangeDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_Quit(DWebBrowserEvents_QuitEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents_SinkHelper helper = new DWebBrowserEvents_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_QuitDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_StatusTextChange(DWebBrowserEvents_StatusTextChangeEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents_SinkHelper helper = new DWebBrowserEvents_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_StatusTextChangeDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_TitleChange(DWebBrowserEvents_TitleChangeEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents_SinkHelper helper = new DWebBrowserEvents_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_TitleChangeDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_WindowActivate(DWebBrowserEvents_WindowActivateEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents_SinkHelper helper = new DWebBrowserEvents_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_WindowActivateDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_WindowMove(DWebBrowserEvents_WindowMoveEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents_SinkHelper helper = new DWebBrowserEvents_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_WindowMoveDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_WindowResize(DWebBrowserEvents_WindowResizeEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents_SinkHelper helper = new DWebBrowserEvents_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_WindowResizeDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void Dispose()
        {
            this.Finalize();
            GC.SuppressFinalize(this);
        }

        public override void Finalize()
        {
            Monitor.Enter(this);
            try
            {
                if (this.m_ConnectionPoint != null)
                {
                    int count = this.m_aEventSinkHelpers.Count;
                    int num2 = 0;
                    if (0 < count)
                    {
                        do
                        {
                            DWebBrowserEvents_SinkHelper helper = (DWebBrowserEvents_SinkHelper) this.m_aEventSinkHelpers[num2];
                            this.m_ConnectionPoint.Unadvise(helper.m_dwCookie);
                            num2++;
                        }
                        while (num2 < count);
                    }
                    Marshal.ReleaseComObject(this.m_ConnectionPoint);
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                Monitor.Exit(this);
            }
        }

        private void Init()
        {
            UCOMIConnectionPoint ppCP = null;
            Guid riid = new Guid(new byte[] { 0xc2, 0x2a, 0xb2, 0xea, 0xc1, 0x30, 0xcf, 0x11, 0xa7, 0xeb, 0, 0, 0xc0, 0x5b, 0xae, 11 });
            this.m_ConnectionPointContainer.FindConnectionPoint(ref riid, out ppCP);
            this.m_ConnectionPoint = ppCP;
            this.m_aEventSinkHelpers = new ArrayList();
        }

        public override void remove_BeforeNavigate(DWebBrowserEvents_BeforeNavigateEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents_SinkHelper helper = (DWebBrowserEvents_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_BeforeNavigateDelegate, null) || !(helper.m_BeforeNavigateDelegate.Equals((object) handler1) & 0xff))
                        {
                            index++;
                            if (index < count)
                            {
                                continue;
                            }
                        }
                        else
                        {
                            this.m_aEventSinkHelpers.RemoveAt(index);
                            this.m_ConnectionPoint.Unadvise(helper.m_dwCookie);
                            if (count <= 1)
                            {
                                Marshal.ReleaseComObject(this.m_ConnectionPoint);
                                this.m_ConnectionPoint = null;
                                this.m_aEventSinkHelpers = null;
                            }
                        }
                        break;
                    }
                }
            }
        }

        public override void remove_CommandStateChange(DWebBrowserEvents_CommandStateChangeEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents_SinkHelper helper = (DWebBrowserEvents_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_CommandStateChangeDelegate, null) || !(helper.m_CommandStateChangeDelegate.Equals((object) handler1) & 0xff))
                        {
                            index++;
                            if (index < count)
                            {
                                continue;
                            }
                        }
                        else
                        {
                            this.m_aEventSinkHelpers.RemoveAt(index);
                            this.m_ConnectionPoint.Unadvise(helper.m_dwCookie);
                            if (count <= 1)
                            {
                                Marshal.ReleaseComObject(this.m_ConnectionPoint);
                                this.m_ConnectionPoint = null;
                                this.m_aEventSinkHelpers = null;
                            }
                        }
                        break;
                    }
                }
            }
        }

        public override void remove_DownloadBegin(DWebBrowserEvents_DownloadBeginEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents_SinkHelper helper = (DWebBrowserEvents_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_DownloadBeginDelegate, null) || !(helper.m_DownloadBeginDelegate.Equals((object) handler1) & 0xff))
                        {
                            index++;
                            if (index < count)
                            {
                                continue;
                            }
                        }
                        else
                        {
                            this.m_aEventSinkHelpers.RemoveAt(index);
                            this.m_ConnectionPoint.Unadvise(helper.m_dwCookie);
                            if (count <= 1)
                            {
                                Marshal.ReleaseComObject(this.m_ConnectionPoint);
                                this.m_ConnectionPoint = null;
                                this.m_aEventSinkHelpers = null;
                            }
                        }
                        break;
                    }
                }
            }
        }

        public override void remove_DownloadComplete(DWebBrowserEvents_DownloadCompleteEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents_SinkHelper helper = (DWebBrowserEvents_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_DownloadCompleteDelegate, null) || !(helper.m_DownloadCompleteDelegate.Equals((object) handler1) & 0xff))
                        {
                            index++;
                            if (index < count)
                            {
                                continue;
                            }
                        }
                        else
                        {
                            this.m_aEventSinkHelpers.RemoveAt(index);
                            this.m_ConnectionPoint.Unadvise(helper.m_dwCookie);
                            if (count <= 1)
                            {
                                Marshal.ReleaseComObject(this.m_ConnectionPoint);
                                this.m_ConnectionPoint = null;
                                this.m_aEventSinkHelpers = null;
                            }
                        }
                        break;
                    }
                }
            }
        }

        public override void remove_FrameBeforeNavigate(DWebBrowserEvents_FrameBeforeNavigateEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents_SinkHelper helper = (DWebBrowserEvents_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_FrameBeforeNavigateDelegate, null) || !(helper.m_FrameBeforeNavigateDelegate.Equals((object) handler1) & 0xff))
                        {
                            index++;
                            if (index < count)
                            {
                                continue;
                            }
                        }
                        else
                        {
                            this.m_aEventSinkHelpers.RemoveAt(index);
                            this.m_ConnectionPoint.Unadvise(helper.m_dwCookie);
                            if (count <= 1)
                            {
                                Marshal.ReleaseComObject(this.m_ConnectionPoint);
                                this.m_ConnectionPoint = null;
                                this.m_aEventSinkHelpers = null;
                            }
                        }
                        break;
                    }
                }
            }
        }

        public override void remove_FrameNavigateComplete(DWebBrowserEvents_FrameNavigateCompleteEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents_SinkHelper helper = (DWebBrowserEvents_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_FrameNavigateCompleteDelegate, null) || !(helper.m_FrameNavigateCompleteDelegate.Equals((object) handler1) & 0xff))
                        {
                            index++;
                            if (index < count)
                            {
                                continue;
                            }
                        }
                        else
                        {
                            this.m_aEventSinkHelpers.RemoveAt(index);
                            this.m_ConnectionPoint.Unadvise(helper.m_dwCookie);
                            if (count <= 1)
                            {
                                Marshal.ReleaseComObject(this.m_ConnectionPoint);
                                this.m_ConnectionPoint = null;
                                this.m_aEventSinkHelpers = null;
                            }
                        }
                        break;
                    }
                }
            }
        }

        public override void remove_FrameNewWindow(DWebBrowserEvents_FrameNewWindowEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents_SinkHelper helper = (DWebBrowserEvents_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_FrameNewWindowDelegate, null) || !(helper.m_FrameNewWindowDelegate.Equals((object) handler1) & 0xff))
                        {
                            index++;
                            if (index < count)
                            {
                                continue;
                            }
                        }
                        else
                        {
                            this.m_aEventSinkHelpers.RemoveAt(index);
                            this.m_ConnectionPoint.Unadvise(helper.m_dwCookie);
                            if (count <= 1)
                            {
                                Marshal.ReleaseComObject(this.m_ConnectionPoint);
                                this.m_ConnectionPoint = null;
                                this.m_aEventSinkHelpers = null;
                            }
                        }
                        break;
                    }
                }
            }
        }

        public override void remove_NavigateComplete(DWebBrowserEvents_NavigateCompleteEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents_SinkHelper helper = (DWebBrowserEvents_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_NavigateCompleteDelegate, null) || !(helper.m_NavigateCompleteDelegate.Equals((object) handler1) & 0xff))
                        {
                            index++;
                            if (index < count)
                            {
                                continue;
                            }
                        }
                        else
                        {
                            this.m_aEventSinkHelpers.RemoveAt(index);
                            this.m_ConnectionPoint.Unadvise(helper.m_dwCookie);
                            if (count <= 1)
                            {
                                Marshal.ReleaseComObject(this.m_ConnectionPoint);
                                this.m_ConnectionPoint = null;
                                this.m_aEventSinkHelpers = null;
                            }
                        }
                        break;
                    }
                }
            }
        }

        public override void remove_NewWindow(DWebBrowserEvents_NewWindowEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents_SinkHelper helper = (DWebBrowserEvents_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_NewWindowDelegate, null) || !(helper.m_NewWindowDelegate.Equals((object) handler1) & 0xff))
                        {
                            index++;
                            if (index < count)
                            {
                                continue;
                            }
                        }
                        else
                        {
                            this.m_aEventSinkHelpers.RemoveAt(index);
                            this.m_ConnectionPoint.Unadvise(helper.m_dwCookie);
                            if (count <= 1)
                            {
                                Marshal.ReleaseComObject(this.m_ConnectionPoint);
                                this.m_ConnectionPoint = null;
                                this.m_aEventSinkHelpers = null;
                            }
                        }
                        break;
                    }
                }
            }
        }

        public override void remove_ProgressChange(DWebBrowserEvents_ProgressChangeEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents_SinkHelper helper = (DWebBrowserEvents_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_ProgressChangeDelegate, null) || !(helper.m_ProgressChangeDelegate.Equals((object) handler1) & 0xff))
                        {
                            index++;
                            if (index < count)
                            {
                                continue;
                            }
                        }
                        else
                        {
                            this.m_aEventSinkHelpers.RemoveAt(index);
                            this.m_ConnectionPoint.Unadvise(helper.m_dwCookie);
                            if (count <= 1)
                            {
                                Marshal.ReleaseComObject(this.m_ConnectionPoint);
                                this.m_ConnectionPoint = null;
                                this.m_aEventSinkHelpers = null;
                            }
                        }
                        break;
                    }
                }
            }
        }

        public override void remove_PropertyChange(DWebBrowserEvents_PropertyChangeEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents_SinkHelper helper = (DWebBrowserEvents_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_PropertyChangeDelegate, null) || !(helper.m_PropertyChangeDelegate.Equals((object) handler1) & 0xff))
                        {
                            index++;
                            if (index < count)
                            {
                                continue;
                            }
                        }
                        else
                        {
                            this.m_aEventSinkHelpers.RemoveAt(index);
                            this.m_ConnectionPoint.Unadvise(helper.m_dwCookie);
                            if (count <= 1)
                            {
                                Marshal.ReleaseComObject(this.m_ConnectionPoint);
                                this.m_ConnectionPoint = null;
                                this.m_aEventSinkHelpers = null;
                            }
                        }
                        break;
                    }
                }
            }
        }

        public override void remove_Quit(DWebBrowserEvents_QuitEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents_SinkHelper helper = (DWebBrowserEvents_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_QuitDelegate, null) || !(helper.m_QuitDelegate.Equals((object) handler1) & 0xff))
                        {
                            index++;
                            if (index < count)
                            {
                                continue;
                            }
                        }
                        else
                        {
                            this.m_aEventSinkHelpers.RemoveAt(index);
                            this.m_ConnectionPoint.Unadvise(helper.m_dwCookie);
                            if (count <= 1)
                            {
                                Marshal.ReleaseComObject(this.m_ConnectionPoint);
                                this.m_ConnectionPoint = null;
                                this.m_aEventSinkHelpers = null;
                            }
                        }
                        break;
                    }
                }
            }
        }

        public override void remove_StatusTextChange(DWebBrowserEvents_StatusTextChangeEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents_SinkHelper helper = (DWebBrowserEvents_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_StatusTextChangeDelegate, null) || !(helper.m_StatusTextChangeDelegate.Equals((object) handler1) & 0xff))
                        {
                            index++;
                            if (index < count)
                            {
                                continue;
                            }
                        }
                        else
                        {
                            this.m_aEventSinkHelpers.RemoveAt(index);
                            this.m_ConnectionPoint.Unadvise(helper.m_dwCookie);
                            if (count <= 1)
                            {
                                Marshal.ReleaseComObject(this.m_ConnectionPoint);
                                this.m_ConnectionPoint = null;
                                this.m_aEventSinkHelpers = null;
                            }
                        }
                        break;
                    }
                }
            }
        }

        public override void remove_TitleChange(DWebBrowserEvents_TitleChangeEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents_SinkHelper helper = (DWebBrowserEvents_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_TitleChangeDelegate, null) || !(helper.m_TitleChangeDelegate.Equals((object) handler1) & 0xff))
                        {
                            index++;
                            if (index < count)
                            {
                                continue;
                            }
                        }
                        else
                        {
                            this.m_aEventSinkHelpers.RemoveAt(index);
                            this.m_ConnectionPoint.Unadvise(helper.m_dwCookie);
                            if (count <= 1)
                            {
                                Marshal.ReleaseComObject(this.m_ConnectionPoint);
                                this.m_ConnectionPoint = null;
                                this.m_aEventSinkHelpers = null;
                            }
                        }
                        break;
                    }
                }
            }
        }

        public override void remove_WindowActivate(DWebBrowserEvents_WindowActivateEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents_SinkHelper helper = (DWebBrowserEvents_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_WindowActivateDelegate, null) || !(helper.m_WindowActivateDelegate.Equals((object) handler1) & 0xff))
                        {
                            index++;
                            if (index < count)
                            {
                                continue;
                            }
                        }
                        else
                        {
                            this.m_aEventSinkHelpers.RemoveAt(index);
                            this.m_ConnectionPoint.Unadvise(helper.m_dwCookie);
                            if (count <= 1)
                            {
                                Marshal.ReleaseComObject(this.m_ConnectionPoint);
                                this.m_ConnectionPoint = null;
                                this.m_aEventSinkHelpers = null;
                            }
                        }
                        break;
                    }
                }
            }
        }

        public override void remove_WindowMove(DWebBrowserEvents_WindowMoveEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents_SinkHelper helper = (DWebBrowserEvents_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_WindowMoveDelegate, null) || !(helper.m_WindowMoveDelegate.Equals((object) handler1) & 0xff))
                        {
                            index++;
                            if (index < count)
                            {
                                continue;
                            }
                        }
                        else
                        {
                            this.m_aEventSinkHelpers.RemoveAt(index);
                            this.m_ConnectionPoint.Unadvise(helper.m_dwCookie);
                            if (count <= 1)
                            {
                                Marshal.ReleaseComObject(this.m_ConnectionPoint);
                                this.m_ConnectionPoint = null;
                                this.m_aEventSinkHelpers = null;
                            }
                        }
                        break;
                    }
                }
            }
        }

        public override void remove_WindowResize(DWebBrowserEvents_WindowResizeEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents_SinkHelper helper = (DWebBrowserEvents_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_WindowResizeDelegate, null) || !(helper.m_WindowResizeDelegate.Equals((object) handler1) & 0xff))
                        {
                            index++;
                            if (index < count)
                            {
                                continue;
                            }
                        }
                        else
                        {
                            this.m_aEventSinkHelpers.RemoveAt(index);
                            this.m_ConnectionPoint.Unadvise(helper.m_dwCookie);
                            if (count <= 1)
                            {
                                Marshal.ReleaseComObject(this.m_ConnectionPoint);
                                this.m_ConnectionPoint = null;
                                this.m_aEventSinkHelpers = null;
                            }
                        }
                        break;
                    }
                }
            }
        }
    }
}

