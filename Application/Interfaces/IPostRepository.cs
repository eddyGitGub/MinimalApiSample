using Domain.Entities;

namespace Application.Interfaces;

public interface IPostRepository
{
    Task<ICollection<Post>> GetPosts();
    Task DeletePost(int id);
    Task<Post> GetPostById(int id);
    Task<Post> CreatePost(Post post);
    Task<Post> UpdatePost(string? post, int id);

}
