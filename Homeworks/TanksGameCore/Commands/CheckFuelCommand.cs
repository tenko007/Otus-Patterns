using Tanks_Game_Core;

public class CheckFuelCommand : ICommand
{
    public readonly Fuel Fuel;

    public CheckFuelCommand(Fuel fuel) =>
        this.Fuel = fuel;

    public void Execute()
    {
        if (Fuel.Amount < Fuel.Consumption)
            throw new CommandException(this);
    }

    public void Undo()
    {
        // do nothing
    }
}