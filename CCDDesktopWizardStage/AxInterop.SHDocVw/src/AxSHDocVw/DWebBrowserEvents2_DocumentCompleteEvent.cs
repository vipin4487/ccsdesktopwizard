namespace AxSHDocVw
{
    using System;

    public class DWebBrowserEvents2_DocumentCompleteEvent
    {
        public object pDisp;
        public object uRL;

        public DWebBrowserEvents2_DocumentCompleteEvent(object pDisp, object uRL)
        {
            this.pDisp = pDisp;
            this.uRL = uRL;
        }
    }
}

