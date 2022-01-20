namespace SHDocVw
{
    using System;
    using System.Runtime.InteropServices;

    [ClassInterface(ClassInterfaceType.None)]
    public sealed class DShellNameSpaceEvents_SinkHelper : DShellNameSpaceEvents
    {
        public DShellNameSpaceEvents_InitializedEventHandler m_InitializedDelegate = null;
        public DShellNameSpaceEvents_DoubleClickEventHandler m_DoubleClickDelegate = null;
        public DShellNameSpaceEvents_SelectionChangeEventHandler m_SelectionChangeDelegate = null;
        public DShellNameSpaceEvents_FavoritesSelectionChangeEventHandler m_FavoritesSelectionChangeDelegate = null;
        public int m_dwCookie = 0;

        internal DShellNameSpaceEvents_SinkHelper()
        {
        }

        public override void DoubleClick()
        {
            if (this.m_DoubleClickDelegate != null)
            {
                this.m_DoubleClickDelegate();
            }
        }

        public override void FavoritesSelectionChange(int num1, int num2, string text1, string text2, int num3, string text3, int num4)
        {
            if (this.m_FavoritesSelectionChangeDelegate != null)
            {
                this.m_FavoritesSelectionChangeDelegate(num1, num2, text1, text2, num3, text3, num4);
            }
        }

        public override void Initialized()
        {
            if (this.m_InitializedDelegate != null)
            {
                this.m_InitializedDelegate();
            }
        }

        public override void SelectionChange()
        {
            if (this.m_SelectionChangeDelegate != null)
            {
                this.m_SelectionChangeDelegate();
            }
        }
    }
}

