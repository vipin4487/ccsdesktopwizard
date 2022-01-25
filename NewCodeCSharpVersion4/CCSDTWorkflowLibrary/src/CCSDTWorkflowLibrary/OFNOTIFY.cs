namespace CCSDTWorkflowLibrary
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct OFNOTIFY
    {
        public NMHDR hdr;
        public IntPtr OPENFILENAME;
        public IntPtr fileNameShareViolation;
    }
}

