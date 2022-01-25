namespace CCSDTWorkflowLibrary
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct WINDOWPOS
    {
        public IntPtr hwnd;
        public IntPtr hwndAfter;
        public int x;
        public int y;
        public int cx;
        public int cy;
        public uint flags;
        public override string ToString()
        {
            object[] objArray1 = new object[] { this.x, ":", this.y, ":", this.cx, ":", this.cy, ":", this.flags.ToString() };
            return string.Concat(objArray1);
        }
    }
}

