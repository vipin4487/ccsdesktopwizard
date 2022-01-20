namespace SHDocVw
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [TypeLibType((short) 0x10), ComVisible(false)]
    public delegate void DWebBrowserEvents_NewWindowEventHandler([In, MarshalAs(UnmanagedType.BStr)] string URL, [In] int Flags, [In, MarshalAs(UnmanagedType.BStr)] string TargetFrameName, [In, MarshalAs(UnmanagedType.Struct)] ref object PostData, [In, MarshalAs(UnmanagedType.BStr)] string Headers, [In, Out] ref bool Processed);
}

