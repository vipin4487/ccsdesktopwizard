namespace SHDocVw
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, Guid("55136806-B2DE-11D1-B9F2-00A0C98BC547"), TypeLibType((short) 0x1000), InterfaceType((short) 2)]
    public interface DShellNameSpaceEvents
    {
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(1)]
        extern void FavoritesSelectionChange([In] int cItems, [In] int hItem, [In, MarshalAs(UnmanagedType.BStr)] string strName, [In, MarshalAs(UnmanagedType.BStr)] string strUrl, [In] int cVisits, [In, MarshalAs(UnmanagedType.BStr)] string strDate, [In] int fAvailableOffline);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(2)]
        extern void SelectionChange();
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(3)]
        extern void DoubleClick();
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(4)]
        extern void Initialized();
    }
}

