using Shared.Models;

namespace Shared.DaoInterfaces;

public interface IUserDAO
{
    public Task<User> CreateAsync(User user);
    public Task<User?> GetByUsernameAsync(string userName);
    public IEnumerable<User> GetAll();


}