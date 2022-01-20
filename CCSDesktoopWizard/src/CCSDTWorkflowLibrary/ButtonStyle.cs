namespace CCSDTWorkflowLibrary
{
    using System;

    public enum ButtonStyle : long
    {
        BS_PUSHBUTTON = 0L,
        BS_DEFPUSHBUTTON = 1L,
        BS_CHECKBOX = 2L,
        BS_AUTOCHECKBOX = 3L,
        BS_RADIOBUTTON = 4L,
        BS_3STATE = 5L,
        BS_AUTO3STATE = 6L,
        BS_GROUPBOX = 7L,
        BS_USERBUTTON = 8L,
        BS_AUTORADIOBUTTON = 9L,
        BS_PUSHBOX = 10L,
        BS_OWNERDRAW = 11L,
        BS_TYPEMASK = 15L,
        BS_LEFTTEXT = 0x20L,
        BS_TEXT = 0L,
        BS_ICON = 0x40L,
        BS_BITMAP = 0x80L,
        BS_LEFT = 0x100L,
        BS_RIGHT = 0x200L,
        BS_CENTER = 0x300L,
        BS_TOP = 0x400L,
        BS_BOTTOM = 0x800L,
        BS_VCENTER = 0xc00L,
        BS_PUSHLIKE = 0x1000L,
        BS_MULTILINE = 0x2000L,
        BS_NOTIFY = 0x4000L,
        BS_FLAT = 0x8000L,
        BS_RIGHTBUTTON = 0x20L
    }
}

