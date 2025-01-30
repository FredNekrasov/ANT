using ANTWebAPI.BLL.Models;
using ANTWebAPI.BLL.Repositories;
using ANTWebAPI.BLL.UseCases;
using ANTWebAPI.DAL.Database;
using ANTWebAPI.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ANTWebAPI.DAL;

public static class DIModules
{
    public static IServiceCollection AddDALModule(this IServiceCollection services)
    {
        services.AddDbContext<ANTDbContext>();
        services.AddScoped<IRepository<Catalog>, CatalogRepository>();
        services.AddScoped<IRepository<Article>, ArticleRepository>();
        services.AddScoped<IRepository<Content>, ContentRepository>();
        services.AddScoped<IChapterRepository, ChapterRepository>();
        return services;
    }
    public static IServiceCollection AddBLLModule(this IServiceCollection services)
    {
        services.AddScoped<CatalogUseCases>();
        services.AddScoped<ArticleUseCases>();
        services.AddScoped<ContentUseCases>();
        return services;
    }
}
