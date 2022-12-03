using Application.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var cs = configuration.GetConnectionString("Default");
        //services.AddDbContext<SocialDbContext>(x => x.UseSqlServer(cs));
        services.AddDbContext<SocialDbContext>(options =>
                options.UseInMemoryDatabase("CleanArchitectureDb"));
        services.AddScoped<IPostRepository, PostRepository>();
            
     return services;
    }
}
