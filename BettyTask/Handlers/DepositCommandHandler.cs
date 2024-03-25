using BettyTask.Abstractions;
using BettyTask.Helpers;

namespace BettyTask.Handlers;

internal class DepositCommandHandler : ICommandHandler
{
    private readonly IWallet wallet;
    private readonly OutputCommandHandler outputHandler;

    public DepositCommandHandler(IWallet wallet, OutputCommandHandler outputHandler)
    {
        this.wallet = wallet;
        this.outputHandler = outputHandler;
    }

    public Result Handle(int amount)
    {
        try
        {
            var depositResult = wallet.Deposit(amount);
            var message = depositResult.Succeeded ? String.Format(GameMessages.SuccessfulDeposit, amount) : depositResult.Error;

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
