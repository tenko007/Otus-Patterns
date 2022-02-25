using Tanks_Game_Core;

public class Fuel : IComponent
{
    public int Amount { get; private set; }
    public int MaxAmount { get; private set; }
    public int Consumption { get; private set; }  

    public Fuel(int amount, int maxAmount, int consumption)
    {
        this.Amount = amount;
        this.MaxAmount = maxAmount;
        this.Consumption = consumption;
    }
    
    public void Fill(int amount)
    {
        this.Amount += amount;
        if (this.Amount >= this.MaxAmount)
            this.Amount = this.MaxAmount;
    }

    public void Burn()
    {
        this.Amount -= Consumption;
        // TODO exception?
    }
}