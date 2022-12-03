using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Posts.Commands;

public record UpdatePost(int Id, string? PostContent):IRequest<Post>;

public class UpdatePostHandler : IRequestHandler<UpdatePost, Post>
{
    private readonly IPostRepository _postRepository;

    public UpdatePostHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<Post> Handle(UpdatePost request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.UpdatePost(request.PostContent, request.Id);
        return post;
    }
}