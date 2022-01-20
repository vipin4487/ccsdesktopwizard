namespace SHDocVw
{
    using System;
    using System.Runtime.InteropServices;

    [ClassInterface(ClassInterfaceType.None)]
    public sealed class _SearchAssistantEvents_SinkHelper : _SearchAssistantEvents
    {
        public _SearchAssistantEvents_OnNewSearchEventHandler m_OnNewSearchDelegate = null;
        public _SearchAssistantEvents_OnNextMenuSelectEventHandler m_OnNextMenuSelectDelegate = null;
        public int m_dwCookie = 0;

        internal _SearchAssistantEvents_SinkHelper()
        {
        }

        public override void OnNewSearch()
        {
            if (this.m_OnNewSearchDelegate != null)
            {
                this.m_OnNewSearchDelegate();
            }
        }

        public override void OnNextMenuSelect(int num1)
        {
            if (this.m_OnNextMenuSelectDelegate != null)
            {
                this.m_OnNextMenuSelectDelegate(num1);
            }
        }
    }
}

