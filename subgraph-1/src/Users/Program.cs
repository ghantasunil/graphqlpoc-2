using Users.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddGraphQLServer()
        .DisableIntrospection(disable: false)
        .AddUsersTypes()
        .ModifyOptions(options => options.DefaultQueryDependencyInjectionScope = DependencyInjectionScope.Resolver)
        .RegisterDbContextFactory<UserDbContext>()
        .AddProjections()
        .AddFiltering()
        .AddSorting()
        .AddDbContextCursorPagingProvider()
        .AddPagingArguments();

    var connectionString = builder.Configuration.GetConnectionString("default");
    builder.Services.AddPooledDbContextFactory<UserDbContext>(o => o.UseSqlite(connectionString));
}

var app = builder.Build();
{
    app.UseWebSockets();    
    app.MapGraphQL();

    await app.RunWithGraphQLCommandsAsync(args);
}

// Make the implicit Program class public so test projects can access it
public partial class Program { }