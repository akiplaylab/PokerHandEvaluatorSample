using HandEvaluator.Models;

namespace HandEvaluator;

public partial class Hand
{
    public const int TotalCardsStandard = NumRanksPerSuit * NumSuits;
    public const int NumRanksPerSuit = 13;
    public const int NumSuits = 4;

    private const int HandTypeShift = 24;
    private const int TopCardShift = 16;
    private const uint TopCardMask = 0x000F0000;
    private const int SecondCardShift = 12;
    private const uint SecondCardMask = 0x0000F000;
    private const int ThirdCardShift = 8;
    private const int FourthCardShift = 4;
    private const int FifthCardShift = 0;
    private const uint FifthCardMask = 0x0000000F;
    private const int CardWidth = 4;
    // UNDONE: Since a method with the same name exists, naming refactoring will be done later.
    private const uint CARD_MASK = 0x0F;

    private const uint HandTypeValueStraightFlush = (uint)HandTypes.StraightFlush << HandTypeShift;
    private const uint HandTypeValueStraight = (uint)HandTypes.Straight << HandTypeShift;
    private const uint HandTypeValueFlush = (uint)HandTypes.Flush << HandTypeShift;
    private const uint HandTypeValueFullHouse = (uint)HandTypes.FullHouse << HandTypeShift;
    private const uint HandTypeValueFourOfAKind = (uint)HandTypes.FourOfAKind << HandTypeShift;
    private const uint HandTypeValueTrips = (uint)HandTypes.Trips << HandTypeShift;
    private const uint HandTypeValueTwoPair = (uint)HandTypes.TwoPair << HandTypeShift;
    private const uint HandTypeValuePair = (uint)HandTypes.Pair << HandTypeShift;
    private const uint HandTypeValueHighCard = (uint)HandTypes.HighCard << HandTypeShift;

    public const int ClubOffset = NumRanksPerSuit * (int)Suit.Clubs;
    public const int DiamondOffset = NumRanksPerSuit * (int)Suit.Diamonds;
    public const int HeartOffset = NumRanksPerSuit * (int)Suit.Hearts;
    public const int SpadeOffset = NumRanksPerSuit * (int)Suit.Spades;

    private const ulong RankMask13Bit = 0x1FFFUL;
}
