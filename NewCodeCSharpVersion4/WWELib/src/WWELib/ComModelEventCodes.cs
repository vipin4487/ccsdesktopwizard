namespace WWELib
{
    using System;

    public static class ComModelEventCodes
    {
        public const int ChannelClosed = 1;
        public const int ChannelOpened = 2;
        public const int ChannelError = 3;
        public const int ChannelMessage = 4;
        public const int InternalError = 5;
        public const int PersonCreated = 100;
        public const int PersonReaded = 0x65;
        public const int PersonUpdated = 0x66;
        public const int PersonDeleted = 0x67;
    }
}

