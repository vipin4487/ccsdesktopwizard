namespace SHDocVw
{
    using System;
    using System.Collections;
    using System.Runtime.InteropServices;
    using System.Threading;

    internal sealed class DShellNameSpaceEvents_EventProvider : DShellNameSpaceEvents_Event, IDisposable
    {
        private UCOMIConnectionPointContainer m_ConnectionPointContainer;
        private ArrayList m_aEventSinkHelpers;
        private UCOMIConnectionPoint m_ConnectionPoint;

        public DShellNameSpaceEvents_EventProvider(object obj1)
        {
            this.m_ConnectionPointContainer = (UCOMIConnectionPointContainer) obj1;
        }

        public override void add_DoubleClick(DShellNameSpaceEvents_DoubleClickEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DShellNameSpaceEvents_SinkHelper helper = new DShellNameSpaceEvents_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_DoubleClickDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_FavoritesSelectionChange(DShellNameSpaceEvents_FavoritesSelectionChangeEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DShellNameSpaceEvents_SinkHelper helper = new DShellNameSpaceEvents_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_FavoritesSelectionChangeDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_Initialized(DShellNameSpaceEvents_InitializedEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DShellNameSpaceEvents_SinkHelper helper = new DShellNameSpaceEvents_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_InitializedDelegate = handler1;
                this.m_aEventSinkHelpers.Add((object) helper);
            }
        }

        public override void add_SelectionChange(DShellNameSpaceEvents_SelectionChangeEventHandler handler1)
        {
            lock (this)
            {
                if (this.m_ConnectionPoint == null)
                {
                    this.Init();
                }
                DShellNameSpaceEvents_SinkHelper helper = new DShellNameSpaceEvents_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object) helper, out pdwCookie);
                helper.m_dwCookie = pdwCookie;
                helper.m_SelectionChangeDelegate = handler1;
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
                            DShellNameSpaceEvents_SinkHelper helper = (DShellNameSpaceEvents_SinkHelper) this.m_aEventSinkHelpers[num2];
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
            Guid riid = new Guid(new byte[] { 6, 0x68, 0x13, 0x55, 0xde, 0xb2, 0xd1, 0x11, 0xb9, 0xf2, 0, 160, 0xc9, 0x8b, 0xc5, 0x47 });
            this.m_ConnectionPointContainer.FindConnectionPoint(ref riid, out ppCP);
            this.m_ConnectionPoint = ppCP;
            this.m_aEventSinkHelpers = new ArrayList();
        }

        public override void remove_DoubleClick(DShellNameSpaceEvents_DoubleClickEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DShellNameSpaceEvents_SinkHelper helper = (DShellNameSpaceEvents_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_DoubleClickDelegate, null) || !(helper.m_DoubleClickDelegate.Equals((object) handler1) & 0xff))
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

        public override void remove_FavoritesSelectionChange(DShellNameSpaceEvents_FavoritesSelectionChangeEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DShellNameSpaceEvents_SinkHelper helper = (DShellNameSpaceEvents_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_FavoritesSelectionChangeDelegate, null) || !(helper.m_FavoritesSelectionChangeDelegate.Equals((object) handler1) & 0xff))
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

        public override void remove_Initialized(DShellNameSpaceEvents_InitializedEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DShellNameSpaceEvents_SinkHelper helper = (DShellNameSpaceEvents_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_InitializedDelegate, null) || !(helper.m_InitializedDelegate.Equals((object) handler1) & 0xff))
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

        public override void remove_SelectionChange(DShellNameSpaceEvents_SelectionChangeEventHandler handler1)
        {
            lock (this)
            {
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    while (true)
                    {
                        DShellNameSpaceEvents_SinkHelper helper = (DShellNameSpaceEvents_SinkHelper) this.m_aEventSinkHelpers[index];
                        if (ReferenceEquals(helper.m_SelectionChangeDelegate, null) || !(helper.m_SelectionChangeDelegate.Equals((object) handler1) & 0xff))
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

