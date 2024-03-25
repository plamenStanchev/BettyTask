using BettyTask.Abstractions;

namespace BettyTask.PayOuts;

internal sealed class PayOutWin : PayOut
{
    private new const int Odd = 40;
    private new const int MinWin = 100;
    private new const int MaxWin = 200;
    public PayOutWin() : base(Odd, MinWin, MaxWin)
    {
    }
}
