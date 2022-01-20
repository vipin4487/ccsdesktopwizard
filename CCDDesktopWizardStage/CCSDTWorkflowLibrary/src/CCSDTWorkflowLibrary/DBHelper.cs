namespace CCSDTWorkflowLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using WWELib;

    public class DBHelper
    {
        private static AppSettingsReader _ConfigurationAppSettings = new AppSettingsReader();
        private static string _ConnectionString = ((string) _ConfigurationAppSettings.GetValue("DBConnectionString", typeof(string)));
        private static bool _doCallVarRefresh = false;

        public static string AddSingleQuotes(string sVal)
        {
            string str = string.Empty;
            if (!string.IsNullOrEmpty(sVal))
            {
                str = "'" + sVal + "'";
            }
            return str;
        }

        public static bool DoCallVariableRefresh()
        {
            _doCallVarRefresh = true;
            return _doCallVarRefresh;
        }

        public static List<string> GetCallVariableNames()
        {
            List<string> callVariables = GetCallVariables();
            List<string> list2 = new List<string>();
            if (callVariables != null)
            {
                foreach (string str in callVariables)
                {
                    list2.Add(str);
                }
            }
            return list2;
        }

        public static List<string> GetCallVariables() => 
            GetScreenPopsAndCallVars();

        public static List<string> GetScreenPopsAndCallVars()
        {
            List<string> callVariables;
            try
            {
                callVariables = new ScreenPopDBConnection().GetCallVariables();
            }
            catch (Exception exception1)
            {
                throw exception1;
            }
            return callVariables;
        }

        public static void InserCallVariableData(string CallVariable)
        {
            try
            {
                new ScreenPopDBConnection().InsertCallVariable(CallVariable);
            }
            catch (Exception exception1)
            {
                throw exception1;
            }
        }

        public static bool IsCallVariableExists(string value)
        {
            bool flag = false;
            try
            {
                List<string> callVariables = new ScreenPopDBConnection().GetCallVariables();
                if (callVariables != null)
                {
                    foreach (string str in callVariables)
                    {
                        if (str == value)
                        {
                            flag = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception exception1)
            {
                throw exception1;
            }
            return flag;
        }

        public static bool IsCallVariableRefresh() => 
            _doCallVarRefresh;
    }
}

