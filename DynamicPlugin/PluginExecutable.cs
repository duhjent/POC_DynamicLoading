using BaseContracts;

namespace DynamicPlugin;

public class PluginExecutable : IExecutable
{
    public void Execute(object args)
    {
        Console.WriteLine("Hello from dynamic plugin");
    }
}