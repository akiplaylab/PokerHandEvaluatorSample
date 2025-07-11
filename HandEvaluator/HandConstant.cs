using HandEvaluator.Models;

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

    private static readonly uint HANDTYPE_VALUE_STRAIGHTFLUSH = (uint)HandTypes.StraightFlush << HANDTYPE_SHIFT;
    private static readonly uint HANDTYPE_VALUE_STRAIGHT = (uint)HandTypes.Straight << HANDTYPE_SHIFT;
    private static readonly uint HANDTYPE_VALUE_FLUSH = (uint)HandTypes.Flush << HANDTYPE_SHIFT;
    private static readonly uint HANDTYPE_VALUE_FULLHOUSE = (uint)HandTypes.FullHouse << HANDTYPE_SHIFT;
    private static readonly uint HANDTYPE_VALUE_FOUR_OF_A_KIND = (uint)HandTypes.FourOfAKind << HANDTYPE_SHIFT;
    private static readonly uint HANDTYPE_VALUE_TRIPS = (uint)HandTypes.Trips << HANDTYPE_SHIFT;
    private static readonly uint HANDTYPE_VALUE_TWOPAIR = (uint)HandTypes.TwoPair << HANDTYPE_SHIFT;
    private static readonly uint HANDTYPE_VALUE_PAIR = (uint)HandTypes.Pair << HANDTYPE_SHIFT;
    private static readonly uint HANDTYPE_VALUE_HIGHCARD = (uint)HandTypes.HighCard << HANDTYPE_SHIFT;

    public static readonly int SPADE_OFFSET = 13 * Suit.Spades;
    public static readonly int CLUB_OFFSET = 13 * Suit.Clubs;
    public static readonly int DIAMOND_OFFSET = 13 * Suit.Diamonds;
    public static readonly int HEART_OFFSET = 13 * Suit.Hearts;
}
