using BettyTask.Abstractions;
using BettyTask.Helpers;

namespace BettyTask;

public class Wallet : IWallet
{
    public const string AmountExceptionMessage = "Amount can`t be less or equal to zero.";

    public const string WithdrawAmountExceptionMessage = "Amount can`t be greater than balance.";

    public Wallet()
    {
        Balance = 0.0m;
    }
    public decimal Balance { get; private set; }

    public Result Deposit(decimal amount)
    {
        if (amount <= 0.0m)
            return AmountExceptionMessage;

            Balance += amount;
        return true;
    }

    public Result Withdraw(decimal amount)
    {
        if (amount <= 0.0m)
            return AmountExceptionMessage;

        if (amount > Balance)
           return WithdrawAmountExceptionMessage;

            Balance -= amount;
        return true;
    }
}
