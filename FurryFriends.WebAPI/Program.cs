using FurryFriends.Data;
using FurryFriends.Models.Maps;
using FurryFriends.Services.Comment;
using FurryFriends.Services.Post;
using FurryFriends.Services.Reply;
using FurryFriends.Services.Token;
using FurryFriends.Services.User;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpContextAccessor();

var Connectionstrings = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Connectionstrings));

builder.Services.AddScoped<ICommentServices, CommentServices>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IPostServices, PostServices>();
builder.Services.AddScoped<IReplyServices, ReplyServices>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddAutoMapper(typeof(PostMapProfile));
builder.Services.AddAutoMapper(typeof(ReplyMapProfile));
builder.Services.AddAutoMapper(typeof(CommentMapProfile));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.ToString());
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
