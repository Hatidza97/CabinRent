using CabinRent.Services;
using CabinRent.Services.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IKlijentService, KlijentService>();
builder.Services.AddTransient<IKorisniciService, KorisniciService>();
builder.Services.AddTransient<IOcjenaService, OcjenaService>();
builder.Services.AddTransient<IGradService, GradService>();
builder.Services.AddTransient<IUlogaService, UlogaService>();
builder.Services.AddTransient<IObjekatService, ObjekatService>();
builder.Services.AddTransient<IRezervacijaService, RezervacijaService>();
builder.Services.AddTransient<ITipObjektumService, TipObjektumService>();
builder.Services.AddTransient<IDetaljiRezervacijeService, DetaljiRezervacijeService>();
builder.Services.AddTransient<ITipObjektaSLlikeService, TipObjektaSllikeService>();
builder.Services.AddAutoMapper(typeof(IKlijentService)); 
builder.Services.AddDbContext<eRentContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
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
