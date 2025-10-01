using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace GuestbookApp;

public class Guestbook
{
    private string filename = @"guestbook.json";
    private List<GuestbookPost> posts = new List<GuestbookPost>();


    public Guestbook()
    {
        if (File.Exists(filename) == true)
        { //If stored json data exists then read
            string jsonString = File.ReadAllText(filename);
            posts = JsonSerializer.Deserialize<List<GuestbookPost>>(jsonString)?? new List<GuestbookPost>();
        }
    }

    public GuestbookPost AddPost(string message, string owner)
    {
        GuestbookPost obj = new GuestbookPost();
        obj.Message = message;
        obj.Owner = owner;
        posts.Add(obj);
        Marshal();
        return obj;
    }
        
                
        public int DelPosts(int index){
            posts.RemoveAt(index);
            Marshal();
            return index;
        }

        public List<GuestbookPost> GetPosts(){
            return posts;
        }

              private void Marshal()
    {
        //Serialize all the objects and save to file
        var jsonString = JsonSerializer.Serialize(posts);
        File.WriteAllText(filename, jsonString);
    }
}