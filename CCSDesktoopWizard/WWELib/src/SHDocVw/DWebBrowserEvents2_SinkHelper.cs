namespace SHDocVw
{
    using System;
    using System.Runtime.InteropServices;

    [ClassInterface(ClassInterfaceType.None)]
    public sealed class DWebBrowserEvents2_SinkHelper : DWebBrowserEvents2
    {
        public DWebBrowserEvents2_NewWindow3EventHandler m_NewWindow3Delegate = null;
        public DWebBrowserEvents2_PrivacyImpactedStateChangeEventHandler m_PrivacyImpactedStateChangeDelegate = null;
        public DWebBrowserEvents2_UpdatePageStatusEventHandler m_UpdatePageStatusDelegate = null;
        public DWebBrowserEvents2_PrintTemplateTeardownEventHandler m_PrintTemplateTeardownDelegate = null;
        public DWebBrowserEvents2_PrintTemplateInstantiationEventHandler m_PrintTemplateInstantiationDelegate = null;
        public DWebBrowserEvents2_NavigateErrorEventHandler m_NavigateErrorDelegate = null;
        public DWebBrowserEvents2_FileDownloadEventHandler m_FileDownloadDelegate = null;
        public DWebBrowserEvents2_SetSecureLockIconEventHandler m_SetSecureLockIconDelegate = null;
        public DWebBrowserEvents2_ClientToHostWindowEventHandler m_ClientToHostWindowDelegate = null;
        public DWebBrowserEvents2_WindowClosingEventHandler m_WindowClosingDelegate = null;
        public DWebBrowserEvents2_WindowSetHeightEventHandler m_WindowSetHeightDelegate = null;
        public DWebBrowserEvents2_WindowSetWidthEventHandler m_WindowSetWidthDelegate = null;
        public DWebBrowserEvents2_WindowSetTopEventHandler m_WindowSetTopDelegate = null;
        public DWebBrowserEvents2_WindowSetLeftEventHandler m_WindowSetLeftDelegate = null;
        public DWebBrowserEvents2_WindowSetResizableEventHandler m_WindowSetResizableDelegate = null;
        public DWebBrowserEvents2_OnTheaterModeEventHandler m_OnTheaterModeDelegate = null;
        public DWebBrowserEvents2_OnFullScreenEventHandler m_OnFullScreenDelegate = null;
        public DWebBrowserEvents2_OnStatusBarEventHandler m_OnStatusBarDelegate = null;
        public DWebBrowserEvents2_OnMenuBarEventHandler m_OnMenuBarDelegate = null;
        public DWebBrowserEvents2_OnToolBarEventHandler m_OnToolBarDelegate = null;
        public DWebBrowserEvents2_OnVisibleEventHandler m_OnVisibleDelegate = null;
        public DWebBrowserEvents2_OnQuitEventHandler m_OnQuitDelegate = null;
        public DWebBrowserEvents2_DocumentCompleteEventHandler m_DocumentCompleteDelegate = null;
        public DWebBrowserEvents2_NavigateComplete2EventHandler m_NavigateComplete2Delegate = null;
        public DWebBrowserEvents2_NewWindow2EventHandler m_NewWindow2Delegate = null;
        public DWebBrowserEvents2_BeforeNavigate2EventHandler m_BeforeNavigate2Delegate = null;
        public DWebBrowserEvents2_PropertyChangeEventHandler m_PropertyChangeDelegate = null;
        public DWebBrowserEvents2_TitleChangeEventHandler m_TitleChangeDelegate = null;
        public DWebBrowserEvents2_DownloadCompleteEventHandler m_DownloadCompleteDelegate = null;
        public DWebBrowserEvents2_DownloadBeginEventHandler m_DownloadBeginDelegate = null;
        public DWebBrowserEvents2_CommandStateChangeEventHandler m_CommandStateChangeDelegate = null;
        public DWebBrowserEvents2_ProgressChangeEventHandler m_ProgressChangeDelegate = null;
        public DWebBrowserEvents2_StatusTextChangeEventHandler m_StatusTextChangeDelegate = null;
        public int m_dwCookie = 0;

        internal DWebBrowserEvents2_SinkHelper()
        {
        }

        public override void BeforeNavigate2(object obj1, ref object objRef1, ref object objRef2, ref object objRef3, ref object objRef4, ref object objRef5, ref bool flagRef1)
        {
            if (this.m_BeforeNavigate2Delegate != null)
            {
                this.m_BeforeNavigate2Delegate(obj1, ref objRef1, ref objRef2, ref objRef3, ref objRef4, ref objRef5, ref flagRef1);
            }
        }

        public override void ClientToHostWindow(ref int numRef1, ref int numRef2)
        {
            if (this.m_ClientToHostWindowDelegate != null)
            {
                this.m_ClientToHostWindowDelegate(ref numRef1, ref numRef2);
            }
        }

        public override void CommandStateChange(int num1, bool flag1)
        {
            if (this.m_CommandStateChangeDelegate != null)
            {
                this.m_CommandStateChangeDelegate(num1, flag1);
            }
        }

        public override void DocumentComplete(object obj1, ref object objRef1)
        {
            if (this.m_DocumentCompleteDelegate != null)
            {
                this.m_DocumentCompleteDelegate(obj1, ref objRef1);
            }
        }

        public override void DownloadBegin()
        {
            if (this.m_DownloadBeginDelegate != null)
            {
                this.m_DownloadBeginDelegate();
            }
        }

        public override void DownloadComplete()
        {
            if (this.m_DownloadCompleteDelegate != null)
            {
                this.m_DownloadCompleteDelegate();
            }
        }

        public override void FileDownload(ref bool flagRef1)
        {
            if (this.m_FileDownloadDelegate != null)
            {
                this.m_FileDownloadDelegate(ref flagRef1);
            }
        }

        public override void NavigateComplete2(object obj1, ref object objRef1)
        {
            if (this.m_NavigateComplete2Delegate != null)
            {
                this.m_NavigateComplete2Delegate(obj1, ref objRef1);
            }
        }

        public override void NavigateError(object obj1, ref object objRef1, ref object objRef2, ref object objRef3, ref bool flagRef1)
        {
            if (this.m_NavigateErrorDelegate != null)
            {
                this.m_NavigateErrorDelegate(obj1, ref objRef1, ref objRef2, ref objRef3, ref flagRef1);
            }
        }

        public override void NewWindow2(ref object objRef1, ref bool flagRef1)
        {
            if (this.m_NewWindow2Delegate != null)
            {
                this.m_NewWindow2Delegate(ref objRef1, ref flagRef1);
            }
        }

        public override void NewWindow3(ref object objRef1, ref bool flagRef1, uint num1, string text1, string text2)
        {
            if (this.m_NewWindow3Delegate != null)
            {
                this.m_NewWindow3Delegate(ref objRef1, ref flagRef1, num1, text1, text2);
            }
        }

        public override void OnFullScreen(bool flag1)
        {
            if (this.m_OnFullScreenDelegate != null)
            {
                this.m_OnFullScreenDelegate(flag1);
            }
        }

        public override void OnMenuBar(bool flag1)
        {
            if (this.m_OnMenuBarDelegate != null)
            {
                this.m_OnMenuBarDelegate(flag1);
            }
        }

        public override void OnQuit()
        {
            if (this.m_OnQuitDelegate != null)
            {
                this.m_OnQuitDelegate();
            }
        }

        public override void OnStatusBar(bool flag1)
        {
            if (this.m_OnStatusBarDelegate != null)
            {
                this.m_OnStatusBarDelegate(flag1);
            }
        }

        public override void OnTheaterMode(bool flag1)
        {
            if (this.m_OnTheaterModeDelegate != null)
            {
                this.m_OnTheaterModeDelegate(flag1);
            }
        }

        public override void OnToolBar(bool flag1)
        {
            if (this.m_OnToolBarDelegate != null)
            {
                this.m_OnToolBarDelegate(flag1);
            }
        }

        public override void OnVisible(bool flag1)
        {
            if (this.m_OnVisibleDelegate != null)
            {
                this.m_OnVisibleDelegate(flag1);
            }
        }

        public override void PrintTemplateInstantiation(object obj1)
        {
            if (this.m_PrintTemplateInstantiationDelegate != null)
            {
                this.m_PrintTemplateInstantiationDelegate(obj1);
            }
        }

        public override void PrintTemplateTeardown(object obj1)
        {
            if (this.m_PrintTemplateTeardownDelegate != null)
            {
                this.m_PrintTemplateTeardownDelegate(obj1);
            }
        }

        public override void PrivacyImpactedStateChange(bool flag1)
        {
            if (this.m_PrivacyImpactedStateChangeDelegate != null)
            {
                this.m_PrivacyImpactedStateChangeDelegate(flag1);
            }
        }

        public override void ProgressChange(int num1, int num2)
        {
            if (this.m_ProgressChangeDelegate != null)
            {
                this.m_ProgressChangeDelegate(num1, num2);
            }
        }

        public override void PropertyChange(string text1)
        {
            if (this.m_PropertyChangeDelegate != null)
            {
                this.m_PropertyChangeDelegate(text1);
            }
        }

        public override void SetSecureLockIcon(int num1)
        {
            if (this.m_SetSecureLockIconDelegate != null)
            {
                this.m_SetSecureLockIconDelegate(num1);
            }
        }

        public override void StatusTextChange(string text1)
        {
            if (this.m_StatusTextChangeDelegate != null)
            {
                this.m_StatusTextChangeDelegate(text1);
            }
        }

        public override void TitleChange(string text1)
        {
            if (this.m_TitleChangeDelegate != null)
            {
                this.m_TitleChangeDelegate(text1);
            }
        }

        public override void UpdatePageStatus(object obj1, ref object objRef1, ref object objRef2)
        {
            if (this.m_UpdatePageStatusDelegate != null)
            {
                this.m_UpdatePageStatusDelegate(obj1, ref objRef1, ref objRef2);
            }
        }

        public override void WindowClosing(bool flag1, ref bool flagRef1)
        {
            if (this.m_WindowClosingDelegate != null)
            {
                this.m_WindowClosingDelegate(flag1, ref flagRef1);
            }
        }

        public override void WindowSetHeight(int num1)
        {
            if (this.m_WindowSetHeightDelegate != null)
            {
                this.m_WindowSetHeightDelegate(num1);
            }
        }

        public override void WindowSetLeft(int num1)
        {
            if (this.m_WindowSetLeftDelegate != null)
            {
                this.m_WindowSetLeftDelegate(num1);
            }
        }

        public override void WindowSetResizable(bool flag1)
        {
            if (this.m_WindowSetResizableDelegate != null)
            {
                this.m_WindowSetResizableDelegate(flag1);
            }
        }

        public override void WindowSetTop(int num1)
        {
            if (this.m_WindowSetTopDelegate != null)
            {
                this.m_WindowSetTopDelegate(num1);
            }
        }

        public override void WindowSetWidth(int num1)
        {
            if (this.m_WindowSetWidthDelegate != null)
            {
                this.m_WindowSetWidthDelegate(num1);
            }
        }
    }
}

