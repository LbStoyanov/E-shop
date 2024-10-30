

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>)); //, means generic
    config.AddOpenBehavior(typeof(LoggingBehavior<,>)); //, means generic

});

builder.Services.AddValidatorsFromAssembly(assembly);


builder.Services.AddCarter();

builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions(); //Used for perfrmance

builder.Services.AddExceptionHandler<CustomExceptionHandler>();


var app = builder.Build();

app.MapCarter();

app.UseExceptionHandler(option => { });


app.Run();
