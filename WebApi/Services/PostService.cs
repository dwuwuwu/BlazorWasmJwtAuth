using Shared.DaoInterfaces;
using Shared.Dtos;
using Shared.Models;

namespace WebApi.Services;

public class PostService : IPostService
{
    private readonly IPostDao postDao;
    private readonly IUserDAO userDao;

    public PostService(IPostDao postDao, IUserDAO userDao)
    {
        this.postDao = postDao;
        this.userDao = userDao;
    }
    

    public Task CreatePost(PostCreationDtos dto)
    {
        int id = postDao.GetAsync().Result.Count()+ 1;
        User user = getUserByUsername(dto.AuthorUsername);
        Post post = new Post(id, dto.Title, dto.Body, user);
        
        postDao.CreateAsync(post);
        
        return Task.CompletedTask;
    }

    public Task<IEnumerable<Post>> GetPosts()
    {
        return postDao.GetAsync();
    }

    public Task<Post> GetPostById(int id)
    {
        Post post = postDao.GetAsync().Result.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(post);
    }

    public User getUserByUsername(string username)
    {
        User? user = userDao.GetByUsernameAsync(username).Result;
        if (user == null)
        {
            throw new Exception("User not found");
        }
        return user;
    }
}