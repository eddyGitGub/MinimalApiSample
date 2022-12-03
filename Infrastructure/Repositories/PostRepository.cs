using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PostRepository : IPostRepository
{
    private readonly SocialDbContext _dbContext;

    public PostRepository(SocialDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Post> CreatePost(Post post)
    {
        try
        {
            post.DateCreated = DateTime.Now;
            post.LastModified = DateTime.Now;
            await _dbContext.Posts.AddAsync(post);
            await _dbContext.SaveChangesAsync();
            return post;
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    public async Task DeletePost(int id)
    {
        var post = await _dbContext.Posts.FirstOrDefaultAsync(x => x.Id == id);
        if (post == null) return;
        _dbContext.Posts.Remove(post);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Post> GetPostById(int id)
    {
        return await _dbContext.Posts.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ICollection<Post>> GetPosts()
    {
        return await _dbContext.Posts.ToListAsync();
    }

    public async Task<Post> UpdatePost(string? updatePostContent, int id)
    {
        var post = await _dbContext.Posts.FirstOrDefaultAsync(x => x.Id == id);
        post.LastModified = DateTime.Now;
        post.Content = updatePostContent;
        await _dbContext.SaveChangesAsync();
        return post;
    }
}
