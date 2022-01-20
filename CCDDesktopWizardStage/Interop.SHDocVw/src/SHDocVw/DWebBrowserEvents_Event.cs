namespace SHDocVw
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComEventInterface(typeof(DWebBrowserEvents), typeof(DWebBrowserEvents_EventProvider)), TypeLibType((short) 0x10), ComVisible(false)]
    public interface DWebBrowserEvents_Event
    {
        event DWebBrowserEvents_BeforeNavigateEventHandler BeforeNavigate;

        event DWebBrowserEvents_CommandStateChangeEventHandler CommandStateChange;

        event DWebBrowserEvents_DownloadBeginEventHandler DownloadBegin;

        event DWebBrowserEvents_DownloadCompleteEventHandler DownloadComplete;

        event DWebBrowserEvents_FrameBeforeNavigateEventHandler FrameBeforeNavigate;

        event DWebBrowserEvents_FrameNavigateCompleteEventHandler FrameNavigateComplete;

        event DWebBrowserEvents_FrameNewWindowEventHandler FrameNewWindow;

        event DWebBrowserEvents_NavigateCompleteEventHandler NavigateComplete;

        event DWebBrowserEvents_NewWindowEventHandler NewWindow;

        event DWebBrowserEvents_ProgressChangeEventHandler ProgressChange;

        event DWebBrowserEvents_PropertyChangeEventHandler PropertyChange;

        event DWebBrowserEvents_QuitEventHandler Quit;

        event DWebBrowserEvents_StatusTextChangeEventHandler StatusTextChange;

        event DWebBrowserEvents_TitleChangeEventHandler TitleChange;

        event DWebBrowserEvents_WindowActivateEventHandler WindowActivate;

        event DWebBrowserEvents_WindowMoveEventHandler WindowMove;

        event DWebBrowserEvents_WindowResizeEventHandler WindowResize;
    }
}

