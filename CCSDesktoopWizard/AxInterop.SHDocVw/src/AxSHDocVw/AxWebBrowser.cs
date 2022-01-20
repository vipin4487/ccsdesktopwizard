namespace AxSHDocVw
{
    using SHDocVw;
    using System;
    using System.ComponentModel;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    [DefaultProperty("Name"), Clsid("{8856f961-340a-11d0-a96b-00c04fd705a2}"), DesignTimeVisible(true)]
    public class AxWebBrowser : AxHost
    {
        private SHDocVw.IWebBrowser2 ocx;
        private AxWebBrowserEventMulticaster eventMulticaster;
        private AxHost.ConnectionPointCookie cookie;
        private AxSHDocVw.DWebBrowserEvents2_NewWindow3EventHandler NewWindow3;
        private AxSHDocVw.DWebBrowserEvents2_PrivacyImpactedStateChangeEventHandler PrivacyImpactedStateChange;
        private AxSHDocVw.DWebBrowserEvents2_UpdatePageStatusEventHandler UpdatePageStatus;
        private AxSHDocVw.DWebBrowserEvents2_PrintTemplateTeardownEventHandler PrintTemplateTeardown;
        private AxSHDocVw.DWebBrowserEvents2_PrintTemplateInstantiationEventHandler PrintTemplateInstantiation;
        private AxSHDocVw.DWebBrowserEvents2_NavigateErrorEventHandler NavigateError;
        private AxSHDocVw.DWebBrowserEvents2_FileDownloadEventHandler FileDownload;
        private AxSHDocVw.DWebBrowserEvents2_SetSecureLockIconEventHandler SetSecureLockIcon;
        private AxSHDocVw.DWebBrowserEvents2_ClientToHostWindowEventHandler ClientToHostWindow;
        private AxSHDocVw.DWebBrowserEvents2_WindowClosingEventHandler WindowClosing;
        private AxSHDocVw.DWebBrowserEvents2_WindowSetHeightEventHandler WindowSetHeight;
        private AxSHDocVw.DWebBrowserEvents2_WindowSetWidthEventHandler WindowSetWidth;
        private AxSHDocVw.DWebBrowserEvents2_WindowSetTopEventHandler WindowSetTop;
        private AxSHDocVw.DWebBrowserEvents2_WindowSetLeftEventHandler WindowSetLeft;
        private AxSHDocVw.DWebBrowserEvents2_WindowSetResizableEventHandler WindowSetResizable;
        private AxSHDocVw.DWebBrowserEvents2_OnTheaterModeEventHandler OnTheaterMode;
        private AxSHDocVw.DWebBrowserEvents2_OnFullScreenEventHandler OnFullScreen;
        private AxSHDocVw.DWebBrowserEvents2_OnStatusBarEventHandler OnStatusBar;
        private AxSHDocVw.DWebBrowserEvents2_OnMenuBarEventHandler OnMenuBar;
        private AxSHDocVw.DWebBrowserEvents2_OnToolBarEventHandler OnToolBar;
        private AxSHDocVw.DWebBrowserEvents2_OnVisibleEventHandler OnVisible;
        private EventHandler OnQuit;
        private AxSHDocVw.DWebBrowserEvents2_DocumentCompleteEventHandler DocumentComplete;
        private AxSHDocVw.DWebBrowserEvents2_NavigateComplete2EventHandler NavigateComplete2;
        private AxSHDocVw.DWebBrowserEvents2_NewWindow2EventHandler NewWindow2;
        private AxSHDocVw.DWebBrowserEvents2_BeforeNavigate2EventHandler BeforeNavigate2;
        private AxSHDocVw.DWebBrowserEvents2_PropertyChangeEventHandler PropertyChange;
        private AxSHDocVw.DWebBrowserEvents2_TitleChangeEventHandler TitleChange;
        private EventHandler DownloadComplete;
        private EventHandler DownloadBegin;
        private AxSHDocVw.DWebBrowserEvents2_CommandStateChangeEventHandler CommandStateChange;
        private AxSHDocVw.DWebBrowserEvents2_ProgressChangeEventHandler ProgressChange;
        private AxSHDocVw.DWebBrowserEvents2_StatusTextChangeEventHandler StatusTextChange;

        public event AxSHDocVw.DWebBrowserEvents2_BeforeNavigate2EventHandler BeforeNavigate2
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.BeforeNavigate2 += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.BeforeNavigate2 -= value;
            }
        }

        public event AxSHDocVw.DWebBrowserEvents2_ClientToHostWindowEventHandler ClientToHostWindow
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.ClientToHostWindow += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.ClientToHostWindow -= value;
            }
        }

        public event AxSHDocVw.DWebBrowserEvents2_CommandStateChangeEventHandler CommandStateChange
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.CommandStateChange += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.CommandStateChange -= value;
            }
        }

        public event AxSHDocVw.DWebBrowserEvents2_DocumentCompleteEventHandler DocumentComplete
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.DocumentComplete += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.DocumentComplete -= value;
            }
        }

        public event EventHandler DownloadBegin
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.DownloadBegin += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.DownloadBegin -= value;
            }
        }

        public event EventHandler DownloadComplete
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.DownloadComplete += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.DownloadComplete -= value;
            }
        }

        public event AxSHDocVw.DWebBrowserEvents2_FileDownloadEventHandler FileDownload
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.FileDownload += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.FileDownload -= value;
            }
        }

        public event AxSHDocVw.DWebBrowserEvents2_NavigateComplete2EventHandler NavigateComplete2
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.NavigateComplete2 += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.NavigateComplete2 -= value;
            }
        }

        public event AxSHDocVw.DWebBrowserEvents2_NavigateErrorEventHandler NavigateError
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.NavigateError += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.NavigateError -= value;
            }
        }

        public event AxSHDocVw.DWebBrowserEvents2_NewWindow2EventHandler NewWindow2
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.NewWindow2 += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.NewWindow2 -= value;
            }
        }

        public event AxSHDocVw.DWebBrowserEvents2_NewWindow3EventHandler NewWindow3
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.NewWindow3 += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.NewWindow3 -= value;
            }
        }

        public event AxSHDocVw.DWebBrowserEvents2_OnFullScreenEventHandler OnFullScreen
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.OnFullScreen += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.OnFullScreen -= value;
            }
        }

        public event AxSHDocVw.DWebBrowserEvents2_OnMenuBarEventHandler OnMenuBar
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.OnMenuBar += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.OnMenuBar -= value;
            }
        }

        public event EventHandler OnQuit
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.OnQuit += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.OnQuit -= value;
            }
        }

        public event AxSHDocVw.DWebBrowserEvents2_OnStatusBarEventHandler OnStatusBar
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.OnStatusBar += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.OnStatusBar -= value;
            }
        }

        public event AxSHDocVw.DWebBrowserEvents2_OnTheaterModeEventHandler OnTheaterMode
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.OnTheaterMode += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.OnTheaterMode -= value;
            }
        }

        public event AxSHDocVw.DWebBrowserEvents2_OnToolBarEventHandler OnToolBar
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.OnToolBar += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.OnToolBar -= value;
            }
        }

        public event AxSHDocVw.DWebBrowserEvents2_OnVisibleEventHandler OnVisible
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.OnVisible += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.OnVisible -= value;
            }
        }

        public event AxSHDocVw.DWebBrowserEvents2_PrintTemplateInstantiationEventHandler PrintTemplateInstantiation
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.PrintTemplateInstantiation += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.PrintTemplateInstantiation -= value;
            }
        }

        public event AxSHDocVw.DWebBrowserEvents2_PrintTemplateTeardownEventHandler PrintTemplateTeardown
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.PrintTemplateTeardown += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.PrintTemplateTeardown -= value;
            }
        }

        public event AxSHDocVw.DWebBrowserEvents2_PrivacyImpactedStateChangeEventHandler PrivacyImpactedStateChange
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.PrivacyImpactedStateChange += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.PrivacyImpactedStateChange -= value;
            }
        }

        public event AxSHDocVw.DWebBrowserEvents2_ProgressChangeEventHandler ProgressChange
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.ProgressChange += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.ProgressChange -= value;
            }
        }

        public event AxSHDocVw.DWebBrowserEvents2_PropertyChangeEventHandler PropertyChange
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.PropertyChange += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.PropertyChange -= value;
            }
        }

        public event AxSHDocVw.DWebBrowserEvents2_SetSecureLockIconEventHandler SetSecureLockIcon
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.SetSecureLockIcon += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.SetSecureLockIcon -= value;
            }
        }

        public event AxSHDocVw.DWebBrowserEvents2_StatusTextChangeEventHandler StatusTextChange
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.StatusTextChange += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.StatusTextChange -= value;
            }
        }

        public event AxSHDocVw.DWebBrowserEvents2_TitleChangeEventHandler TitleChange
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.TitleChange += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.TitleChange -= value;
            }
        }

        public event AxSHDocVw.DWebBrowserEvents2_UpdatePageStatusEventHandler UpdatePageStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.UpdatePageStatus += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.UpdatePageStatus -= value;
            }
        }

        public event AxSHDocVw.DWebBrowserEvents2_WindowClosingEventHandler WindowClosing
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.WindowClosing += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.WindowClosing -= value;
            }
        }

        public event AxSHDocVw.DWebBrowserEvents2_WindowSetHeightEventHandler WindowSetHeight
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.WindowSetHeight += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.WindowSetHeight -= value;
            }
        }

        public event AxSHDocVw.DWebBrowserEvents2_WindowSetLeftEventHandler WindowSetLeft
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.WindowSetLeft += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.WindowSetLeft -= value;
            }
        }

        public event AxSHDocVw.DWebBrowserEvents2_WindowSetResizableEventHandler WindowSetResizable
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.WindowSetResizable += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.WindowSetResizable -= value;
            }
        }

        public event AxSHDocVw.DWebBrowserEvents2_WindowSetTopEventHandler WindowSetTop
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.WindowSetTop += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.WindowSetTop -= value;
            }
        }

        public event AxSHDocVw.DWebBrowserEvents2_WindowSetWidthEventHandler WindowSetWidth
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.WindowSetWidth += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.WindowSetWidth -= value;
            }
        }

        public AxWebBrowser() : base("8856f961-340a-11d0-a96b-00c04fd705a2")
        {
        }

        protected override void AttachInterfaces()
        {
            try
            {
                this.ocx = (SHDocVw.IWebBrowser2) base.GetOcx();
            }
            catch (Exception)
            {
            }
        }

        public virtual void ClientToWindow(ref int pcx, ref int pcy)
        {
            if (this.ocx == null)
            {
                throw new AxHost.InvalidActiveXStateException("ClientToWindow", AxHost.ActiveXInvokeKind.MethodInvoke);
            }
            this.ocx.ClientToWindow(ref pcx, ref pcy);
        }

        protected override void CreateSink()
        {
            try
            {
                this.eventMulticaster = new AxWebBrowserEventMulticaster(this);
                this.cookie = new AxHost.ConnectionPointCookie(this.ocx, this.eventMulticaster, typeof(SHDocVw.DWebBrowserEvents2));
            }
            catch (Exception)
            {
            }
        }

        public virtual void CtlRefresh()
        {
            if (this.ocx == null)
            {
                throw new AxHost.InvalidActiveXStateException("CtlRefresh", AxHost.ActiveXInvokeKind.MethodInvoke);
            }
            this.ocx.Refresh();
        }

        protected override void DetachSink()
        {
            try
            {
                this.cookie.Disconnect();
            }
            catch (Exception)
            {
            }
        }

        public virtual void ExecWB(SHDocVw.OLECMDID cmdID, SHDocVw.OLECMDEXECOPT cmdexecopt)
        {
            if (this.ocx == null)
            {
                throw new AxHost.InvalidActiveXStateException("ExecWB", AxHost.ActiveXInvokeKind.MethodInvoke);
            }
            object[] parameters = new object[] { cmdID, cmdexecopt, Missing.Value, Missing.Value };
            typeof(SHDocVw.IWebBrowser2).GetMethod("ExecWB").Invoke(this.ocx, parameters);
        }

        public virtual void ExecWB(SHDocVw.OLECMDID cmdID, SHDocVw.OLECMDEXECOPT cmdexecopt, ref object pvaIn, ref object pvaOut)
        {
            if (this.ocx == null)
            {
                throw new AxHost.InvalidActiveXStateException("ExecWB", AxHost.ActiveXInvokeKind.MethodInvoke);
            }
            this.ocx.ExecWB(cmdID, cmdexecopt, ref pvaIn, ref pvaOut);
        }

        public virtual object GetProperty(string property)
        {
            if (this.ocx == null)
            {
                throw new AxHost.InvalidActiveXStateException("GetProperty", AxHost.ActiveXInvokeKind.MethodInvoke);
            }
            return this.ocx.GetProperty(property);
        }

        public virtual void GoBack()
        {
            if (this.ocx == null)
            {
                throw new AxHost.InvalidActiveXStateException("GoBack", AxHost.ActiveXInvokeKind.MethodInvoke);
            }
            this.ocx.GoBack();
        }

        public virtual void GoForward()
        {
            if (this.ocx == null)
            {
                throw new AxHost.InvalidActiveXStateException("GoForward", AxHost.ActiveXInvokeKind.MethodInvoke);
            }
            this.ocx.GoForward();
        }

        public virtual void GoHome()
        {
            if (this.ocx == null)
            {
                throw new AxHost.InvalidActiveXStateException("GoHome", AxHost.ActiveXInvokeKind.MethodInvoke);
            }
            this.ocx.GoHome();
        }

        public virtual void GoSearch()
        {
            if (this.ocx == null)
            {
                throw new AxHost.InvalidActiveXStateException("GoSearch", AxHost.ActiveXInvokeKind.MethodInvoke);
            }
            this.ocx.GoSearch();
        }

        public virtual void Navigate(string uRL)
        {
            if (this.ocx == null)
            {
                throw new AxHost.InvalidActiveXStateException("Navigate", AxHost.ActiveXInvokeKind.MethodInvoke);
            }
            object[] parameters = new object[] { uRL, Missing.Value, Missing.Value, Missing.Value, Missing.Value };
            typeof(SHDocVw.IWebBrowser2).GetMethod("Navigate").Invoke(this.ocx, parameters);
        }

        public virtual void Navigate(string uRL, ref object flags, ref object targetFrameName, ref object postData, ref object headers)
        {
            if (this.ocx == null)
            {
                throw new AxHost.InvalidActiveXStateException("Navigate", AxHost.ActiveXInvokeKind.MethodInvoke);
            }
            this.ocx.Navigate(uRL, ref flags, ref targetFrameName, ref postData, ref headers);
        }

        public virtual void Navigate2(ref object uRL)
        {
            if (this.ocx == null)
            {
                throw new AxHost.InvalidActiveXStateException("Navigate2", AxHost.ActiveXInvokeKind.MethodInvoke);
            }
            object[] parameters = new object[] { uRL, Missing.Value, Missing.Value, Missing.Value, Missing.Value };
            typeof(SHDocVw.IWebBrowser2).GetMethod("Navigate2").Invoke(this.ocx, parameters);
            uRL = parameters[0];
        }

        public virtual void Navigate2(ref object uRL, ref object flags, ref object targetFrameName, ref object postData, ref object headers)
        {
            if (this.ocx == null)
            {
                throw new AxHost.InvalidActiveXStateException("Navigate2", AxHost.ActiveXInvokeKind.MethodInvoke);
            }
            this.ocx.Navigate2(ref uRL, ref flags, ref targetFrameName, ref postData, ref headers);
        }

        public virtual void PutProperty(string property, object vtValue)
        {
            if (this.ocx == null)
            {
                throw new AxHost.InvalidActiveXStateException("PutProperty", AxHost.ActiveXInvokeKind.MethodInvoke);
            }
            this.ocx.PutProperty(property, vtValue);
        }

        public virtual SHDocVw.OLECMDF QueryStatusWB(SHDocVw.OLECMDID cmdID)
        {
            if (this.ocx == null)
            {
                throw new AxHost.InvalidActiveXStateException("QueryStatusWB", AxHost.ActiveXInvokeKind.MethodInvoke);
            }
            return this.ocx.QueryStatusWB(cmdID);
        }

        public virtual void Quit()
        {
            if (this.ocx == null)
            {
                throw new AxHost.InvalidActiveXStateException("Quit", AxHost.ActiveXInvokeKind.MethodInvoke);
            }
            this.ocx.Quit();
        }

        internal void RaiseOnBeforeNavigate2(object sender, DWebBrowserEvents2_BeforeNavigate2Event e)
        {
            if (this.BeforeNavigate2 != null)
            {
                this.BeforeNavigate2(sender, e);
            }
        }

        internal void RaiseOnClientToHostWindow(object sender, DWebBrowserEvents2_ClientToHostWindowEvent e)
        {
            if (this.ClientToHostWindow != null)
            {
                this.ClientToHostWindow(sender, e);
            }
        }

        internal void RaiseOnCommandStateChange(object sender, DWebBrowserEvents2_CommandStateChangeEvent e)
        {
            if (this.CommandStateChange != null)
            {
                this.CommandStateChange(sender, e);
            }
        }

        internal void RaiseOnDocumentComplete(object sender, DWebBrowserEvents2_DocumentCompleteEvent e)
        {
            if (this.DocumentComplete != null)
            {
                this.DocumentComplete(sender, e);
            }
        }

        internal void RaiseOnDownloadBegin(object sender, EventArgs e)
        {
            if (this.DownloadBegin != null)
            {
                this.DownloadBegin(sender, e);
            }
        }

        internal void RaiseOnDownloadComplete(object sender, EventArgs e)
        {
            if (this.DownloadComplete != null)
            {
                this.DownloadComplete(sender, e);
            }
        }

        internal void RaiseOnFileDownload(object sender, DWebBrowserEvents2_FileDownloadEvent e)
        {
            if (this.FileDownload != null)
            {
                this.FileDownload(sender, e);
            }
        }

        internal void RaiseOnNavigateComplete2(object sender, DWebBrowserEvents2_NavigateComplete2Event e)
        {
            if (this.NavigateComplete2 != null)
            {
                this.NavigateComplete2(sender, e);
            }
        }

        internal void RaiseOnNavigateError(object sender, DWebBrowserEvents2_NavigateErrorEvent e)
        {
            if (this.NavigateError != null)
            {
                this.NavigateError(sender, e);
            }
        }

        internal void RaiseOnNewWindow2(object sender, DWebBrowserEvents2_NewWindow2Event e)
        {
            if (this.NewWindow2 != null)
            {
                this.NewWindow2(sender, e);
            }
        }

        internal void RaiseOnNewWindow3(object sender, DWebBrowserEvents2_NewWindow3Event e)
        {
            if (this.NewWindow3 != null)
            {
                this.NewWindow3(sender, e);
            }
        }

        internal void RaiseOnOnFullScreen(object sender, DWebBrowserEvents2_OnFullScreenEvent e)
        {
            if (this.OnFullScreen != null)
            {
                this.OnFullScreen(sender, e);
            }
        }

        internal void RaiseOnOnMenuBar(object sender, DWebBrowserEvents2_OnMenuBarEvent e)
        {
            if (this.OnMenuBar != null)
            {
                this.OnMenuBar(sender, e);
            }
        }

        internal void RaiseOnOnQuit(object sender, EventArgs e)
        {
            if (this.OnQuit != null)
            {
                this.OnQuit(sender, e);
            }
        }

        internal void RaiseOnOnStatusBar(object sender, DWebBrowserEvents2_OnStatusBarEvent e)
        {
            if (this.OnStatusBar != null)
            {
                this.OnStatusBar(sender, e);
            }
        }

        internal void RaiseOnOnTheaterMode(object sender, DWebBrowserEvents2_OnTheaterModeEvent e)
        {
            if (this.OnTheaterMode != null)
            {
                this.OnTheaterMode(sender, e);
            }
        }

        internal void RaiseOnOnToolBar(object sender, DWebBrowserEvents2_OnToolBarEvent e)
        {
            if (this.OnToolBar != null)
            {
                this.OnToolBar(sender, e);
            }
        }

        internal void RaiseOnOnVisible(object sender, DWebBrowserEvents2_OnVisibleEvent e)
        {
            if (this.OnVisible != null)
            {
                this.OnVisible(sender, e);
            }
        }

        internal void RaiseOnPrintTemplateInstantiation(object sender, DWebBrowserEvents2_PrintTemplateInstantiationEvent e)
        {
            if (this.PrintTemplateInstantiation != null)
            {
                this.PrintTemplateInstantiation(sender, e);
            }
        }

        internal void RaiseOnPrintTemplateTeardown(object sender, DWebBrowserEvents2_PrintTemplateTeardownEvent e)
        {
            if (this.PrintTemplateTeardown != null)
            {
                this.PrintTemplateTeardown(sender, e);
            }
        }

        internal void RaiseOnPrivacyImpactedStateChange(object sender, DWebBrowserEvents2_PrivacyImpactedStateChangeEvent e)
        {
            if (this.PrivacyImpactedStateChange != null)
            {
                this.PrivacyImpactedStateChange(sender, e);
            }
        }

        internal void RaiseOnProgressChange(object sender, DWebBrowserEvents2_ProgressChangeEvent e)
        {
            if (this.ProgressChange != null)
            {
                this.ProgressChange(sender, e);
            }
        }

        internal void RaiseOnPropertyChange(object sender, DWebBrowserEvents2_PropertyChangeEvent e)
        {
            if (this.PropertyChange != null)
            {
                this.PropertyChange(sender, e);
            }
        }

        internal void RaiseOnSetSecureLockIcon(object sender, DWebBrowserEvents2_SetSecureLockIconEvent e)
        {
            if (this.SetSecureLockIcon != null)
            {
                this.SetSecureLockIcon(sender, e);
            }
        }

        internal void RaiseOnStatusTextChange(object sender, DWebBrowserEvents2_StatusTextChangeEvent e)
        {
            if (this.StatusTextChange != null)
            {
                this.StatusTextChange(sender, e);
            }
        }

        internal void RaiseOnTitleChange(object sender, DWebBrowserEvents2_TitleChangeEvent e)
        {
            if (this.TitleChange != null)
            {
                this.TitleChange(sender, e);
            }
        }

        internal void RaiseOnUpdatePageStatus(object sender, DWebBrowserEvents2_UpdatePageStatusEvent e)
        {
            if (this.UpdatePageStatus != null)
            {
                this.UpdatePageStatus(sender, e);
            }
        }

        internal void RaiseOnWindowClosing(object sender, DWebBrowserEvents2_WindowClosingEvent e)
        {
            if (this.WindowClosing != null)
            {
                this.WindowClosing(sender, e);
            }
        }

        internal void RaiseOnWindowSetHeight(object sender, DWebBrowserEvents2_WindowSetHeightEvent e)
        {
            if (this.WindowSetHeight != null)
            {
                this.WindowSetHeight(sender, e);
            }
        }

        internal void RaiseOnWindowSetLeft(object sender, DWebBrowserEvents2_WindowSetLeftEvent e)
        {
            if (this.WindowSetLeft != null)
            {
                this.WindowSetLeft(sender, e);
            }
        }

        internal void RaiseOnWindowSetResizable(object sender, DWebBrowserEvents2_WindowSetResizableEvent e)
        {
            if (this.WindowSetResizable != null)
            {
                this.WindowSetResizable(sender, e);
            }
        }

        internal void RaiseOnWindowSetTop(object sender, DWebBrowserEvents2_WindowSetTopEvent e)
        {
            if (this.WindowSetTop != null)
            {
                this.WindowSetTop(sender, e);
            }
        }

        internal void RaiseOnWindowSetWidth(object sender, DWebBrowserEvents2_WindowSetWidthEvent e)
        {
            if (this.WindowSetWidth != null)
            {
                this.WindowSetWidth(sender, e);
            }
        }

        public virtual void Refresh2()
        {
            if (this.ocx == null)
            {
                throw new AxHost.InvalidActiveXStateException("Refresh2", AxHost.ActiveXInvokeKind.MethodInvoke);
            }
            object[] parameters = new object[] { Missing.Value };
            typeof(SHDocVw.IWebBrowser2).GetMethod("Refresh2").Invoke(this.ocx, parameters);
        }

        public virtual void Refresh2(ref object level)
        {
            if (this.ocx == null)
            {
                throw new AxHost.InvalidActiveXStateException("Refresh2", AxHost.ActiveXInvokeKind.MethodInvoke);
            }
            this.ocx.Refresh2(ref level);
        }

        public virtual void ShowBrowserBar(ref object pvaClsid)
        {
            if (this.ocx == null)
            {
                throw new AxHost.InvalidActiveXStateException("ShowBrowserBar", AxHost.ActiveXInvokeKind.MethodInvoke);
            }
            object[] parameters = new object[] { pvaClsid, Missing.Value, Missing.Value };
            typeof(SHDocVw.IWebBrowser2).GetMethod("ShowBrowserBar").Invoke(this.ocx, parameters);
            pvaClsid = parameters[0];
        }

        public virtual void ShowBrowserBar(ref object pvaClsid, ref object pvarShow, ref object pvarSize)
        {
            if (this.ocx == null)
            {
                throw new AxHost.InvalidActiveXStateException("ShowBrowserBar", AxHost.ActiveXInvokeKind.MethodInvoke);
            }
            this.ocx.ShowBrowserBar(ref pvaClsid, ref pvarShow, ref pvarSize);
        }

        public virtual void Stop()
        {
            if (this.ocx == null)
            {
                throw new AxHost.InvalidActiveXStateException("Stop", AxHost.ActiveXInvokeKind.MethodInvoke);
            }
            this.ocx.Stop();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DispId(200)]
        public virtual object Application
        {
            get
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("Application", AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.Application;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DispId(0xc9)]
        public virtual object CtlParent
        {
            get
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("CtlParent", AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.Parent;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DispId(0xca)]
        public virtual object CtlContainer
        {
            get
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("CtlContainer", AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.Container;
            }
        }

        [DispId(0xcb), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual object Document
        {
            get
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("Document", AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.Document;
            }
        }

        [DispId(0xcc), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool TopLevelContainer
        {
            get
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("TopLevelContainer", AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.TopLevelContainer;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DispId(0xcd)]
        public virtual string Type
        {
            get
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("Type", AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.Type;
            }
        }

        [DispId(0xce), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual int CtlLeft
        {
            get
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("CtlLeft", AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.Left;
            }
            set
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("CtlLeft", AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.Left = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DispId(0xcf)]
        public virtual int CtlTop
        {
            get
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("CtlTop", AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.Top;
            }
            set
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("CtlTop", AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.Top = value;
            }
        }

        [DispId(0xd0), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual int CtlWidth
        {
            get
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("CtlWidth", AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.Width;
            }
            set
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("CtlWidth", AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.Width = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DispId(0xd1)]
        public virtual int CtlHeight
        {
            get
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("CtlHeight", AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.Height;
            }
            set
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("CtlHeight", AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.Height = value;
            }
        }

        [DispId(210), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual string LocationName
        {
            get
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("LocationName", AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.LocationName;
            }
        }

        [DispId(0xd3), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual string LocationURL
        {
            get
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("LocationURL", AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.LocationURL;
            }
        }

        [DispId(0xd4), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool Busy
        {
            get
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("Busy", AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.Busy;
            }
        }

        [Browsable(true), DispId(0), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual string Name
        {
            get
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("Name", AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx[];
            }
        }

        [DispId(-515), Browsable(false), ComAliasName("System.Int32"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual int HWND
        {
            get
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("HWND", AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.HWND;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DispId(400)]
        public virtual string FullName
        {
            get
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("FullName", AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.FullName;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DispId(0x191)]
        public virtual string Path
        {
            get
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("Path", AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.Path;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DispId(0x192)]
        public virtual bool CtlVisible
        {
            get
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("CtlVisible", AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.Visible;
            }
            set
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("CtlVisible", AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.Visible = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DispId(0x193)]
        public virtual bool StatusBar
        {
            get
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("StatusBar", AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.StatusBar;
            }
            set
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("StatusBar", AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.StatusBar = value;
            }
        }

        [DispId(0x194), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual string StatusText
        {
            get
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("StatusText", AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.StatusText;
            }
            set
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("StatusText", AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.StatusText = value;
            }
        }

        [DispId(0x195), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual int ToolBar
        {
            get
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("ToolBar", AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.ToolBar;
            }
            set
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("ToolBar", AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.ToolBar = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DispId(0x196)]
        public virtual bool MenuBar
        {
            get
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("MenuBar", AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.MenuBar;
            }
            set
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("MenuBar", AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.MenuBar = value;
            }
        }

        [DispId(0x197), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool FullScreen
        {
            get
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("FullScreen", AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.FullScreen;
            }
            set
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("FullScreen", AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.FullScreen = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Bindable(BindableSupport.Yes), DispId(-525)]
        public virtual tagREADYSTATE ReadyState
        {
            get
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("ReadyState", AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.ReadyState;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DispId(550)]
        public virtual bool Offline
        {
            get
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("Offline", AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.Offline;
            }
            set
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("Offline", AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.Offline = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DispId(0x227)]
        public virtual bool Silent
        {
            get
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("Silent", AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.Silent;
            }
            set
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("Silent", AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.Silent = value;
            }
        }

        [DispId(0x228), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool RegisterAsBrowser
        {
            get
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("RegisterAsBrowser", AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.RegisterAsBrowser;
            }
            set
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("RegisterAsBrowser", AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.RegisterAsBrowser = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DispId(0x229)]
        public virtual bool RegisterAsDropTarget
        {
            get
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("RegisterAsDropTarget", AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.RegisterAsDropTarget;
            }
            set
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("RegisterAsDropTarget", AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.RegisterAsDropTarget = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DispId(0x22a)]
        public virtual bool TheaterMode
        {
            get
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("TheaterMode", AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.TheaterMode;
            }
            set
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("TheaterMode", AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.TheaterMode = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DispId(0x22b)]
        public virtual bool AddressBar
        {
            get
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("AddressBar", AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.AddressBar;
            }
            set
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("AddressBar", AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.AddressBar = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DispId(0x22c)]
        public virtual bool Resizable
        {
            get
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("Resizable", AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.Resizable;
            }
            set
            {
                if (this.ocx == null)
                {
                    throw new AxHost.InvalidActiveXStateException("Resizable", AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.Resizable = value;
            }
        }
    }
}

