// See https://aka.ms/new-console-template for more information

using System.Reflection;
using BaseContracts;

var plugins = new List<Assembly>();

foreach (var arg in args)
{
    // var assembly = System.Runtime.Loader.AssemblyLoadContext.Default.LoadFromAssemblyPath(arg);
    plugins.Add(Assembly.LoadFile(arg));
}


var pluggedInTypes = plugins.SelectMany(x => x.DefinedTypes)
    .Where(x => x.IsClass && !x.IsAbstract && x.ImplementedInterfaces.Contains(typeof(IExecutable)));

foreach (var type in pluggedInTypes)
{
    var typeInstance = (IExecutable) Activator.CreateInstance(type)!;
    typeInstance.Execute(null);
}
