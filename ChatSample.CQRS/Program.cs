using Microsoft.EntityFrameworkCore;
using ChatSample.CQRS.Database;
using ChatSample.CQRS.Events.Handlers;
using ChatSample.CQRS.Events.Repos;
using ChatSample.CQRS.Handlers.Messages;
using ChatSample.CQRS.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

string Connection = "Server = 127.0.0.1,5434;Database = cqrs;User Id = SA;Password = Pass@word ;" +
    "TrustServerCertificate=true;";

string? isDocker = Environment.GetEnvironmentVariable("RUNNING_ON_DOCKER");

if (!String.IsNullOrEmpty(isDocker) && isDocker == "true")
    Connection = Connection.Replace("127.0.0.1", "host.docker.internal");


builder.Services.AddDbContext<WriteDBContext>(options =>
{
    options.UseSqlServer(Connection);
    options.EnableDetailedErrors();
});

builder.Services.AddDbContext<ReadDBContext>(options =>
{
    options.UseSqlServer(Connection);
    options.EnableDetailedErrors();
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddScoped<IEventRepo, RabbitMQRepo>();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(MessageCommandHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(MessageEventHandler).Assembly);
});


builder.Services.AddSignalR();

var app = builder.Build();


app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<WriteDBContext>();

db.Database.Migrate();

app.MapHub<ChatHub>("/chatHub");

app.UseCors(options => options.AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithOrigins("http://localhost:3000")
                        .AllowCredentials());

app.Run();
