using BettyTask.Abstractions;

namespace BettyTask.PayOuts;

internal sealed class PayOutLose : PayOut
{
    private new const int Odd = 50;
    private new const int MinWin = 0;
    private new const int MaxWin = 0;
    public PayOutLose() : base(Odd, MinWin, MaxWin)
    {
    }
}
