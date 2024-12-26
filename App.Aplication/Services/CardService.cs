using System;
using App.Aplication.Models;

namespace App.Aplication.Services;

public class CardService
{
    public Card CreateCard(Brand brand, Responsible responsible)
    {
        ValidResponsibleCard(responsible);
        string cardNumber = GenerateCardNumber();

        Card cardCreated = new()
        {
            Number = cardNumber,
            Brand = brand,
            Responsible = responsible,
            Status = CardStatus.Active,
        };
        return cardCreated;
    }

    public string GenerateCardNumber()
    {
        Random random = new();
        int number = random.Next(9999999);
        int digit = random.Next(9);
        return $"{number}-{digit}";
    }

    public void ValidResponsibleCard(Responsible responsible)
    {
        if (responsible == null)
        {
            throw new ArgumentException("Responsável Obrigatório");
        }
        if (string.IsNullOrEmpty(responsible.Name))
        {
            throw new ArgumentException("Campo Obrigatório: Nome do Responsável");
        }
        if (string.IsNullOrEmpty(responsible.Document))
        {
            throw new ArgumentException("Campo Obrigatório: Documento do Responsável");
        }
    }
}
