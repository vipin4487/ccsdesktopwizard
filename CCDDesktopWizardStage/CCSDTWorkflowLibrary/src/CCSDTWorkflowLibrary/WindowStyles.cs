﻿namespace CCSDTWorkflowLibrary
{
    using System;

    public enum WindowStyles : long
    {
        WS_OVERLAPPED = 0L,
        WS_POPUP = 0x80000000L,
        WS_CHILD = 0x40000000L,
        WS_MINIMIZE = 0x20000000L,
        WS_VISIBLE = 0x10000000L,
        WS_DISABLED = 0x8000000L,
        WS_CLIPSIBLINGS = 0x4000000L,
        WS_CLIPCHILDREN = 0x2000000L,
        WS_MAXIMIZE = 0x1000000L,
        WS_CAPTION = 0xc00000L,
        WS_BORDER = 0x800000L,
        WS_DLGFRAME = 0x400000L,
        WS_VSCROLL = 0x200000L,
        WS_HSCROLL = 0x100000L,
        WS_SYSMENU = 0x80000L,
        WS_THICKFRAME = 0x40000L,
        WS_GROUP = 0x20000L,
        WS_TABSTOP = 0x10000L,
        WS_MINIMIZEBOX = 0x20000L,
        WS_MAXIMIZEBOX = 0x10000L,
        WS_TILED = 0L,
        WS_ICONIC = 0x20000000L,
        WS_SIZEBOX = 0x40000L,
        WS_POPUPWINDOW = 0x80880000L,
        WS_OVERLAPPEDWINDOW = 0xcf0000L,
        WS_TILEDWINDOW = 0xcf0000L,
        WS_CHILDWINDOW = 0x40000000L
    }
}
