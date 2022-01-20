namespace AxSHDocVw
{
    using System;

    public class DWebBrowserEvents2_NewWindow3Event
    {
        public object ppDisp;
        public bool cancel;
        public uint dwFlags;
        public string bstrUrlContext;
        public string bstrUrl;

        public DWebBrowserEvents2_NewWindow3Event(object ppDisp, bool cancel, uint dwFlags, string bstrUrlContext, string bstrUrl)
        {
            this.ppDisp = ppDisp;
            this.cancel = cancel;
            this.dwFlags = dwFlags;
            this.bstrUrlContext = bstrUrlContext;
            this.bstrUrl = bstrUrl;
        }
    }
}

