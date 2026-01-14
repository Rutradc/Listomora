using Listomora.BLL.Services.Implementations;
using Listomora.BLL.Services.Interfaces;
using Listomora.DAL;
using Listomora.DAL.Repositories;
using Listomora.Domain.Model;
using Listomora.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

// Add services to the container.

//builder.Services.AddAuthorization(options => {
//    options.AddPolicy("Member", policy => policy.RequireClaim("Member", "Admin"));
//});

//config services EF
builder.Services.AddDbContext<ListomoraDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("Listomora.EntityFramework")));
//config services DAL
builder.Services.AddScoped<IArticleRepo, SqlArticleRepo>();
builder.Services.AddScoped<IUserRepo, SqlUserRepo>();
//config services BLL
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opt =>
{
    // Déclaration d'une policy CORS nommée "MvcCors"
    opt.AddPolicy("ListomoraCors", p =>
    {
        var origins = builder.Configuration
            .GetSection("Cors:AllowedOrigins")
            .Get<string[]>() ?? [];

        p.WithOrigins(origins)
         .AllowAnyHeader()
         .AllowAnyMethod();
        //.WithMethods("GET", "POST", "PUT");
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("ListomoraCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
