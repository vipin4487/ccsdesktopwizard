namespace WWELib
{
    using System;
    using System.Data.Linq.Mapping;
    using System.Xml.Linq;

    [Table(Name="dbo.BUSINESS_UNIT_DISPLAY")]
    public class BUSINESS_UNIT_DISPLAY
    {
        private int _Business_Unit_Display_ID;
        private int _business_unit_id;
        private int _display_type_id;
        private byte? _type_priority;
        private string _display_tag;
        private string _screen_pop_header;
        private string _display_window_size_txt;
        private string _display_window_location_txt;
        private byte? _display_window_top_most_nbr;
        private string _display_window_properties_txt;
        private byte? _Priority;
        private int _trigger_call_event_id;
        private int? _call_type_id;
        private string _call_org_type_filter;
        private int? _trigger_timeout_nbr;
        private string _timeout_message_txt;
        private string _Greeting_txt;
        private string _key_CTI_value;
        private string _data_source_connection_txt;
        private string _data_source_command_txt;
        private string _data_source_command_input_txt;
        private string _URL_display_address_txt;
        private int? _survey_type_id;
        private int? _application_script_id;
        private int? _application_id;
        private XElement _xslt_transform_file;
        private DateTime? _xslt_transform_file_update;
        private XElement _xslt_transform_file_reply;
        private DateTime? _xslt_transform_file_reply_update;
        private string _screenpop_script_xoml;
        private string _call_type_list;

        [Column(Storage="_Business_Unit_Display_ID", DbType="Int NOT NULL")]
        public int Business_Unit_Display_ID
        {
            get
            {
                return this._Business_Unit_Display_ID;
            }
            set
            {
                if (this._Business_Unit_Display_ID != value)
                {
                    this._Business_Unit_Display_ID = value;
                }
            }
        }

        [Column(Storage="_business_unit_id", DbType="Int NOT NULL")]
        public int business_unit_id
        {
            get
            {
                return this._business_unit_id;
            }
            set
            {
                if (this._business_unit_id != value)
                {
                    this._business_unit_id = value;
                }
            }
        }

        [Column(Storage="_display_type_id", DbType="Int NOT NULL")]
        public int display_type_id
        {
            get
            {
                return this._display_type_id;
            }
            set
            {
                if (this._display_type_id != value)
                {
                    this._display_type_id = value;
                }
            }
        }

        [Column(Storage="_type_priority", DbType="TinyInt")]
        public byte? type_priority
        {
            get
            {
                return this._type_priority;
            }
            set
            {
                byte? nullable3 = this._type_priority;
                int? nullable = nullable3.HasValue ? new int?(nullable3.GetValueOrDefault()) : null;
                nullable3 = value;
                int? nullable2 = nullable3.HasValue ? new int?(nullable3.GetValueOrDefault()) : null;
                if ((nullable.GetValueOrDefault() == nullable2.GetValueOrDefault()) ? (nullable.HasValue != nullable2.HasValue) : true)
                {
                    this._type_priority = value;
                }
            }
        }

        [Column(Storage="_display_tag", DbType="VarChar(100)")]
        public string display_tag
        {
            get
            {
                return this._display_tag;
            }
            set
            {
                if (this._display_tag != value)
                {
                    this._display_tag = value;
                }
            }
        }

        [Column(Storage="_screen_pop_header", DbType="VarChar(500)")]
        public string screen_pop_header
        {
            get
            {
                return this._screen_pop_header;
            }
            set
            {
                if (this._screen_pop_header != value)
                {
                    this._screen_pop_header = value;
                }
            }
        }

        [Column(Storage="_display_window_size_txt", DbType="VarChar(15)")]
        public string display_window_size_txt
        {
            get
            {
                return this._display_window_size_txt;
            }
            set
            {
                if (this._display_window_size_txt != value)
                {
                    this._display_window_size_txt = value;
                }
            }
        }

        [Column(Storage="_display_window_location_txt", DbType="VarChar(15)")]
        public string display_window_location_txt
        {
            get
            {
                return this._display_window_location_txt;
            }
            set
            {
                if (this._display_window_location_txt != value)
                {
                    this._display_window_location_txt = value;
                }
            }
        }

        [Column(Storage="_display_window_top_most_nbr", DbType="TinyInt")]
        public byte? display_window_top_most_nbr
        {
            get
            {
                return this._display_window_top_most_nbr;
            }
            set
            {
                byte? nullable3 = this._display_window_top_most_nbr;
                int? nullable = nullable3.HasValue ? new int?(nullable3.GetValueOrDefault()) : null;
                nullable3 = value;
                int? nullable2 = nullable3.HasValue ? new int?(nullable3.GetValueOrDefault()) : null;
                if ((nullable.GetValueOrDefault() == nullable2.GetValueOrDefault()) ? (nullable.HasValue != nullable2.HasValue) : true)
                {
                    this._display_window_top_most_nbr = value;
                }
            }
        }

        [Column(Storage="_display_window_properties_txt", DbType="VarChar(500)")]
        public string display_window_properties_txt
        {
            get
            {
                return this._display_window_properties_txt;
            }
            set
            {
                if (this._display_window_properties_txt != value)
                {
                    this._display_window_properties_txt = value;
                }
            }
        }

        [Column(Storage="_Priority", DbType="TinyInt")]
        public byte? Priority
        {
            get
            {
                return this._Priority;
            }
            set
            {
                byte? nullable3 = this._Priority;
                int? nullable = nullable3.HasValue ? new int?(nullable3.GetValueOrDefault()) : null;
                nullable3 = value;
                int? nullable2 = nullable3.HasValue ? new int?(nullable3.GetValueOrDefault()) : null;
                if ((nullable.GetValueOrDefault() == nullable2.GetValueOrDefault()) ? (nullable.HasValue != nullable2.HasValue) : true)
                {
                    this._Priority = value;
                }
            }
        }

        [Column(Storage="_trigger_call_event_id", DbType="Int NOT NULL")]
        public int trigger_call_event_id
        {
            get
            {
                return this._trigger_call_event_id;
            }
            set
            {
                if (this._trigger_call_event_id != value)
                {
                    this._trigger_call_event_id = value;
                }
            }
        }

        [Column(Storage="_call_type_id", DbType="Int")]
        public int? call_type_id
        {
            get
            {
                return this._call_type_id;
            }
            set
            {
                int? nullable = this._call_type_id;
                int? nullable2 = value;
                if ((nullable.GetValueOrDefault() == nullable2.GetValueOrDefault()) ? (nullable.HasValue != nullable2.HasValue) : true)
                {
                    this._call_type_id = value;
                }
            }
        }

        [Column(Storage="_call_org_type_filter", DbType="VarChar(50)")]
        public string call_org_type_filter
        {
            get
            {
                return this._call_org_type_filter;
            }
            set
            {
                if (this._call_org_type_filter != value)
                {
                    this._call_org_type_filter = value;
                }
            }
        }

        [Column(Storage="_trigger_timeout_nbr", DbType="Int")]
        public int? trigger_timeout_nbr
        {
            get
            {
                return this._trigger_timeout_nbr;
            }
            set
            {
                int? nullable = this._trigger_timeout_nbr;
                int? nullable2 = value;
                if ((nullable.GetValueOrDefault() == nullable2.GetValueOrDefault()) ? (nullable.HasValue != nullable2.HasValue) : true)
                {
                    this._trigger_timeout_nbr = value;
                }
            }
        }

        [Column(Storage="_timeout_message_txt", DbType="VarChar(300)")]
        public string timeout_message_txt
        {
            get
            {
                return this._timeout_message_txt;
            }
            set
            {
                if (this._timeout_message_txt != value)
                {
                    this._timeout_message_txt = value;
                }
            }
        }

        [Column(Storage="_Greeting_txt", DbType="VarChar(MAX)")]
        public string Greeting_txt
        {
            get
            {
                return this._Greeting_txt;
            }
            set
            {
                if (this._Greeting_txt != value)
                {
                    this._Greeting_txt = value;
                }
            }
        }

        [Column(Storage="_key_CTI_value", DbType="VarChar(50)")]
        public string key_CTI_value
        {
            get
            {
                return this._key_CTI_value;
            }
            set
            {
                if (this._key_CTI_value != value)
                {
                    this._key_CTI_value = value;
                }
            }
        }

        [Column(Storage="_data_source_connection_txt", DbType="VarChar(500)")]
        public string data_source_connection_txt
        {
            get
            {
                return this._data_source_connection_txt;
            }
            set
            {
                if (this._data_source_connection_txt != value)
                {
                    this._data_source_connection_txt = value;
                }
            }
        }

        [Column(Storage="_data_source_command_txt", DbType="VarChar(1000)")]
        public string data_source_command_txt
        {
            get
            {
                return this._data_source_command_txt;
            }
            set
            {
                if (this._data_source_command_txt != value)
                {
                    this._data_source_command_txt = value;
                }
            }
        }

        [Column(Storage="_data_source_command_input_txt", DbType="VarChar(600)")]
        public string data_source_command_input_txt
        {
            get
            {
                return this._data_source_command_input_txt;
            }
            set
            {
                if (this._data_source_command_input_txt != value)
                {
                    this._data_source_command_input_txt = value;
                }
            }
        }

        [Column(Storage="_URL_display_address_txt", DbType="VarChar(500)")]
        public string URL_display_address_txt
        {
            get
            {
                return this._URL_display_address_txt;
            }
            set
            {
                if (this._URL_display_address_txt != value)
                {
                    this._URL_display_address_txt = value;
                }
            }
        }

        [Column(Storage="_survey_type_id", DbType="Int")]
        public int? survey_type_id
        {
            get
            {
                return this._survey_type_id;
            }
            set
            {
                int? nullable = this._survey_type_id;
                int? nullable2 = value;
                if ((nullable.GetValueOrDefault() == nullable2.GetValueOrDefault()) ? (nullable.HasValue != nullable2.HasValue) : true)
                {
                    this._survey_type_id = value;
                }
            }
        }

        [Column(Storage="_application_script_id", DbType="Int")]
        public int? application_script_id
        {
            get
            {
                return this._application_script_id;
            }
            set
            {
                int? nullable = this._application_script_id;
                int? nullable2 = value;
                if ((nullable.GetValueOrDefault() == nullable2.GetValueOrDefault()) ? (nullable.HasValue != nullable2.HasValue) : true)
                {
                    this._application_script_id = value;
                }
            }
        }

        [Column(Storage="_application_id", DbType="Int")]
        public int? application_id
        {
            get
            {
                return this._application_id;
            }
            set
            {
                int? nullable = this._application_id;
                int? nullable2 = value;
                if ((nullable.GetValueOrDefault() == nullable2.GetValueOrDefault()) ? (nullable.HasValue != nullable2.HasValue) : true)
                {
                    this._application_id = value;
                }
            }
        }

        [Column(Storage="_xslt_transform_file", DbType="Xml", UpdateCheck=UpdateCheck.Never)]
        public XElement xslt_transform_file
        {
            get
            {
                return this._xslt_transform_file;
            }
            set
            {
                if (this._xslt_transform_file != value)
                {
                    this._xslt_transform_file = value;
                }
            }
        }

        [Column(Storage="_xslt_transform_file_update", DbType="DateTime")]
        public DateTime? xslt_transform_file_update
        {
            get
            {
                return this._xslt_transform_file_update;
            }
            set
            {
                DateTime? nullable = this._xslt_transform_file_update;
                DateTime? nullable2 = value;
                if ((nullable.HasValue == nullable2.HasValue) ? (nullable.HasValue ? (nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) : false) : true)
                {
                    this._xslt_transform_file_update = value;
                }
            }
        }

        [Column(Storage="_xslt_transform_file_reply", DbType="Xml", UpdateCheck=UpdateCheck.Never)]
        public XElement xslt_transform_file_reply
        {
            get
            {
                return this._xslt_transform_file_reply;
            }
            set
            {
                if (this._xslt_transform_file_reply != value)
                {
                    this._xslt_transform_file_reply = value;
                }
            }
        }

        [Column(Storage="_xslt_transform_file_reply_update", DbType="DateTime")]
        public DateTime? xslt_transform_file_reply_update
        {
            get
            {
                return this._xslt_transform_file_reply_update;
            }
            set
            {
                DateTime? nullable = this._xslt_transform_file_reply_update;
                DateTime? nullable2 = value;
                if ((nullable.HasValue == nullable2.HasValue) ? (nullable.HasValue ? (nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) : false) : true)
                {
                    this._xslt_transform_file_reply_update = value;
                }
            }
        }

        [Column(Storage="_screenpop_script_xoml", DbType="VarChar(MAX)")]
        public string screenpop_script_xoml
        {
            get
            {
                return this._screenpop_script_xoml;
            }
            set
            {
                if (this._screenpop_script_xoml != value)
                {
                    this._screenpop_script_xoml = value;
                }
            }
        }

        [Column(Storage="_call_type_list", DbType="VarChar(50)")]
        public string call_type_list
        {
            get
            {
                return this._call_type_list;
            }
            set
            {
                if (this._call_type_list != value)
                {
                    this._call_type_list = value;
                }
            }
        }
    }
}

