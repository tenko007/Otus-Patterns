using System.Numerics;
using NUnit.Framework;
using Tanks_Game_Core;

[TestFixture]
public class MoveAndBurnFuelCommandTests
{
    [Test]
    public void MoveAndBurnFuelCommandDecreaseFuelAmount()
    {
        // Количество топлива уменьшается

        Fuel fuel = new Fuel(100, 100, 50);
        Transform transform = new Transform();
        GameObject tank = new GameObject();
        tank.AddComponent(fuel);
        tank.AddComponent(transform);
        
        MoveAndBurnFuelCommand moveAndBurnFuelCommand = new MoveAndBurnFuelCommand(tank, Vector3.One);

        Assert.AreEqual(fuel.Amount, 100);
        
        moveAndBurnFuelCommand.Execute();
        Assert.AreEqual(fuel.Amount, 50);
        
        moveAndBurnFuelCommand.Execute();
        Assert.AreEqual(fuel.Amount, 0);
    }
    
    [Test]
    public void MoveAndBurnFuelCommandChangesPosition()
    {
        // Положение танка меняется

        Fuel fuel = new Fuel(100, 100, 50);
        Transform transform = new Transform();
        GameObject tank = new GameObject();
        tank.AddComponent(fuel);
        tank.AddComponent(transform);
        
        MoveAndBurnFuelCommand moveAndBurnFuelCommand = new MoveAndBurnFuelCommand(tank, Vector3.One);

        Assert.AreEqual(transform.Position, Vector3.Zero);
        
        moveAndBurnFuelCommand.Execute();
        Assert.AreEqual(transform.Position, Vector3.One);
        
        moveAndBurnFuelCommand.Execute();
        Assert.AreEqual(transform.Position, Vector3.One * 2);
    }
    
    [Test]
    public void MoveAndBurnFuelCommandThrowWhenNotEnoughFuel()
    {
        // При недостатке топлива выбрасывается исключение CommandException

        Fuel fuel = new Fuel(10, 100, 11);
        Transform transform = new Transform();
        GameObject tank = new GameObject();
        tank.AddComponent(fuel);
        tank.AddComponent(transform);
        
        MoveAndBurnFuelCommand moveAndBurnFuelCommand = new MoveAndBurnFuelCommand(tank, Vector3.One);

        Assert.Throws<CommandException>(()=>moveAndBurnFuelCommand.Execute());
    }
}