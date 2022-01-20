namespace AxSHDocVw
{
    using System;

    public class DWebBrowserEvents2_BeforeNavigate2Event
    {
        public object pDisp;
        public object uRL;
        public object flags;
        public object targetFrameName;
        public object postData;
        public object headers;
        public bool cancel;

        public DWebBrowserEvents2_BeforeNavigate2Event(object pDisp, object uRL, object flags, object targetFrameName, object postData, object headers, bool cancel)
        {
            this.pDisp = pDisp;
            this.uRL = uRL;
            this.flags = flags;
            this.targetFrameName = targetFrameName;
            this.postData = postData;
            this.headers = headers;
            this.cancel = cancel;
        }
    }
}

