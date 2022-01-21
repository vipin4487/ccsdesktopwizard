using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

public class AppLogger
{
    private const int ERROR_SUCCESS = 0;
    private const int INFINITE = -1;
    private const int WAIT_TIMEOUT = 0x102;
    public IntPtr HKEY_LOCAL_MACHINE = new IntPtr(-2147483646);
    private static AppLogger instance = null;
    private static object syncRoot = new object();
    private Thread workerThread = null;
    private ManualResetEvent workerThreadStarted = new ManualResetEvent(false);
    private ManualResetEvent workerThreadStopped = new ManualResetEvent(false);
    private ManualResetEvent allDone = new ManualResetEvent(false);
    private Thread monitorThread = null;
    private ManualResetEvent monitorThreadStarted = new ManualResetEvent(false);
    private BlockingQueue syncBuffer = new BlockingQueue();
    private string logFilePath;
    private int maxLogFileSize;
    private int loggingLevel = 0;
    private int dbLoggingLevel = 0;
    private string dbConnectStr;
    private int dbAgentId;
    private string applicationType;
    private string logLevelKey;
    private string logLevelValue;
    private string dbLogLevelValue;
    private IntPtr keyChangedEvent = IntPtr.Zero;
    private int numOfFilesToArchive = 10;
    private bool echoOutputToConsole = false;
    private bool done = false;
    private static Hashtable registryKeyChangeHandlerMap = new Hashtable();

    [field: CompilerGenerated, DebuggerBrowsable(0)]
    public event onRegistryKeyChangeEventHandler onRegistryKeyChange;

    private AppLogger()
    {
    }

    private bool AddDBEventLogEntry(LogEntry logEntry) => 
        false;

    public static void AddMsg(string msg, LoggingLevelTypes severity)
    {
        if (!MyInstance.done && ((MyInstance.loggingLevel >= severity) | (MyInstance.dbLoggingLevel >= severity)))
        {
            int num = (int) severity;
            string[] textArray1 = new string[] { string.Format(DateTime.Now.ToString(), "MM/dd/yyyy HH:mm:ss.ffff("), Thread.CurrentThread.ManagedThreadId.ToString("D4"), ")", num.ToString("D3"), ": ", msg };
            msg = string.Concat(textArray1);
            MyInstance.syncBuffer.Enqueue(new LogEntry(severity, msg));
            if (MyInstance.echoOutputToConsole)
            {
                Console.WriteLine(msg);
            }
        }
    }

