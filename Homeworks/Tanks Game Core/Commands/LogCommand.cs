using System;
using System.IO;
using System.Text;
using Tanks_Game_Core.Logging;

namespace Tanks_Game_Core
{
    public class LogCommand : ICommand
    {
        private readonly ICommand Command;
        private readonly Exception Exception;

        public LogCommand(ICommand command, Exception exception)
        {
            this.Command = command;
            this.Exception = exception;
        }
        public void Execute() => 
            WriteLog(Command, Exception);

        public void Undo() { }
	    
        public static void WriteLog(ICommand command, Exception exception) =>
            WriteLog(LoggingSetup.LogErrorCommandText(command, exception));
	    
        public static void WriteLog(string msg)
        {
            if (string.IsNullOrEmpty(msg)) return;
            using (var outfile = new StreamWriter(LoggingSetup.LogFilePath, true, Encoding.UTF8))
            {
                outfile.WriteLine("***********************");
                outfile.WriteLine("Date: {0}", DateTime.Now);
                outfile.WriteLine(msg);
                outfile.WriteLine();
            }
        }
    }
}