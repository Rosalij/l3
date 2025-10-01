using System;
namespace GuestbookApp;


//klass för gästboksinlägg
public class GuestbookPost
{
    //getters och setters för ägare och meddelande
    public string? Owner { get; set; }
    public string? Message { get; set; }


    //konstruktorer
    public GuestbookPost() { }

    public GuestbookPost(string owner, string message)
    {//parametrar för ägare och meddelande
        Owner = owner;
        Message = message;
    }

    //override ToString-metoden för att skriva ut ägare och meddelande
    public override string ToString()
    {
        return $"{Owner}: {Message}";
    }
}
