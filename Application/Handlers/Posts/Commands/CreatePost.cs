using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Posts.Commands;

public record CreatePost(string? PostContent) : IRequest<Post>;

public class PostHandler : IRequestHandler<CreatePost, Post>
{
    private readonly IPostRepository _postRepository;

    public PostHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<Post> Handle(CreatePost request, CancellationToken cancellationToken)
    {
        var newPost = new Post
        {
            Content = request.PostContent
        };

        return await _postRepository.CreatePost(newPost);
    }
}