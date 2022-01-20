namespace AxSHDocVw
{
    using System;

    public class DWebBrowserEvents2_NewWindow2Event
    {
        public object ppDisp;
        public bool cancel;

        public DWebBrowserEvents2_NewWindow2Event(object ppDisp, bool cancel)
        {
            this.ppDisp = ppDisp;
            this.cancel = cancel;
        }
    }
}

