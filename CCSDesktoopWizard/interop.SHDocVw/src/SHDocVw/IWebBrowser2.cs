namespace SHDocVw
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, DefaultMember("Name"), Guid("D30C1661-CDAF-11D0-8A3E-00C04FC9E26E"), TypeLibType((short) 0x1050)]
    public interface IWebBrowser2 : IWebBrowserApp
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(100)]
        extern void GoBack();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x65)]
        extern void GoForward();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x66)]
        extern void GoHome();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x67)]
        extern void GoSearch();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x68)]
        extern void Navigate([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.Struct)] ref object Flags, [In, MarshalAs(UnmanagedType.Struct)] ref object TargetFrameName, [In, MarshalAs(UnmanagedType.Struct)] ref object PostData, [In, MarshalAs(UnmanagedType.Struct)] ref object Headers);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(-550)]
        extern void Refresh();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x69)]
        extern void Refresh2([In, MarshalAs(UnmanagedType.Struct)] ref object Level);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x6a)]
        extern void Stop();
        [DispId(200)]
        object Application { [return: MarshalAs(UnmanagedType.IDispatch)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(200)] get; }
        [DispId(0xc9)]
        object Parent { [return: MarshalAs(UnmanagedType.IDispatch)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xc9)] get; }
        [DispId(0xca)]
        object Container { [return: MarshalAs(UnmanagedType.IDispatch)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xca)] get; }
        [DispId(0xcb)]
        object Document { [return: MarshalAs(UnmanagedType.IDispatch)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xcb)] get; }
        [DispId(0xcc)]
        bool TopLevelContainer { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xcc)] get; }
        [DispId(0xcd)]
        string Type { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xcd)] get; }
        [DispId(0xce)]
        int Left { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xce)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xce)] set; }
        [DispId(0xcf)]
        int Top { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xcf)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xcf)] set; }
        [DispId(0xd0)]
        int Width { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xd0)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xd0)] set; }
        [DispId(0xd1)]
        int Height { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xd1)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xd1)] set; }
        [DispId(210)]
        string LocationName { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(210)] get; }
        [DispId(0xd3)]
        string LocationURL { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xd3)] get; }
        [DispId(0xd4)]
        bool Busy { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xd4)] get; }
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(300)]
        extern void Quit();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x12d)]
        extern void ClientToWindow([In, Out] ref int pcx, [In, Out] ref int pcy);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x12e)]
        extern void PutProperty([In, MarshalAs(UnmanagedType.BStr)] string Property, [In, MarshalAs(UnmanagedType.Struct)] object vtValue);
        [return: MarshalAs(UnmanagedType.Struct)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x12f)]
        extern object GetProperty([In, MarshalAs(UnmanagedType.BStr)] string Property);
        [DispId(0)]
        string this[] { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0)] get; }
        [DispId(-515)]
        int HWND { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(-515)] get; }
        [DispId(400)]
        string FullName { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(400)] get; }
        [DispId(0x191)]
        string Path { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x191)] get; }
        [DispId(0x192)]
        bool Visible { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x192)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x192)] set; }
        [DispId(0x193)]
        bool StatusBar { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x193)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x193)] set; }
        [DispId(0x194)]
        string StatusText { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x194)] get; [param: In, MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x194)] set; }
        [DispId(0x195)]
        int ToolBar { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x195)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x195)] set; }
        [DispId(0x196)]
        bool MenuBar { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x196)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x196)] set; }
        [DispId(0x197)]
        bool FullScreen { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x197)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x197)] set; }
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(500)]
        extern void Navigate2([In, MarshalAs(UnmanagedType.Struct)] ref object URL, [In, MarshalAs(UnmanagedType.Struct)] ref object Flags, [In, MarshalAs(UnmanagedType.Struct)] ref object TargetFrameName, [In, MarshalAs(UnmanagedType.Struct)] ref object PostData, [In, MarshalAs(UnmanagedType.Struct)] ref object Headers);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x1f5)]
        extern OLECMDF QueryStatusWB([In] OLECMDID cmdID);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x1f6)]
        extern void ExecWB([In] OLECMDID cmdID, [In] OLECMDEXECOPT cmdexecopt, [In, MarshalAs(UnmanagedType.Struct)] ref object pvaIn, [In, Out, MarshalAs(UnmanagedType.Struct)] ref object pvaOut);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x1f7)]
        extern void ShowBrowserBar([In, MarshalAs(UnmanagedType.Struct)] ref object pvaClsid, [In, MarshalAs(UnmanagedType.Struct)] ref object pvarShow, [In, MarshalAs(UnmanagedType.Struct)] ref object pvarSize);
        [DispId(-525)]
        tagREADYSTATE ReadyState { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), TypeLibFunc((short) 4), DispId(-525)] get; }
        [DispId(550)]
        bool Offline { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(550)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(550)] set; }
        [DispId(0x227)]
        bool Silent { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x227)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x227)] set; }
        [DispId(0x228)]
        bool RegisterAsBrowser { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x228)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x228)] set; }
        [DispId(0x229)]
        bool RegisterAsDropTarget { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x229)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x229)] set; }
        [DispId(0x22a)]
        bool TheaterMode { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x22a)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x22a)] set; }
        [DispId(0x22b)]
        bool AddressBar { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x22b)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x22b)] set; }
        [DispId(0x22c)]
        bool Resizable { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x22c)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x22c)] set; }
    }
}

