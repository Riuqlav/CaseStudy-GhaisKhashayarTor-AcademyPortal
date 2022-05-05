using CaseStudy.Server.Models;
using CaseStudy.Server.Repositories;
using CaseStudy.Server.Repository;
using CaseStudy.Shared;
using Microsoft.AspNetCore.ResponseCompression;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Adding requirements for swagger Core
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register Mongo connection info -- registered in the Dependency Injection (DI) container
builder.Services.Configure<MongoDBSettings>(
    builder.Configuration.GetSection("MongoDBSettings")
    );

var settings = builder.Configuration.GetSection(nameof(MongoDBSettings)).Get<MongoDBSettings>();

builder.Services.AddSingleton<MongoDBSettings>(settings);

// Register MongoDb driver 
builder.Services.AddSingleton<IMongoDatabase>(options => {

    var client = new MongoClient(settings.ConnectionString);
    return client.GetDatabase(settings.DatabaseName);
});

// Handling Bson Name properties 
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

// Registering the repository .. Acording to Erik, when is possible Transient is a better choice
builder.Services.AddTransient<IParticipantRepository, ParticipantRepository>();

var app = builder.Build();
// Swagger 
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//Swagger 
app.UseSwagger();

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
