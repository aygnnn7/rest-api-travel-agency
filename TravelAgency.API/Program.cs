using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using TravelAgency.Business.Abstract;
using TravelAgency.Business.AutoMappers;
using TravelAgency.Business.Concrete;
using TravelAgency.DataAcces;
using TravelAgency.DataAcces.Abstract;
using TravelAgency.DataAcces.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://127.0.0.1:8080")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});
//builder.Services.AddDbContext<AgencyDbContext>(options =>
  //  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IHolidayService, HolidayService>();
builder.Services.AddScoped<IHolidayRepository, HolidayRepository>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<AgencyDbContext>();
builder.Services.AddAutoMapper(typeof(LocationProfile));
builder.Services.AddAutoMapper(typeof(HolidayProfile));
builder.Services.AddAutoMapper(typeof(ReservationProfile));
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
    app.UseDeveloperExceptionPage();
}
app.UseCors();  

app.UseAuthorization();

app.MapControllers();

app.Run();
