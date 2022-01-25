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

        public static string AddSingleQuotes(string sVal)
        {
            string str = string.Empty;
            if (!string.IsNullOrEmpty(sVal))
            {
                str = "'" + sVal + "'";
            }
            return str;
        }

        public static List<string> GetCallVariableNames()
        {
            List<string> callVariables = GetCallVariables();
            List<string> list2 = new List<string>();
            if (callVariables > null)
            {
                foreach (string str in callVariables)
                {
                    list2.Add(str);
                }
            }
            return list2;
        }

        public static List<string> GetCallVariables()
        {
            return GetScreenPopsAndCallVars();
        }

        public static List<string> GetScreenPopsAndCallVars()
        {
            List<string> callVariables;
            try
            {
                callVariables = new ScreenPopDBConnection().GetCallVariables();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return callVariables;
        }
    }
}

