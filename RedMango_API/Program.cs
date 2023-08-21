using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using RedMango_API.Data;
using RedMango_API.Models;
using Azure.Storage.Blobs;
using RedMango_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.//Class that implements DB Context
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDbConnection"));
});

builder.Services.AddIdentity<ApplicationUser,IdentityRole>().AddEntityFrameworkStores<ApplicationDBContext>();

builder.Services.AddSingleton(u => new BlobServiceClient(builder.Configuration.GetConnectionString("Storage Account")));
//Addsingleton is created once and stays forever, 

builder.Services.AddSingleton<IBlobService, BlobService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
