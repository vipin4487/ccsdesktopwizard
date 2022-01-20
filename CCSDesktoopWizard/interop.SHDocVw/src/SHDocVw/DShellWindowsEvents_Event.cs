namespace SHDocVw
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComVisible(false), ComEventInterface(typeof(DShellWindowsEvents), typeof(DShellWindowsEvents_EventProvider)), TypeLibType((short) 0x10)]
    public interface DShellWindowsEvents_Event
    {
        event DShellWindowsEvents_WindowRegisteredEventHandler WindowRegistered;

        event DShellWindowsEvents_WindowRevokedEventHandler WindowRevoked;
    }
}

