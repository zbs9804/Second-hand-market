//this is where the entire program starts
using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);//create a host for web server

// registering services to the container.(dependency injection container), order does not matter

builder.Services.AddControllers();//all controllers(in that folder) will be registered in this funciton
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StoreContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
    //don't forget to define "DefaultConnection in appsettings.Development.json, 
    //it will automatically pass configurations to here
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//below is about middle ware, the order of these lines matters
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();//add route configuration to controller


//in the first lines of this class, we registered some services, now we are going to use one of them 
//to inject the seed data into database
var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<StoreContext>();
var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
//                                        specify the<service <class>> that we want to log in console
try 
{
    context.Database.Migrate();
//Migrate applies any pending migrations for the context to the database. 
//Will create the database if it does not already exist.
    DbInitializer.Initialize(context);//call our static class to save 
}
catch (Exception ex)
{
    logger.LogError(ex, "A problem occured during migration");
}

app.Run();
