using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TeachersPet.Context;
using TeachersPet.Services;
using TeachersPet.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Add the jwt settings
var jwtSettings = new JwtSetting();
builder.Configuration.Bind("Jwt", jwtSettings);

//Add CORS service 
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        {
            policy.WithOrigins("http://127.0.0.1:5173").AllowCredentials().AllowAnyHeader().AllowAnyMethod();
        });
});

builder.Services.AddControllers();

//Add authentication service
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]))
            };
            options.SaveToken = true;
            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    if (context.Request.Cookies.ContainsKey("TeachersPetCookie"))
                    {
                        context.Token = context.Request.Cookies["TeachersPetCookie"];
                    }
                    return Task.CompletedTask;
                }
            };
        })
    .AddCookie(x =>
    {
        x.Cookie.SameSite = SameSiteMode.None;
        x.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        x.Cookie.IsEssential = true;
    });

    //configure http client
    builder.Services.AddHttpClient();

//Add the jwt token creator
builder.Services.AddSingleton(jwtSettings);
builder.Services.AddTransient<JwtTokenCreator>();

//Add the user repository
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ITestRepository, TestRepository>();
//register the sqlite database
builder.Services.AddDbContext<SiteContext>(options => options.UseSqlite("Data Source=users.db"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

IConfiguration configuration = app.Configuration;

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
