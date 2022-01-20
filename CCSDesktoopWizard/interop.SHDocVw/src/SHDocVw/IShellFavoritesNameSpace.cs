namespace SHDocVw
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, TypeLibType((short) 0x1050), Guid("55136804-B2DE-11D1-B9F2-00A0C98BC547")]
    public interface IShellFavoritesNameSpace
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(1)]
        extern void MoveSelectionUp();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(2)]
        extern void MoveSelectionDown();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(3)]
        extern void ResetSort();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(4)]
        extern void NewFolder();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(5)]
        extern void Synchronize();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(6)]
        extern void Import();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(7)]
        extern void Export();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(8)]
        extern void InvokeContextMenuCommand([In, MarshalAs(UnmanagedType.BStr)] string strCommand);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(9)]
        extern void MoveSelectionTo();
        [DispId(10)]
        bool SubscriptionsEnabled { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(10)] get; }
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(11)]
        extern bool CreateSubscriptionForSelection();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(12)]
        extern bool DeleteSubscriptionForSelection();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(13)]
        extern void SetRoot([In, MarshalAs(UnmanagedType.BStr)] string bstrFullPath);
    }
}

