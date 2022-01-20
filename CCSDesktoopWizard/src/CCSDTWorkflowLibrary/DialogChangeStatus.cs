namespace CCSDTWorkflowLibrary
{
    using System;

    public enum DialogChangeStatus : long
    {
        CDN_FIRST = 0xfffffda7L,
        CDN_INITDONE = 0xfffffda7L,
        CDN_SELCHANGE = 0xfffffda6L,
        CDN_FOLDERCHANGE = 0xfffffda5L,
        CDN_SHAREVIOLATION = 0xfffffda4L,
        CDN_HELP = 0xfffffda3L,
        CDN_FILEOK = 0xfffffda2L,
        CDN_TYPECHANGE = 0xfffffda1L
    }
}

