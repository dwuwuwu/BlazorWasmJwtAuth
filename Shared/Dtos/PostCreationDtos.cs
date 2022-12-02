namespace Shared.Dtos;

public class PostCreationDtos
{
    public string Title{get;set;}
    public string Body{get;set;}
    public string AuthorUsername{get;set;}

    public PostCreationDtos(string title, string body, string authorUsername)
    {
        Title = title;
        Body = body;
        AuthorUsername = authorUsername;
    }
}