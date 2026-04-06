using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OrderApi.Data;
using OrderApi.Middleware;
using OrderApi.Repositories;
using OrderApi.Services;
using OrderApi.Validators;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ─────────────────────────────────────────────────────────────
// 1. DATABASE  (EF Core with SQL Server)
// ─────────────────────────────────────────────────────────────
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ─────────────────────────────────────────────────────────────
// 2. DEPENDENCY INJECTION  (register your own services)
// ─────────────────────────────────────────────────────────────
builder.Services.AddScoped<IOrderRepository, OrderRepository>();  // new per HTTP request
builder.Services.AddScoped<IOrderService, OrderService>();         // new per HTTP request
builder.Services.AddSingleton<TokenService>();                      // one for entire app lifetime

// ─────────────────────────────────────────────────────────────
// 3. AUTOMAPPER
// ─────────────────────────────────────────────────────────────
builder.Services.AddAutoMapper(typeof(Program));

// ─────────────────────────────────────────────────────────────
// 4. FLUENT VALIDATION
// ─────────────────────────────────────────────────────────────
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<OrderValidator>();

// ─────────────────────────────────────────────────────────────
// 5. IN-MEMORY CACHE  (no Redis installation needed to start)
// ─────────────────────────────────────────────────────────────
builder.Services.AddMemoryCache();

// ─────────────────────────────────────────────────────────────
// 6. JWT AUTHENTICATION
// ─────────────────────────────────────────────────────────────
var jwtKey = builder.Configuration["Jwt:Key"]!;

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer           = true,
            ValidateAudience         = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime         = true,
            ValidIssuer              = builder.Configuration["Jwt:Issuer"],
            ValidAudience            = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey         = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });

builder.Services.AddAuthorization();

// ─────────────────────────────────────────────────────────────
// 7. SWAGGER  (with JWT support so you can test protected routes)
// ─────────────────────────────────────────────────────────────
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title       = "Order Management API",
        Version     = "v1",
        Description = "A learning project showing DI, JWT, Repository Pattern, EF Core"
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Enter your JWT token below (you get this from POST /api/auth/login)",
        Name        = "Authorization",
        In          = ParameterLocation.Header,
        Type        = SecuritySchemeType.Http,
        Scheme      = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddControllers();

// ─────────────────────────────────────────────────────────────
// BUILD THE APP
// ─────────────────────────────────────────────────────────────
var app = builder.Build();

// Auto-create and seed the database on startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();  // applies any pending migrations automatically
}

// ─────────────────────────────────────────────────────────────
// MIDDLEWARE PIPELINE  (order matters!)
// ─────────────────────────────────────────────────────────────
app.UseMiddleware<ExceptionMiddleware>(); // must be first to catch all errors

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order API v1");
        c.RoutePrefix = string.Empty; // makes swagger open at root URL
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();  // who are you?
app.UseAuthorization();   // what are you allowed to do?
app.MapControllers();

app.Run();
