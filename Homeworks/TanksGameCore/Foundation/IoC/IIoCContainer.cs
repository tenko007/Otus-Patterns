using System;

public interface IIoCContainer
{
    void SetScope(string scope);
    void Bind(string key, Func<object[], object> strategy);
    T Resolve<T>(string key, object[] args);
    void Unbind(string key);
    bool IsBinded(string key);
}