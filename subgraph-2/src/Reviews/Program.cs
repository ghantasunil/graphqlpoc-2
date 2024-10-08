using Microsoft.EntityFrameworkCore;

using Reviews.Data;

var builder = WebApplication.CreateBuilder(args);
{
    // 1. The middleware pipeline order for the field `Query.products` is invalid.
    // Middleware order is important especially with data pipelines. The correct
    // order of a data pipeline is as follows:
    // UseDbContext -> UsePaging -> UseProjection -> UseFiltering -> UseSorting.
    // You may omit any of these middleware or have other middleware in between
    // but you need to abide by the overall order. Your order is:
    // UsePaging -> UseProjection -> UseSorting -> UseProjection. (HotChocolate.Types.ObjectType)
    builder.Services.AddGraphQLServer()
        .DisableIntrospection(disable: false)
        .AddReviewsTypes()
        .ModifyOptions(options => options.DefaultQueryDependencyInjectionScope = DependencyInjectionScope.Resolver)
        .RegisterDbContextFactory<ReviewDbContext>()
        .AddDbContextCursorPagingProvider()
        .AddPagingArguments()
        //.AddProjections()
        .AddSorting();

    var connectionString = builder.Configuration.GetConnectionString("default");
    builder.Services.AddPooledDbContextFactory<ReviewDbContext>(o => o.UseSqlite(connectionString));
}

var app = builder.Build();
{
    app.UseWebSockets();
    app.MapGraphQL();

    await app.RunWithGraphQLCommandsAsync(args);
}

// Make the implicit Program class public so test projects can access it
public partial class Program { }