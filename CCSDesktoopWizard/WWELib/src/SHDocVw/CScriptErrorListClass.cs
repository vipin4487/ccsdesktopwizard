namespace SHDocVw
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, Guid("EFD01300-160F-11D2-BB2E-00805FF7EFCA"), TypeLibType((short) 0x12), ClassInterface((short) 0)]
    public class CScriptErrorListClass : IScriptErrorList, CScriptErrorList
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(10)]
        public virtual extern void advanceError();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(12)]
        public virtual extern int canAdvanceError();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(13)]
        public virtual extern int canRetreatError();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x17)]
        public virtual extern int getAlwaysShowLockState();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x13)]
        public virtual extern int getDetailsPaneOpen();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(15)]
        public virtual extern int getErrorChar();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x10)]
        public virtual extern int getErrorCode();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(14)]
        public virtual extern int getErrorLine();
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x11)]
        public virtual extern string getErrorMsg();
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x12)]
        public virtual extern string getErrorUrl();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x15)]
        public virtual extern int getPerErrorDisplay();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(11)]
        public virtual extern void retreatError();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(20)]
        public virtual extern void setDetailsPaneOpen(int fDetailsPaneOpen);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x16)]
        public virtual extern void setPerErrorDisplay(int fPerErrorDisplay);
    }
}

