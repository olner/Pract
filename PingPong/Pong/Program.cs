using Microsoft.EntityFrameworkCore;
using Pong.PongDbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextFactory<PongDbContext>(opt =>
{
    opt.UseMySql("Server=127.0.0.1;Database=ping_pong;port=3306;User Id=root;password=Olegka_2003",
    //opt.UseMySql(builder.Configuration.GetConnectionString("SplitConnection"),
        new MySqlServerVersion(new Version(8, 0, 30)));
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

app.Run();
