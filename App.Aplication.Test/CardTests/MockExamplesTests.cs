using App.Aplication.Models;
using App.Aplication.Services;
using Moq;

namespace App.Aplication.Test.CardTests;

// dotnet add package Moq --version 4.20.72

public class MockExamplesTests
{
    [Fact(DisplayName = "Testando Save com Cartão Existente")]
    public void TestSaveWithExistentCard()
    {
        Mock<ICardRepository> mockRepository = new();
        mockRepository.Setup(a => a.GetByNumber(It.IsAny<string>())).Returns(CardMock);
        CardService service = new(mockRepository.Object);

        var myCard = new Card()
        {
            Number = "123",
            Id = 1,
            Brand = Brand.Visa,
            Status = CardStatus.Active,
            Responsible = new Responsible(1, "Peter", "DOCUMENT")
        };

        void saveMethod() => service.Save(myCard);

        var exception = Assert.Throws<ArgumentException>(saveMethod);
        Assert.Contains("Já existe um Cartão", exception.Message);
    }

    private Card CardMock()
    {
        return new Card()
        {
            Number = "777777",
            Id = 7,
            Brand = Brand.Visa,
            Status = CardStatus.Active,
            Responsible = new Responsible(1, "Peter", "DOCUMENT")
        };
    }

    [Fact(DisplayName = "Testando Save com Cartão Inexistente")]
    public void TestSaveWithNonExistentCard()
    {
        int numberTest = 7;
        Mock<ICardRepository> mockRepository = new();
        mockRepository.Setup(a => a.GetByNumber(It.IsAny<string>())).Returns(null as Card);
        mockRepository.Setup(x => x.Save(It.IsAny<Card>())).Returns(numberTest);
        CardService service = new(mockRepository.Object);

        var myCard = new Card()
        {
            Number = "123",
            Id = 1,
            Brand = Brand.Visa,
            Status = CardStatus.Active,
            Responsible = new Responsible(1, "Peter", "DOCUMENT")
        };

        service.Save(myCard);

        Assert.Equal(numberTest, myCard.Id);
    }
}
