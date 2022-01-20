namespace AxSHDocVw
{
    using System;

    public class DWebBrowserEvents2_ProgressChangeEvent
    {
        public int progress;
        public int progressMax;

        public DWebBrowserEvents2_ProgressChangeEvent(int progress, int progressMax)
        {
            this.progress = progress;
            this.progressMax = progressMax;
        }
    }
}

