using Tanks_Game_Core;

public class BurnFuelCommand : ICommand
{
    public readonly Fuel Fuel;
    public BurnFuelCommand(Fuel fuel) =>
        this.Fuel = fuel;
    public void Execute() =>
        Fuel.Burn();   

    public void Undo() =>
        Fuel.Fill(Fuel.Consumption);
}