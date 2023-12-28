using MovieApp.Data;
using MovieApp.Model;
using MovieApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<Configurations>(builder.Configuration.GetSection("Configurations"));
builder.Services.AddScoped<IAppContext, MovieAppContext>();
builder.Services.AddTransient<ICustomerCredService, CustomerCredService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient<IScreenService, ScreenService>();
builder.Services.AddTransient<IScreenTierService, ScreenTierService>();
builder.Services.AddTransient<ISeatService, SeatService>();
builder.Services.AddTransient<ISeatTypeService, SeatTypeService>();
builder.Services.AddTransient<IShowingService, ShowingService>();
builder.Services.AddTransient<IStaffCredentialService, StaffCredentialService>();
builder.Services.AddTransient<IStaffService, StaffService>();
builder.Services.AddTransient<ITicketService, TicketService>();

builder.Services.AddControllers();

// Defining CORS policy
builder.Services.AddCors(p => p.AddPolicy("movieapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("movieapp");

app.UseAuthorization();

app.MapControllers();

app.Run();
