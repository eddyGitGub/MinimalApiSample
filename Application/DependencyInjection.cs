using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //services.AddTransient(typeof(IRequestValidator<>), typeof(RequestValidator<>));

        var thisAssembly = Assembly.GetExecutingAssembly();
        //services.AddAutoMapper(thisAssembly);
        //services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(thisAssembly));
        services.AddMediatR(thisAssembly);
        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));

        return services;
    }
}
