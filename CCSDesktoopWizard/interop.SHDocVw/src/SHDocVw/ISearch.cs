namespace SHDocVw
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, TypeLibType((short) 0x1050), Guid("BA9239A4-3DD5-11D2-BF8B-00C04FB93661")]
    public interface ISearch
    {
        [DispId(0x60020000)]
        string Title { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x60020000)] get; }
        [DispId(0x60020001)]
        string Id { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x60020001)] get; }
        [DispId(0x60020002)]
        string URL { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x60020002)] get; }
    }
}

