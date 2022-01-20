namespace SHDocVw
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, Guid("EAB22AC2-30C1-11CF-A7EB-0000C05BAE0B"), TypeLibType((short) 0x1010), InterfaceType((short) 2)]
    public interface DWebBrowserEvents
    {
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(100)]
        extern void BeforeNavigate([In, MarshalAs(UnmanagedType.BStr)] string URL, int Flags, [MarshalAs(UnmanagedType.BStr)] string TargetFrameName, [MarshalAs(UnmanagedType.Struct)] ref object PostData, [MarshalAs(UnmanagedType.BStr)] string Headers, [In, Out] ref bool Cancel);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x65)]
        extern void NavigateComplete([In, MarshalAs(UnmanagedType.BStr)] string URL);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x66)]
        extern void StatusTextChange([In, MarshalAs(UnmanagedType.BStr)] string Text);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x6c)]
        extern void ProgressChange([In] int Progress, [In] int ProgressMax);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x68)]
        extern void DownloadComplete();
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x69)]
        extern void CommandStateChange([In] int Command, [In] bool Enable);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x6a)]
        extern void DownloadBegin();
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x6b)]
        extern void NewWindow([In, MarshalAs(UnmanagedType.BStr)] string URL, [In] int Flags, [In, MarshalAs(UnmanagedType.BStr)] string TargetFrameName, [In, MarshalAs(UnmanagedType.Struct)] ref object PostData, [In, MarshalAs(UnmanagedType.BStr)] string Headers, [In, Out] ref bool Processed);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x71)]
        extern void TitleChange([In, MarshalAs(UnmanagedType.BStr)] string Text);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(200)]
        extern void FrameBeforeNavigate([In, MarshalAs(UnmanagedType.BStr)] string URL, int Flags, [MarshalAs(UnmanagedType.BStr)] string TargetFrameName, [MarshalAs(UnmanagedType.Struct)] ref object PostData, [MarshalAs(UnmanagedType.BStr)] string Headers, [In, Out] ref bool Cancel);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xc9)]
        extern void FrameNavigateComplete([In, MarshalAs(UnmanagedType.BStr)] string URL);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xcc)]
        extern void FrameNewWindow([In, MarshalAs(UnmanagedType.BStr)] string URL, [In] int Flags, [In, MarshalAs(UnmanagedType.BStr)] string TargetFrameName, [In, MarshalAs(UnmanagedType.Struct)] ref object PostData, [In, MarshalAs(UnmanagedType.BStr)] string Headers, [In, Out] ref bool Processed);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x67)]
        extern void Quit([In, Out] ref bool Cancel);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x6d)]
        extern void WindowMove();
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(110)]
        extern void WindowResize();
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x6f)]
        extern void WindowActivate();
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x70)]
        extern void PropertyChange([In, MarshalAs(UnmanagedType.BStr)] string Property);
    }
}

