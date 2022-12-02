using Shared.Models;

namespace Shared.DaoInterfaces;

public interface IPostDao
{
    public Task<Post> CreateAsync(Post post);
    public Task<IEnumerable<Post>> GetAsync();
    public Task<Post?> GetByIdAsync(int todoId);


}