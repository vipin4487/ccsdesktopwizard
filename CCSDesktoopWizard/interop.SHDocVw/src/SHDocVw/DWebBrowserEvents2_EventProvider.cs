namespace SHDocVw
{
    using System;
    using System.Collections;
    using System.Runtime.InteropServices;
    using System.Threading;

    internal sealed class DWebBrowserEvents2_EventProvider : DWebBrowserEvents2_Event, IDisposable
    {
        private UCOMIConnectionPointContainer m_ConnectionPointContainer;
        private ArrayList m_aEventSinkHelpers;
        private UCOMIConnectionPoint m_ConnectionPoint;

        public DWebBrowserEvents2_EventProvider(object obj1)
        {
            this.m_ConnectionPointContainer = (UCOMIConnectionPointContainer) obj1;
        }

        public override void add_BeforeNavigate2(DWebBrowserEvents2_BeforeNavigate2EventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents2_SinkHelper helper = new DWebBrowserEvents2_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_BeforeNavigate2Delegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_ClientToHostWindow(DWebBrowserEvents2_ClientToHostWindowEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents2_SinkHelper helper = new DWebBrowserEvents2_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_ClientToHostWindowDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_CommandStateChange(DWebBrowserEvents2_CommandStateChangeEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents2_SinkHelper helper = new DWebBrowserEvents2_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_CommandStateChangeDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_DocumentComplete(DWebBrowserEvents2_DocumentCompleteEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents2_SinkHelper helper = new DWebBrowserEvents2_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_DocumentCompleteDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_DownloadBegin(DWebBrowserEvents2_DownloadBeginEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents2_SinkHelper helper = new DWebBrowserEvents2_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_DownloadBeginDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_DownloadComplete(DWebBrowserEvents2_DownloadCompleteEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents2_SinkHelper helper = new DWebBrowserEvents2_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_DownloadCompleteDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_FileDownload(DWebBrowserEvents2_FileDownloadEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents2_SinkHelper helper = new DWebBrowserEvents2_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_FileDownloadDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_NavigateComplete2(DWebBrowserEvents2_NavigateComplete2EventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents2_SinkHelper helper = new DWebBrowserEvents2_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_NavigateComplete2Delegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_NavigateError(DWebBrowserEvents2_NavigateErrorEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents2_SinkHelper helper = new DWebBrowserEvents2_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_NavigateErrorDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_NewWindow2(DWebBrowserEvents2_NewWindow2EventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents2_SinkHelper helper = new DWebBrowserEvents2_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_NewWindow2Delegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_NewWindow3(DWebBrowserEvents2_NewWindow3EventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents2_SinkHelper helper = new DWebBrowserEvents2_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_NewWindow3Delegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_OnFullScreen(DWebBrowserEvents2_OnFullScreenEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents2_SinkHelper helper = new DWebBrowserEvents2_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_OnFullScreenDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_OnMenuBar(DWebBrowserEvents2_OnMenuBarEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents2_SinkHelper helper = new DWebBrowserEvents2_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_OnMenuBarDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_OnQuit(DWebBrowserEvents2_OnQuitEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents2_SinkHelper helper = new DWebBrowserEvents2_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_OnQuitDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_OnStatusBar(DWebBrowserEvents2_OnStatusBarEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents2_SinkHelper helper = new DWebBrowserEvents2_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_OnStatusBarDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_OnTheaterMode(DWebBrowserEvents2_OnTheaterModeEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents2_SinkHelper helper = new DWebBrowserEvents2_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_OnTheaterModeDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_OnToolBar(DWebBrowserEvents2_OnToolBarEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents2_SinkHelper helper = new DWebBrowserEvents2_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_OnToolBarDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_OnVisible(DWebBrowserEvents2_OnVisibleEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents2_SinkHelper helper = new DWebBrowserEvents2_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_OnVisibleDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_PrintTemplateInstantiation(DWebBrowserEvents2_PrintTemplateInstantiationEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents2_SinkHelper helper = new DWebBrowserEvents2_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_PrintTemplateInstantiationDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_PrintTemplateTeardown(DWebBrowserEvents2_PrintTemplateTeardownEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents2_SinkHelper helper = new DWebBrowserEvents2_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_PrintTemplateTeardownDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_PrivacyImpactedStateChange(DWebBrowserEvents2_PrivacyImpactedStateChangeEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents2_SinkHelper helper = new DWebBrowserEvents2_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_PrivacyImpactedStateChangeDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_ProgressChange(DWebBrowserEvents2_ProgressChangeEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents2_SinkHelper helper = new DWebBrowserEvents2_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_ProgressChangeDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_PropertyChange(DWebBrowserEvents2_PropertyChangeEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents2_SinkHelper helper = new DWebBrowserEvents2_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_PropertyChangeDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_SetSecureLockIcon(DWebBrowserEvents2_SetSecureLockIconEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents2_SinkHelper helper = new DWebBrowserEvents2_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_SetSecureLockIconDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_StatusTextChange(DWebBrowserEvents2_StatusTextChangeEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents2_SinkHelper helper = new DWebBrowserEvents2_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_StatusTextChangeDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_TitleChange(DWebBrowserEvents2_TitleChangeEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents2_SinkHelper helper = new DWebBrowserEvents2_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_TitleChangeDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_UpdatePageStatus(DWebBrowserEvents2_UpdatePageStatusEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents2_SinkHelper helper = new DWebBrowserEvents2_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_UpdatePageStatusDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_WindowClosing(DWebBrowserEvents2_WindowClosingEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents2_SinkHelper helper = new DWebBrowserEvents2_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_WindowClosingDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_WindowSetHeight(DWebBrowserEvents2_WindowSetHeightEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents2_SinkHelper helper = new DWebBrowserEvents2_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_WindowSetHeightDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_WindowSetLeft(DWebBrowserEvents2_WindowSetLeftEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents2_SinkHelper helper = new DWebBrowserEvents2_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_WindowSetLeftDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_WindowSetResizable(DWebBrowserEvents2_WindowSetResizableEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents2_SinkHelper helper = new DWebBrowserEvents2_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_WindowSetResizableDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_WindowSetTop(DWebBrowserEvents2_WindowSetTopEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents2_SinkHelper helper = new DWebBrowserEvents2_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_WindowSetTopDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_WindowSetWidth(DWebBrowserEvents2_WindowSetWidthEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DWebBrowserEvents2_SinkHelper helper = new DWebBrowserEvents2_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_WindowSetWidthDelegate = handler1;
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
                            DWebBrowserEvents2_SinkHelper helper = (DWebBrowserEvents2_SinkHelper) this.m_aEventSinkHelpers[num2];
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
            Guid riid = new Guid(new byte[] { 160, 0x15, 0xa7, 0x34, 0x87, 0x65, 0xd0, 0x11, 0x92, 0x4a, 0, 0x20, 0xaf, 0xc7, 0xac, 0x4d });
            this.m_ConnectionPointContainer.FindConnectionPoint(ref riid, out ppCP);
            this.m_ConnectionPoint = ppCP;
            this.m_aEventSinkHelpers = new ArrayList();
        }

        public override void remove_BeforeNavigate2(DWebBrowserEvents2_BeforeNavigate2EventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents2_SinkHelper helper = (DWebBrowserEvents2_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_BeforeNavigate2Delegate, null) || !(helper.m_BeforeNavigate2Delegate.Equals((object) handler1) & 0xff))
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

        public override void remove_ClientToHostWindow(DWebBrowserEvents2_ClientToHostWindowEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents2_SinkHelper helper = (DWebBrowserEvents2_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_ClientToHostWindowDelegate, null) || !(helper.m_ClientToHostWindowDelegate.Equals((object) handler1) & 0xff))
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

        public override void remove_CommandStateChange(DWebBrowserEvents2_CommandStateChangeEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents2_SinkHelper helper = (DWebBrowserEvents2_SinkHelper) this.m_aEventSinkHelpers[index];
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

        public override void remove_DocumentComplete(DWebBrowserEvents2_DocumentCompleteEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents2_SinkHelper helper = (DWebBrowserEvents2_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_DocumentCompleteDelegate, null) || !(helper.m_DocumentCompleteDelegate.Equals((object) handler1) & 0xff))
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

        public override void remove_DownloadBegin(DWebBrowserEvents2_DownloadBeginEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents2_SinkHelper helper = (DWebBrowserEvents2_SinkHelper) this.m_aEventSinkHelpers[index];
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

        public override void remove_DownloadComplete(DWebBrowserEvents2_DownloadCompleteEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents2_SinkHelper helper = (DWebBrowserEvents2_SinkHelper) this.m_aEventSinkHelpers[index];
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

        public override void remove_FileDownload(DWebBrowserEvents2_FileDownloadEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents2_SinkHelper helper = (DWebBrowserEvents2_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_FileDownloadDelegate, null) || !(helper.m_FileDownloadDelegate.Equals((object) handler1) & 0xff))
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

        public override void remove_NavigateComplete2(DWebBrowserEvents2_NavigateComplete2EventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents2_SinkHelper helper = (DWebBrowserEvents2_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_NavigateComplete2Delegate, null) || !(helper.m_NavigateComplete2Delegate.Equals((object) handler1) & 0xff))
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

        public override void remove_NavigateError(DWebBrowserEvents2_NavigateErrorEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents2_SinkHelper helper = (DWebBrowserEvents2_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_NavigateErrorDelegate, null) || !(helper.m_NavigateErrorDelegate.Equals((object) handler1) & 0xff))
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

        public override void remove_NewWindow2(DWebBrowserEvents2_NewWindow2EventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents2_SinkHelper helper = (DWebBrowserEvents2_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_NewWindow2Delegate, null) || !(helper.m_NewWindow2Delegate.Equals((object) handler1) & 0xff))
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

        public override void remove_NewWindow3(DWebBrowserEvents2_NewWindow3EventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents2_SinkHelper helper = (DWebBrowserEvents2_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_NewWindow3Delegate, null) || !(helper.m_NewWindow3Delegate.Equals((object) handler1) & 0xff))
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

        public override void remove_OnFullScreen(DWebBrowserEvents2_OnFullScreenEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents2_SinkHelper helper = (DWebBrowserEvents2_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_OnFullScreenDelegate, null) || !(helper.m_OnFullScreenDelegate.Equals((object) handler1) & 0xff))
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

        public override void remove_OnMenuBar(DWebBrowserEvents2_OnMenuBarEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents2_SinkHelper helper = (DWebBrowserEvents2_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_OnMenuBarDelegate, null) || !(helper.m_OnMenuBarDelegate.Equals((object) handler1) & 0xff))
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

        public override void remove_OnQuit(DWebBrowserEvents2_OnQuitEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents2_SinkHelper helper = (DWebBrowserEvents2_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_OnQuitDelegate, null) || !(helper.m_OnQuitDelegate.Equals((object) handler1) & 0xff))
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

        public override void remove_OnStatusBar(DWebBrowserEvents2_OnStatusBarEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents2_SinkHelper helper = (DWebBrowserEvents2_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_OnStatusBarDelegate, null) || !(helper.m_OnStatusBarDelegate.Equals((object) handler1) & 0xff))
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

        public override void remove_OnTheaterMode(DWebBrowserEvents2_OnTheaterModeEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents2_SinkHelper helper = (DWebBrowserEvents2_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_OnTheaterModeDelegate, null) || !(helper.m_OnTheaterModeDelegate.Equals((object) handler1) & 0xff))
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

        public override void remove_OnToolBar(DWebBrowserEvents2_OnToolBarEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents2_SinkHelper helper = (DWebBrowserEvents2_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_OnToolBarDelegate, null) || !(helper.m_OnToolBarDelegate.Equals((object) handler1) & 0xff))
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

        public override void remove_OnVisible(DWebBrowserEvents2_OnVisibleEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents2_SinkHelper helper = (DWebBrowserEvents2_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_OnVisibleDelegate, null) || !(helper.m_OnVisibleDelegate.Equals((object) handler1) & 0xff))
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

        public override void remove_PrintTemplateInstantiation(DWebBrowserEvents2_PrintTemplateInstantiationEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents2_SinkHelper helper = (DWebBrowserEvents2_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_PrintTemplateInstantiationDelegate, null) || !(helper.m_PrintTemplateInstantiationDelegate.Equals((object) handler1) & 0xff))
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

        public override void remove_PrintTemplateTeardown(DWebBrowserEvents2_PrintTemplateTeardownEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents2_SinkHelper helper = (DWebBrowserEvents2_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_PrintTemplateTeardownDelegate, null) || !(helper.m_PrintTemplateTeardownDelegate.Equals((object) handler1) & 0xff))
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

        public override void remove_PrivacyImpactedStateChange(DWebBrowserEvents2_PrivacyImpactedStateChangeEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents2_SinkHelper helper = (DWebBrowserEvents2_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_PrivacyImpactedStateChangeDelegate, null) || !(helper.m_PrivacyImpactedStateChangeDelegate.Equals((object) handler1) & 0xff))
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

        public override void remove_ProgressChange(DWebBrowserEvents2_ProgressChangeEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents2_SinkHelper helper = (DWebBrowserEvents2_SinkHelper) this.m_aEventSinkHelpers[index];
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

        public override void remove_PropertyChange(DWebBrowserEvents2_PropertyChangeEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents2_SinkHelper helper = (DWebBrowserEvents2_SinkHelper) this.m_aEventSinkHelpers[index];
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

        public override void remove_SetSecureLockIcon(DWebBrowserEvents2_SetSecureLockIconEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents2_SinkHelper helper = (DWebBrowserEvents2_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_SetSecureLockIconDelegate, null) || !(helper.m_SetSecureLockIconDelegate.Equals((object) handler1) & 0xff))
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

        public override void remove_StatusTextChange(DWebBrowserEvents2_StatusTextChangeEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents2_SinkHelper helper = (DWebBrowserEvents2_SinkHelper) this.m_aEventSinkHelpers[index];
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

        public override void remove_TitleChange(DWebBrowserEvents2_TitleChangeEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents2_SinkHelper helper = (DWebBrowserEvents2_SinkHelper) this.m_aEventSinkHelpers[index];
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

        public override void remove_UpdatePageStatus(DWebBrowserEvents2_UpdatePageStatusEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents2_SinkHelper helper = (DWebBrowserEvents2_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_UpdatePageStatusDelegate, null) || !(helper.m_UpdatePageStatusDelegate.Equals((object) handler1) & 0xff))
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

        public override void remove_WindowClosing(DWebBrowserEvents2_WindowClosingEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents2_SinkHelper helper = (DWebBrowserEvents2_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_WindowClosingDelegate, null) || !(helper.m_WindowClosingDelegate.Equals((object) handler1) & 0xff))
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

        public override void remove_WindowSetHeight(DWebBrowserEvents2_WindowSetHeightEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents2_SinkHelper helper = (DWebBrowserEvents2_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_WindowSetHeightDelegate, null) || !(helper.m_WindowSetHeightDelegate.Equals((object) handler1) & 0xff))
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

        public override void remove_WindowSetLeft(DWebBrowserEvents2_WindowSetLeftEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents2_SinkHelper helper = (DWebBrowserEvents2_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_WindowSetLeftDelegate, null) || !(helper.m_WindowSetLeftDelegate.Equals((object) handler1) & 0xff))
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

        public override void remove_WindowSetResizable(DWebBrowserEvents2_WindowSetResizableEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents2_SinkHelper helper = (DWebBrowserEvents2_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_WindowSetResizableDelegate, null) || !(helper.m_WindowSetResizableDelegate.Equals((object) handler1) & 0xff))
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

        public override void remove_WindowSetTop(DWebBrowserEvents2_WindowSetTopEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents2_SinkHelper helper = (DWebBrowserEvents2_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_WindowSetTopDelegate, null) || !(helper.m_WindowSetTopDelegate.Equals((object) handler1) & 0xff))
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

        public override void remove_WindowSetWidth(DWebBrowserEvents2_WindowSetWidthEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DWebBrowserEvents2_SinkHelper helper = (DWebBrowserEvents2_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_WindowSetWidthDelegate, null) || !(helper.m_WindowSetWidthDelegate.Equals((object) handler1) & 0xff))
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

