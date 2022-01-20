namespace SHDocVw
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComVisible(false), TypeLibType((short) 0x10), ComEventInterface(typeof(_SearchAssistantEvents), typeof(_SearchAssistantEvents_EventProvider))]
    public interface _SearchAssistantEvents_Event
    {
        event _SearchAssistantEvents_OnNewSearchEventHandler OnNewSearch;

        event _SearchAssistantEvents_OnNextMenuSelectEventHandler OnNextMenuSelect;
    }
}

