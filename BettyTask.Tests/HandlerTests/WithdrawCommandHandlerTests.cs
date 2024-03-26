namespace BettyTask.Tests.HandlerTests;

public class WithdrawCommandHandlerTests : BaseComandHandlerTests
{
    WithdrawCommandHandler withdrawCommandHandler;
    public WithdrawCommandHandlerTests() : base() 
    {
        withdrawCommandHandler = new WithdrawCommandHandler(wallet.Object, outputCommandHandler);
    }

    [Fact]
    public void Handle_WhenAmoutIs5_HitWithdrawAndHitMessageSuccessWithdraw()
    {
        var amout = 5;
        withdrawCommandHandler.Handle(amout);
        wallet.Verify(x => x.Withdraw(amout),Times.Once());
        writer.Verify(x => x.WriteLine(It.Is<string>(c => c.StartsWith(String.Format(GameMessages.SuccessfulWithdraw, amout)))),Times.Once());
    }

    [Fact]
    public void Handle_WhenAmoutIsLessThan0_HitWithdrawAndHitMessageFailWithdraw()
    {
        var amout = -5;
        withdrawCommandHandler.Handle(amout);
        wallet.Verify(x => x.Withdraw(amout), Times.Once());
        writer.Verify(x => x.WriteLine(It.Is<string>(c => c.StartsWith(Wallet.AmountExceptionMessage))), Times.Once());
    }
}
