namespace SHDocVw
{
    using System;
    using System.Collections;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.CustomMarshalers;

    [ComImport, TypeLibType((short) 0x1040), Guid("85CB6900-4D95-11CF-960C-0080C7F4EE85"), DefaultMember("Item")]
    public interface IShellWindows : IEnumerable
    {
        [DispId(0x60020000)]
        int Count { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x60020000)] get; }
        [return: MarshalAs(UnmanagedType.IDispatch)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0)]
        extern object Item([In, MarshalAs(UnmanagedType.Struct)] object index);
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType="", MarshalTypeRef=typeof(EnumeratorToEnumVariantMarshaler), MarshalCookie="")]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(-4)]
        extern IEnumerator GetEnumerator();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x60020003), TypeLibFunc((short) 0x40)]
        extern void Register([In, MarshalAs(UnmanagedType.IDispatch)] object pid, [In] int HWND, [In] int swClass, out int plCookie);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), TypeLibFunc((short) 0x40), DispId(0x60020004)]
        extern void RegisterPending([In] int lThreadId, [In, MarshalAs(UnmanagedType.Struct)] ref object pvarloc, [In, MarshalAs(UnmanagedType.Struct)] ref object pvarlocRoot, [In] int swClass, out int plCookie);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), TypeLibFunc((short) 0x40), DispId(0x60020005)]
        extern void Revoke([In] int lCookie);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), TypeLibFunc((short) 0x40), DispId(0x60020006)]
        extern void OnNavigate([In] int lCookie, [In, MarshalAs(UnmanagedType.Struct)] ref object pvarloc);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), TypeLibFunc((short) 0x40), DispId(0x60020007)]
        extern void OnActivated([In] int lCookie, [In] bool fActive);
        [return: MarshalAs(UnmanagedType.IDispatch)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), TypeLibFunc((short) 0x40), DispId(0x60020008)]
        extern object FindWindowSW([In, MarshalAs(UnmanagedType.Struct)] ref object pvarloc, [In, MarshalAs(UnmanagedType.Struct)] ref object pvarlocRoot, [In] int swClass, out int pHWND, [In] int swfwOptions);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), TypeLibFunc((short) 0x40), DispId(0x60020009)]
        extern void OnCreated([In] int lCookie, [In, MarshalAs(UnmanagedType.IUnknown)] object punk);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x6002000a), TypeLibFunc((short) 0x40)]
        extern void ProcessAttachDetach([In] bool fAttach);
    }
}

