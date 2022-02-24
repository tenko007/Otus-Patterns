using System;

namespace Tanks_Game_Core
{
    public class RepeatErrorHandler : IErrorHandler
    {
        public void Handle(ICommand command, Exception exception)
        {
            if (command is not RepeatCommand)
                CommandExecutor.Instance.Add(new RepeatCommand(command));
        }
    }
}