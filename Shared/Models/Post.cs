namespace Shared.Models;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string body { get; set; }
    public User Author { get; set; }


    public Post(int id, string title, string body, User author)
    {
        Id = id;
        Title = title;
        this.body = body;
        Author = author;
    }
}