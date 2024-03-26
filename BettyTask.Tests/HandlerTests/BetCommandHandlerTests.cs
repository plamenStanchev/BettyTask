namespace BettyTask.Tests.HandlerTests;

public class BetCommandHandlerTests : BaseComandHandlerTests
{
    BetCommandHandler betCommandHandler;
    Mock<IGame> game;
    public const int defualtWinAmout = 1;
    public BetCommandHandlerTests() : base()
    {
        game = new Mock<IGame>();
        game.Setup(x => x.Bet(It.IsAny<int>())).Returns(defualtWinAmout);
        betCommandHandler = new BetCommandHandler(wallet.Object, game.Object, outputCommandHandler);
    }

    [Fact]
    public void Handle_WhenBetAmountIs5_WalletWithdrowGetsHitWithAmoutWalletDepositGetHitWithReturnFromBet1()
    {
        var amout = 5;
        betCommandHandler.Handle(amout);
        wallet.Verify(x => x.Withdraw(amout),Times.Once());
        wallet.Verify(x => x.Deposit(defualtWinAmout/ 100m),Times.Once());
    }
}
