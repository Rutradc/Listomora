using Listomora.API.Handlers;
using Listomora.Application;
using Listomora.Domain.Enums;
using Listomora.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

// Add services to the container.

// Add Policies for Authorization
builder.Services.AddAuthorization(options => {
    options.AddPolicy("Authenticated", policy => policy.RequireRole(UserRole.USER.ToString(), UserRole.ADMIN.ToString()));
});
builder.Services.AddAuthorization(options => {
    options.AddPolicy("Admin", policy => policy.RequireRole(UserRole.ADMIN.ToString()));
});

// Add services from Application and Infrastructure
builder.Services.AddApplication();
builder.Services.AddInfrastructure(configuration);

builder.Services.AddScoped<TokenService>();

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

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Définition du schéma de sécurité
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Entrez votre token.\n\nExemple: eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
    });

    // Appliquer la sécurité globalement
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

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

#region JWT Bearer Authentification
builder
    .Services.AddAuthentication(option =>
    {
        option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
            ),

            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],

            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],

            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("ListomoraCors");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
