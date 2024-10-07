var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddMarten(options =>
{

    options.Connection(builder.Configuration.GetConnectionString("Database")!);


}).UseLightweightSessions(); //Used for perfrmance


var app = builder.Build();

app.MapCarter();

app.Run();
