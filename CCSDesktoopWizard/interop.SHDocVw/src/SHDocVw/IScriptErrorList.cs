namespace SHDocVw
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, Guid("F3470F24-15FD-11D2-BB2E-00805FF7EFCA"), TypeLibType((short) 0x1050)]
    public interface IScriptErrorList
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(10)]
        extern void advanceError();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(11)]
        extern void retreatError();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(12)]
        extern int canAdvanceError();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(13)]
        extern int canRetreatError();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(14)]
        extern int getErrorLine();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(15)]
        extern int getErrorChar();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x10)]
        extern int getErrorCode();
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x11)]
        extern string getErrorMsg();
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x12)]
        extern string getErrorUrl();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x17)]
        extern int getAlwaysShowLockState();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x13)]
        extern int getDetailsPaneOpen();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(20)]
        extern void setDetailsPaneOpen(int fDetailsPaneOpen);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x15)]
        extern int getPerErrorDisplay();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x16)]
        extern void setPerErrorDisplay(int fPerErrorDisplay);
    }
}

