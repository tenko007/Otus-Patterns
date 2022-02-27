using System;
using System.IO;
using System.Numerics;

namespace Tanks_Game_Core
{
    class Program
    {
        static void Main(string[] args)
        {
            //ErrorHandler.SetHandler(new RepeatOnceAndLogErrorHandler());
            ErrorHandler.SetHandler(new RepeatTwiceAndLogErrorHandler());
            ErrorCommand errorCommand = new ErrorCommand();
            
            CommandExecutor.Instance.Add(errorCommand);
            CommandExecutor.Instance.Add(new MoveCommand(new GameObject(), Vector3.One));

            var commandsArray = CommandExecutor.Instance.GetLastCompletedCommands();
            Console.WriteLine($"{Directory.GetCurrentDirectory()}");
        }
    }
}
