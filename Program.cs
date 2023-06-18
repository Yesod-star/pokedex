using PokeApi.Models;
using PokeApi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<PokemonDatabaseSettings>(
    builder.Configuration.GetSection("PokemonDatabaseSettings"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSingleton<iItemPokeService,ItemPokeService>();
builder.Services.AddSingleton<iTypePokeService,TypePokeService>();
builder.Services.AddSingleton<iMovePokeService,MovePokeService>();
builder.Services.AddSingleton<iPokeService,PokeService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowAllOrigins");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
