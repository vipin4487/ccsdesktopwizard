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
            object[] objArray1 = new object[9];
            objArray1[0] = this.x;
            objArray1[1] = ":";
            objArray1[2] = this.y;
            objArray1[3] = ":";
            objArray1[4] = this.cx;
            objArray1[5] = ":";
            objArray1[6] = this.cy;
            objArray1[7] = ":";
            objArray1[8] = this.flags.ToString();
            return string.Concat(objArray1);
        }
    }
}

