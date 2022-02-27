using System;

public static class IoC
{
    private static IIoCContainer realization = new IoCContainer();

    public static void SetRealization(IIoCContainer realization) =>
        IoC.realization = realization;

    public static void SetScope(string scope) =>
        realization.SetScope(scope);
    
    public static void Bind(string key, Func<object[], object> strategy) =>
        realization.Bind(key, strategy);

    public static T Resolve<T>(string key, params object[] args) =>
        realization.Resolve<T>(key, args);

    public static void Unbind(string key) => 
        realization.Unbind(key);

    public static bool IsBinded(string key) =>
        realization.IsBinded(key);
}