namespace WWELib
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public class ScreenPopDBConnection
    {
        public List<string> GetCallVariables()
        {
            List<string> list;
            LogWriter writer = new LogWriter("start" + DateTime.Now.ToString());
            ComModelCrud crud = new ComModelCrud();
            string host = ConfigurationManager.AppSettings["host"];
            int port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            string clientName = ConfigurationManager.AppSettings["clientName"];
            string userName = ConfigurationManager.AppSettings["userName"];
            string password = ConfigurationManager.AppSettings["password"];
            string str5 = ConfigurationManager.AppSettings["SipServer"];
            string folderName = ConfigurationManager.AppSettings["FolderNameBU"];
            string str7 = ConfigurationManager.AppSettings["SectionTserver"];
            string str8 = ConfigurationManager.AppSettings["DeviceName"];
            crud.Initialization(host, port, clientName, userName, password);
            crud.Open();
            try
            {
                list = crud.RequestBUNamesfromFolder(folderName);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                crud.Close();
            }
            writer.LogWrite("End" + DateTime.Now.ToString());
            return list;
        }

        public BUSINESS_UNIT_DISPLAY GetScreenPopDefinition(int screenPopRecordId)
        {
            BUSINESS_UNIT_DISPLAY business_unit_display;
            GetScreepopdataDataContext context = new GetScreepopdataDataContext();
            try
            {
                <>c__DisplayClass1_0 class_;
                ParameterExpression expression;
                ParameterExpression[] parameters = new ParameterExpression[] { expression };
                business_unit_display = context.BUSINESS_UNIT_DISPLAYs.Where<BUSINESS_UNIT_DISPLAY>(Expression.Lambda<Func<BUSINESS_UNIT_DISPLAY, bool>>(Expression.Equal(Expression.Property(expression = Expression.Parameter(typeof(BUSINESS_UNIT_DISPLAY), "p"), (MethodInfo) methodof(BUSINESS_UNIT_DISPLAY.get_Business_Unit_Display_ID)), Expression.Field(Expression.Constant(class_, typeof(<>c__DisplayClass1_0)), fieldof(<>c__DisplayClass1_0.screenPopRecordId))), parameters)).Single<BUSINESS_UNIT_DISPLAY>();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return business_unit_display;
        }

        public void UpdateScreenPop(int screenPopRecordId, string screenPopScriptHtml, string screenPopScriptXoml)
        {
            try
            {
                new GetScreepopdataDataContext().usp_update_screenpop_htmlxoml(new int?(screenPopRecordId), screenPopScriptHtml, screenPopScriptXoml);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}

