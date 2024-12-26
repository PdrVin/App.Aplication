using App.Aplication.Models;
using App.Aplication.Services;

CardService service = new();

Responsible responsible = new(0, "Peter", "123123123");

Card myCard = service.CreateCard(Brand.Visa, responsible);
myCard.Deposit(100);
myCard.Buy(50);
myCard.Buy(50);

string result = @$"
Saldo: {myCard.Money}:
Número: {myCard.Number} ";

Console.WriteLine(result);