using HandEvaluator.Models;
using static HandEvaluator.Hand;

namespace HandEvaluator.Tests;

[TestClass()]
public partial class HandTests
{
    [TestMethod()]
    [DataRow("2c", 1UL << 0)]
    [DataRow("As", 1UL << 51)]
    [DataRow("3c 2c", 1UL << 1 | 1UL << 0)]
    [DataRow("As 2c", 1UL << 51 | 1UL << 0)]
    [DataRow("As Ks Qs Js Ts", 1UL << 51 | 1UL << 50 | 1UL << 49 | 1UL << 48 | 1UL << 47)]
    public void ParseHandTest(string hand, ulong expected)
    {
        var actual = ParseHand(hand);
        Assert.AreEqual(expected, actual, $"Expected {expected} for hand '{hand}', but got {actual}.");
    }

    [TestMethod()]
    [DataRow("As Kd 8h 5s 2c", HandTypes.HighCard)]
    [DataRow("Qh Qs 9d 5c 2h", HandTypes.Pair)]
    [DataRow("Jh Jc 9s 9h 2d", HandTypes.TwoPair)]
    [DataRow("8d 8c 8s 4h 2d", HandTypes.Trips)]
    [DataRow("5c 4d 3h 2s As", HandTypes.Straight)]
    [DataRow("Ah Kh Th 7h 2h", HandTypes.Flush)]
    [DataRow("Kc Ks Kh 2d 2c", HandTypes.FullHouse)]
    [DataRow("9h 9c 9s 9d 3c", HandTypes.FourOfAKind)]
    [DataRow("9h 8h 7h 6h 5h", HandTypes.StraightFlush)]
    public void EvaluateTypeTest(string hand, HandTypes expected)
    {
        var handValue = ParseHand(hand);
        var actual = EvaluateType(handValue);
        Assert.AreEqual(expected, actual, $"Expected {expected} for hand '{hand}', but got {actual}.");
    }

    [TestMethod()]
    [DataRow("Ah Qh Th 7h 3h 2d Kc", HandTypes.Flush)]
    [DataRow("Ks Kd Kh 2c 2d 9s 5h", HandTypes.FullHouse)]
    [DataRow("6c 7d 4s 5h 8h Ks Td", HandTypes.Straight)]
    [DataRow("9s 9d 9c 9h 2d 3c Jd", HandTypes.FourOfAKind)]
    [DataRow("Ah Qh Kh Jh Th 3c 2d", HandTypes.StraightFlush)]
    public void EvaluateTypeTest_SevenCard(string hand, HandTypes expected)
    {
        var handValue = ParseHand(hand);
        var actual = EvaluateType(handValue);
        Assert.AreEqual(expected, actual, $"Expected {expected} for hand '{hand}', but got {actual}.");
    }

    [TestMethod()]
    [DataRow(new string[] { "9h 8h 7h 6h 5h", "5h 6h 7h 8h 9h" }, HandTypes.StraightFlush)]
    public void EvaluateTypeTest_SequenceOrOrderDependency(string[] hands, HandTypes expected)
    {
        foreach (var hand in hands)
        {
            var handValue = ParseHand(hand);
            var actual = EvaluateType(handValue);
            Assert.AreEqual(expected, actual, $"Expected {expected} for hand '{hand}', but got {actual}.");
        }
    }

    [TestMethod()]
    [DataRow("As Kd 8h 5s 2c", true)]
    [DataRow("As Ah Ad Ac", true)]
    [DataRow("Aa", false)]
    [DataRow("As As", false)]
    public void ValidateHandTest(string hand, bool expected)
    {
        var actual = ValidateHand(hand);
        Assert.AreEqual(expected, actual, $"Expected {expected} for hand '{hand}', but got {actual}.");
    }
}
