using Listomora.Application;
using Listomora.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddApplication();
builder.Services.AddInfrastructure(configuration);

//builder.Services.AddAuthorization(options => {
//    options.AddPolicy("Member", policy => policy.RequireClaim("Member", "Admin"));
//});

#region ancienne config n-tiers
//config services EF
//builder.Services.AddDbContext<ListomoraDbContext>(options =>
//    options.UseSqlServer(configuration.GetConnectionString("Listomora.EntityFramework")));
////config services DAL
//builder.Services.AddScoped<IArticleRepo, SqlArticleRepo>();
//builder.Services.AddScoped<IIngredientRepo, SqlIngredientRepo>();
//builder.Services.AddScoped<IUserRepo, SqlUserRepo>();
////config services BLL
//builder.Services.AddScoped<IArticleService, ArticleService>();
//builder.Services.AddScoped<IIngredientService, IngredientService>();
//builder.Services.AddScoped<IAuthService, AuthService>();
#endregion

// TODO : Retirer passwordHasher pour utiliser procédure stockée
//builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opt =>
{
    // Déclaration d'une policy CORS nommée "MvcCors"
    opt.AddPolicy("ListomoraCors", p =>
    {
        var origins = configuration
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
