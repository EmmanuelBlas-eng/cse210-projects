using System;
using System.Collections.Generic;
using System.Transactions;


public class Video
    
{
    public string Title { get; set;}
    public string Author { get; set;}
    public int LengthSeconds { get; set;}
    private List<Comment>  _comments;
    public Video ( string title, string author, int lengthseconds)
    {
        Title = title;
        Author = author;
        LengthSeconds = lengthseconds;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment commment)
    {
        _comments.Add(commment);
    }
    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }
}