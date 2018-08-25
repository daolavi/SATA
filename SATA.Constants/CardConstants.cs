namespace SATA.Constants
{
    public enum CardType
    {
        WrongFormatCard = -1,
        Unknown = 0,
        Visa = 1,
        Master = 2,
        Amex = 3,
        JCB = 4,
    }

    public static class CardConstants
    {
        public const string VISA_START_NUMBER = "4";
        public const int VISA_LENGTH = 16;

        public const string MASTERCARD_START_NUMBER = "5";
        public const int MASTERCARD_LENGTH = 16;

        public const string AMEX_START_NUMBER = "3";
        public const int AMEX_LENGTH = 15;

        public const string JCB_START_NUMBER = "3";
        public const int JCB_LENGTH = 16;
        
        public const int UNKNOWNCARD_LENGTH = 16;

        public static readonly string[] WELL_KNOWN_START_NUMBER = { VISA_START_NUMBER, MASTERCARD_START_NUMBER, AMEX_START_NUMBER, JCB_START_NUMBER };
    }
}
