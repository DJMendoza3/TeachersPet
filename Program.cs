using Microsoft.EntityFrameworkCore;

using TeachersPet.Context;
using TeachersPet.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Add CORS service 
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});

builder.Services.AddControllers();

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

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
