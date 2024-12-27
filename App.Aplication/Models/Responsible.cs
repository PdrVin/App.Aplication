using System;

namespace App.Aplication.Models;

public class Responsible(int id, string name, string document)
{
    public int Id { get; private set; } = id;
    public string Name { get; private set; } = name;
    public string Document { get; private set; } = document;
}
