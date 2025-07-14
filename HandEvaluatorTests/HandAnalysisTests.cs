namespace HandEvaluatorTests;

public partial class HandTests
{
    [TestMethod()]
    [DataRow(new string[] { "AsAh", "KsKd" }, new int[] { 1399204, 305177 }, 7923)]
    public void HandOddsTest(string[] pockets, int[] expectedWins, int tie)
    {
        string board = string.Empty;
        string dead = string.Empty;
        long[] wins = new long[pockets.Length];
        long[] ties = new long[pockets.Length];
        long[] losses = new long[pockets.Length];
        long totalHands = 0;
        HandEvaluator.Hand.HandOdds(pockets, board, dead, wins, ties, losses, ref totalHands);
        Assert.AreEqual(pockets.Length, wins.Length);
        Assert.AreEqual(pockets.Length, ties.Length);
        Assert.AreEqual(pockets.Length, losses.Length);
        Assert.AreEqual(expectedWins.Length, wins.Length);
        for (int i = 0; i < pockets.Length; i++)
        {
            Assert.AreEqual(expectedWins[i], wins[i]);
            Assert.AreEqual(tie, ties[i]);
            Assert.IsTrue(losses[i] >= 0);
        }
        Assert.IsTrue(totalHands > 0);
    }
}
