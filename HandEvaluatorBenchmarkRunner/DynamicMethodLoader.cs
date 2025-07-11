using HandEvaluator.Models;
using System.Reflection;
using static HandEvaluator.Hand;

namespace HandEvaluatorBenchmarkRunner;

public static class DynamicMethodLoader
{
    public static Dictionary<string, Delegate> LoadStaticMethods(Type type)
    {
        var methods = new Dictionary<string, Delegate>();

        MethodInfo evalMethod = type.GetMethod(
            nameof(Evaluate),
            BindingFlags.Public | BindingFlags.Static,
            null,
            [typeof(ulong)],
            null
        ) ?? throw new Exception("Method not found in method map");

        methods[nameof(Evaluate)] = Delegate.CreateDelegate(typeof(Func<ulong, uint>), evalMethod);

        MethodInfo evalTypeMethod = type.GetMethod(
            nameof(EvaluateType),
            BindingFlags.Public | BindingFlags.Static,
            null,
            [typeof(ulong)],
            null
        ) ?? throw new Exception("Method not found in method map");

        methods[nameof(EvaluateType)] = Delegate.CreateDelegate(typeof(Func<ulong, HandTypes>), evalTypeMethod);

        return methods;
    }
}
