namespace SHDocVw
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, ClassInterface((short) 0), Guid("2E71FD0F-AAB1-42C0-9146-6D2C4EDCF07D"), TypeLibType((short) 0x12), ComSourceInterfaces("SHDocVw._SearchAssistantEvents\0")]
    public class ShellSearchAssistantOCClass : ISearchAssistantOC3, ShellSearchAssistantOC, _SearchAssistantEvents_Event
    {
        public virtual event _SearchAssistantEvents_OnNewSearchEventHandler OnNewSearch;

        public virtual event _SearchAssistantEvents_OnNextMenuSelectEventHandler OnNextMenuSelect;

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(1)]
        public virtual extern void AddNextMenuItem([In, MarshalAs(UnmanagedType.BStr)] string bstrText, [In] int idItem);
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x19)]
        public virtual extern string EncodeString([In, MarshalAs(UnmanagedType.BStr)] string bstrValue, [In, MarshalAs(UnmanagedType.BStr)] string bstrCharSet, [In] bool bUseUTF8);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(15)]
        public virtual extern void FindComputer();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(14)]
        public virtual extern void FindFilesOrFolders();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(13)]
        public virtual extern void FindOnWeb();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x11)]
        public virtual extern void FindPeople();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x10)]
        public virtual extern void FindPrinter();
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(10)]
        public virtual extern string GetProperty([In] bool bPerLocale, [In, MarshalAs(UnmanagedType.BStr)] string bstrName);
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x12)]
        public virtual extern string GetSearchAssistantURL([In] bool bSubstitute, [In] bool bCustomize);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(4)]
        public virtual extern bool IsRestricted([In, MarshalAs(UnmanagedType.BStr)] string bstrGuid);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(3)]
        public virtual extern void NavigateToDefaultSearch();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x16)]
        public virtual extern void NETDetectNextNavigate();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x13)]
        public virtual extern void NotifySearchSettingsChanged();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x17)]
        public virtual extern void PutFindText([In, MarshalAs(UnmanagedType.BStr)] string FindText);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(9)]
        public virtual extern void PutProperty([In] bool bPerLocale, [In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In, MarshalAs(UnmanagedType.BStr)] string bstrValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(12)]
        public virtual extern void ResetNextMenu();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(2)]
        public virtual extern void SetDefaultSearchUrl([In, MarshalAs(UnmanagedType.BStr)] string bstrUrl);

        [DispId(5)]
        public virtual bool ShellFeaturesEnabled { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(5)] get; }

        [DispId(6)]
        public virtual bool SearchAssistantDefault { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(6)] get; }

        [DispId(7)]
        public virtual ISearches Searches { [return: MarshalAs(UnmanagedType.Interface)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(7)] get; }

        [DispId(8)]
        public virtual bool InWebFolder { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(8)] get; }

        [DispId(11)]
        public virtual bool EventHandled { [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(11)] set; }

        [DispId(20)]
        public virtual string ASProvider { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(20)] get; [param: In, MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(20)] set; }

        [DispId(0x15)]
        public virtual int ASSetting { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x15)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x15)] set; }

        [DispId(0x18)]
        public virtual int Version { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x18)] get; }

        [DispId(0x1a)]
        public virtual bool ShowFindPrinter { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x1a)] get; }

        [DispId(0x1b)]
        public virtual bool SearchCompanionAvailable { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x1b)] get; }

        [DispId(0x1c)]
        public virtual bool UseSearchCompanion { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x1c)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x1c)] set; }

        [DispId(5)]
        public virtual bool SHDocVw.ISearchAssistantOC3.ShellFeaturesEnabled { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(5)] get; }

        [DispId(6)]
        public virtual bool SHDocVw.ISearchAssistantOC3.SearchAssistantDefault { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(6)] get; }

        [DispId(7)]
        public virtual ISearches SHDocVw.ISearchAssistantOC3.Searches { [return: MarshalAs(UnmanagedType.Interface)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(7)] get; }

        [DispId(8)]
        public virtual bool SHDocVw.ISearchAssistantOC3.InWebFolder { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(8)] get; }

        [DispId(11)]
        public virtual bool SHDocVw.ISearchAssistantOC3.EventHandled { [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(11)] set; }

        [DispId(20)]
        public virtual string SHDocVw.ISearchAssistantOC3.ASProvider { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(20)] get; [param: In, MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(20)] set; }

        [DispId(0x15)]
        public virtual int SHDocVw.ISearchAssistantOC3.ASSetting { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x15)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x15)] set; }

        [DispId(0x18)]
        public virtual int SHDocVw.ISearchAssistantOC3.Version { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x18)] get; }

        [DispId(0x1a)]
        public virtual bool SHDocVw.ISearchAssistantOC3.ShowFindPrinter { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x1a)] get; }

        [DispId(0x1b)]
        public virtual bool SHDocVw.ISearchAssistantOC3.SearchCompanionAvailable { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x1b)] get; }

        [DispId(0x1c)]
        public virtual bool SHDocVw.ISearchAssistantOC3.UseSearchCompanion { [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x1c)] get; [param: In] [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime), DispId(0x1c)] set; }
    }
}

