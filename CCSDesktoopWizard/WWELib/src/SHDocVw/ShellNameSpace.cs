namespace SHDocVw
{
    using System.Runtime.InteropServices;

    [ComImport, Guid("E572D3C9-37BE-4AE2-825D-D521763E3108"), CoClass(typeof(ShellNameSpaceClass))]
    public interface ShellNameSpace : IShellNameSpace, DShellNameSpaceEvents_Event
    {
    }
}