    private void ArchiveLogFile()
    {
        string str = string.Format(DateTime.Now.ToString(), "MMddyyyyHHmmssffff");
        string directoryName = Path.GetDirectoryName(this.logFilePath);
        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(this.logFilePath);
        try
        {
            File.Move(this.logFilePath, directoryName + @"\" + fileNameWithoutExtension + "_" + str + ".txt");
        }
        catch (IOException)
        {
            return;
        }
        catch (UnauthorizedAccessException)
        {
            return;
        }
        string searchPattern = fileNameWithoutExtension + "_*";
        string[] files = Directory.GetFiles(directoryName, searchPattern);
        if (files.Length > this.numOfFilesToArchive)
        {
            SortedList list = new SortedList();
            for (int i = 0; i <= (files.Length - 1); i++)
            {
                try
                {
                    list.Add(File.GetLastWriteTime(files[i]), files[i]);
                }
                catch (ArgumentException)
                {
                }
            }
            for (int j = 0; j <= ((list.Count - this.numOfFilesToArchive) - 1); j++)
            {
                try
                {
                    File.Delete(list.GetByIndex(j).ToString());
                }
                catch (IOException)
                {
                }
                catch (UnauthorizedAccessException)
                {
                }
            }
        }
    }

    public static void ChangeDBLoggingLevel(int newLevel)
    {
        MyInstance.dbLoggingLevel = newLevel;
    }

    public static void ChangeLoggingLevel(int newLevel)
    {
        MyInstance.loggingLevel = newLevel;
    }

    public static void ChangeNumLogFiles(int newNumOfFiles)
    {
        MyInstance.numOfFilesToArchive = newNumOfFiles;
    }

    [DllImport("kernel32", CharSet=CharSet.Auto, SetLastError=true, ExactSpelling=true)]
    private static extern void CloseHandle(IntPtr handle);
    [DllImport("kernel32", CharSet=CharSet.Auto, SetLastError=true, ExactSpelling=true)]
    private static extern IntPtr CreateEvent(IntPtr eventAttributes, bool manualReset, bool initialState, string name);
    public static void DumpObject(object theObj)
    {
        if (MyInstance.loggingLevel >= 100)
        {
            Type type = theObj.GetType();
            AddMsg("*********************************", LoggingLevelTypes.VerboseDebug);
            AddMsg("Dumping object type: " + type.FullName, LoggingLevelTypes.VerboseDebug);
            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            foreach (FieldInfo info in fields)
            {
                string msg = info.Name + "=";
                if (info.GetValue(theObj) > null)
                {
                    if (info.FieldType == typeof(string[,]))
                    {
                        msg = msg + "}";
                    }
                    else if (info.FieldType == typeof(string[]))
                    {
                        char[] chArray = info.GetValue(theObj).ToString().ToCharArray();
                        msg = msg + "{";
                        for (int i = 0; i <= (chArray.Length - 1); i++)
                        {
                            msg = msg + chArray[i].ToString();
                            if (i < (chArray.Length - 1))
                            {
                                msg = msg + ",";
                            }
                        }
                        msg = msg + "}";
                    }
                    else
                    {
                        if (MyInstance.loggingLevel >= 110)
                        {
                            if (info.FieldType == typeof(DataTable))
                            {
                                DumpTable((DataTable) info.GetValue(theObj));
                            }
                            else if (info.FieldType == typeof(ArrayList))
                            {
                                foreach (object obj2 in (ArrayList) info.GetValue(theObj))
                                {
                                    if (obj2 is DataTable)
                                    {
                                        DumpTable((DataTable) obj2);
                                    }
                                }
                            }
                        }
                        msg = msg + info.GetValue(theObj).ToString();
                    }
                }
                AddMsg(msg, LoggingLevelTypes.VerboseDebug);
            }
            AddMsg("*********************************", LoggingLevelTypes.VerboseDebug);
        }
    }

    private static void DumpTable(DataTable theTable)
    {
    }

    public static void ListenForRegistryKeyChanges(object caller, string handlerName)
    {
        try
        {
            object syncRoot = registryKeyChangeHandlerMap.SyncRoot;
            lock (syncRoot)
            {
                if (!registryKeyChangeHandlerMap.ContainsKey(caller))
                {
                    Delegate delegate2 = Delegate.CreateDelegate(MyInstance.GetType().GetEvent("onRegistryKeyChange").EventHandlerType, caller, handlerName);
                    MyInstance.onRegistryKeyChange += ((onRegistryKeyChangeEventHandler) delegate2);
                    registryKeyChangeHandlerMap.Add(caller, delegate2);
                }
            }
        }
        catch (Exception exception)
        {
            AddMsg("**** ERROR: (AppLogger.ListenForRegistryKeyChanges) " + exception.Message + "//" + exception.StackTrace.ToString(), LoggingLevelTypes.ApplicationExceptions);
        }
    }

    public static void LogToDB(string connectStr, string appType, LoggingLevelTypes logLevel = 10, int agentId = -1, string dbLogLevelKey = null)
    {
        MyInstance.dbConnectStr = connectStr;
        MyInstance.applicationType = appType;
        MyInstance.dbAgentId = agentId;
        MyInstance.dbLoggingLevel = (int) logLevel;
        MyInstance.dbLogLevelValue = dbLogLevelKey;
    }

    public static void RemoveOnAgentStatus(object caller)
    {
        object syncRoot = registryKeyChangeHandlerMap.SyncRoot;
        lock (syncRoot)
        {
            if (registryKeyChangeHandlerMap.ContainsKey(caller))
            {
                Delegate delegate2 = (Delegate) registryKeyChangeHandlerMap[caller];
                MyInstance.onRegistryKeyChange -= ((onRegistryKeyChangeEventHandler) delegate2);
            }
        }
    }

    private void RunLoggingThread()
    {
        try
        {
            FileInfo info = new FileInfo(this.logFilePath);
            FileStream stream = null;
            try
            {
                stream = new FileStream(this.logFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            }
            catch (IOException)
            {
                return;
            }
            catch (UnauthorizedAccessException)
            {
                return;
            }
            if ((this.logLevelKey > null) & (this.logLevelValue > null))
            {
                this.monitorThread = new Thread(new ThreadStart(this.RunRegistryMonitorThread));
                this.monitorThread.IsBackground = true;
                this.monitorThread.Start();
                this.monitorThreadStarted.WaitOne(0x3e8, false);
            }
            this.workerThreadStarted.Set();
            StreamWriter writer = new StreamWriter(stream);
            while (!this.done)
            {
                info.Refresh();
                if (info.Exists && (info.Length >= this.maxLogFileSize))
                {
                    writer.Close();
                    stream.Close();
                    this.ArchiveLogFile();
                    stream = new FileStream(this.logFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    writer = new StreamWriter(stream);
                }
                LogEntry logEntry = (LogEntry) MyInstance.syncBuffer.Dequeue();
                if ((logEntry.logMsg != null) && (logEntry.logMsg.Length > 0))
                {
                    if (MyInstance.loggingLevel >= logEntry.logSeverity)
                    {
                        writer.BaseStream.Seek(0L, SeekOrigin.End);
                        writer.WriteLine(logEntry.logMsg);
                        writer.Flush();
                    }
                    if (MyInstance.dbLoggingLevel >= logEntry.logSeverity)
                    {
                        this.AddDBEventLogEntry(logEntry);
                    }
                }
            }
            if (this.keyChangedEvent != IntPtr.Zero)
            {
                SetEvent(this.keyChangedEvent);
            }
            writer.Close();
            this.workerThreadStopped.Set();
        }
        catch (Exception exception3)
        {
            string source = "VCC Desktop Logger";
            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, "Application");
            }
            new EventLog { Source = source }.WriteEntry("VCC Desktop Logger has failed, error: " + exception3.Message + "//" + exception3.StackTrace.ToString(), EventLogEntryType.Warning, 0);
        }
    }

    private void RunRegistryMonitorThread()
    {
        try
        {
            StringBuilder builder = new StringBuilder(this.logLevelKey);
            if (Convert.ToInt32(ConfigurationManager.AppSettings["LogLevel"]) == 0)
            {
                StringBuilder builder2 = new StringBuilder(this.logLevelValue);
                int num4 = 0;
                if (Convert.ToInt32(ConfigurationManager.AppSettings["LogLevel"]) == 0)
                {
                    this.loggingLevel = num4;
                }
                IntPtr eventAttributes = (IntPtr) 1;
                this.keyChangedEvent = CreateEvent(eventAttributes, false, false, null);
                this.monitorThreadStarted.Set();
                while (!this.done)
                {
                    int num = Convert.ToInt32(ConfigurationManager.AppSettings["LogLevel"]);
                    if (WaitForSingleObject(this.keyChangedEvent, -1) != 0x102)
                    {
                        if (Convert.ToInt32(ConfigurationManager.AppSettings["LogLevel"]) == 0)
                        {
                            this.loggingLevel = num4;
                        }
                        if (this.dbLogLevelValue > null)
                        {
                            StringBuilder builder3 = new StringBuilder(this.dbLogLevelValue);
                            if (Convert.ToInt32(ConfigurationManager.AppSettings["LogLevel"]) == 0)
                            {
                                this.dbLoggingLevel = num4;
                            }
                        }
                        this.SignalOnRegistryKeyChange();
                    }
                }
                CloseHandle(this.keyChangedEvent);
            }
        }
        catch (Exception exception)
        {
            AddMsg("**** ERROR: (AppLogger.RunRegistryMonitorThread) " + exception.Message + "//" + exception.StackTrace.ToString(), LoggingLevelTypes.ApplicationExceptions);
        }
    }

    [DllImport("kernel32", CharSet=CharSet.Auto, SetLastError=true, ExactSpelling=true)]
    private static extern bool SetEvent(IntPtr handle);
    private void SignalOnRegistryKeyChange()
    {
        try
        {
            if (this.onRegistryKeyChange > null)
            {
                this.onRegistryKeyChange();
            }
        }
        catch (Exception exception)
        {
            AddMsg("**** ERROR: (AppLogger.SignalOnRegistryKeyChange) " + exception.Message + "//" + exception.StackTrace.ToString(), LoggingLevelTypes.ApplicationExceptions);
        }
    }

    public static void StartLogging(string filePath, int maximumSize, int logLevel, int numOfFilesToArchive = 10, bool echoToConsole = false)
    {
        MyInstance.logFilePath = filePath;
        MyInstance.maxLogFileSize = maximumSize;
        MyInstance.loggingLevel = logLevel;
        MyInstance.numOfFilesToArchive = numOfFilesToArchive;
        MyInstance.echoOutputToConsole = echoToConsole;
        MyInstance.workerThread = new Thread(new ThreadStart(MyInstance.RunLoggingThread));
        MyInstance.workerThread.IsBackground = true;
        MyInstance.workerThread.Start();
        MyInstance.workerThreadStarted.WaitOne(0x3e8, false);
    }

    public static void StartLogging(string filePath, int maximumSize, string logLevelKey, string logLevelValue, int numOfFilesToArchive = 10, bool echoToConsole = false)
    {
        MyInstance.logFilePath = filePath;
        MyInstance.maxLogFileSize = maximumSize;
        MyInstance.loggingLevel = 0;
        MyInstance.logLevelKey = logLevelKey;
        MyInstance.logLevelValue = logLevelValue;
        MyInstance.numOfFilesToArchive = numOfFilesToArchive;
        MyInstance.echoOutputToConsole = echoToConsole;
        MyInstance.workerThread = new Thread(new ThreadStart(MyInstance.RunLoggingThread));
        MyInstance.workerThread.IsBackground = true;
        MyInstance.workerThread.Start();
        MyInstance.workerThreadStarted.WaitOne(0x3e8, false);
    }

    public static void StopLogging()
    {
        MyInstance.done = true;
        MyInstance.syncBuffer.Enqueue(new LogEntry(LoggingLevelTypes.None, ""));
        MyInstance.workerThreadStopped.WaitOne(0x3e8, false);
    }

    [DllImport("kernel32", CharSet=CharSet.Auto, SetLastError=true, ExactSpelling=true)]
    private static extern int WaitForSingleObject(IntPtr handle, int timeOut);

    private static AppLogger MyInstance
    {
        get
        {
            if (instance == null)
            {
                object syncRoot = AppLogger.syncRoot;
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new AppLogger();
                    }
                }
            }
            return instance;
        }
    }

    public static int LogLevel =>
        MyInstance.loggingLevel;

    private class LogEntry
    {
        public string logMsg;
        public AppLogger.LoggingLevelTypes logSeverity;

        public LogEntry(AppLogger.LoggingLevelTypes severity, string msg)
        {
            this.logSeverity = severity;
            this.logMsg = msg;
        }
    }

    public enum LoggingLevelTypes
    {
        None = 0,
        ApplicationExceptions = 1,
        Errors = 5,
        Warnings = 10,
        Transactions = 20,
        Informational = 40,
        NormalDebug = 90,
        VerboseDebug = 100,
        HugeDebug = 110
    }

    public delegate void onRegistryKeyChangeEventHandler();
}

