using BettyTask.Abstractions;
using BettyTask.Handlers;
using BettyTask.Helpers;

namespace BettyTask;

public class Program
{
    private readonly IWallet wallet;
    private readonly IGame game;
    private readonly OutputCommandHandler outputCommandHandler;
    public Program()//DI simulation Stuff
    {
        this.wallet = new Wallet();
        this.game = new Game();
        outputCommandHandler = new OutputCommandHandler(new ConsoleWriter());
    }

    static void Main(string[] args)
    {
        var program = new Program();
        program.Run();
    }

    public void Run()
    {
        outputCommandHandler.OutputMessage(GameMessages.PleaseSubmitAction);
        string command = string.Empty;
        while ((command = Console.ReadLine().ToLower()) != "exit")
        {
            ProcessCommand(command);
        }
        outputCommandHandler.OutputMessage(GameMessages.GoAwayMessage);
    }

    private void ProcessCommand(string command)// Imagine this is a speared class 
    {
        var betCommand = new BetCommandHandler(wallet, game, outputCommandHandler); // and this is its DI stuff
        var withdrawCommand = new WithdrawCommandHandler(wallet, outputCommandHandler);
        var depositCommand = new DepositCommandHandler(wallet, outputCommandHandler);// because i feel strange doing so much abstraction for such a little task :)

        try//this is to play around with the program more easily
        {
            var commandParts = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var commandType = commandParts[0];
            var amount = int.Parse(commandParts[1]);

            switch (commandType)
            {
                case "bet":
                    var resultBet = betCommand.Handle(amount);
                    CheckAndOutputIfFail(resultBet);
                    break;
                case "deposit":
                    var resultDeposit = depositCommand.Handle(amount);
                    CheckAndOutputIfFail(resultDeposit);
                    break;
                case "withdraw":
                    var resultWithdraw = withdrawCommand.Handle(amount);
                    CheckAndOutputIfFail(resultWithdraw);
                    break;
                default:
                    outputCommandHandler.OutputMessage(GameMessages.UnrecognizedAction);
                    outputCommandHandler.OutputMessage(GameMessages.PleaseSubmitAction);
                    break;
            }
        }
        catch (FormatException)
        {
            outputCommandHandler.OutputMessage("Something went wrong in the input please try again");
        }
        catch (ArgumentOutOfRangeException)
        {
            outputCommandHandler.OutputMessage("Something went wrong in the input please try again");

        }
    }

    private void CheckAndOutputIfFail(Result result)
    {
        if (!result.Succeeded)
        {
            outputCommandHandler.OutputMessage(result.Error);
            outputCommandHandler.OutputBalance(wallet.Balance);
            outputCommandHandler.OutputMessage(GameMessages.PleaseSubmitAction);
        }
    }
}
