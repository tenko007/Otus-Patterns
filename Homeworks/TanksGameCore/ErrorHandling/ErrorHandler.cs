using System;

namespace Tanks_Game_Core
{
    public static class ErrorHandler
    {
        public static IErrorHandler Instance { get; private set; } = new EmptyErrorHandler();

        public static void SetHandler(IErrorHandler handler) =>
            Instance = handler;
        
        public static void Handle(ICommand command, Exception exception) =>
            Instance.Handle(command, exception);
    }
}