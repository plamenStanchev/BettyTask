using BettyTask.Helpers;

namespace BettyTask.Abstractions;

public interface IWallet
{
    public decimal Balance { get; }
    public Result Withdraw(decimal amount);
    public Result Deposit(decimal amount);

}
