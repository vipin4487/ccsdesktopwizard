namespace SHDocVw
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [TypeLibType((short) 0x10), ComVisible(false)]
    public delegate void DWebBrowserEvents2_UpdatePageStatusEventHandler([In, MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In, MarshalAs(UnmanagedType.Struct)] ref object nPage, [In, MarshalAs(UnmanagedType.Struct)] ref object fDone);
}

