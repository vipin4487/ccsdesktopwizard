namespace WWELib
{
    using System;
    using System.Data.Linq.Mapping;

    public class usp_insert_callvariable_DetailsResult
    {
        private int? _Column1;

        [Column(Name="", Storage="_Column1", DbType="Int")]
        public int? Column1
        {
            get => 
                this._Column1;
            set
            {
                int? nullable = this._Column1;
                int? nullable2 = value;
                if (!((nullable.GetValueOrDefault() == nullable2.GetValueOrDefault()) & ((nullable != null) == (nullable2 != null))))
                {
                    this._Column1 = value;
                }
            }
        }
    }
}

