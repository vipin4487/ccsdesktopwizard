namespace SHDocVw
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [TypeLibType((short) 0x10), ComVisible(false)]
    public delegate void DWebBrowserEvents_FrameNavigateCompleteEventHandler([In, MarshalAs(UnmanagedType.BStr)] string URL);
}

