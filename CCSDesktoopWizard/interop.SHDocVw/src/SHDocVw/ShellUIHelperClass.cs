namespace SHDocVw
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, TypeLibType((short) 2), Guid("64AB4BB7-111E-11D1-8F79-00C04FC2FBE1"), ClassInterface((short) 0)]
    public class ShellUIHelperClass : IShellUIHelper, ShellUIHelper
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(5)]
        public virtual extern void AddChannel([In, MarshalAs(UnmanagedType.BStr)] string URL);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(6)]
        public virtual extern void AddDesktopComponent([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string Type, [In, MarshalAs(UnmanagedType.Struct)] ref object Left, [In, MarshalAs(UnmanagedType.Struct)] ref object Top, [In, MarshalAs(UnmanagedType.Struct)] ref object Width, [In, MarshalAs(UnmanagedType.Struct)] ref object Height);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(4)]
        public virtual extern void AddFavorite([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.Struct)] ref object Title);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), TypeLibFunc((short) 0x40), DispId(12)]
        public virtual extern void AutoCompleteAttach([In, MarshalAs(UnmanagedType.Struct)] ref object Reserved);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(10)]
        public virtual extern void AutoCompleteSaveForm([In, MarshalAs(UnmanagedType.Struct)] ref object Form);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(11)]
        public virtual extern void AutoScan([In, MarshalAs(UnmanagedType.BStr)] string strSearch, [In, MarshalAs(UnmanagedType.BStr)] string strFailureUrl, [In, MarshalAs(UnmanagedType.Struct)] ref object pvarTargetFrame);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(9)]
        public virtual extern void ImportExportFavorites([In] bool fImport, [In, MarshalAs(UnmanagedType.BStr)] string strImpExpPath);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(7)]
        public virtual extern bool IsSubscribed([In, MarshalAs(UnmanagedType.BStr)] string URL);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(8)]
        public virtual extern void NavigateAndFind([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string strQuery, [In, MarshalAs(UnmanagedType.Struct)] ref object varTargetFrame);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), TypeLibFunc((short) 0x40), DispId(3)]
        public virtual extern void RefreshOfflineDesktop();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), TypeLibFunc((short) 0x40), DispId(1)]
        public virtual extern void ResetFirstBootMode();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(2), TypeLibFunc((short) 0x40)]
        public virtual extern void ResetSafeMode();
        [return: MarshalAs(UnmanagedType.Struct)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(13)]
        public virtual extern object ShowBrowserUI([In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In, MarshalAs(UnmanagedType.Struct)] ref object pvarIn);
    }
}

