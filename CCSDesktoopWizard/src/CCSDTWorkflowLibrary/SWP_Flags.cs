﻿namespace CCSDTWorkflowLibrary
{
    using System;

    [Flags]
    public enum SWP_Flags
    {
        SWP_NOSIZE = 1,
        SWP_NOMOVE = 2,
        SWP_NOZORDER = 4,
        SWP_NOACTIVATE = 0x10,
        SWP_FRAMECHANGED = 0x20,
        SWP_SHOWWINDOW = 0x40,
        SWP_HIDEWINDOW = 0x80,
        SWP_NOOWNERZORDER = 0x200,
        SWP_DRAWFRAME = 0x20,
        SWP_NOREPOSITION = 0x200
    }
}

