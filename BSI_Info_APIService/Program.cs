using FluentValidation;
using BSI_Info_APIService.Helpers;
using BSI_Info_APIService_BLL.Interface;
using BSI_Info_APIService_BLL;
using BSI_Info_APIService_Data.Interface;
using BSI_Info_APIService_Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using BSI_Info_APIService_BLL.DTOs.Validation;
using BSI_Info_APIService_BLL.DTOs;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure database context
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbConnectionString"));
});

// Register BLL and Data layer services
builder.Services.AddScoped<IUserBLL, UserBLL>();
builder.Services.AddScoped<IUserData, UserData>();
builder.Services.AddScoped<IEventsBLL, EventsBLL>();
builder.Services.AddScoped<IEventsData, EventsData>();
builder.Services.AddScoped<ITasksBLL, TasksBLL>();
builder.Services.AddScoped<ITasksData, TasksData>();
builder.Services.AddTransient<IValidator<TasksCreateDTO>, TasksCreateDTOValidator>();

// Configure AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddValidatorsFromAssemblyContaining<EventsCreateDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<TasksCreateDTOValidator>();

// Configure JWT authentication
var jwtSettings = builder.Configuration.GetSection("Jwttoken");
var key = Encoding.ASCII.GetBytes(jwtSettings["Secret"]);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("OrganizerPolicy", policy => policy.RequireRole("Organizer"));
    options.AddPolicy("ParticipantPolicy", policy => policy.RequireRole("Participant"));
});

// Register JwtHelper as a singleton service
builder.Services.AddSingleton<AppSettings>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); // Add this line to enable authentication

app.UseAuthorization();

app.MapControllers();

app.Run();