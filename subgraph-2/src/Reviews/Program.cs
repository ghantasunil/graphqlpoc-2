using Microsoft.EntityFrameworkCore;

using Reviews.Data;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddGraphQLServer()
        .DisableIntrospection(disable: false)
        .AddReviewsTypes()
        .ModifyOptions(options => options.DefaultQueryDependencyInjectionScope = DependencyInjectionScope.Resolver)
        .RegisterDbContextFactory<ReviewDbContext>()
        .AddDbContextCursorPagingProvider()
        .AddPagingArguments()
        .AddProjections()
        .AddFiltering()
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