namespace WWELib
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    public class ScreenPopDBConnection
    {
        public List<string> GetCallVariables()
        {
            List<string> callVariablesFromDB;
            LogWriter writer = new LogWriter("start" + DateTime.Now.ToString());
            string folderName = ConfigurationManager.AppSettings["FolderNameBU"];
            try
            {
                try
                {
                    callVariablesFromDB = this.GetCallVariablesFromDB(folderName);
                }
                catch (Exception exception1)
                {
                    throw exception1;
                }
            }
            finally
            {
            }
            writer.LogWrite("End" + DateTime.Now.ToString());
            return callVariablesFromDB;
        }

        private List<string> GetCallVariablesFromDB(string folderName)
        {
            GetScreepopdataDataContext context = new GetScreepopdataDataContext();
            List<string> list = null;
            try
            {
                ParameterExpression expression = Expression.Parameter(typeof(CALL_VARIABLE), "p");
                ParameterExpression[] parameters = new ParameterExpression[] { expression };
                IQueryable<CALL_VARIABLE> source = context.CALL_VARIABLEs.Where<CALL_VARIABLE>(Expression.Lambda<Func<CALL_VARIABLE, bool>>(Expression.Equal(Expression.Property(expression, (MethodInfo) methodof(CALL_VARIABLE.get_BU_ID)), Expression.Constant("0", typeof(string))), parameters));
                expression = Expression.Parameter(typeof(CALL_VARIABLE), "p");
                ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
                list = source.Select<CALL_VARIABLE, string>(Expression.Lambda<Func<CALL_VARIABLE, string>>(Expression.Property(expression, (MethodInfo) methodof(CALL_VARIABLE.get_VariableName)), expressionArray2)).ToList<string>();
            }
            catch (Exception exception1)
            {
                throw exception1;
            }
            return list;
        }

        public BUSINESS_UNIT_DISPLAY GetScreenPopDefinition(int screenPopRecordId)
        {
            BUSINESS_UNIT_DISPLAY business_unit_display;
            GetScreepopdataDataContext context = new GetScreepopdataDataContext();
            try
            {
                <>c__DisplayClass1_0 class_;
                ParameterExpression expression = Expression.Parameter(typeof(BUSINESS_UNIT_DISPLAY), "p");
                ParameterExpression[] parameters = new ParameterExpression[] { expression };
                business_unit_display = context.BUSINESS_UNIT_DISPLAYs.Where<BUSINESS_UNIT_DISPLAY>(Expression.Lambda<Func<BUSINESS_UNIT_DISPLAY, bool>>(Expression.Equal(Expression.Property(expression, (MethodInfo) methodof(BUSINESS_UNIT_DISPLAY.get_Business_Unit_Display_ID)), Expression.Field(Expression.Constant(class_, typeof(<>c__DisplayClass1_0)), fieldof(<>c__DisplayClass1_0.screenPopRecordId))), parameters)).Single<BUSINESS_UNIT_DISPLAY>();
            }
            catch (Exception exception1)
            {
                throw exception1;
            }
            return business_unit_display;
        }

        public void InsertCallVariable(string callVariable)
        {
            try
            {
                new GetScreepopdataDataContext().usp_insert_callvariable_Details(0, callVariable);
            }
            catch (Exception exception1)
            {
                throw exception1;
            }
        }

        public void UpdateScreenPop(int screenPopRecordId, string screenPopScriptHtml, string screenPopScriptXoml)
        {
            try
            {
                new GetScreepopdataDataContext().usp_update_screenpop_htmlxoml(new int?(screenPopRecordId), screenPopScriptHtml, screenPopScriptXoml);
            }
            catch (Exception exception1)
            {
                throw exception1;
            }
        }

        [Serializable, CompilerGenerated]
        private sealed class <>c
        {
            public static readonly ScreenPopDBConnection.<>c <>9 = new ScreenPopDBConnection.<>c();
        }
    }
}

