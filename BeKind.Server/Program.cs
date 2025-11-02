using BeKind.Infrastructure;
using BeKind.Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.RegisterServer(builder.Configuration); //adds connection between projects to register services inside them to keep main app clean

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<CompanyDTOProfile>();
});

var app = builder.Build();

var appScope = app.Services.CreateScope();
var seeder = appScope.ServiceProvider.GetRequiredService<StockNewsMasterDataSeeder>();
await seeder.SeedData();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
