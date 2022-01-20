namespace SHDocVw
{
    using System.Runtime.InteropServices;

    [ComImport, Guid("85CB6900-4D95-11CF-960C-0080C7F4EE85"), CoClass(typeof(ShellWindowsClass))]
    public interface ShellWindows : IShellWindows, DShellWindowsEvents_Event
    {
    }
}

