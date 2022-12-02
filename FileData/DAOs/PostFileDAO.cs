using Shared.DaoInterfaces;
using Shared.Models;

namespace FileData.DAOs;

public class PostFileDAO : IPostDao
{
    

    private readonly FileContext context;

    public PostFileDAO(FileContext context)
    {
        this.context = context;
    }

    public Task<Post> CreateAsync(Post todo)
    {
        int id = 1;
        if (context.Posts.Any())
        {
            id = context.Posts.Max(t => t.Id);
            id++;
        }

        todo.Id = id;

        context.Posts.Add(todo);
        context.SaveChanges();

        return Task.FromResult(todo);
    }

    public Task<IEnumerable<Post>> GetAsync()
    {
        IEnumerable<Post> result = context.Posts.AsEnumerable();

        return Task.FromResult(result);
    }

    public Task<Post?> GetByIdAsync(int todoId)
    {
        Post? existing = context.Posts.FirstOrDefault(t => t.Id == todoId);
        return Task.FromResult(existing);
    }

   
}

   

