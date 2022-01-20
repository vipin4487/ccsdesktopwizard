namespace AxSHDocVw
{
    using System;

    public class DWebBrowserEvents2_UpdatePageStatusEvent
    {
        public object pDisp;
        public object nPage;
        public object fDone;

        public DWebBrowserEvents2_UpdatePageStatusEvent(object pDisp, object nPage, object fDone)
        {
            this.pDisp = pDisp;
            this.nPage = nPage;
            this.fDone = fDone;
        }
    }
}

