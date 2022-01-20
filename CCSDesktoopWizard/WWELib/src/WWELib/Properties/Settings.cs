namespace WWELib.Properties
{
    using System;
    using System.CodeDom.Compiler;
    using System.Configuration;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed class Settings : ApplicationSettingsBase
    {
        private static Settings defaultInstance = ((Settings) Synchronized(new Settings()));

        public static Settings Default =>
            defaultInstance;

        [ApplicationScopedSetting, DebuggerNonUserCode, SpecialSetting(SpecialSetting.ConnectionString), DefaultSettingValue("Data Source=dbsed3339;Initial Catalog=VCC_DESKTOP;Integrated Security=True")]
        public string VCC_DESKTOPConnectionString =>
            (string) this["VCC_DESKTOPConnectionString"];

        [ApplicationScopedSetting, DebuggerNonUserCode, SpecialSetting(SpecialSetting.ConnectionString), DefaultSettingValue("Data Source=dbsed3339;Initial Catalog=CCSData;Integrated Security=True")]
        public string CCSDataConnectionString =>
            (string) this["CCSDataConnectionString"];

        [ApplicationScopedSetting, DebuggerNonUserCode, SpecialSetting(SpecialSetting.ConnectionString), DefaultSettingValue("Data Source=DBSED1446;Initial Catalog=CCSData;Integrated Security=True")]
        public string CCSDataConnectionString1 =>
            (string) this["CCSDataConnectionString1"];
    }
}

