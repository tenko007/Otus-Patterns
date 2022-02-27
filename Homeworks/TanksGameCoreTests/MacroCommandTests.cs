using System.Numerics;
using NUnit.Framework;
using Tanks_Game_Core;

[TestFixture]
public class MacroCommandTests
{
    [Test]
    public void MacroCommandTestsWithUndo()
    {
        // Макро команда выполняется до первого исключения
        // Undo макро команды возвращает в изначальное состояние

        GameObject gameObject = new GameObject();
        gameObject.AddComponent(new Transform());
        Transform transform = gameObject.GetComponent<Transform>();
        
        ICommand[] commands = new ICommand[]
        {
            new MoveCommand(gameObject, Vector3.One),
            new ErrorCommand(),
            new RotateCommand(gameObject, Vector3.One)
        };
        
        MacroCommand macroCommand = new MacroCommand(commands);

        Assert.Throws<CommandException>(() => macroCommand.Execute());

        Assert.AreEqual(transform.Position, Vector3.One);
        Assert.AreEqual(transform.Rotation, Vector3.Zero);

        macroCommand.Undo();
        
        Assert.AreEqual(transform.Position, Vector3.Zero);
        Assert.AreEqual(transform.Rotation, Vector3.Zero);
    }
}