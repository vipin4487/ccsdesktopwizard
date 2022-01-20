namespace SHDocVw
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, Guid("729FE2F8-1EA8-11D1-8F85-00C04FC2FBE1"), TypeLibType((short) 0x1040)]
    public interface IShellUIHelper
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), TypeLibFunc((short) 0x40), DispId(1)]
        extern void ResetFirstBootMode();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), TypeLibFunc((short) 0x40), DispId(2)]
        extern void ResetSafeMode();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(3), TypeLibFunc((short) 0x40)]
        extern void RefreshOfflineDesktop();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(4)]
        extern void AddFavorite([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.Struct)] ref object Title);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(5)]
        extern void AddChannel([In, MarshalAs(UnmanagedType.BStr)] string URL);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(6)]
        extern void AddDesktopComponent([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string Type, [In, MarshalAs(UnmanagedType.Struct)] ref object Left, [In, MarshalAs(UnmanagedType.Struct)] ref object Top, [In, MarshalAs(UnmanagedType.Struct)] ref object Width, [In, MarshalAs(UnmanagedType.Struct)] ref object Height);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(7)]
        extern bool IsSubscribed([In, MarshalAs(UnmanagedType.BStr)] string URL);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(8)]
        extern void NavigateAndFind([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string strQuery, [In, MarshalAs(UnmanagedType.Struct)] ref object varTargetFrame);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(9)]
        extern void ImportExportFavorites([In] bool fImport, [In, MarshalAs(UnmanagedType.BStr)] string strImpExpPath);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(10)]
        extern void AutoCompleteSaveForm([In, MarshalAs(UnmanagedType.Struct)] ref object Form);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(11)]
        extern void AutoScan([In, MarshalAs(UnmanagedType.BStr)] string strSearch, [In, MarshalAs(UnmanagedType.BStr)] string strFailureUrl, [In, MarshalAs(UnmanagedType.Struct)] ref object pvarTargetFrame);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(12), TypeLibFunc((short) 0x40)]
        extern void AutoCompleteAttach([In, MarshalAs(UnmanagedType.Struct)] ref object Reserved);
        [return: MarshalAs(UnmanagedType.Struct)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(13)]
        extern object ShowBrowserUI([In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In, MarshalAs(UnmanagedType.Struct)] ref object pvarIn);
    }
}

