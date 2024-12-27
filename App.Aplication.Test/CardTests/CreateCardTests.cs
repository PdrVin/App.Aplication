using App.Aplication.Models;
using App.Aplication.Services;

namespace App.Aplication.Test.CardTests;

public class CreateCardTests
{
    [Fact(DisplayName = "Cartão Deve Possuir Número")]
    public void MustCreateCardWithNumber()
    {
        CardService service = new();
        Responsible responsible = new(1, "Peter", "123123123");

        var card = service.CreateCard(Models.Brand.Mastercard, responsible);

        // Asserts XUnit
        Assert.NotNull(card.Number);
        Assert.NotEqual("", card.Number);
    }

    [Fact(DisplayName = "Pessoa Deve Possuir Documento")]
    public void MustReturnErrorPersonWIthoutDoc()
    {
        CardService service = new();
        Responsible responsible = new(1, "Peter", "");

        Func<Card> card = () => service.CreateCard(Models.Brand.Mastercard, responsible);

        // Asserts XUnit
        var exception = Assert.Throws<ArgumentException>(card);
        Assert.Contains("campo obrigatório", exception.Message.ToLower());
    }
}
