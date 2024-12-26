using Microsoft.EntityFrameworkCore;
using Specification_Pattern.Data;
using Specification_Pattern.Entitties;
using Specification_Pattern.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGameRepository, GameRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});



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

using(var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    SeedData(context);
}

app.Run();

static void SeedData(ApplicationDbContext context)
{
    if (!context.Genres.Any())
    {
        var rpgGenre = new Genre { Name = "RPG" };
        var actionGenre = new Genre { Name = "Action" };



        var skyrim = new Game { Name = "Skyrim", Genre = rpgGenre, DLCs = [new() { Name = "New Lands" } ,new DLC {  Name ="Dragonborn"}] };
        var witcher = new Game { Name = "Witcher", Genre = actionGenre, DLCs = [new() { Name = "Blood and Wine" },new() { Name ="Hearts of  Stone"}] };


        context.Genres.AddRange(rpgGenre, actionGenre);

        context.Games.AddRange(skyrim, witcher);

        context.SaveChanges();  
    
    }
}