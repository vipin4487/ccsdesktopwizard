namespace SHDocVw
{
    using System;
    using System.Runtime.InteropServices;

    [ClassInterface(ClassInterfaceType.None)]
    public sealed class DShellWindowsEvents_SinkHelper : DShellWindowsEvents
    {
        public DShellWindowsEvents_WindowRevokedEventHandler m_WindowRevokedDelegate = null;
        public DShellWindowsEvents_WindowRegisteredEventHandler m_WindowRegisteredDelegate = null;
        public int m_dwCookie = 0;

        internal DShellWindowsEvents_SinkHelper()
        {
        }

        public override void WindowRegistered(int num1)
        {
            if (this.m_WindowRegisteredDelegate != null)
            {
                this.m_WindowRegisteredDelegate(num1);
            }
        }

        public override void WindowRevoked(int num1)
        {
            if (this.m_WindowRevokedDelegate != null)
            {
                this.m_WindowRevokedDelegate(num1);
            }
        }
    }
}

