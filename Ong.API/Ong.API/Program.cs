using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Ong.Domain.DomainService.GenerateTokenJwt;
using Ong.Domain.Interfaces;
using Ong.Domain.Interfaces.Base;
using Ong.Domain.Interfaces.Repositories;
using Ong.Domain.MapperProfiles.Parceiro;
using Ong.Domain.Queries.Parceiro.GetAllParceiro;
using Ong.Infra.Data.Context;
using Ong.Infra.Data.Data.BaseData;
using Ong.Infra.Data.Repositories;
using Ong.Infra.Data.UnityOfWork;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ILoggerFactory, LoggerFactory>();

builder.Services.AddScoped(typeof(IBaseData<>), typeof(OngRepository<>));

builder.Services.AddScoped<IParceiroRepository, ParceiroRepository>();
builder.Services.AddScoped<INoticiaRepository, NoticiaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<IAdocaoRepository, AdocaoRepository>();
builder.Services.AddScoped<IUnityOfWork, UnityOfWork>();



builder.Services.AddScoped<IGenerateToken, GenerateToken>();

builder.Services.AddMediatR(opt =>
                                opt.RegisterServicesFromAssembly(typeof(GetAllParceirosQueryHandler).Assembly));

builder.Services.AddAutoMapper(opt =>
                                opt.AddMaps(typeof(CreateParceiroProfile).Assembly));

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration["Database"]));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
    };
});


builder.Services.AddControllers();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Acesso protegido utilizando o accessToken obtido em \"api/Authenticate/login\""
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
