using BettyTask.Handlers;

namespace BettyTask.Tests.HandlerTests;

public class DepositCommandHandlerTests : BaseComandHandlerTests
{
    DepositCommandHandler depositCommandHandler;
    public DepositCommandHandlerTests() : base()
    {
        depositCommandHandler = new DepositCommandHandler(wallet.Object, outputCommandHandler);
    }

    [Fact]
    public void Handle_WhenAmountIs5_WaletDepostiGetsHitAndWriterGetsHit()
    {
        int amount = 5;
        depositCommandHandler.Handle(5);
        wallet.Verify(x => x.Deposit(amount),Times.Once());
        writer.Verify(x => x.WriteLine(It.Is<string>(c => c.StartsWith(String.Format(GameMessages.SuccessfulDeposit,amount)))), Times.AtLeastOnce());

    }

    [Fact]
    public void Handle_WhenAmountIs100_WaletDepostiGetHitAndWriterGetsHitWithAnError()
    {
        int amount = 100;
        depositCommandHandler.Handle(100);
        wallet.Verify(x => x.Deposit(amount), Times.Once());
        writer.Verify(x => x.WriteLine(It.Is<string>(c => c.StartsWith(GameMessages.BetLimitError) )), Times.AtLeastOnce());
    }
}
