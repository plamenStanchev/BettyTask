using BettyTask.Handlers;

namespace BettyTask.Tests.HandlerTests;

public class DepositCommandHandlerTests : BaseComandHandlerTests
{
    DepositCommandHandler depositCommandHandler;
    public DepositCommandHandlerTests() : base()
    {
        depositCommandHandler = new DepositCommandHandler();
    } 

}
