using Microsoft.EntityFrameworkCore;

using Users.Data;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddGraphQLServer()
        .DisableIntrospection(disable: false)
        .AddUsersTypes()
        .ModifyOptions(options => options.DefaultQueryDependencyInjectionScope = DependencyInjectionScope.Resolver)
        .ModifyRequestOptions(configure =>
        {
            configure.IncludeExceptionDetails = true;
            configure.EnableSchemaFileSupport = true;
        })
        .RegisterDbContextFactory<UserDbContext>()
        .AddDbContextCursorPagingProvider()
        .AddPagingArguments()
        .AddProjections()
        .AddSorting();

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