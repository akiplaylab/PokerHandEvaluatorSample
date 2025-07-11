namespace HandEvaluator;

public partial class Hand : IComparable
{
    public static readonly int NumberOfCards = 52;

    private static readonly int HANDTYPE_SHIFT = 24;
    private static readonly int TOP_CARD_SHIFT = 16;
    private static readonly uint TOP_CARD_MASK = 0x000F0000;
    private static readonly int SECOND_CARD_SHIFT = 12;
    private static readonly uint SECOND_CARD_MASK = 0x0000F000;
    private static readonly int THIRD_CARD_SHIFT = 8;
    private static readonly int FOURTH_CARD_SHIFT = 4;
    private static readonly int FIFTH_CARD_SHIFT = 0;
    private static readonly uint FIFTH_CARD_MASK = 0x0000000F;
    private static readonly int CARD_WIDTH = 4;
    private static readonly uint CARD_MASK = 0x0F;
}
