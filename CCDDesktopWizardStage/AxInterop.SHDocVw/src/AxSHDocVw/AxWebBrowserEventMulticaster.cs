namespace AxSHDocVw
{
    using SHDocVw;
    using System;

    public class AxWebBrowserEventMulticaster : DWebBrowserEvents2
    {
        private AxWebBrowser parent;

        public AxWebBrowserEventMulticaster(AxWebBrowser parent)
        {
            this.parent = parent;
        }

        public virtual void BeforeNavigate2(object pDisp, ref object uRL, ref object flags, ref object targetFrameName, ref object postData, ref object headers, ref bool cancel)
        {
            DWebBrowserEvents2_BeforeNavigate2Event e = new DWebBrowserEvents2_BeforeNavigate2Event(pDisp, uRL, flags, targetFrameName, postData, headers, cancel);
            this.parent.RaiseOnBeforeNavigate2(this.parent, e);
            uRL = e.uRL;
            flags = e.flags;
            targetFrameName = e.targetFrameName;
            postData = e.postData;
            headers = e.headers;
            cancel = e.cancel;
        }

        public virtual void ClientToHostWindow(ref int cX, ref int cY)
        {
            DWebBrowserEvents2_ClientToHostWindowEvent e = new DWebBrowserEvents2_ClientToHostWindowEvent(cX, cY);
            this.parent.RaiseOnClientToHostWindow(this.parent, e);
            cX = e.cX;
            cY = e.cY;
        }

        public virtual void CommandStateChange(int command, bool enable)
        {
            DWebBrowserEvents2_CommandStateChangeEvent e = new DWebBrowserEvents2_CommandStateChangeEvent(command, enable);
            this.parent.RaiseOnCommandStateChange(this.parent, e);
        }

        public virtual void DocumentComplete(object pDisp, ref object uRL)
        {
            DWebBrowserEvents2_DocumentCompleteEvent e = new DWebBrowserEvents2_DocumentCompleteEvent(pDisp, uRL);
            this.parent.RaiseOnDocumentComplete(this.parent, e);
            uRL = e.uRL;
        }

        public virtual void DownloadBegin()
        {
            EventArgs e = new EventArgs();
            this.parent.RaiseOnDownloadBegin(this.parent, e);
        }

        public virtual void DownloadComplete()
        {
            EventArgs e = new EventArgs();
            this.parent.RaiseOnDownloadComplete(this.parent, e);
        }

        public virtual void FileDownload(ref bool cancel)
        {
            DWebBrowserEvents2_FileDownloadEvent e = new DWebBrowserEvents2_FileDownloadEvent(cancel);
            this.parent.RaiseOnFileDownload(this.parent, e);
            cancel = e.cancel;
        }

        public virtual void NavigateComplete2(object pDisp, ref object uRL)
        {
            DWebBrowserEvents2_NavigateComplete2Event e = new DWebBrowserEvents2_NavigateComplete2Event(pDisp, uRL);
            this.parent.RaiseOnNavigateComplete2(this.parent, e);
            uRL = e.uRL;
        }

        public virtual void NavigateError(object pDisp, ref object uRL, ref object frame, ref object statusCode, ref bool cancel)
        {
            DWebBrowserEvents2_NavigateErrorEvent e = new DWebBrowserEvents2_NavigateErrorEvent(pDisp, uRL, frame, statusCode, cancel);
            this.parent.RaiseOnNavigateError(this.parent, e);
            uRL = e.uRL;
            frame = e.frame;
            statusCode = e.statusCode;
            cancel = e.cancel;
        }

        public virtual void NewWindow2(ref object ppDisp, ref bool cancel)
        {
            DWebBrowserEvents2_NewWindow2Event e = new DWebBrowserEvents2_NewWindow2Event(ppDisp, cancel);
            this.parent.RaiseOnNewWindow2(this.parent, e);
            ppDisp = e.ppDisp;
            cancel = e.cancel;
        }

        public virtual void NewWindow3(ref object ppDisp, ref bool cancel, uint dwFlags, string bstrUrlContext, string bstrUrl)
        {
            DWebBrowserEvents2_NewWindow3Event e = new DWebBrowserEvents2_NewWindow3Event(ppDisp, cancel, dwFlags, bstrUrlContext, bstrUrl);
            this.parent.RaiseOnNewWindow3(this.parent, e);
            ppDisp = e.ppDisp;
            cancel = e.cancel;
        }

        public virtual void OnFullScreen(bool fullScreen)
        {
            DWebBrowserEvents2_OnFullScreenEvent e = new DWebBrowserEvents2_OnFullScreenEvent(fullScreen);
            this.parent.RaiseOnOnFullScreen(this.parent, e);
        }

        public virtual void OnMenuBar(bool menuBar)
        {
            DWebBrowserEvents2_OnMenuBarEvent e = new DWebBrowserEvents2_OnMenuBarEvent(menuBar);
            this.parent.RaiseOnOnMenuBar(this.parent, e);
        }

        public virtual void OnQuit()
        {
            EventArgs e = new EventArgs();
            this.parent.RaiseOnOnQuit(this.parent, e);
        }

        public virtual void OnStatusBar(bool statusBar)
        {
            DWebBrowserEvents2_OnStatusBarEvent e = new DWebBrowserEvents2_OnStatusBarEvent(statusBar);
            this.parent.RaiseOnOnStatusBar(this.parent, e);
        }

        public virtual void OnTheaterMode(bool theaterMode)
        {
            DWebBrowserEvents2_OnTheaterModeEvent e = new DWebBrowserEvents2_OnTheaterModeEvent(theaterMode);
            this.parent.RaiseOnOnTheaterMode(this.parent, e);
        }

        public virtual void OnToolBar(bool toolBar)
        {
            DWebBrowserEvents2_OnToolBarEvent e = new DWebBrowserEvents2_OnToolBarEvent(toolBar);
            this.parent.RaiseOnOnToolBar(this.parent, e);
        }

        public virtual void OnVisible(bool visible)
        {
            DWebBrowserEvents2_OnVisibleEvent e = new DWebBrowserEvents2_OnVisibleEvent(visible);
            this.parent.RaiseOnOnVisible(this.parent, e);
        }

        public virtual void PrintTemplateInstantiation(object pDisp)
        {
            DWebBrowserEvents2_PrintTemplateInstantiationEvent e = new DWebBrowserEvents2_PrintTemplateInstantiationEvent(pDisp);
            this.parent.RaiseOnPrintTemplateInstantiation(this.parent, e);
        }

        public virtual void PrintTemplateTeardown(object pDisp)
        {
            DWebBrowserEvents2_PrintTemplateTeardownEvent e = new DWebBrowserEvents2_PrintTemplateTeardownEvent(pDisp);
            this.parent.RaiseOnPrintTemplateTeardown(this.parent, e);
        }

        public virtual void PrivacyImpactedStateChange(bool bImpacted)
        {
            DWebBrowserEvents2_PrivacyImpactedStateChangeEvent e = new DWebBrowserEvents2_PrivacyImpactedStateChangeEvent(bImpacted);
            this.parent.RaiseOnPrivacyImpactedStateChange(this.parent, e);
        }

        public virtual void ProgressChange(int progress, int progressMax)
        {
            DWebBrowserEvents2_ProgressChangeEvent e = new DWebBrowserEvents2_ProgressChangeEvent(progress, progressMax);
            this.parent.RaiseOnProgressChange(this.parent, e);
        }

        public virtual void PropertyChange(string szProperty)
        {
            DWebBrowserEvents2_PropertyChangeEvent e = new DWebBrowserEvents2_PropertyChangeEvent(szProperty);
            this.parent.RaiseOnPropertyChange(this.parent, e);
        }

        public virtual void SetSecureLockIcon(int secureLockIcon)
        {
            DWebBrowserEvents2_SetSecureLockIconEvent e = new DWebBrowserEvents2_SetSecureLockIconEvent(secureLockIcon);
            this.parent.RaiseOnSetSecureLockIcon(this.parent, e);
        }

        public virtual void StatusTextChange(string text)
        {
            DWebBrowserEvents2_StatusTextChangeEvent e = new DWebBrowserEvents2_StatusTextChangeEvent(text);
            this.parent.RaiseOnStatusTextChange(this.parent, e);
        }

        public virtual void TitleChange(string text)
        {
            DWebBrowserEvents2_TitleChangeEvent e = new DWebBrowserEvents2_TitleChangeEvent(text);
            this.parent.RaiseOnTitleChange(this.parent, e);
        }

        public virtual void UpdatePageStatus(object pDisp, ref object nPage, ref object fDone)
        {
            DWebBrowserEvents2_UpdatePageStatusEvent e = new DWebBrowserEvents2_UpdatePageStatusEvent(pDisp, nPage, fDone);
            this.parent.RaiseOnUpdatePageStatus(this.parent, e);
            nPage = e.nPage;
            fDone = e.fDone;
        }

        public virtual void WindowClosing(bool isChildWindow, ref bool cancel)
        {
            DWebBrowserEvents2_WindowClosingEvent e = new DWebBrowserEvents2_WindowClosingEvent(isChildWindow, cancel);
            this.parent.RaiseOnWindowClosing(this.parent, e);
            cancel = e.cancel;
        }

        public virtual void WindowSetHeight(int height)
        {
            DWebBrowserEvents2_WindowSetHeightEvent e = new DWebBrowserEvents2_WindowSetHeightEvent(height);
            this.parent.RaiseOnWindowSetHeight(this.parent, e);
        }

        public virtual void WindowSetLeft(int left)
        {
            DWebBrowserEvents2_WindowSetLeftEvent e = new DWebBrowserEvents2_WindowSetLeftEvent(left);
            this.parent.RaiseOnWindowSetLeft(this.parent, e);
        }

        public virtual void WindowSetResizable(bool resizable)
        {
            DWebBrowserEvents2_WindowSetResizableEvent e = new DWebBrowserEvents2_WindowSetResizableEvent(resizable);
            this.parent.RaiseOnWindowSetResizable(this.parent, e);
        }

        public virtual void WindowSetTop(int top)
        {
            DWebBrowserEvents2_WindowSetTopEvent e = new DWebBrowserEvents2_WindowSetTopEvent(top);
            this.parent.RaiseOnWindowSetTop(this.parent, e);
        }

        public virtual void WindowSetWidth(int width)
        {
            DWebBrowserEvents2_WindowSetWidthEvent e = new DWebBrowserEvents2_WindowSetWidthEvent(width);
            this.parent.RaiseOnWindowSetWidth(this.parent, e);
        }
    }
}

