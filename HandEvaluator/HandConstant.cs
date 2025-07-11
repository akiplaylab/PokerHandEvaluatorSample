using HandEvaluator.Models;

namespace HandEvaluator;

public partial class Hand : IComparable
{
    public const int TotalCardsStandard = NumRanksPerSuit * NumSuits;
    public const int NumRanksPerSuit = 13;
    public const int NumSuits = 4;

    private const int HANDTYPE_SHIFT = 24;
    private const int TOP_CARD_SHIFT = 16;
    private const uint TOP_CARD_MASK = 0x000F0000;
    private const int SECOND_CARD_SHIFT = 12;
    private const uint SECOND_CARD_MASK = 0x0000F000;
    private const int THIRD_CARD_SHIFT = 8;
    private const int FOURTH_CARD_SHIFT = 4;
    private const int FIFTH_CARD_SHIFT = 0;
    private const uint FIFTH_CARD_MASK = 0x0000000F;
    private const int CARD_WIDTH = 4;
    private const uint CARD_MASK = 0x0F;

    private const uint HANDTYPE_VALUE_STRAIGHTFLUSH = (uint)HandTypes.StraightFlush << HANDTYPE_SHIFT;
    private const uint HANDTYPE_VALUE_STRAIGHT = (uint)HandTypes.Straight << HANDTYPE_SHIFT;
    private const uint HANDTYPE_VALUE_FLUSH = (uint)HandTypes.Flush << HANDTYPE_SHIFT;
    private const uint HANDTYPE_VALUE_FULLHOUSE = (uint)HandTypes.FullHouse << HANDTYPE_SHIFT;
    private const uint HANDTYPE_VALUE_FOUR_OF_A_KIND = (uint)HandTypes.FourOfAKind << HANDTYPE_SHIFT;
    private const uint HANDTYPE_VALUE_TRIPS = (uint)HandTypes.Trips << HANDTYPE_SHIFT;
    private const uint HANDTYPE_VALUE_TWOPAIR = (uint)HandTypes.TwoPair << HANDTYPE_SHIFT;
    private const uint HANDTYPE_VALUE_PAIR = (uint)HandTypes.Pair << HANDTYPE_SHIFT;
    private const uint HANDTYPE_VALUE_HIGHCARD = (uint)HandTypes.HighCard << HANDTYPE_SHIFT;

    public const int CLUB_OFFSET = NumRanksPerSuit * Suit.Clubs;
    public const int DIAMOND_OFFSET = NumRanksPerSuit * Suit.Diamonds;
    public const int HEART_OFFSET = NumRanksPerSuit * Suit.Hearts;
    public const int SPADE_OFFSET = NumRanksPerSuit * Suit.Spades;

    private const ulong RANK_MASK_13BIT = 0x1FFFUL;
}
