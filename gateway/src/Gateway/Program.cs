var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("Fusion");

builder.Services
    .AddFusionGatewayServer()
    .ModifyFusionOptions(o => o.AllowQueryPlan = true)
    .ModifyRequestOptions(configure =>
    {
        configure.IncludeExceptionDetails = true;
        configure.EnableSchemaFileSupport = true;
    })
    .ConfigureFromFile("./gateway.fgp", watchFileForUpdates: true);

var app = builder.Build();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);
