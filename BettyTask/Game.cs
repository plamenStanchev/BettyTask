using BettyTask.Abstractions;
using BettyTask.PayOuts;
using System.Diagnostics;

namespace BettyTask;

public class Game : IGame
{
    private static readonly List<PayOut> PayOuts = new()
    {
        new PayOutLose(),
        new PayOutWin(),
        new PayOutBigWin()
    };

    private static readonly int PayOutsOddsSum = PayOuts.Sum(p => p.Odd);

    private Random Random { get; set; }

    public Game()
    {
        Random = new Random();
    }

    public int Bet(int bet)
    {
        var payOutForSpin = WeigthedRandomPayOut();
        var betPayout = Random.Next(payOutForSpin.MinWin, payOutForSpin.MaxWin);
        return bet * betPayout;
    }

    private PayOut WeigthedRandomPayOut()
    {
        var randomValue = this.Random.Next(PayOutsOddsSum);
        foreach (var payOut in PayOuts)
        {
            if (randomValue <= payOut.Odd)
            {
                return payOut;
            }
            randomValue -= payOut.Odd;
        }

        throw new UnreachableException();
    }
}
