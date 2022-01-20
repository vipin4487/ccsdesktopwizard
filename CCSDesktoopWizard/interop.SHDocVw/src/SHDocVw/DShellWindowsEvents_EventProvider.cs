namespace SHDocVw
{
    using System;
    using System.Collections;
    using System.Runtime.InteropServices;
    using System.Threading;

    internal sealed class DShellWindowsEvents_EventProvider : DShellWindowsEvents_Event, IDisposable
    {
        private UCOMIConnectionPointContainer m_ConnectionPointContainer;
        private ArrayList m_aEventSinkHelpers;
        private UCOMIConnectionPoint m_ConnectionPoint;

        public DShellWindowsEvents_EventProvider(object obj1)
        {
            this.m_ConnectionPointContainer = (UCOMIConnectionPointContainer) obj1;
        }

        public override void add_WindowRegistered(DShellWindowsEvents_WindowRegisteredEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DShellWindowsEvents_SinkHelper helper = new DShellWindowsEvents_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_WindowRegisteredDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_WindowRevoked(DShellWindowsEvents_WindowRevokedEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DShellWindowsEvents_SinkHelper helper = new DShellWindowsEvents_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_WindowRevokedDelegate = handler1;
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
                            DShellWindowsEvents_SinkHelper helper = (DShellWindowsEvents_SinkHelper) this.m_aEventSinkHelpers[num2];
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
            Guid riid = new Guid(new byte[] { 0xe0, 6, 0x41, 0xfe, 0x9a, 0x39, 0xd0, 0x11, 0xa4, 140, 0, 160, 0xc9, 10, 0x8f, 0x39 });
            this.m_ConnectionPointContainer.FindConnectionPoint(ref riid, out ppCP);
            this.m_ConnectionPoint = ppCP;
            this.m_aEventSinkHelpers = new ArrayList();
        }

        public override void remove_WindowRegistered(DShellWindowsEvents_WindowRegisteredEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DShellWindowsEvents_SinkHelper helper = (DShellWindowsEvents_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_WindowRegisteredDelegate, null) || !(helper.m_WindowRegisteredDelegate.Equals((object) handler1) & 0xff))
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

        public override void remove_WindowRevoked(DShellWindowsEvents_WindowRevokedEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DShellWindowsEvents_SinkHelper helper = (DShellWindowsEvents_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_WindowRevokedDelegate, null) || !(helper.m_WindowRevokedDelegate.Equals((object) handler1) & 0xff))
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

