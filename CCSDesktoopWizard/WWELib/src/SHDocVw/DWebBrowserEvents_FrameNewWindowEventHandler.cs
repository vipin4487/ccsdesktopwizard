namespace SHDocVw
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComVisible(false), TypeLibType((short) 0x10)]
    public delegate void DWebBrowserEvents_FrameNewWindowEventHandler([In, MarshalAs(UnmanagedType.BStr)] string URL, [In] int Flags, [In, MarshalAs(UnmanagedType.BStr)] string TargetFrameName, [In, MarshalAs(UnmanagedType.Struct)] ref object PostData, [In, MarshalAs(UnmanagedType.BStr)] string Headers, [In, Out] ref bool Processed);
}

