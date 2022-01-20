namespace SHDocVw
{
    using System.Runtime.InteropServices;

    [ComImport, Guid("D30C1661-CDAF-11D0-8A3E-00C04FC9E26E"), CoClass(typeof(ShellBrowserWindowClass))]
    public interface ShellBrowserWindow : IWebBrowser2, DWebBrowserEvents2_Event
    {
    }
}

