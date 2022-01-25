namespace WWELib
{
    using Genesyslab.Platform.Commons.Connection.Configuration;
    using Genesyslab.Platform.Commons.Protocols;
    using System;
    using System.Runtime.CompilerServices;

    public static class ClientChannelHelper
    {
        public static void ConfigureAddp(this ClientChannel channel)
        {
            ManagedConnectionConfiguration configuration = channel.get_Endpoint().GetConfiguration() as ManagedConnectionConfiguration;
            if (configuration > null)
            {
                configuration.set_AddpClientTimeout(10);
                configuration.set_AddpServerTimeout(12);
                configuration.set_AddpTraceMode(3);
                configuration.set_UseAddp(true);
            }
        }
    }
}

