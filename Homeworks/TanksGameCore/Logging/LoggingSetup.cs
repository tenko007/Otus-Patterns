using System;
using System.IO;

namespace Tanks_Game_Core.Logging
{
    public static class LoggingSetup
    {
        public static string LogFilePath = Directory.GetCurrentDirectory() + "\\log.txt"; 
        public static string LogErrorCommandText(ICommand command, Exception exception) =>
            $"Error in command {command.GetType()}: {exception.Message}";
    }
}