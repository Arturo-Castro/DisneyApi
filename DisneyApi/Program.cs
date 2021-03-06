using DisneyApi.Repositories;
using DisneyApi.UseCases;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(routing => routing.LowercaseUrls = true);
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<DisneyContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DisneyConnection"));
});

builder.Services.AddScoped<IUpdateCharacterUseCase, UpdateCharacterUseCase>();
builder.Services.AddScoped<IUpdateShowUseCase, UpdateShowUseCase>();

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
