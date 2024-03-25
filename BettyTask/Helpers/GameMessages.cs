namespace BettyTask.Helpers;

public class GameMessages
{
    public const string PleaseSubmitAction = "Please, submit action:";
    public const string UnrecognizedAction = "Unrecognized action please try again! ";
    public const string BetLimitError = "Bet must be between 1 and 10";
    public const string GoAwayMessage = "You have stopped playing :( me sad";
    public static readonly string SuccessfulDeposit = "Your deposit of ${0} was successful. ";
    public static readonly string SuccessfulWithdraw = "Your withdraw of ${0} was successful. ";
    public static readonly string LoseSpin = "No luck this time! ";
    public static readonly string WinSpin = "Congrats - you won ${0}! ";

    public static readonly string BalanceMessage = "Your balance is: ${0}";
}
