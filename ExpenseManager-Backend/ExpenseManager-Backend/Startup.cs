using ExpenseManager_Backend.Datebase;
using ExpenseManager_Backend.Repositories;
using ExpenseManager_Backend.Repositories.Abstraction;
using ExpenseManager_Backend.Services;
using ExpenseManager_Backend.Services.Abstractions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ExpenseManager_Backend
{
    public class Startup
    {
        public IConfiguration config;
        string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration config)
        {
            this.config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllers(options =>
            {
                options.Filters.Add<ApiResponseStatusCodeFilter>();
            });
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer("Server=localhost;Database=expense_manager;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;");
            });
            services.AddHttpContextAccessor();
            services.AddSingleton<IPasswordHasherService, PasswordHasherService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IExpenseService, ExpenseService>();
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<IExpenseGroupRepository, ExpenseGroupRepository>();
            services.AddScoped<IExpenseGroupService, ExpenseGroupService>();
            services.AddScoped<IHttpContextHelper, HttpContextHelper>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = config["Jwt:Issuer"],
                    ValidAudience = config["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(config["Jwt:Key"]!))
                };
            });
            services.AddSingleton<IJwtTokenService, JwtTokenService>();
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200",
                                            "http://www.example.com")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    }
                );
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
