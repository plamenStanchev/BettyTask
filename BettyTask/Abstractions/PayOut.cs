namespace BettyTask.Abstractions;

/// <summary>
/// Helper class for to represent all we need to know about a possible pay out
/// </summary>
internal abstract class PayOut
{
    public PayOut(int odd, int minWin, int maxWin)
    {
        Odd = odd;
        MinWin = minWin;
        MaxWin = maxWin;
    }

    public int Odd { get; private set; }

    public int MinWin { get; private set; } = 0;

    public int MaxWin { get; private set; } = 0;
}
