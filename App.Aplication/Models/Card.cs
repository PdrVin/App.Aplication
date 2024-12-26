namespace App.Aplication.Models;

public class Card
{
    public int Id { get; set; }
    public string? Number { get; set; }
    public decimal Money { get; set; }
    public CardStatus Status { get; set; }
    public required Responsible Responsible { get; set; }
    public Brand Brand { get; set; }

    public void Deposit(decimal value)
    {
        this.Money += value;
    }

    public void Buy(decimal value)
    {
        this.Money -= value;
    }
}
