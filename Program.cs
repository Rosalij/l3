using System;
using System.Diagnostics;

namespace GuestbookApp;

class Program
{
    static void Main(string[] args)
    {//Create instance of Guestbook
        Guestbook guestbook = new Guestbook();
        int i = 0;

        bool running = true;
        while (running)
        {//Menu
            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine("G Ä S T B O K\n\n");
            Console.WriteLine("1. Lägg till inlägg");
            Console.WriteLine("2. Ta bort inlägg\n");
            Console.WriteLine("X. Avsluta\n");
            //List posts
            i = 0;
            foreach (GuestbookPost post in guestbook.GetPosts())
            { // List all posts in guestbook
                Console.WriteLine("[" + i++ + "] " + post.ToString());
            }
            //User input
            string userChoice = Console.ReadLine()?.Trim() ?? "";

            switch (userChoice.ToUpper())
            {
                //add post in guestbook
                case "1":
                    Console.CursorVisible = true;
                    Console.Write("Ange ägare: ");
                    string? owner = Console.ReadLine() ?? ""; ;
                    Console.Write("Ange meddelande: ");
                    string post = Console.ReadLine() ?? "";
                    //check that owner and message are not empty
                    if (!string.IsNullOrWhiteSpace(owner) && !String.IsNullOrWhiteSpace(post))
                    { guestbook.AddPost(owner, post); }
                    else
                    { //error message if owner or message are empty
                        Console.WriteLine("Ägare och meddelande får inte vara tomma. Tryck en tangent för att fortsätta.");
                        //wait for user to press a key
                        Console.ReadKey();
                    }
                    break;
                //delete post in guestbook
                case "2":
                    Console.CursorVisible = true;
                    Console.Write("Ange index för inlägget som ska tas bort: ");
                    //get user input
                    string input = Console.ReadLine() ?? "";

                    if (int.TryParse(input, out int index))
                    {
                        try
                        {
                            guestbook.DelPosts(index);
                        }

                        //catch error if index is out of range
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("Ogiltigt index! Tryck en tangent för att fortsätta...");
                            Console.ReadKey();
                        }
                    }
                    else //catch error if input is not a number
                    {
                        Console.WriteLine("Ogiltig inmatning! Tryck en tangent för att fortsätta...");
                        Console.ReadKey();
                    }
                    break;

                //end program
                case "X":
                    running = false;
                    break;
                //wrong input
                default:
                    Console.WriteLine("Ogiltigt val!, välj ur menyn. Tryck en tangent för att fortsätta...");
                    Console.ReadKey();
                    break;
            }
        }
    }
}