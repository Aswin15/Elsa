using Elsa.Infrastructure.DocumentService;
using ElsaAPI;
using ElsaAPI.Context;
using ElsaAPI.Extensions;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configuration = builder.Configuration;
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ElsaAPIDbContext>();
builder.Services.AddTransient<UserService>();
// set path for file download
builder.Services.AddSingleton<IFileProvider>(
            new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "uploadedDocs")));
builder.Services.AddTransient<ModifyDocument>();


// elsa
builder.Services.AddElsa();
builder.Services.AddLiquidHandlers();




/*
AddWorkflowServices(builder.Services, configuration.GetConnectionString("DB"));

void AddWorkflowServices(IServiceCollection services, string dbConnectionString)
{
    services.AddWorkflowServices(dbContext => dbContext.UseNpgsql(dbConnectionString, b => b.MigrationsAssembly("ElsaAPI")), configuration);

    // Configure HTTP activities.
    services.Configure<HttpActivityOptions>(options => configuration.GetSection("Elsa:Server").Bind(options));

    // Elsa API (to allow Elsa Dashboard to connect for checking workflow instances).
    services.AddElsaApiEndpoints();
}*/

var app = builder.Build();



app.UseHttpActivities();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(o => o.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
}

app.UseAuthorization();
app.MapControllers();
app.Run();
