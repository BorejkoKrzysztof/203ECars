using System.Text;
using _2035Cars_Application;
using _2035Cars_Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "203E Cars", Version = "v1" });                
    });

//  Add Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
// Add Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JwtAuthentication:JwtAudience"],
        ValidIssuer = builder.Configuration["JwtAuthentication:JwtIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                                    (builder.Configuration["JwtAuthentication:JwtKey"]))
    };
});

// Add Services
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

// Configure CORS
builder.Services.AddCors(cfg => {
    
    cfg.AddPolicy(name: "developmentPolicy",
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });

    cfg.AddPolicy(name: "productionPolicy", policy => {
       policy.WithOrigins(builder.Configuration["CorsSetting:AllowedOrigin"]);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "203E Cars v1");
        });
}

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseCors("developmentPolicy");   
}
else if (app.Environment.IsProduction())
{
    app.UseCors("productionPolicy");
}

app.UseAuthorization();

app.MapControllers();

app.Run();
