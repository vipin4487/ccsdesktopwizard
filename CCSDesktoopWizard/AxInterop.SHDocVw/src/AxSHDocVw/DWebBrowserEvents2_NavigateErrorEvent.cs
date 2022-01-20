namespace AxSHDocVw
{
    using System;

    public class DWebBrowserEvents2_NavigateErrorEvent
    {
        public object pDisp;
        public object uRL;
        public object frame;
        public object statusCode;
        public bool cancel;

        public DWebBrowserEvents2_NavigateErrorEvent(object pDisp, object uRL, object frame, object statusCode, bool cancel)
        {
            this.pDisp = pDisp;
            this.uRL = uRL;
            this.frame = frame;
            this.statusCode = statusCode;
            this.cancel = cancel;
        }
    }
}

