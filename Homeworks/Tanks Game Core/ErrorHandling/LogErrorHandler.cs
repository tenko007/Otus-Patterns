using System;

namespace Tanks_Game_Core
{
    public class LogErrorHandler : IErrorHandler
    {
        public void Handle(ICommand command, Exception exception)
        {
            CommandExecutor.Instance.Add(new LogCommand(command, exception));
        }
    }
}