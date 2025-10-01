using System;
using System.Diagnostics;

namespace GuestbookApp;

class Program
{
    static void Main(string[] args)
    {
        Guestbook guestbook = new Guestbook();
        int i = 0;

        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine("G Ä S T B O K\n\n");
            Console.WriteLine("1. Lägg till inlägg");
            Console.WriteLine("2. Ta bort inlägg\n");
            Console.WriteLine("X. Avsluta\n");

            i = 0;
            foreach (GuestbookPost post in guestbook.GetPosts())
            { // List all posts in guestbook
                Console.WriteLine("[" + i++ + "] " + post.ToString());
            }

            string userChoice = Console.ReadLine()?.Trim() ?? "";

            switch (userChoice.ToUpper())
            {
                case "1":
                    Console.CursorVisible = true;
                    Console.Write("skriv ett inlägg: ");
                    string? post = Console.ReadLine();
                    if (!String.IsNullOrEmpty(post)) Guestbook.AddPost(owner, message);
                    
                    break;
                case "2":
                    break;
                case "X":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Ogiltigt val!");
                    Console.ReadKey();
                    break;
            }
        }
    }
} 