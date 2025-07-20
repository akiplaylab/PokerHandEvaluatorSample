using MathNet.Numerics;
using System.Numerics;

namespace HandEvaluator.Tests;

public partial class HandTests
{
    [TestMethod()]
    [DataRow(1, new ulong[] { 1UL << 0, 1UL << 51 })]
    [DataRow(2, new ulong[] { 1UL << 1 | 1UL << 0, 1UL << 51 | 1UL << 50 })]
    [DataRow(5, new ulong[] { 1UL << 4 | 1UL << 3 | 1UL << 2 | 1UL << 1 | 1UL << 0, 1UL << 51 | 1UL << 50 | 1UL << 49 | 1UL << 48 | 1UL << 47 })]
    public void HandsTest(int numberOfCards, ulong[] contains)
    {
        var result = Hand.Hands(numberOfCards);
        var expectedCount = Combinatorics.Combinations(52, numberOfCards);
        Assert.AreEqual(expectedCount, result.Count(), "The number of combinations should match the expected count.");
        Assert.IsTrue(result.All(hand => BitOperations.PopCount(hand) == numberOfCards), "All hands should have exactly k cards.");
        Assert.IsTrue(result.All(hand => hand < 1UL << 52), "All hands should be valid 52-card hands.");
        Assert.IsTrue(result.Distinct().Count() == result.Count(), "All hands should be unique.");

        Assert.IsTrue(contains.All(c => result.Contains(c)), "The result should contain all expected hands.");
    }

    [TestMethod()]
    [DataRow(5, 1UL << 51 | 1UL << 50 | 1UL << 1 | 1UL << 0, new ulong[] { 1UL << 6 | 1UL << 5 | 1UL << 4 | 1UL << 3 | 1UL << 2, 1UL << 49 | 1UL << 48 | 1UL << 47 | 1UL << 46 | 1UL << 45 })]
    public void GetHandsTest_WithDead(int numberOfCards, ulong dead, ulong[] contains)
    {
        var result = Hand.Hands(0UL, dead, numberOfCards);
        var expectedCount = Combinatorics.Combinations(52 - BitOperations.PopCount(dead), numberOfCards);
        Assert.AreEqual(expectedCount, result.Count(), "The number of combinations should match the expected count.");
        Assert.IsTrue(result.All(hand => BitOperations.PopCount(hand) == numberOfCards), "All hands should have exactly numberOfCards cards.");
        Assert.IsTrue(result.All(hand => hand < 1UL << 52), "All hands should be valid 52-card hands.");
        Assert.IsTrue(result.Distinct().Count() == result.Count(), "All hands should be unique.");

        Assert.IsTrue(contains.All(c => result.Contains(c)), "The result should contain all expected hands.");
    }
}
