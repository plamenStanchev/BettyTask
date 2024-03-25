using BettyTask.Abstractions;

namespace BettyTask.Helpers;

public class ConsoleWriter : IWriter
{
    public void Write(string value)
     => Console.WriteLine(value);
    
    public void WriteLine(string value)
    => Console.WriteLine(value);
    
}
