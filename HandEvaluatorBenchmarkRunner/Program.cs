using HandEvaluatorBenchmarkRunner;
using System.Reflection;

string assemblyName = nameof(HandEvaluator);
string className = $"{assemblyName}.{nameof(HandEvaluator.Hand)}";

Assembly assembly = Assembly.Load(assemblyName);

Type type = assembly.GetType(className) ?? throw new Exception("Class not found");

var methodMap = DynamicMethodLoader.LoadStaticMethods(type);

foreach (var method in methodMap)
{
    foreach (int numberOfCards in new int[] { 5, 7 })
    {
        BenchmarkRunner.BenchmarkMethod(method.Key, methodMap[method.Key], numberOfCards);
    }
}
