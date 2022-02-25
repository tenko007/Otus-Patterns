using System;
using Tanks_Game_Core;

public class EmptyErrorHandler : IErrorHandler
{
    public void Handle(ICommand command, Exception exception)
    {
        // do nothing
    }
}