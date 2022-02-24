using System;

namespace Tanks_Game_Core
{
    public class RepeatOnceAndLogErrorHandler : IErrorHandler
    {
        public void Handle(ICommand command, Exception exception)
        {
            CommandExecutor.Instance.Add(
                command is RepeatCommand repeatCommand
                    ? new LogCommand(repeatCommand.RepeatableCommand, exception)
                    : new RepeatCommand(command));
        }
    }
}