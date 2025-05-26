using Formula1API.Helper;
using Formula1API.Model;
using Formula1API.Repository;
using Formula1API.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IPilotoRepository, PilotoRepository>();
builder.Services.AddTransient<IPilotoService, PilotoService>();
builder.Services.AddTransient<IEquipeRepository, EquipeRepository>();
builder.Services.AddTransient<IEquipeService, EquipeService>();
builder.Services.AddAutoMapper(typeof(MappingProfiles));

builder.Services.AddDbContext<Context>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.MapControllers();


app.Run();
