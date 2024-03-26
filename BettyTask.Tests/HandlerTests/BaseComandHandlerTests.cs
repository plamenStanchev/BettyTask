using BettyTask.Abstractions;

namespace BettyTask.Tests.HandlerTests;

public abstract class BaseComandHandlerTests
{
    public Mock<IWallet> wallet;
    public OutputCommandHandler outputCommandHandler;
    public Mock<IWriter> writer;
    public BaseComandHandlerTests()
    {
        wallet = new Mock<IWallet>();
        wallet.Setup(x => x.Deposit(It.Is<decimal>(c => c > 1 && c < 10))).Returns(true);
        wallet.Setup(x => x.Deposit(It.Is<decimal>(c => c < 1 || c > 10))).Returns(GameMessages.BetLimitError);
        wallet.Setup(x => x.Withdraw(It.Is<decimal>(c => c > 0))).Returns(true);
        wallet.Setup(x => x.Withdraw(It.Is<decimal>(c => c < 0))).Returns(Wallet.AmountExceptionMessage);

        writer = new Mock<IWriter>();
        writer.Setup(x => x.WriteLine(It.IsAny<string>()));
        writer.Setup(x => x.Write(It.IsAny<string>()));

        outputCommandHandler = new OutputCommandHandler(writer.Object);
    }
}
