using MediatR;
using Ong.Domain.Interfaces;
using Ong.Domain.Queries;
using Ong.Infra.Data.BaseData;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ILoggerFactory, LoggerFactory>();
builder.Services.AddScoped<IParceirosRepository, ParceirosRepository>();

builder.Services.AddMediatR(opt =>
{
    opt.RegisterServicesFromAssembly(typeof(GetParceirosQueryCommandHandler).Assembly);
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
