using System.Diagnostics;

string[] pockets =
    [
        "AsAh",
        "KsKd",
    ];
string board = string.Empty;
string dead = string.Empty;
long[] wins = new long[pockets.Length];
long[] ties = new long[pockets.Length];
long[] losses = new long[pockets.Length];
long totalHands = 0;

Stopwatch stopwatch = new();
stopwatch.Start();
HandEvaluator.Hand.HandOdds(pockets, board, dead, wins, ties, losses, ref totalHands);
stopwatch.Stop();
Console.WriteLine($"Elapsed Time: {stopwatch.ElapsedMilliseconds} ms");
Console.WriteLine($"Total Hands: {totalHands:N0}");

Console.WriteLine();

Console.WriteLine("Pockets: " + string.Join(", ", pockets));
Console.WriteLine("Wins: " + string.Join(", ", wins));
Console.WriteLine("Ties: " + string.Join(", ", ties));

for (int i = 0; i < pockets.Length; i++)
{
    Console.WriteLine();

    var winPercentage = (double)wins[i] / totalHands * 100;
    var tiePercentage = (double)ties[i] / totalHands * 100;
    Console.WriteLine($"Pocket: {pockets[i]}");
    Console.WriteLine($"Win Percentage: {(winPercentage):F2}%");
    Console.WriteLine($"Tie Percentage: {(tiePercentage):F2}%");
}
