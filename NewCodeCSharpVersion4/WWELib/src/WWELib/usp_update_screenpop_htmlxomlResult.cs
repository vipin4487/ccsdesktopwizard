namespace WWELib
{
    using System;
    using System.Data.Linq.Mapping;

    public class usp_update_screenpop_htmlxomlResult
    {
        private int? _Column1;

        [Column(Name="", Storage="_Column1", DbType="Int")]
        public int? Column1
        {
            get
            {
                return this._Column1;
            }
            set
            {
                int? nullable = this._Column1;
                int? nullable2 = value;
                if ((nullable.GetValueOrDefault() == nullable2.GetValueOrDefault()) ? (nullable.HasValue != nullable2.HasValue) : true)
                {
                    this._Column1 = value;
                }
            }
        }
    }
}

