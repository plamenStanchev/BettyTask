namespace BettyTask.Abstractions;

public interface IWriter
{
    public void Write(string value);

    public void WriteLine(string value = "");
}
