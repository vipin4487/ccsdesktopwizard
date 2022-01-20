namespace AxSHDocVw
{
    using System;

    public class DWebBrowserEvents2_CommandStateChangeEvent
    {
        public int command;
        public bool enable;

        public DWebBrowserEvents2_CommandStateChangeEvent(int command, bool enable)
        {
            this.command = command;
            this.enable = enable;
        }
    }
}

