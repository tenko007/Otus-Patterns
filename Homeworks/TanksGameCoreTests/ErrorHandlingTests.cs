using NUnit.Framework;
using Tanks_Game_Core;

namespace Tanks_Game_Core___Tests
{
    [TestFixture]
    public class ErrorHandlingTests
    {
        [Test]
        public void TestLogHandler()
        {
            // Обработчик исключения, который ставит Команду, пишущую в лог в очередь Команд.

            ErrorHandler.SetHandler(new LogErrorHandler());
            ErrorCommand errorCommand = new ErrorCommand();
            
            CommandExecutor.Instance.ClearLastCompletedCommands();
            CommandExecutor.Instance.Add(errorCommand);

            var commandsArray = CommandExecutor.Instance.GetLastCompletedCommands();

            Assert.That(commandsArray.Length, Is.EqualTo(2));
            Assert.That(commandsArray[0].GetType(), Is.EqualTo(typeof(ErrorCommand)));
            Assert.That(commandsArray[1].GetType(), Is.EqualTo(typeof(LogCommand)));
        }
        
        [Test]
        public void TestRepeatHandler()
        {
            // Обработчик исключения, который ставит в очередь Команду - повторитель команды, выбросившей исключение.

            ErrorHandler.SetHandler(new RepeatErrorHandler());
            ErrorCommand errorCommand = new ErrorCommand();
            
            CommandExecutor.Instance.ClearLastCompletedCommands();
            CommandExecutor.Instance.Add(errorCommand);

            var commandsArray = CommandExecutor.Instance.GetLastCompletedCommands();

            Assert.That(commandsArray.Length, Is.EqualTo(2));
            Assert.That(commandsArray[0].GetType(), Is.EqualTo(typeof(ErrorCommand)));
            Assert.That(commandsArray[1].GetType(), Is.EqualTo(typeof(RepeatCommand)));
        }
        
        [Test]
        public void TestOnceRepeatAndLogHandler()
        {
            // При первом выбросе исключения повторить команду, при повторном выбросе исключения записать информацию в лог.

            ErrorHandler.SetHandler(new RepeatOnceAndLogErrorHandler());
            ErrorCommand errorCommand = new ErrorCommand();

            CommandExecutor.Instance.ClearLastCompletedCommands();
            CommandExecutor.Instance.Add(errorCommand);

            var commandsArray = CommandExecutor.Instance.GetLastCompletedCommands();

            Assert.That(commandsArray.Length, Is.EqualTo(3));
            Assert.That(commandsArray[0].GetType(), Is.EqualTo(typeof(ErrorCommand)));
            Assert.That(commandsArray[1].GetType(), Is.EqualTo(typeof(RepeatCommand)));
            Assert.That(commandsArray[2].GetType(), Is.EqualTo(typeof(LogCommand)));
        }
        
        [Test]
        public void TestTwiceRepeatAndLogHandler()
        {
            // Стратегия обработки исключения - повторить два раза, потом записать в лог.

            ErrorHandler.SetHandler(new RepeatTwiceAndLogErrorHandler());
            ErrorCommand errorCommand = new ErrorCommand();
            
            CommandExecutor.Instance.ClearLastCompletedCommands();
            CommandExecutor.Instance.Add(errorCommand);

            var commandsArray = CommandExecutor.Instance.GetLastCompletedCommands();

            Assert.That(commandsArray.Length, Is.EqualTo(4));
            Assert.That(commandsArray[0].GetType(), Is.EqualTo(typeof(ErrorCommand)));
            Assert.That(commandsArray[1].GetType(), Is.EqualTo(typeof(RepeatCommand)));
            Assert.That(commandsArray[2].GetType(), Is.EqualTo(typeof(RepeatCommand)));
            Assert.That(commandsArray[3].GetType(), Is.EqualTo(typeof(LogCommand)));
        }
        
    }
}