namespace CCSDTWorkflowWizard
{
    using System;
    using System.Collections.Specialized;
    using System.IO;
    using System.Web;
    using System.Windows.Forms;

    internal static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Application.CompanyName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = Path.Combine(path, Application.ProductName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = Path.Combine(path, Application.ProductVersion);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
            path = path + @"\" + fileNameWithoutExtension + ".log";
            AppLogger.StartLogging(path, 0xf4240, 100, 10, false);
            NameValueCollection values = new NameValueCollection();
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            try
            {
                AppLogger.AddMsg("************* Main has started.", AppLogger.LoggingLevelTypes.NormalDebug);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                AppLogger.AddMsg("************* Calling Mainform .", AppLogger.LoggingLevelTypes.NormalDebug);
                MainForm mainForm = new MainForm();
                AppLogger.AddMsg("************* Back to main.", AppLogger.LoggingLevelTypes.NormalDebug);
                if (args.Length != 0)
                {
                    AppLogger.AddMsg("*************args.Length" + args.Length.ToString(), AppLogger.LoggingLevelTypes.NormalDebug);
                    string query = args[0];
                    values = HttpUtility.ParseQueryString(query);
                    AppLogger.AddMsg("*************queryString.IndexOfbusiness_unit_display_id" + query.IndexOf("business_unit_display_id").ToString(), AppLogger.LoggingLevelTypes.NormalDebug);
                    if (query.IndexOf("redirect_id") >= 0)
                    {
                        num = Convert.ToInt32(values["redirect_id"]);
                        num4 = Convert.ToInt32(values["business_unit_id"]);
                    }
                    else if (query.IndexOf("business_unit_display_id") >= 0)
                    {
                        num2 = Convert.ToInt32(values["business_unit_display_id"]);
                        num4 = Convert.ToInt32(values["business_unit_id"]);
                    }
                    else if (query.IndexOf("aux_code_id") >= 0)
                    {
                        num3 = Convert.ToInt32(values["aux_code_id"]);
                        num4 = Convert.ToInt32(values["business_unit_id"]);
                    }
                }
                mainForm.redirect_id = num;
                mainForm.business_unit_display_id = num2;
                mainForm.aux_code_id = num3;
                mainForm.business_unit_id = num4;
                mainForm.logFilePath = path;
                AppLogger.AddMsg("Before Application.Run is called", AppLogger.LoggingLevelTypes.NormalDebug);
                Application.Run(mainForm);
                AppLogger.AddMsg("After Application.Run is called", AppLogger.LoggingLevelTypes.NormalDebug);
            }
            catch (Exception exception)
            {
                AppLogger.AddMsg("**** ERROR: (Program.Main) " + exception.Message + "//" + exception.StackTrace.ToString(), AppLogger.LoggingLevelTypes.ApplicationExceptions);
            }
        }
    }
}

