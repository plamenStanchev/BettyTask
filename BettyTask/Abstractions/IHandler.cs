using BettyTask.Helpers;

namespace BettyTask.Abstractions;

public interface ICommandHandler
{
    public Result Handle(int amount);
}
