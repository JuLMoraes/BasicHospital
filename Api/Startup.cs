using Api.Ioc;
using Infra;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Versioning;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Infra.DbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"),
        settings => settings.EnableRetryOnFailure().CommandTimeout(900));
});
builder.Services.Configure<string>(builder.Configuration.GetSection("ConnectionStrings"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Register();
builder.Services.Configure<SwaggerConfiguration>(builder.Configuration.GetSection(nameof(SwaggerConfiguration)));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(x =>
{
    x.DefaultModelExpandDepth(-1);
    x.EnablePersistAuthorization();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
