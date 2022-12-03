using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Posts.Queries;

public record GetPostById(int postId) : IRequest<Post>;

public class GetPostByIdHandler : IRequestHandler<GetPostById, Post>
{
    private readonly IPostRepository _postRepository;

    public GetPostByIdHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }
    public async Task<Post> Handle(GetPostById request, CancellationToken cancellationToken)
    {
        return await _postRepository.GetPostById(request.postId);
    }
}
