using BettyTask.Abstractions;

namespace BettyTask.PayOuts;

internal sealed class PayOutBigWin : PayOut
{
    private new const int Odd = 10;
    private new const int MinWin = 200;
    private new const int MaxWin = 1000;
    public PayOutBigWin() : base(Odd, MinWin, MaxWin)
    {
    }
}
