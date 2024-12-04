using DAL.Data;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Mappings;


var builder = WebApplication.CreateBuilder(args);
// Video source: https://www.udemy.com/course/build-rest-apis-with-aspnet-core-web-api-entity-framework/learn/lecture/36980486#overview
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

builder.Services.AddScoped<IUserRepository, SQLUserRepository>();
builder.Services.AddScoped<IMovieRepository, SQLMovieRepository>();
builder.Services.AddScoped<IPostalCodeRepository, SQLPostalCodeRepository>();
builder.Services.AddScoped<IGenreRepository, SQLGenreRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowSpecificOrigins",
                          policy =>
                          {
                              policy.AllowAnyOrigin()
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                          });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("MyAllowSpecificOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
