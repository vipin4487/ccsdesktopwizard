namespace WWELib
{
    using Genesyslab.Platform.ApplicationBlocks.ConfigurationObjectModel;
    using Genesyslab.Platform.Commons.Logging;
    using Genesyslab.Platform.Commons.Protocols;
    using Genesyslab.Platform.Configuration.Protocols;
    using System;

    public class ComModelBase
    {
        private ILogger _logger;
        private ConfServerProtocol _client;
        private IConfService _service;

        protected bool CheckClientIsNull()
        {
            if (this._client == null)
            {
                Console.WriteLine("{0} : {1} : {2}", 5, 0, new ArgumentException("Client is null"));
                return false;
            }
            return true;
        }

        protected bool CheckClientIsOpened()
        {
            if (this._client.get_State() != 1)
            {
                Console.WriteLine("{0} : {1} : {2}", 5, 0, new ArgumentException("Client is not opened"));
                return false;
            }
            return true;
        }

        public void Close()
        {
            if (this.CheckClientIsNull())
            {
                this._client.Close();
            }
        }

        public void EnableLogging(ILogger logger)
        {
            this._logger = logger;
            if (this._client > null)
            {
                this._client.EnableLogging(logger);
            }
        }

        ~ComModelBase()
        {
            this.ReleaseService();
            if (this._client > null)
            {
                if (this._client.get_State() != 3)
                {
                    this._client.Close();
                }
                this._client.Dispose();
                this._client = null;
            }
        }

        public void Initialization(string host, int port, string clientName, string userName, string password)
        {
            ConfServerProtocol protocol1 = new ConfServerProtocol(new Endpoint(host, port));
            protocol1.set_ClientName(clientName);
            protocol1.set_UserPassword(password);
            protocol1.set_UserName(userName);
            protocol1.set_ClientApplicationType(0x13);
            this._client = protocol1;
            this._client.ConfigureAddp();
            this._service = ConfServiceFactory.CreateConfService(this._client);
            this._client.add_Opened(new EventHandler(this.OnOpened));
            this._client.add_Closed(new EventHandler(this.OnClosed));
            if (this._logger > null)
            {
                this._client.EnableLogging(this._logger);
                AbstractLogEnabled enabled = this._service as AbstractLogEnabled;
                if (enabled > null)
                {
                    enabled.EnableLogging(this._logger.CreateChildLogger("COM.service"));
                }
            }
        }

        private void OnClosed(object sender, EventArgs args)
        {
            this.ReleaseService();
        }

        private void OnOpened(object sender, EventArgs args)
        {
        }

        public void Open()
        {
            if (this.CheckClientIsNull())
            {
                this._client.Open();
            }
        }

        private void ReleaseService()
        {
            if (this._service > null)
            {
                ConfServiceFactory.ReleaseConfService(this._service);
                this._service = null;
            }
        }

        protected IConfService Service
        {
            get
            {
                return this._service;
            }
        }

        private ILogger Log_
        {
            get
            {
                return this._logger;
            }
        }
    }
}

