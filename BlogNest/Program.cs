
using BlogNest.Extensions;
using Microsoft.EntityFrameworkCore;
using Repositories.EF_CORE;
using Newtonsoft.Json;
using NLog;
using Services.Contracts;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreRateLimit;

var builder = WebApplication.CreateBuilder(args);


//nlogun kaydı
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// 📌 **Bağlantı dizesini ekleme (app = builder.Build();'den ÖNCE olmalı)**
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager(); 
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureActionFilters();
builder.Services.ConfigureDataShapper();
builder.Services.ConfigureResponseCaching();
builder.Services.ConfigureVersioning();
builder.Services.AddMemoryCache();
builder.Services.ConfigureRateLimitingOptions();
builder.Services.AddAuthentication();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers(
    config => {
        config.RespectBrowserAcceptHeader = true;
        config.ReturnHttpNotAcceptable=true;
        config.CacheProfiles.Add("5mins", new CacheProfile { Duration = 300 });
   } )
    .AddXmlDataContractSerializerFormatters().AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly).
    AddNewtonsoftJson();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggingService>();
app.ConfigureExceptionHandler(logger);  

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseIpRateLimiting();
app.UseHttpsRedirection();
app.UseResponseCaching();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
