using Application.Handlers.Posts.Commands;
using Application.Handlers.Posts.Queries;
using Domain.Entities;
using MediatR;

namespace MinimalApi.Extensions;

public static class PostRouteExtension
{

    public static IEndpointRouteBuilder MapPostRoutes(this IEndpointRouteBuilder routes)
    {
        var posts = routes.MapGroup("/api/posts");
        posts.MapPost("/", CreatePost);
        posts.MapGet("/", GetAllPosts);
        posts.MapGet("/{id}", GetPostByIdAsync);
        posts.MapPut("/{id}", UpdatePostAsync);
        posts.MapDelete("/{id}", DeletePostAsync);
        return routes;
    }

    private async static Task<IResult> CreatePost(IMediator mediator, CreatePost post)
    {
        var createdPost = await mediator.Send(post);
        return TypedResults.Created($"GetPostById/{createdPost.Id}", createdPost);
    }

    private async static Task<IResult> GetAllPosts(IMediator mediator)
    {
        var posts = await mediator.Send(new GetAllPost());
        return TypedResults.Ok(posts);
    }

    private async static Task<IResult> GetPostByIdAsync(IMediator mediator, int id)
    {
        return await mediator.Send(new GetPostById(id))
          is Post post
              ? TypedResults.Ok(post)
              : TypedResults.NotFound();
    }

    static async Task<IResult> UpdatePostAsync(IMediator mediator, UpdatePost post, int id)
    {
        if (id != post.Id) return TypedResults.NotFound();
        var command = await mediator.Send(post);
        return TypedResults.Ok(command);
    }

    static async Task<IResult> DeletePostAsync(IMediator mediator, int id)
    {
        await mediator.Send(new DeletePost(id));
        return TypedResults.NoContent();
    }
}
