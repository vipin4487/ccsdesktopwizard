namespace WWELib
{
    using System;
    using System.IO;
    using System.Reflection;

    public class LogWriter
    {
        private string m_exePath = string.Empty;

        public LogWriter(string logMessage)
        {
            this.LogWrite(logMessage);
        }

        public void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("  :");
                txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception)
            {
            }
        }

        public void LogWrite(string logMessage)
        {
            this.m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                using (StreamWriter writer = File.AppendText(this.m_exePath + @"\log.txt"))
                {
                    this.Log(logMessage, writer);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}

