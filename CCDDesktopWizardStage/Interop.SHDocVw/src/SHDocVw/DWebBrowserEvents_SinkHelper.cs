namespace SHDocVw
{
    using System;
    using System.Runtime.InteropServices;

    [ClassInterface(ClassInterfaceType.None)]
    public sealed class DWebBrowserEvents_SinkHelper : DWebBrowserEvents
    {
        public DWebBrowserEvents_PropertyChangeEventHandler m_PropertyChangeDelegate = null;
        public DWebBrowserEvents_WindowActivateEventHandler m_WindowActivateDelegate = null;
        public DWebBrowserEvents_WindowResizeEventHandler m_WindowResizeDelegate = null;
        public DWebBrowserEvents_WindowMoveEventHandler m_WindowMoveDelegate = null;
        public DWebBrowserEvents_QuitEventHandler m_QuitDelegate = null;
        public DWebBrowserEvents_FrameNewWindowEventHandler m_FrameNewWindowDelegate = null;
        public DWebBrowserEvents_FrameNavigateCompleteEventHandler m_FrameNavigateCompleteDelegate = null;
        public DWebBrowserEvents_FrameBeforeNavigateEventHandler m_FrameBeforeNavigateDelegate = null;
        public DWebBrowserEvents_TitleChangeEventHandler m_TitleChangeDelegate = null;
        public DWebBrowserEvents_NewWindowEventHandler m_NewWindowDelegate = null;
        public DWebBrowserEvents_DownloadBeginEventHandler m_DownloadBeginDelegate = null;
        public DWebBrowserEvents_CommandStateChangeEventHandler m_CommandStateChangeDelegate = null;
        public DWebBrowserEvents_DownloadCompleteEventHandler m_DownloadCompleteDelegate = null;
        public DWebBrowserEvents_ProgressChangeEventHandler m_ProgressChangeDelegate = null;
        public DWebBrowserEvents_StatusTextChangeEventHandler m_StatusTextChangeDelegate = null;
        public DWebBrowserEvents_NavigateCompleteEventHandler m_NavigateCompleteDelegate = null;
        public DWebBrowserEvents_BeforeNavigateEventHandler m_BeforeNavigateDelegate = null;
        public int m_dwCookie = 0;

        internal DWebBrowserEvents_SinkHelper()
        {
        }

        public override void BeforeNavigate(string text1, int num1, string text2, ref object objRef1, string text3, ref bool flagRef1)
        {
            if (this.m_BeforeNavigateDelegate != null)
            {
                this.m_BeforeNavigateDelegate(text1, num1, text2, ref objRef1, text3, ref flagRef1);
            }
        }

        public override void CommandStateChange(int num1, bool flag1)
        {
            if (this.m_CommandStateChangeDelegate != null)
            {
                this.m_CommandStateChangeDelegate(num1, flag1);
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

        public override void FrameBeforeNavigate(string text1, int num1, string text2, ref object objRef1, string text3, ref bool flagRef1)
        {
            if (this.m_FrameBeforeNavigateDelegate != null)
            {
                this.m_FrameBeforeNavigateDelegate(text1, num1, text2, ref objRef1, text3, ref flagRef1);
            }
        }

        public override void FrameNavigateComplete(string text1)
        {
            if (this.m_FrameNavigateCompleteDelegate != null)
            {
                this.m_FrameNavigateCompleteDelegate(text1);
            }
        }

        public override void FrameNewWindow(string text1, int num1, string text2, ref object objRef1, string text3, ref bool flagRef1)
        {
            if (this.m_FrameNewWindowDelegate != null)
            {
                this.m_FrameNewWindowDelegate(text1, num1, text2, ref objRef1, text3, ref flagRef1);
            }
        }

        public override void NavigateComplete(string text1)
        {
            if (this.m_NavigateCompleteDelegate != null)
            {
                this.m_NavigateCompleteDelegate(text1);
            }
        }

        public override void NewWindow(string text1, int num1, string text2, ref object objRef1, string text3, ref bool flagRef1)
        {
            if (this.m_NewWindowDelegate != null)
            {
                this.m_NewWindowDelegate(text1, num1, text2, ref objRef1, text3, ref flagRef1);
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

        public override void Quit(ref bool flagRef1)
        {
            if (this.m_QuitDelegate != null)
            {
                this.m_QuitDelegate(ref flagRef1);
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

        public override void WindowActivate()
        {
            if (this.m_WindowActivateDelegate != null)
            {
                this.m_WindowActivateDelegate();
            }
        }

        public override void WindowMove()
        {
            if (this.m_WindowMoveDelegate != null)
            {
                this.m_WindowMoveDelegate();
            }
        }

        public override void WindowResize()
        {
            if (this.m_WindowResizeDelegate != null)
            {
                this.m_WindowResizeDelegate();
            }
        }
    }
}

