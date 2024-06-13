

using Application.Interfaces;
using Application.MappingProfiles;
using Application.Services;
using AutoMapper;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var telegramBotDatabase = builder.Configuration.GetConnectionString("TelegramBotDatabase");

builder.Services.AddDbContext<TelegramBotDbContext>(options => options.UseNpgsql(telegramBotDatabase));

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new PersonProfile());
    mc.AddProfile(new FullNameProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddTransient<IPersonRepository, PersonRepository>();

builder.Services.AddTransient<PersonService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();