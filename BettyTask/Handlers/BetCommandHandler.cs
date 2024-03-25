using BettyTask.Abstractions;
using BettyTask.Helpers;

namespace BettyTask.Handlers;

public class BetCommandHandler : ICommandHandler
{
    private const decimal ToDollarsDelimitar = 100m;
    private const decimal DefaultValue = 0.0m;
    private const int NoWinValue = 0;

    private readonly IWallet wallet;
    private readonly IGame game;
    private readonly OutputCommandHandler outputHandler;

    public BetCommandHandler(IWallet wallet, IGame game, OutputCommandHandler outputHandler)
    {
        this.wallet = wallet;
        this.game = game;
        this.outputHandler = outputHandler;
    }

    public Result Handle(int amount)
    {
        try
        {
            if (amount > 10 || amount < 1)
            {
                return GameMessages.BetLimitError;
            }

            var winAmount = DefaultValue;
            var message = string.Empty;

            var withdrawResult = this.wallet.Withdraw(amount);
            if (!withdrawResult.Succeeded)
            {
                return withdrawResult.Error;
            }

            var win = game.Bet(amount);
            if (win == NoWinValue)
            {
                message = GameMessages.LoseSpin;
            }
            else
            {
                winAmount = win / ToDollarsDelimitar;
                message = string.Format(GameMessages.WinSpin, winAmount);
            }

            this.wallet.Deposit(winAmount);

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
