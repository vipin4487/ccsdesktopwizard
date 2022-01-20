namespace SHDocVw
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, ClassInterface((short) 0), ComSourceInterfaces("SHDocVw.DShellNameSpaceEvents\0"), Guid("55136805-B2DE-11D1-B9F2-00A0C98BC547"), TypeLibType((short) 2)]
    public class ShellNameSpaceClass : IShellNameSpace, ShellNameSpace, DShellNameSpaceEvents_Event
    {
        public virtual event DShellNameSpaceEvents_DoubleClickEventHandler DoubleClick;

        public virtual event DShellNameSpaceEvents_FavoritesSelectionChangeEventHandler FavoritesSelectionChange;

        public virtual event DShellNameSpaceEvents_InitializedEventHandler Initialized;

        public virtual event DShellNameSpaceEvents_SelectionChangeEventHandler SelectionChange;

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(11)]
        public virtual extern bool CreateSubscriptionForSelection();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(12)]
        public virtual extern bool DeleteSubscriptionForSelection();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x19)]
        public virtual extern void Expand([In, MarshalAs(UnmanagedType.Struct)] object var, int iDepth);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(7)]
        public virtual extern void Export();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(6)]
        public virtual extern void Import();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(8)]
        public virtual extern void InvokeContextMenuCommand([In, MarshalAs(UnmanagedType.BStr)] string strCommand);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(2)]
        public virtual extern void MoveSelectionDown();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(9)]
        public virtual extern void MoveSelectionTo();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(1)]
        public virtual extern void MoveSelectionUp();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(4)]
        public virtual extern void NewFolder();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(3)]
        public virtual extern void ResetSort();
        [return: MarshalAs(UnmanagedType.IDispatch)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x18)]
        public virtual extern object SelectedItems();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(13)]
        public virtual extern void SetRoot([In, MarshalAs(UnmanagedType.BStr)] string bstrFullPath);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x17)]
        public virtual extern void SetViewType([In] int iType);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(5)]
        public virtual extern void Synchronize();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x1a)]
        public virtual extern void UnselectAll();

        [DispId(10)]
        public virtual bool SubscriptionsEnabled { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(10)] get; }

        [DispId(14)]
        public virtual int EnumOptions { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(14)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(14)] set; }

        [DispId(15)]
        public virtual object SelectedItem { [return: MarshalAs(UnmanagedType.IDispatch)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(15)] get; [param: In, MarshalAs(UnmanagedType.IDispatch)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(15)] set; }

        [DispId(0x10)]
        public virtual object Root { [return: MarshalAs(UnmanagedType.Struct)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x10)] get; [param: In, MarshalAs(UnmanagedType.Struct)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x10)] set; }

        [DispId(0x11)]
        public virtual int Depth { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x11)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x11)] set; }

        [DispId(0x12)]
        public virtual uint Mode { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x12)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x12)] set; }

        [DispId(0x13)]
        public virtual uint Flags { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x13)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x13)] set; }

        [DispId(20)]
        public virtual uint TVFlags { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(20)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(20)] set; }

        [DispId(0x15)]
        public virtual string Columns { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x15)] get; [param: In, MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x15)] set; }

        [DispId(0x16)]
        public virtual int CountViewTypes { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x16)] get; }

        [DispId(10)]
        public virtual bool SHDocVw.IShellNameSpace.SubscriptionsEnabled { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(10)] get; }

        [DispId(14)]
        public virtual int SHDocVw.IShellNameSpace.EnumOptions { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(14)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(14)] set; }

        [DispId(15)]
        public virtual object SHDocVw.IShellNameSpace.SelectedItem { [return: MarshalAs(UnmanagedType.IDispatch)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(15)] get; [param: In, MarshalAs(UnmanagedType.IDispatch)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(15)] set; }

        [DispId(0x10)]
        public virtual object SHDocVw.IShellNameSpace.Root { [return: MarshalAs(UnmanagedType.Struct)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x10)] get; [param: In, MarshalAs(UnmanagedType.Struct)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x10)] set; }

        [DispId(0x11)]
        public virtual int SHDocVw.IShellNameSpace.Depth { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x11)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x11)] set; }

        [DispId(0x12)]
        public virtual uint SHDocVw.IShellNameSpace.Mode { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x12)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x12)] set; }

        [DispId(0x13)]
        public virtual uint SHDocVw.IShellNameSpace.Flags { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x13)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x13)] set; }

        [DispId(20)]
        public virtual uint SHDocVw.IShellNameSpace.TVFlags { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(20)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(20)] set; }

        [DispId(0x15)]
        public virtual string SHDocVw.IShellNameSpace.Columns { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x15)] get; [param: In, MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x15)] set; }

        [DispId(0x16)]
        public virtual int SHDocVw.IShellNameSpace.CountViewTypes { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x16)] get; }
    }
}

