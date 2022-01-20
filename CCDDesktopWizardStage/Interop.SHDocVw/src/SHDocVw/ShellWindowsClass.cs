namespace SHDocVw
{
    using System;
    using System.Collections;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.CustomMarshalers;

    [ComImport, ClassInterface((short) 0), ComSourceInterfaces("SHDocVw.DShellWindowsEvents\0"), TypeLibType((short) 2), Guid("9BA05972-F6A8-11CF-A442-00A0C90A8F39"), DefaultMember("Item")]
    public class ShellWindowsClass : IShellWindows, ShellWindows, DShellWindowsEvents_Event, IEnumerable
    {
        public virtual event DShellWindowsEvents_WindowRegisteredEventHandler WindowRegistered;

        public virtual event DShellWindowsEvents_WindowRevokedEventHandler WindowRevoked;

        [return: MarshalAs(UnmanagedType.IDispatch)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x60020008), TypeLibFunc((short) 0x40)]
        public virtual extern object FindWindowSW([In, MarshalAs(UnmanagedType.Struct)] ref object pvarloc, [In, MarshalAs(UnmanagedType.Struct)] ref object pvarlocRoot, [In] int swClass, out int pHWND, [In] int swfwOptions);
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType="", MarshalTypeRef=typeof(EnumeratorToEnumVariantMarshaler), MarshalCookie="")]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(-4)]
        public virtual extern IEnumerator GetEnumerator();
        [return: MarshalAs(UnmanagedType.IDispatch)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0)]
        public virtual extern object Item([In, MarshalAs(UnmanagedType.Struct)] object index);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), TypeLibFunc((short) 0x40), DispId(0x60020007)]
        public virtual extern void OnActivated([In] int lCookie, [In] bool fActive);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), TypeLibFunc((short) 0x40), DispId(0x60020009)]
        public virtual extern void OnCreated([In] int lCookie, [In, MarshalAs(UnmanagedType.IUnknown)] object punk);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x60020006), TypeLibFunc((short) 0x40)]
        public virtual extern void OnNavigate([In] int lCookie, [In, MarshalAs(UnmanagedType.Struct)] ref object pvarloc);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x6002000a), TypeLibFunc((short) 0x40)]
        public virtual extern void ProcessAttachDetach([In] bool fAttach);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), TypeLibFunc((short) 0x40), DispId(0x60020003)]
        public virtual extern void Register([In, MarshalAs(UnmanagedType.IDispatch)] object pid, [In] int HWND, [In] int swClass, out int plCookie);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), TypeLibFunc((short) 0x40), DispId(0x60020004)]
        public virtual extern void RegisterPending([In] int lThreadId, [In, MarshalAs(UnmanagedType.Struct)] ref object pvarloc, [In, MarshalAs(UnmanagedType.Struct)] ref object pvarlocRoot, [In] int swClass, out int plCookie);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), TypeLibFunc((short) 0x40), DispId(0x60020005)]
        public virtual extern void Revoke([In] int lCookie);

        [DispId(0x60020000)]
        public virtual int Count { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x60020000)] get; }

        [DispId(0x60020000)]
        public virtual int SHDocVw.IShellWindows.Count { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x60020000)] get; }
    }
}

