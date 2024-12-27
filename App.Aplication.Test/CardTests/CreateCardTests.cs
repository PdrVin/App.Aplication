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
        Assert.Contains("Campo Obrigatório", exception.Message);
    }

    [Fact]
    public void TestDeposit()
    {
        CardService service = new();
        Responsible responsible = new(1, "Peter", "123123123");

        Card myCard = service.CreateCard(Models.Brand.Mastercard, responsible);
        myCard.Deposit(1000);

        // Asserts XUnit
        Assert.Equal(1000, myCard.Money);
    }

    [Fact]
    public void TestBuy()
    {
        CardService service = new();
        Responsible responsible = new(1, "Peter", "123123123");

        Card myCard = service.CreateCard(Models.Brand.Visa, responsible);
        myCard.Deposit(1000);
        myCard.Buy(100);
        myCard.Buy(100);

        // Asserts XUnit
        Assert.Equal(800, myCard.Money);
    }

    [Theory]
    [InlineData("1")]
    [InlineData("123")]
    [InlineData("123123")]
    public void TestValidDocuments(string document)
    {
        try
        {
            CardService service = new();
            Responsible responsible = new(1, "Peter", document);

            service.ValidResponsibleCard(responsible);
        }
        catch (Exception error)
        {
            Assert.Fail(error.Message);
        }
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void TestNotValidDocuments(string document)
    {
        try
        {
            CardService service = new();
            Responsible responsible = new(1, "Peter", document);

            service.ValidResponsibleCard(responsible);
            Assert.Fail("Não esperado");
        }
        catch (Exception error)
        {
            Assert.Contains("Campo Obrigatório", error.Message);
        }
    }
}
