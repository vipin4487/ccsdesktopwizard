namespace CCSDTWorkflowLibrary
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public uint left;
        public uint top;
        public uint right;
        public uint bottom;
        public POINT Location
        {
            get => 
                new POINT((int) this.left, (int) this.top);
            set
            {
                this.right -= this.left - ((uint) value.x);
                this.bottom -= this.bottom - ((uint) value.y);
                this.left = (uint) value.x;
                this.top = (uint) value.y;
            }
        }
        public uint Width
        {
            get => 
                this.right - this.left;
            set => 
                this.right = this.left + value;
        }
        public uint Height
        {
            get => 
                this.bottom - this.top;
            set => 
                this.bottom = this.top + value;
        }
        public override string ToString()
        {
            object[] objArray1 = new object[] { this.left, ":", this.top, ":", this.right, ":", this.bottom };
            return string.Concat(objArray1);
        }
    }
}

