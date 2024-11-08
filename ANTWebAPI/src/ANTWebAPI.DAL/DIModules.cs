using ANTWebAPI.BLL.Models;
using ANTWebAPI.BLL.Repositories;
using ANTWebAPI.BLL.UseCases;
using ANTWebAPI.DAL.Database;
using ANTWebAPI.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ANTWebAPI.DAL;

/*
 * DI Modules is a class that contains the dependency injection modules
 */
public static class DIModules
{
    /*
     * AddDALModule is an extension method that adds the DAL module to the service collection
     * 
     * The extension method returns the service collection
     */
    public static IServiceCollection AddDALModule(this IServiceCollection services)
    {
        services.AddDbContext<ANTDbContext>();
        services.AddScoped<IRepository<Catalog>, CatalogRepository>();
        services.AddScoped<IRepository<Article>, ArticleRepository>();
        services.AddScoped<IRepository<Content>, ContentRepository>();
        services.AddScoped<IChapterRepository, ChapterRepository>();
        return services;
    }
    /*
     * AddBLLModule is an extension method that adds the BLL module to the service collection
     * 
     * The extension method returns the service collection
     */
    public static IServiceCollection AddBLLModule(this IServiceCollection services)
    {
        services.AddScoped<CatalogUseCases>();
        services.AddScoped<ArticleUseCases>();
        services.AddScoped<ContentUseCases>();
        return services;
    }
}
