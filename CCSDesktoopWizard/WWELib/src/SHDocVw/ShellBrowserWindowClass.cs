namespace SHDocVw
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, ClassInterface((short) 0), TypeLibType((short) 0x12), DefaultMember("Name"), Guid("C08AFD90-F2A1-11D1-8455-00A0C91F3880"), ComSourceInterfaces("SHDocVw.DWebBrowserEvents2\0SHDocVw.DWebBrowserEvents\0")]
    public class ShellBrowserWindowClass : IWebBrowser2, ShellBrowserWindow, DWebBrowserEvents2_Event, IWebBrowserApp, DWebBrowserEvents_Event
    {
        public virtual event DWebBrowserEvents_BeforeNavigateEventHandler BeforeNavigate;

        public virtual event DWebBrowserEvents2_BeforeNavigate2EventHandler BeforeNavigate2;

        public virtual event DWebBrowserEvents2_ClientToHostWindowEventHandler ClientToHostWindow;

        public virtual event DWebBrowserEvents2_CommandStateChangeEventHandler CommandStateChange;

        public virtual event DWebBrowserEvents2_DocumentCompleteEventHandler DocumentComplete;

        public virtual event DWebBrowserEvents2_DownloadBeginEventHandler DownloadBegin;

        public virtual event DWebBrowserEvents2_DownloadCompleteEventHandler DownloadComplete;

        public virtual event DWebBrowserEvents_CommandStateChangeEventHandler DWebBrowserEvents_Event_CommandStateChange;

        public virtual event DWebBrowserEvents_DownloadBeginEventHandler DWebBrowserEvents_Event_DownloadBegin;

        public virtual event DWebBrowserEvents_DownloadCompleteEventHandler DWebBrowserEvents_Event_DownloadComplete;

        public virtual event DWebBrowserEvents_ProgressChangeEventHandler DWebBrowserEvents_Event_ProgressChange;

        public virtual event DWebBrowserEvents_PropertyChangeEventHandler DWebBrowserEvents_Event_PropertyChange;

        public virtual event DWebBrowserEvents_QuitEventHandler DWebBrowserEvents_Event_Quit;

        public virtual event DWebBrowserEvents_StatusTextChangeEventHandler DWebBrowserEvents_Event_StatusTextChange;

        public virtual event DWebBrowserEvents_TitleChangeEventHandler DWebBrowserEvents_Event_TitleChange;

        public virtual event DWebBrowserEvents2_FileDownloadEventHandler FileDownload;

        public virtual event DWebBrowserEvents_FrameBeforeNavigateEventHandler FrameBeforeNavigate;

        public virtual event DWebBrowserEvents_FrameNavigateCompleteEventHandler FrameNavigateComplete;

        public virtual event DWebBrowserEvents_FrameNewWindowEventHandler FrameNewWindow;

        public virtual event DWebBrowserEvents_NavigateCompleteEventHandler NavigateComplete;

        public virtual event DWebBrowserEvents2_NavigateComplete2EventHandler NavigateComplete2;

        public virtual event DWebBrowserEvents2_NavigateErrorEventHandler NavigateError;

        public virtual event DWebBrowserEvents_NewWindowEventHandler NewWindow;

        public virtual event DWebBrowserEvents2_NewWindow2EventHandler NewWindow2;

        public virtual event DWebBrowserEvents2_NewWindow3EventHandler NewWindow3;

        public virtual event DWebBrowserEvents2_OnFullScreenEventHandler OnFullScreen;

        public virtual event DWebBrowserEvents2_OnMenuBarEventHandler OnMenuBar;

        public virtual event DWebBrowserEvents2_OnQuitEventHandler OnQuit;

        public virtual event DWebBrowserEvents2_OnStatusBarEventHandler OnStatusBar;

        public virtual event DWebBrowserEvents2_OnTheaterModeEventHandler OnTheaterMode;

        public virtual event DWebBrowserEvents2_OnToolBarEventHandler OnToolBar;

        public virtual event DWebBrowserEvents2_OnVisibleEventHandler OnVisible;

        public virtual event DWebBrowserEvents2_PrintTemplateInstantiationEventHandler PrintTemplateInstantiation;

        public virtual event DWebBrowserEvents2_PrintTemplateTeardownEventHandler PrintTemplateTeardown;

        public virtual event DWebBrowserEvents2_PrivacyImpactedStateChangeEventHandler PrivacyImpactedStateChange;

        public virtual event DWebBrowserEvents2_ProgressChangeEventHandler ProgressChange;

        public virtual event DWebBrowserEvents2_PropertyChangeEventHandler PropertyChange;

        public virtual event DWebBrowserEvents2_SetSecureLockIconEventHandler SetSecureLockIcon;

        public virtual event DWebBrowserEvents2_StatusTextChangeEventHandler StatusTextChange;

        public virtual event DWebBrowserEvents2_TitleChangeEventHandler TitleChange;

        public virtual event DWebBrowserEvents2_UpdatePageStatusEventHandler UpdatePageStatus;

        public virtual event DWebBrowserEvents_WindowActivateEventHandler WindowActivate;

        public virtual event DWebBrowserEvents2_WindowClosingEventHandler WindowClosing;

        public virtual event DWebBrowserEvents_WindowMoveEventHandler WindowMove;

        public virtual event DWebBrowserEvents_WindowResizeEventHandler WindowResize;

        public virtual event DWebBrowserEvents2_WindowSetHeightEventHandler WindowSetHeight;

        public virtual event DWebBrowserEvents2_WindowSetLeftEventHandler WindowSetLeft;

        public virtual event DWebBrowserEvents2_WindowSetResizableEventHandler WindowSetResizable;

        public virtual event DWebBrowserEvents2_WindowSetTopEventHandler WindowSetTop;

        public virtual event DWebBrowserEvents2_WindowSetWidthEventHandler WindowSetWidth;

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x12d)]
        public virtual extern void ClientToWindow([In, Out] ref int pcx, [In, Out] ref int pcy);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x1f6)]
        public virtual extern void ExecWB([In] OLECMDID cmdID, [In] OLECMDEXECOPT cmdexecopt, [In, MarshalAs(UnmanagedType.Struct)] ref object pvaIn, [In, Out, MarshalAs(UnmanagedType.Struct)] ref object pvaOut);
        [return: MarshalAs(UnmanagedType.Struct)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x12f)]
        public virtual extern object GetProperty([In, MarshalAs(UnmanagedType.BStr)] string Property);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(100)]
        public virtual extern void GoBack();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x65)]
        public virtual extern void GoForward();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x66)]
        public virtual extern void GoHome();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x67)]
        public virtual extern void GoSearch();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        public virtual extern void IWebBrowserApp_ClientToWindow([In, Out] ref int pcx, [In, Out] ref int pcy);
        [return: MarshalAs(UnmanagedType.Struct)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        public virtual extern object IWebBrowserApp_GetProperty([In, MarshalAs(UnmanagedType.BStr)] string Property);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        public virtual extern void IWebBrowserApp_GoBack();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        public virtual extern void IWebBrowserApp_GoForward();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        public virtual extern void IWebBrowserApp_GoHome();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        public virtual extern void IWebBrowserApp_GoSearch();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        public virtual extern void IWebBrowserApp_Navigate([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.Struct)] ref object Flags, [In, MarshalAs(UnmanagedType.Struct)] ref object TargetFrameName, [In, MarshalAs(UnmanagedType.Struct)] ref object PostData, [In, MarshalAs(UnmanagedType.Struct)] ref object Headers);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        public virtual extern void IWebBrowserApp_PutProperty([In, MarshalAs(UnmanagedType.BStr)] string Property, [In, MarshalAs(UnmanagedType.Struct)] object vtValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        public virtual extern void IWebBrowserApp_Quit();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        public virtual extern void IWebBrowserApp_Refresh();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        public virtual extern void IWebBrowserApp_Refresh2([In, MarshalAs(UnmanagedType.Struct)] ref object Level);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        public virtual extern void IWebBrowserApp_Stop();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x68)]
        public virtual extern void Navigate([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.Struct)] ref object Flags, [In, MarshalAs(UnmanagedType.Struct)] ref object TargetFrameName, [In, MarshalAs(UnmanagedType.Struct)] ref object PostData, [In, MarshalAs(UnmanagedType.Struct)] ref object Headers);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(500)]
        public virtual extern void Navigate2([In, MarshalAs(UnmanagedType.Struct)] ref object URL, [In, MarshalAs(UnmanagedType.Struct)] ref object Flags, [In, MarshalAs(UnmanagedType.Struct)] ref object TargetFrameName, [In, MarshalAs(UnmanagedType.Struct)] ref object PostData, [In, MarshalAs(UnmanagedType.Struct)] ref object Headers);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x12e)]
        public virtual extern void PutProperty([In, MarshalAs(UnmanagedType.BStr)] string Property, [In, MarshalAs(UnmanagedType.Struct)] object vtValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x1f5)]
        public virtual extern OLECMDF QueryStatusWB([In] OLECMDID cmdID);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(300)]
        public virtual extern void Quit();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(-550)]
        public virtual extern void Refresh();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x69)]
        public virtual extern void Refresh2([In, MarshalAs(UnmanagedType.Struct)] ref object Level);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x1f7)]
        public virtual extern void ShowBrowserBar([In, MarshalAs(UnmanagedType.Struct)] ref object pvaClsid, [In, MarshalAs(UnmanagedType.Struct)] ref object pvarShow, [In, MarshalAs(UnmanagedType.Struct)] ref object pvarSize);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x6a)]
        public virtual extern void Stop();

        [DispId(200)]
        public virtual object Application { [return: MarshalAs(UnmanagedType.IDispatch)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(200)] get; }

        [DispId(0xc9)]
        public virtual object Parent { [return: MarshalAs(UnmanagedType.IDispatch)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xc9)] get; }

        [DispId(0xca)]
        public virtual object Container { [return: MarshalAs(UnmanagedType.IDispatch)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xca)] get; }

        [DispId(0xcb)]
        public virtual object Document { [return: MarshalAs(UnmanagedType.IDispatch)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xcb)] get; }

        [DispId(0xcc)]
        public virtual bool TopLevelContainer { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xcc)] get; }

        [DispId(0xcd)]
        public virtual string Type { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xcd)] get; }

        [DispId(0xce)]
        public virtual int Left { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xce)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xce)] set; }

        [DispId(0xcf)]
        public virtual int Top { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xcf)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xcf)] set; }

        [DispId(0xd0)]
        public virtual int Width { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xd0)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xd0)] set; }

        [DispId(0xd1)]
        public virtual int Height { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xd1)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xd1)] set; }

        [DispId(210)]
        public virtual string LocationName { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(210)] get; }

        [DispId(0xd3)]
        public virtual string LocationURL { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xd3)] get; }

        [DispId(0xd4)]
        public virtual bool Busy { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xd4)] get; }

        [DispId(0)]
        public virtual string this[] { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0)] get; }

        [DispId(-515)]
        public virtual int HWND { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(-515)] get; }

        [DispId(400)]
        public virtual string FullName { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(400)] get; }

        [DispId(0x191)]
        public virtual string Path { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x191)] get; }

        [DispId(0x192)]
        public virtual bool Visible { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x192)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x192)] set; }

        [DispId(0x193)]
        public virtual bool StatusBar { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x193)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x193)] set; }

        [DispId(0x194)]
        public virtual string StatusText { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x194)] get; [param: In, MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x194)] set; }

        [DispId(0x195)]
        public virtual int ToolBar { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x195)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x195)] set; }

        [DispId(0x196)]
        public virtual bool MenuBar { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x196)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x196)] set; }

        [DispId(0x197)]
        public virtual bool FullScreen { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x197)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x197)] set; }

        [DispId(-525)]
        public virtual tagREADYSTATE ReadyState { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), TypeLibFunc((short) 4), DispId(-525)] get; }

        [DispId(550)]
        public virtual bool Offline { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(550)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(550)] set; }

        [DispId(0x227)]
        public virtual bool Silent { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x227)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x227)] set; }

        [DispId(0x228)]
        public virtual bool RegisterAsBrowser { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x228)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x228)] set; }

        [DispId(0x229)]
        public virtual bool RegisterAsDropTarget { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x229)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x229)] set; }

        [DispId(0x22a)]
        public virtual bool TheaterMode { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x22a)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x22a)] set; }

        [DispId(0x22b)]
        public virtual bool AddressBar { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x22b)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x22b)] set; }

        [DispId(0x22c)]
        public virtual bool Resizable { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x22c)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x22c)] set; }

        public virtual object IWebBrowserApp_Application { [return: MarshalAs(UnmanagedType.IDispatch)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; }

        public virtual object IWebBrowserApp_Parent { [return: MarshalAs(UnmanagedType.IDispatch)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; }

        public virtual object IWebBrowserApp_Container { [return: MarshalAs(UnmanagedType.IDispatch)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; }

        public virtual object IWebBrowserApp_Document { [return: MarshalAs(UnmanagedType.IDispatch)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; }

        public virtual bool IWebBrowserApp_TopLevelContainer { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; }

        public virtual string IWebBrowserApp_Type { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; }

        public virtual int IWebBrowserApp_Left { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] set; }

        public virtual int IWebBrowserApp_Top { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] set; }

        public virtual int IWebBrowserApp_Width { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] set; }

        public virtual int IWebBrowserApp_Height { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] set; }

        public virtual string IWebBrowserApp_LocationName { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; }

        public virtual string IWebBrowserApp_LocationURL { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; }

        public virtual bool IWebBrowserApp_Busy { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; }

        public virtual string IWebBrowserApp_Name { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; }

        public virtual int IWebBrowserApp_HWND { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; }

        public virtual string IWebBrowserApp_FullName { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; }

        public virtual string IWebBrowserApp_Path { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; }

        public virtual bool IWebBrowserApp_Visible { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] set; }

        public virtual bool IWebBrowserApp_StatusBar { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] set; }

        public virtual string IWebBrowserApp_StatusText { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; [param: In, MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] set; }

        public virtual int IWebBrowserApp_ToolBar { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] set; }

        public virtual bool IWebBrowserApp_MenuBar { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] set; }

        public virtual bool IWebBrowserApp_FullScreen { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] set; }

        [DispId(200)]
        public virtual object SHDocVw.IWebBrowser2.Application { [return: MarshalAs(UnmanagedType.IDispatch)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(200)] get; }

        [DispId(0xc9)]
        public virtual object SHDocVw.IWebBrowser2.Parent { [return: MarshalAs(UnmanagedType.IDispatch)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xc9)] get; }

        [DispId(0xca)]
        public virtual object SHDocVw.IWebBrowser2.Container { [return: MarshalAs(UnmanagedType.IDispatch)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xca)] get; }

        [DispId(0xcb)]
        public virtual object SHDocVw.IWebBrowser2.Document { [return: MarshalAs(UnmanagedType.IDispatch)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xcb)] get; }

        [DispId(0xcc)]
        public virtual bool SHDocVw.IWebBrowser2.TopLevelContainer { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xcc)] get; }

        [DispId(0xcd)]
        public virtual string SHDocVw.IWebBrowser2.Type { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xcd)] get; }

        [DispId(0xce)]
        public virtual int SHDocVw.IWebBrowser2.Left { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xce)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xce)] set; }

        [DispId(0xcf)]
        public virtual int SHDocVw.IWebBrowser2.Top { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xcf)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xcf)] set; }

        [DispId(0xd0)]
        public virtual int SHDocVw.IWebBrowser2.Width { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xd0)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xd0)] set; }

        [DispId(0xd1)]
        public virtual int SHDocVw.IWebBrowser2.Height { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xd1)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xd1)] set; }

        [DispId(210)]
        public virtual string SHDocVw.IWebBrowser2.LocationName { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(210)] get; }

        [DispId(0xd3)]
        public virtual string SHDocVw.IWebBrowser2.LocationURL { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xd3)] get; }

        [DispId(0xd4)]
        public virtual bool SHDocVw.IWebBrowser2.Busy { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xd4)] get; }

        [DispId(0)]
        public virtual string this[] { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0)] get; }

        [DispId(-515)]
        public virtual int SHDocVw.IWebBrowser2.HWND { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(-515)] get; }

        [DispId(400)]
        public virtual string SHDocVw.IWebBrowser2.FullName { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(400)] get; }

        [DispId(0x191)]
        public virtual string SHDocVw.IWebBrowser2.Path { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x191)] get; }

        [DispId(0x192)]
        public virtual bool SHDocVw.IWebBrowser2.Visible { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x192)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x192)] set; }

        [DispId(0x193)]
        public virtual bool SHDocVw.IWebBrowser2.StatusBar { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x193)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x193)] set; }

        [DispId(0x194)]
        public virtual string SHDocVw.IWebBrowser2.StatusText { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x194)] get; [param: In, MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x194)] set; }

        [DispId(0x195)]
        public virtual int SHDocVw.IWebBrowser2.ToolBar { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x195)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x195)] set; }

        [DispId(0x196)]
        public virtual bool SHDocVw.IWebBrowser2.MenuBar { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x196)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x196)] set; }

        [DispId(0x197)]
        public virtual bool SHDocVw.IWebBrowser2.FullScreen { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x197)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x197)] set; }

        [DispId(-525)]
        public virtual tagREADYSTATE SHDocVw.IWebBrowser2.ReadyState { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), TypeLibFunc((short) 4), DispId(-525)] get; }

        [DispId(550)]
        public virtual bool SHDocVw.IWebBrowser2.Offline { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(550)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(550)] set; }

        [DispId(0x227)]
        public virtual bool SHDocVw.IWebBrowser2.Silent { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x227)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x227)] set; }

        [DispId(0x228)]
        public virtual bool SHDocVw.IWebBrowser2.RegisterAsBrowser { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x228)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x228)] set; }

        [DispId(0x229)]
        public virtual bool SHDocVw.IWebBrowser2.RegisterAsDropTarget { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x229)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x229)] set; }

        [DispId(0x22a)]
        public virtual bool SHDocVw.IWebBrowser2.TheaterMode { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x22a)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x22a)] set; }

        [DispId(0x22b)]
        public virtual bool SHDocVw.IWebBrowser2.AddressBar { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x22b)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x22b)] set; }

        [DispId(0x22c)]
        public virtual bool SHDocVw.IWebBrowser2.Resizable { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x22c)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x22c)] set; }

        [DispId(200)]
        public virtual object SHDocVw.IWebBrowserApp.Application { [return: MarshalAs(UnmanagedType.IDispatch)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; }

        [DispId(0xc9)]
        public virtual object SHDocVw.IWebBrowserApp.Parent { [return: MarshalAs(UnmanagedType.IDispatch)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; }

        [DispId(0xca)]
        public virtual object SHDocVw.IWebBrowserApp.Container { [return: MarshalAs(UnmanagedType.IDispatch)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; }

        [DispId(0xcb)]
        public virtual object SHDocVw.IWebBrowserApp.Document { [return: MarshalAs(UnmanagedType.IDispatch)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; }

        [DispId(0xcc)]
        public virtual bool SHDocVw.IWebBrowserApp.TopLevelContainer { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; }

        [DispId(0xcd)]
        public virtual string SHDocVw.IWebBrowserApp.Type { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; }

        [DispId(0xce)]
        public virtual int SHDocVw.IWebBrowserApp.Left { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] set; }

        [DispId(0xcf)]
        public virtual int SHDocVw.IWebBrowserApp.Top { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] set; }

        [DispId(0xd0)]
        public virtual int SHDocVw.IWebBrowserApp.Width { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] set; }

        [DispId(0xd1)]
        public virtual int SHDocVw.IWebBrowserApp.Height { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] set; }

        [DispId(210)]
        public virtual string SHDocVw.IWebBrowserApp.LocationName { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; }

        [DispId(0xd3)]
        public virtual string SHDocVw.IWebBrowserApp.LocationURL { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; }

        [DispId(0xd4)]
        public virtual bool SHDocVw.IWebBrowserApp.Busy { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; }

        [DispId(0)]
        public virtual string this[] { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; }

        [DispId(-515)]
        public virtual int SHDocVw.IWebBrowserApp.HWND { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; }

        [DispId(400)]
        public virtual string SHDocVw.IWebBrowserApp.FullName { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; }

        [DispId(0x191)]
        public virtual string SHDocVw.IWebBrowserApp.Path { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; }

        [DispId(0x192)]
        public virtual bool SHDocVw.IWebBrowserApp.Visible { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] set; }

        [DispId(0x193)]
        public virtual bool SHDocVw.IWebBrowserApp.StatusBar { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] set; }

        [DispId(0x194)]
        public virtual string SHDocVw.IWebBrowserApp.StatusText { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; [param: In, MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] set; }

        [DispId(0x195)]
        public virtual int SHDocVw.IWebBrowserApp.ToolBar { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] set; }

        [DispId(0x196)]
        public virtual bool SHDocVw.IWebBrowserApp.MenuBar { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] set; }

        [DispId(0x197)]
        public virtual bool SHDocVw.IWebBrowserApp.FullScreen { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)] set; }
    }
}

