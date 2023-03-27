using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinApiDemo.Models;
using MinApiDemo.Repository;
using MinApiDemo.Services;

var builder = WebApplication.CreateBuilder(args);

//Add Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RatioDb>(opt =>
    opt.UseInMemoryDatabase("ratiodb"));

builder.Services.AddScoped<BussinesLogic>();

var app = builder.Build();

//Seed Data
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<RatioDb>();
    SeedData(dbContext);
}

//Configure Application
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () =>
    "Hello World!");

app.MapGet("/home", () => 
    "Welcome to my SK presentation!");

app.MapGet("/ratio", async (RatioDb ratioDb) => {
    return await ratioDb.Ratios.ToListAsync();
});

app.MapGet("/ratio/{value}", async ([FromServices] BussinesLogic bussinesLogic, [FromRoute] decimal value) 
    => {return await bussinesLogic.GetRatio(value);})
.WithName("Find Ratio")
.WithDescription("Finds the Ratio for given values");

app.Run();

//Seed Data
static void SeedData(RatioDb dbContext)
{
    dbContext.Ratios.AddRange(
        new Ratio { Id = 1, LowerBound = 1000, UpperBound = 3000, Value = 0.5m },
        new Ratio { Id = 2, LowerBound = 4000, UpperBound = 5000, Value = 0.8m },
        new Ratio { Id = 3, LowerBound = 6000, UpperBound = 7000, Value = 1.5m },
        new Ratio { Id = 4, LowerBound = 8000, UpperBound = 9000, Value = 2.5m }
    );
    dbContext.SaveChanges();
}