using Microsoft.EntityFrameworkCore;
using Project2.Data;
using Project2.Models;
using Project2.Services;
using Project2.Services.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var MyAllowSpecificOrigins = "myAllowSpecificOrigins";
builder. Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
    policy =>
    {
        policy.WithOrigins("http://localhost:3001")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddTransient<IUserServices,UserServices>();
builder.Services.AddTransient<IPostServices,PostServices>();
builder.Services.AddTransient<ICommentServices, CommentServices>();
builder.Services.AddTransient<ILikesService, LikeService>();
builder.Services.AddTransient(typeof(MyRepository<>));
builder.Services.AddTransient<MyRepository<CommentModel>>(); 
builder.Services.AddDbContext<MyDbContext>(options =>
{
    string connectionString = "Data Source=DESKTOP-459JF8A\\SQLEXPRESS;Initial Catalog=Project2;Trusted_Connection=True;Encrypt=false";
    options.UseSqlServer(connectionString);
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
app.UseCors(MyAllowSpecificOrigins);
app.Run();
