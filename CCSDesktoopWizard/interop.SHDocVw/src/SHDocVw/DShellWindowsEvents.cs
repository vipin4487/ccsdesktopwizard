namespace SHDocVw
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, TypeLibType((short) 0x1000), InterfaceType((short) 2), Guid("FE4106E0-399A-11D0-A48C-00A0C90A8F39")]
    public interface DShellWindowsEvents
    {
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(200)]
        extern void WindowRegistered([In] int lCookie);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0xc9)]
        extern void WindowRevoked([In] int lCookie);
    }
}

