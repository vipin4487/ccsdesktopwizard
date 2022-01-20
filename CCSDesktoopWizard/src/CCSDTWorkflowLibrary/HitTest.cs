namespace CCSDTWorkflowLibrary
{
    using System;

    public enum HitTest
    {
        HTERROR = -2,
        HTTRANSPARENT = -1,
        HTNOWHERE = 0,
        HTCLIENT = 1,
        HTCAPTION = 2,
        HTSYSMENU = 3,
        HTGROWBOX = 4,
        HTSIZE = 4,
        HTMENU = 5,
        HTHSCROLL = 6,
        HTVSCROLL = 7,
        HTMINBUTTON = 8,
        HTMAXBUTTON = 9,
        HTLEFT = 10,
        HTRIGHT = 11,
        HTTOP = 12,
        HTTOPLEFT = 13,
        HTTOPRIGHT = 14,
        HTBOTTOM = 15,
        HTBOTTOMLEFT = 0x10,
        HTBOTTOMRIGHT = 0x11,
        HTBORDER = 0x12,
        HTREDUCE = 8,
        HTZOOM = 9,
        HTSIZEFIRST = 10,
        HTSIZELAST = 0x11,
        HTOBJECT = 0x13,
        HTCLOSE = 20,
        HTHELP = 0x15
    }
}

