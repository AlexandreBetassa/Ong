using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Ong.API.CrossCutting.Authentication;
using Ong.Domain.Interfaces;
using Ong.Domain.Interfaces.Base;
using Ong.Domain.MapperProfiles.Parceiro;
using Ong.Domain.Queries.Parceiro.GetAllParceiro;
using Ong.Infra.Data.Context;
using Ong.Infra.Data.Data.BaseData;
using Ong.Infra.Data.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ILoggerFactory, LoggerFactory>();

builder.Services.AddScoped(typeof(IBaseData<>), typeof(OngRepository<>));

builder.Services.AddScoped<IParceiroRepository, ParceiroRepository>();
builder.Services.AddScoped<INoticiaRepository, NoticiaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();

builder.Services.AddMediatR(opt =>
                                opt.RegisterServicesFromAssembly(typeof(GetAllParceirosQueryHandler).Assembly));

builder.Services.AddAutoMapper(opt =>
                                opt.AddMaps(typeof(CreateParceiroProfile).Assembly));

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration["Database"]));

builder.Services.AddCors();

var key = Encoding.ASCII.GetBytes(TokenJwt.Key);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
