namespace SHDocVw
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComVisible(false), TypeLibType((short) 0x10)]
    public delegate void DWebBrowserEvents_BeforeNavigateEventHandler([In, MarshalAs(UnmanagedType.BStr)] string URL, int Flags, [MarshalAs(UnmanagedType.BStr)] string TargetFrameName, [MarshalAs(UnmanagedType.Struct)] ref object PostData, [MarshalAs(UnmanagedType.BStr)] string Headers, [In, Out] ref bool Cancel);
}

