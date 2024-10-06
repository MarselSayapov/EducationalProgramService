using Domain.Auth;
using Infastracted;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve);
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = AuthOptions.ISSUER,
        ValidateAudience = true,
        ValidAudience = AuthOptions.AUDIENCE,
        ValidateLifetime = true,
        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.FromSeconds(5)
    };
});
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"Ââåäèòå JWT òîêåí àâòîðèçàöèè.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
            },
            new string[]{}
        }
    });
});
builder.Services.TryAddService();
builder.Services.TryAddInfastracted();
builder.Services.TryAddApplicationContext(builder.Configuration);
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