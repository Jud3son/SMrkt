using Microsoft.EntityFrameworkCore;
using SuperMarketBackend.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program));
//builder.Services.AddDbContext<SuperMrktDbContext>(options => options.UseSqlServer("Server=DESKTOP-JGF5M51\\SQLEXPRESS;Database=SuperMrktDB;Trusted_Connection=True;TrustServerCertificate=True;"));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(p => p.AddPolicy("Policy", build => { build.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("Policy");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
