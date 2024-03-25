using BettyTask.Abstractions;
using BettyTask.Helpers;

namespace BettyTask.Handlers;

public class OutputCommandHandler
{
    private readonly IWriter writer;

    public OutputCommandHandler(IWriter writer)
    {
        this.writer = writer;
    }

    public void OutputMessage(string message)
    {
        writer.WriteLine(message);
    }

    public void OutputBalance(decimal balance)
    {
        writer.WriteLine(string.Format(GameMessages.BalanceMessage, balance));
    }

    public void OutputNewLine()
    {
        writer.WriteLine();
    }
}
