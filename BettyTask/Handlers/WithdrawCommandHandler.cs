using BettyTask.Abstractions;
using BettyTask.Helpers;

namespace BettyTask.Handlers;

public class WithdrawCommandHandler : ICommandHandler
{
    private readonly IWallet wallet;
    private readonly OutputCommandHandler outputHandler;

    public WithdrawCommandHandler(IWallet wallet, OutputCommandHandler outputHandler)
    {
        this.wallet = wallet;
        this.outputHandler = outputHandler;
    }

    public Result Handle(int amount)
    {
        try
        {
            var withdrawResult = wallet.Withdraw(amount);
            var message = withdrawResult.Succeeded ? String.Format(GameMessages.SuccessfulWithdraw, amount) : withdrawResult.Error;

            outputHandler.OutputMessage(message);
            outputHandler.OutputBalance(wallet.Balance);
            outputHandler.OutputNewLine();
            outputHandler.OutputMessage(GameMessages.PleaseSubmitAction);

            return true;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

    }
}
