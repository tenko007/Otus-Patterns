using System;
using System.IO;
using System.Numerics;
using CodeGeneration;
using NUnit.Framework;
using Tanks_Game_Core;
using Tanks_Game_Core.Logging;

[TestFixture]
public class AdapterGeneratorTests
{
    [Test]
    public void AdapterGeneratorCreatesFile()
    {
        // AdapterGenerator создает файл ###Adapter.cs
        AdapterGenerator adapterGenerator = new AdapterGenerator();
        string filePath = adapterGenerator.FilePath(typeof(IMovable));
        
        File.Delete(filePath);
        Assert.False(File.Exists(filePath));

        adapterGenerator.Generate(typeof(IMovable));
        
        Assert.True(File.Exists(filePath));
    }
    
    /*
    [SetUp]
    public void SetUp()
    {
        IoC.SetRealization(new IoCContainer());
    }
    
    [Test]
    public void BindTest()
    {
        // Метод Bind добавляет новую стратегию в IoC-контейнер

        Assert.False(IoC.IsBinded("Move"));
        IoC.Bind("Move", objects => new MoveCommand((GameObject) objects[0], (Vector3) objects[1]));
        Assert.True(IoC.IsBinded("Move"));
        Assert.False(IoC.IsBinded("Rotate"));
    }
    
    [Test]
    public void UnbindTest()
    {
        // Метод Unbind удаляет стратегию из IoC-контейнера

        Assert.False(IoC.IsBinded("Move"));
        IoC.Bind("Move", objects => new MoveCommand((GameObject) objects[0], (Vector3) objects[1]));
        Assert.True(IoC.IsBinded("Move"));
        IoC.Unbind("Move");
        Assert.False(IoC.IsBinded("Move"));
    }
    
    [Test]
    public void ResolveCreateNewObjectTest()
    {
        IoC.Bind("Move", objects => new MoveCommand((GameObject) objects[0], (Vector3) objects[1]));
        
        GameObject gameObject = new GameObject();
        Vector3 direction = Vector3.One;
        object newMoveCommand = IoC.Resolve<ICommand>("Move", gameObject, direction);
        
        Assert.That(newMoveCommand.GetType(), Is.EqualTo(typeof(MoveCommand)));
        Assert.That(((MoveCommand)newMoveCommand).GameObject, Is.EqualTo(gameObject));
        Assert.That(((MoveCommand)newMoveCommand).Direction, Is.EqualTo(direction));
    }
    
    [Test]
    public void RebindResolvesCorrectBinding()
    {
        IoC.Bind("Move", objects => new MoveCommand((GameObject) objects[0], (Vector3) objects[1]));
        IoC.Bind("Move", objects => new MoveAndBurnFuelCommand((GameObject) objects[0], (Vector3) objects[1]));

        GameObject gameObject = new GameObject();
        Vector3 direction = Vector3.One;
        object newMoveCommand = IoC.Resolve<ICommand>("Move", gameObject, direction);
        
        Assert.That(newMoveCommand.GetType(), Is.EqualTo(typeof(MoveAndBurnFuelCommand)));
        Assert.That(((MoveAndBurnFuelCommand)newMoveCommand).GameObject, Is.EqualTo(gameObject));
        Assert.That(((MoveAndBurnFuelCommand)newMoveCommand).Direction, Is.EqualTo(direction));
    }
    
    [Test]
    public void UnbindThenBindResolvesCorrectBinding()
    {
        IoC.Bind("Move", objects => new MoveCommand((GameObject) objects[0], (Vector3) objects[1]));
        IoC.Unbind("Move");
        IoC.Bind("Move", objects => new MoveAndBurnFuelCommand((GameObject) objects[0], (Vector3) objects[1]));

        GameObject gameObject = new GameObject();
        Vector3 direction = Vector3.One;
        object newMoveCommand = IoC.Resolve<ICommand>("Move", gameObject, direction);
        
        Assert.That(newMoveCommand.GetType(), Is.EqualTo(typeof(MoveAndBurnFuelCommand)));
        Assert.That(((MoveAndBurnFuelCommand)newMoveCommand).GameObject, Is.EqualTo(gameObject));
        Assert.That(((MoveAndBurnFuelCommand)newMoveCommand).Direction, Is.EqualTo(direction));
    }
    
    [Test]
    public void NullKeyBindThrowsException()
    {
        Assert.Throws<NullReferenceException>(() => 
            IoC.Bind(
                null, 
                objects => new MoveCommand((GameObject) objects[0], (Vector3) objects[1])));
    }
    
    [Test]
    public void NullStrategyBindThrowsException()
    {
        Assert.Throws<NullReferenceException>(() =>
            IoC.Bind(
                "Move", null));
    }
    */
}
