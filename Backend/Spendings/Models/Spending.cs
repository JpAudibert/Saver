namespace Backend.Spendings.Models;

public class Spending
{
    public double Amount { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }

    public Spending()
    { }

    public Spending(double amount, string description, string type)
    {
        Amount = amount;
        Description = description;
        Type = type;
    }
}
