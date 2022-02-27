using System;
using System.Collections.Generic;

public class IoCContainer : IIoCContainer
{
    private Dictionary<(string, string), Func<object[], object>> container;
    private string defaultScope = "default";
    private string currentScope;

    public IoCContainer() =>
        currentScope = defaultScope;

    public void SetScope(string scope) =>
        currentScope = scope ?? throw new NullReferenceException("Scope cannot be null");

    public void Bind(string key, Func<object[], object> strategy)
    {
        if (key == null) throw new NullReferenceException("Key cannot be null");
        if (strategy == null) throw new NullReferenceException("Strategy cannot be null");
        
        if (container == null) container = new();
        if (container.ContainsKey((currentScope, key))) Unbind(key);
        container.Add((currentScope, key), strategy);
    }
    
    public T Resolve<T>(string key, params object[] args)
    {
        if (container == null) return default(T);
        container.TryGetValue((currentScope, key), out var strategy);
        return (T) strategy?.Invoke(args);
    }
    
    public void Unbind(string key) =>
        container?.Remove((currentScope, key));

    public bool IsBinded(string key)
    {
        if (container == null) return false;
        return container.ContainsKey((currentScope, key));
    }
}
