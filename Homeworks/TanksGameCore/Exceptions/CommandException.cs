using System;
using Tanks_Game_Core;

public class CommandException : Exception
{
    public readonly ICommand Command;
    public readonly Exception Exception;
    
    public CommandException(ICommand command)
    {
        this.Command = command;
        this.Exception = this;
    }
    public CommandException(ICommand command, Exception exception)
    {
        this.Command = command;
        this.Exception = exception;
    }
}