﻿namespace CCSDTWorkflowLibrary
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int x;
        public int y;
        public POINT(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public POINT(Point point)
        {
            this.x = point.X;
            this.y = point.Y;
        }
    }
}

