using System;
using System.IO;
using NUnit.Framework;
using Tanks_Game_Core;
using Tanks_Game_Core.Logging;

namespace Tanks_Game_Core___Tests
{
    [TestFixture]
    public class LogCommandTests
    {
        [Test]
        public void LogCommandCreatesFile()
        {
            // Команда LogCommand создает файл log.txt
            // Команда LogCommand добавляется в очередь выполненных команд

            string filePath = LoggingSetup.LogFilePath;
            CommandExecutor.Instance.ClearLastCompletedCommands();
            File.Delete(filePath);
            
            Assert.False(File.Exists(filePath));

            var logCommand = new LogCommand(new ErrorCommand(), new Exception());
            CommandExecutor.Instance.Add(logCommand);

            Assert.True(File.Exists(filePath));
            
            var commandsArray = CommandExecutor.Instance.GetLastCompletedCommands();
            Assert.That(commandsArray.Length, Is.EqualTo(1));
            Assert.That(commandsArray[0].GetType(), Is.EqualTo(typeof(LogCommand)));
        }
    }
}