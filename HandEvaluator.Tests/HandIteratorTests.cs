using MathNet.Numerics;
using System.Numerics;

namespace HandEvaluator.Tests;

public partial class HandTests
{
    [TestMethod()]
    public void HandsTest()
    {
        const int numberofCards = 5;
        var result = Hand.Hands(numberofCards);
        var expectedCount = Combinatorics.Combinations(52, numberofCards);
        Assert.AreEqual(expectedCount, result.Count(), "The number of combinations should match the expected count.");
        Assert.IsTrue(result.All(hand => BitOperations.PopCount(hand) == numberofCards), "All hands should have exactly k cards.");
        Assert.IsTrue(result.All(hand => hand < 1UL << 52), "All hands should be valid 52-card hands.");
        Assert.IsTrue(result.Distinct().Count() == result.Count(), "All hands should be unique.");

        ulong expectedFirstHand = 1UL << 51 | 1UL << 50 | 1UL << 49 | 1UL << 48 | 1UL << 47;
        Assert.AreEqual(expectedFirstHand, result.First());
    }
}
