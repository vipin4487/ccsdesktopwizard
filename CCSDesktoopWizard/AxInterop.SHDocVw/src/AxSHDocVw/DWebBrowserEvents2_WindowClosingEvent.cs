namespace AxSHDocVw
{
    using System;

    public class DWebBrowserEvents2_WindowClosingEvent
    {
        public bool isChildWindow;
        public bool cancel;

        public DWebBrowserEvents2_WindowClosingEvent(bool isChildWindow, bool cancel)
        {
            this.isChildWindow = isChildWindow;
            this.cancel = cancel;
        }
    }
}

