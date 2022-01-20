namespace WWELib
{
    using System;
    using System.Data;
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using System.Reflection;

    [Database(Name="CCSData")]
    public class GetScreepopdataDataContext : DataContext
    {
        private static MappingSource mappingSource = new AttributeMappingSource();

        public GetScreepopdataDataContext() : base(Settings.Default.CCSDataConnectionString1, mappingSource)
        {
        }

        public GetScreepopdataDataContext(IDbConnection connection) : base(connection, mappingSource)
        {
        }

        public GetScreepopdataDataContext(string connection) : base(connection, mappingSource)
        {
        }

        public GetScreepopdataDataContext(IDbConnection connection, MappingSource mappingSource) : base(connection, mappingSource)
        {
        }

        public GetScreepopdataDataContext(string connection, MappingSource mappingSource) : base(connection, mappingSource)
        {
        }

        [Function(Name="dbo.usp_insert_callvariable_Details")]
        public ISingleResult<usp_insert_callvariable_DetailsResult> usp_insert_callvariable_Details([Parameter(DbType="Int")] int? business_unit_id, [Parameter(DbType="VarChar(MAX)")] string callvariable_txt)
        {
            object[] parameters = new object[] { business_unit_id, callvariable_txt };
            return (ISingleResult<usp_insert_callvariable_DetailsResult>) base.ExecuteMethodCall(this, (MethodInfo) MethodBase.GetCurrentMethod(), parameters).ReturnValue;
        }

        [Function(Name="dbo.usp_update_screenpop_htmlxoml")]
        public ISingleResult<usp_update_screenpop_htmlxomlResult> usp_update_screenpop_htmlxoml([Parameter(DbType="Int")] int? business_unit_display_id, [Parameter(DbType="VarChar(MAX)")] string screenpop_script_html, [Parameter(DbType="VarChar(MAX)")] string screenpop_script_xoml)
        {
            object[] parameters = new object[] { business_unit_display_id, screenpop_script_html, screenpop_script_xoml };
            return (ISingleResult<usp_update_screenpop_htmlxomlResult>) base.ExecuteMethodCall(this, (MethodInfo) MethodBase.GetCurrentMethod(), parameters).ReturnValue;
        }

        public Table<BUSINESS_UNIT_DISPLAY> BUSINESS_UNIT_DISPLAYs =>
            base.GetTable<BUSINESS_UNIT_DISPLAY>();

        public Table<CALL_VARIABLE> CALL_VARIABLEs =>
            base.GetTable<CALL_VARIABLE>();
    }
}

