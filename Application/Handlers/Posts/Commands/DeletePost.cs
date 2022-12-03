using Application.Interfaces;
using MediatR;

namespace Application.Handlers.Posts.Commands;

public record DeletePost(int PostId) : IRequest;

public class DeletePostHandler : IRequestHandler<DeletePost>
{
    private readonly IPostRepository _postRepository;

    public DeletePostHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }
    public async Task<Unit> Handle(DeletePost request, CancellationToken cancellationToken)
    {
        await _postRepository.DeletePost(request.PostId);
        return Unit.Value;
    }
}
