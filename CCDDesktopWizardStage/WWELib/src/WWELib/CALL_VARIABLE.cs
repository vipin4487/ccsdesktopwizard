namespace WWELib
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.CALL_VARIABLES")]
    public class CALL_VARIABLE
    {
        private int _ID;
        private string _VariableName;
        private string _BU_ID;

        [Column(Storage="_ID", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
        public int ID
        {
            get => 
                this._ID;
            set
            {
                if (this._ID != value)
                {
                    this._ID = value;
                }
            }
        }

        [Column(Storage="_VariableName", DbType="NVarChar(50)")]
        public string VariableName
        {
            get => 
                this._VariableName;
            set
            {
                if (this._VariableName != value)
                {
                    this._VariableName = value;
                }
            }
        }

        [Column(Storage="_BU_ID", DbType="NChar(10) NOT NULL", CanBeNull=false)]
        public string BU_ID
        {
            get => 
                this._BU_ID;
            set
            {
                if (this._BU_ID != value)
                {
                    this._BU_ID = value;
                }
            }
        }
    }
}

