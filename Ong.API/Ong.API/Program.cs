using Microsoft.EntityFrameworkCore;
using Ong.Domain.Interfaces;
using Ong.Domain.MapperProfile;
using Ong.Domain.Queries;
using Ong.Infra.Data.BaseData;
using Ong.Infra.Data.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ILoggerFactory, LoggerFactory>();
builder.Services.AddScoped<IParceirosRepository, ParceirosRepository>();

builder.Services.AddMediatR(opt =>
                                opt.RegisterServicesFromAssembly(typeof(GetParceirosQueryCommandHandler).Assembly));

builder.Services.AddAutoMapper(opt =>
                                opt.AddMaps(typeof(CreateParceiroProfile).Assembly));

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration["Database"]));

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
