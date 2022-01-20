﻿namespace SHDocVw
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [TypeLibType((short) 0x10), ComVisible(false), ComEventInterface(typeof(DWebBrowserEvents2), typeof(DWebBrowserEvents2_EventProvider))]
    public interface DWebBrowserEvents2_Event
    {
        event DWebBrowserEvents2_BeforeNavigate2EventHandler BeforeNavigate2;

        event DWebBrowserEvents2_ClientToHostWindowEventHandler ClientToHostWindow;

        event DWebBrowserEvents2_CommandStateChangeEventHandler CommandStateChange;

        event DWebBrowserEvents2_DocumentCompleteEventHandler DocumentComplete;

        event DWebBrowserEvents2_DownloadBeginEventHandler DownloadBegin;

        event DWebBrowserEvents2_DownloadCompleteEventHandler DownloadComplete;

        event DWebBrowserEvents2_FileDownloadEventHandler FileDownload;

        event DWebBrowserEvents2_NavigateComplete2EventHandler NavigateComplete2;

        event DWebBrowserEvents2_NavigateErrorEventHandler NavigateError;

        event DWebBrowserEvents2_NewWindow2EventHandler NewWindow2;

        event DWebBrowserEvents2_NewWindow3EventHandler NewWindow3;

        event DWebBrowserEvents2_OnFullScreenEventHandler OnFullScreen;

        event DWebBrowserEvents2_OnMenuBarEventHandler OnMenuBar;

        event DWebBrowserEvents2_OnQuitEventHandler OnQuit;

        event DWebBrowserEvents2_OnStatusBarEventHandler OnStatusBar;

        event DWebBrowserEvents2_OnTheaterModeEventHandler OnTheaterMode;

        event DWebBrowserEvents2_OnToolBarEventHandler OnToolBar;

        event DWebBrowserEvents2_OnVisibleEventHandler OnVisible;

        event DWebBrowserEvents2_PrintTemplateInstantiationEventHandler PrintTemplateInstantiation;

        event DWebBrowserEvents2_PrintTemplateTeardownEventHandler PrintTemplateTeardown;

        event DWebBrowserEvents2_PrivacyImpactedStateChangeEventHandler PrivacyImpactedStateChange;

        event DWebBrowserEvents2_ProgressChangeEventHandler ProgressChange;

        event DWebBrowserEvents2_PropertyChangeEventHandler PropertyChange;

        event DWebBrowserEvents2_SetSecureLockIconEventHandler SetSecureLockIcon;

        event DWebBrowserEvents2_StatusTextChangeEventHandler StatusTextChange;

        event DWebBrowserEvents2_TitleChangeEventHandler TitleChange;

        event DWebBrowserEvents2_UpdatePageStatusEventHandler UpdatePageStatus;

        event DWebBrowserEvents2_WindowClosingEventHandler WindowClosing;

        event DWebBrowserEvents2_WindowSetHeightEventHandler WindowSetHeight;

        event DWebBrowserEvents2_WindowSetLeftEventHandler WindowSetLeft;

        event DWebBrowserEvents2_WindowSetResizableEventHandler WindowSetResizable;

        event DWebBrowserEvents2_WindowSetTopEventHandler WindowSetTop;

        event DWebBrowserEvents2_WindowSetWidthEventHandler WindowSetWidth;
    }
}
