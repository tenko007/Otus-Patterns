using System;

namespace Tanks_Game_Core
{
    public class RepeatTwiceAndLogErrorHandler : IErrorHandler
    {
        public void Handle(ICommand command, Exception exception)
        {
            if (command is RepeatCommand repeatCommand)
            {
                CommandExecutor.Instance.Add(
                    repeatCommand.Iteration >= 2 
                        ? new LogCommand(repeatCommand.RepeatableCommand, exception)
                        : new RepeatCommand(command, repeatCommand.Iteration + 1));
            }
            else
            {
                CommandExecutor.Instance.Add(new RepeatCommand(command));
            }
        }
    }
}