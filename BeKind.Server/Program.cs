using BeKind.Infrastructure;
using BeKind.Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.RegisterServer(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy =>
        {
            policy.WithOrigins("https://127.0.0.1:4200") // Angular dev URL
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<CompanyDTOProfile>();
});

var app = builder.Build();

// Seed initial data
using (var appScope = app.Services.CreateScope())
{
    var seeder = appScope.ServiceProvider.GetRequiredService<StockNewsMasterDataSeeder>();
    await seeder.SeedData();
}

// Serve Angular static files
app.UseDefaultFiles();
app.UseStaticFiles();

// Enable CORS
app.UseCors("AllowAngularApp");

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

// Angular SPA fallback
app.MapFallbackToFile("/index.html");

// Start the application
app.Run();
