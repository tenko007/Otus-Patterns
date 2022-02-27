using System.Numerics;
using Tanks_Game_Core;

public class MoveAndBurnFuelCommand : ICommand
{
    public readonly GameObject GameObject;
    public readonly Vector3 Direction;

    private Fuel fuel;
    private Transform transform;

    private ICommand[] commands;
    private MacroCommand macroCommand;

    public MoveAndBurnFuelCommand(GameObject gameObject, Vector3 direction)
    {
        this.GameObject = gameObject;
        this.Direction = direction;
        this.fuel = gameObject.GetComponent<Fuel>();
        this.transform = gameObject.GetComponent<Transform>();
        createCommandsList();
        this.macroCommand = new MacroCommand(commands);
    }

    public void Execute() =>
        macroCommand.Execute();

    public void Undo() =>
        macroCommand.Undo();

    private void createCommandsList()
    {
        commands = new ICommand[]
        {
            new CheckFuelCommand(fuel),
            new BurnFuelCommand(fuel),
            new MoveCommand(GameObject, Direction)
        };
    }
}