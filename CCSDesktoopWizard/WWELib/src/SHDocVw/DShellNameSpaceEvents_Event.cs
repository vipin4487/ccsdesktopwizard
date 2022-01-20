namespace SHDocVw
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComEventInterface(typeof(DShellNameSpaceEvents), typeof(DShellNameSpaceEvents_EventProvider)), TypeLibType((short) 0x10), ComVisible(false)]
    public interface DShellNameSpaceEvents_Event
    {
        event DShellNameSpaceEvents_DoubleClickEventHandler DoubleClick;

        event DShellNameSpaceEvents_FavoritesSelectionChangeEventHandler FavoritesSelectionChange;

        event DShellNameSpaceEvents_InitializedEventHandler Initialized;

        event DShellNameSpaceEvents_SelectionChangeEventHandler SelectionChange;
    }
}

