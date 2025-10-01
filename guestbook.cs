
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.IO;


//Guestbook class to manage guestbook posts
namespace GuestbookApp;

public class Guestbook
{
    //filename to store guestbook data
    private string filename = @"guestbook.json";

    //list to hold guestbook posts
    private List<GuestbookPost> posts = new List<GuestbookPost>();


    //constructor
    public Guestbook()
    { //On creation of Guestbook object check if stored json data exists
        if (File.Exists(filename) == true)
        { //If stored json data exists then read
            string jsonString = File.ReadAllText(filename);
            //and deserialize to list of GuestbookPost objects
            posts = JsonSerializer.Deserialize<List<GuestbookPost>>(jsonString) ?? new List<GuestbookPost>();
        }
            else //If no stored json data exists then create new list
    {
        posts = new List<GuestbookPost>();
    }
    }

    //method to add a post to the guestbook
    public GuestbookPost AddPost(string owner, string message)
    {
        //Create new GuestbookPost object and add to list
        GuestbookPost obj = new GuestbookPost();
        obj.Owner = owner;
        obj.Message = message;
        posts.Add(obj);
        Marshal();
        return obj;
    }

    //method to delete a post from the guestbook by index
    public int DelPosts(int index)
    {
        posts.RemoveAt(index);
        Marshal();
        return index;
    }

    //method to get all posts from the guestbook
    public List<GuestbookPost> GetPosts()
    {
        return posts;
    }

    //method to save the current list of posts to the json file
    private void Marshal()
    {
        //Serialize all the objects and save to file
        var jsonString = JsonSerializer.Serialize(posts);
        File.WriteAllText(filename, jsonString);
    }
}