using System.Numerics;
using NUnit.Framework;
using Tanks_Game_Core;

namespace Tanks_Game_Core___Tests
{
    [TestFixture]
    public class RepeatCommandTests
    {
        [Test]
        public void RepeatCommandRepeatsCommand()
        {
            CommandExecutor.Instance.ClearLastCompletedCommands();
            ErrorHandler.SetHandler(new EmptyErrorHandler());

            var errorCommand = new MoveCommand(new Transform(), Vector3.One);
            RepeatCommand repeatCommand = new RepeatCommand(errorCommand);
            CommandExecutor.Instance.Add(repeatCommand);

            var commandsArray = CommandExecutor.Instance.GetLastCompletedCommands();
            Assert.That(commandsArray.Length, Is.EqualTo(1));
            Assert.That(commandsArray[0].GetType(), Is.EqualTo(typeof(RepeatCommand)));
            Assert.That(((RepeatCommand)commandsArray[0]).RepeatableCommand.GetType(), Is.EqualTo(typeof(MoveCommand)));
        }
    }
}