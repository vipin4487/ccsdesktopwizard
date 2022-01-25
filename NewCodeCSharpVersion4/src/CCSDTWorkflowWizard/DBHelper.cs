namespace CCSDTWorkflowWizard
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    internal class DBHelper
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

        private static string GetRedirectNumberXOML(int redirect_id)
        {
            object obj2 = null;
            string str = string.Empty;
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("usp_get_redirect_number_xoml", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@redirect_id ", redirect_id));
                    obj2 = command.ExecuteScalar();
                    if ((obj2 != null) && (obj2 != DBNull.Value))
                    {
                        str = (string) obj2;
                    }
                }
            }
            return str;
        }

        private static string GetScreenPopXOML(int business_unit_display_id)
        {
            object obj2 = null;
            string str = string.Empty;
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("usp_get_screenpop_xoml", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@business_unit_display_id ", business_unit_display_id));
                    obj2 = command.ExecuteScalar();
                    if ((obj2 != null) && (obj2 != DBNull.Value))
                    {
                        str = (string) obj2;
                    }
                }
            }
            return str;
        }

        private static void UpdateRedirectNumber(int redirect_id, string redirect_script_html, string redirect_script_xoml, int author_id)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("usp_update_redirect_number_htmlxoml", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@redirect_id ", redirect_id));
                    command.Parameters.Add(new SqlParameter("@redirect_script_html", redirect_script_html));
                    command.Parameters.Add(new SqlParameter("@redirect_script_xoml", redirect_script_xoml));
                    command.Parameters.Add(new SqlParameter("@author_id", author_id));
                    command.ExecuteNonQuery();
                }
            }
        }

        private static void UpdateScreenPop(int business_unit_display_id, string screenpop_script_html, string screenpop_script_xoml, int author_id)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("usp_update_screenpop_htmlxoml", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@business_unit_display_id ", business_unit_display_id));
                    command.Parameters.Add(new SqlParameter("@screenpop_script_html", screenpop_script_html));
                    command.Parameters.Add(new SqlParameter("@screenpop_script_xoml", screenpop_script_xoml));
                    command.Parameters.Add(new SqlParameter("@author_id", author_id));
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

