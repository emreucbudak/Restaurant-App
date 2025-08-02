using Microsoft.Extensions.DependencyInjection;
using RestaurantDashboardApi.API.Extensions;
using RestaurantDashboardApi.Application;
using RestaurantDashboardApi.Application.Profiles;

using RestaurantDashboardApi.Persistence;
using RestaurantDashboardApi.Persistence.AppDbContext;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.ConfigurePersistence();
builder.Services.AddApplication();
builder.Services.AddAutoMapper(cfg => { }, typeof(MappingProfile).Assembly);


// Ama ilk parametreyi Action<IMapperConfigurationExpression> veriyorsan, o Action'ý doldurman lazým.




var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
