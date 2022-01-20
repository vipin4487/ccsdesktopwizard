namespace SHDocVw
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [TypeLibType((short) 0x10), ComVisible(false)]
    public delegate void DShellNameSpaceEvents_FavoritesSelectionChangeEventHandler([In] int cItems, [In] int hItem, [In, MarshalAs(UnmanagedType.BStr)] string strName, [In, MarshalAs(UnmanagedType.BStr)] string strUrl, [In] int cVisits, [In, MarshalAs(UnmanagedType.BStr)] string strDate, [In] int fAvailableOffline);
}

