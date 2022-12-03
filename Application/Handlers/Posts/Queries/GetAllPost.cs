using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Posts.Queries;

public record GetAllPost:IRequest<ICollection<Post>>;

public class GetAllPostHandler : IRequestHandler<GetAllPost, ICollection<Post>>
{
    private readonly IPostRepository _postRepository;

    public GetAllPostHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }
    public async Task<ICollection<Post>> Handle(GetAllPost request, CancellationToken cancellationToken)
    {
        return await _postRepository.GetPosts();
    }
}
