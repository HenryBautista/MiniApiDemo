var builder = WebApplication.CreateBuilder(args);

//Add Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Configure Application
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () =>
    "Hello World!");

app.MapGet("/home", () => 
    "Welcome to my SK presentation!");

app.Run("http://+:4000");