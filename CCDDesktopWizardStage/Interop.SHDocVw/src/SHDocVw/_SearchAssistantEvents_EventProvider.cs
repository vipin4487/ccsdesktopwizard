namespace SHDocVw
{
    using System;
    using System.Collections;
    using System.Runtime.InteropServices;
    using System.Threading;

    internal sealed class _SearchAssistantEvents_EventProvider : _SearchAssistantEvents_Event, IDisposable
    {
        private UCOMIConnectionPointContainer m_ConnectionPointContainer;
        private ArrayList m_aEventSinkHelpers;
        private UCOMIConnectionPoint m_ConnectionPoint;

        public _SearchAssistantEvents_EventProvider(object obj1)
        {
            this.m_ConnectionPointContainer = (UCOMIConnectionPointContainer) obj1;
        }

        public override void add_OnNewSearch(_SearchAssistantEvents_OnNewSearchEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                _SearchAssistantEvents_SinkHelper helper = new _SearchAssistantEvents_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_OnNewSearchDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_OnNextMenuSelect(_SearchAssistantEvents_OnNextMenuSelectEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                _SearchAssistantEvents_SinkHelper helper = new _SearchAssistantEvents_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_OnNextMenuSelectDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void Dispose()
        {
            this.Finalize();
            GC.SuppressFinalize(this);
        }

        public override void Finalize()
        {
            Monitor.Enter(this);
            try
            {
                if (this.m_ConnectionPoint != null)
                {
                    int count = this.m_aEventSinkHelpers.Count;
                    int num2 = 0;
                    if (0 < count)
                    {
                        do
                        {
                            _SearchAssistantEvents_SinkHelper helper = (_SearchAssistantEvents_SinkHelper) this.m_aEventSinkHelpers[num2];
                            this.m_ConnectionPoint.Unadvise(helper.m_dwCookie);
                            num2++;
                        }
                        while (num2 < count);
                    }
                    Marshal.ReleaseComObject(this.m_ConnectionPoint);
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                Monitor.Exit(this);
            }
        }

        private void Init()
        {
            UCOMIConnectionPoint ppCP = null;
            Guid riid = new Guid(new byte[] { 0xda, 0xfd, 0x11, 0x16, 0x5b, 0x44, 210, 0x11, 0x85, 0xde, 0, 0xc0, 0x4f, 0xa3, 0x5c, 0x89 });
            this.m_ConnectionPointContainer.FindConnectionPoint(ref riid, out ppCP);
            this.m_ConnectionPoint = ppCP;
            this.m_aEventSinkHelpers = new ArrayList();
        }

        public override void remove_OnNewSearch(_SearchAssistantEvents_OnNewSearchEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        _SearchAssistantEvents_SinkHelper helper = (_SearchAssistantEvents_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_OnNewSearchDelegate, null) || !(helper.m_OnNewSearchDelegate.Equals((object) handler1) & 0xff))
                        {
                            index++;
                            if (index < count)
                            {
                                continue;
                            }
                        }
                        else
                        {
                            this.m_aEventSinkHelpers.RemoveAt(index);
                            this.m_ConnectionPoint.Unadvise(helper.m_dwCookie);
                            if (count <= 1)
                            {
                                Marshal.ReleaseComObject(this.m_ConnectionPoint);
                                this.m_ConnectionPoint = null;
                                this.m_aEventSinkHelpers = null;
                            }
                        }
                        break;
                    }
                }
            }
        }

        public override void remove_OnNextMenuSelect(_SearchAssistantEvents_OnNextMenuSelectEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        _SearchAssistantEvents_SinkHelper helper = (_SearchAssistantEvents_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_OnNextMenuSelectDelegate, null) || !(helper.m_OnNextMenuSelectDelegate.Equals((object) handler1) & 0xff))
                        {
                            index++;
                            if (index < count)
                            {
                                continue;
                            }
                        }
                        else
                        {
                            this.m_aEventSinkHelpers.RemoveAt(index);
                            this.m_ConnectionPoint.Unadvise(helper.m_dwCookie);
                            if (count <= 1)
                            {
                                Marshal.ReleaseComObject(this.m_ConnectionPoint);
                                this.m_ConnectionPoint = null;
                                this.m_aEventSinkHelpers = null;
                            }
                        }
                        break;
                    }
                }
            }
        }
    }
}

