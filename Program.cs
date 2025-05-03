
using InventoryManagementSystem.InventoryMSAPIDomain.Entities;
using InventoryManagementSystem.InventoryMSAPIDomain.Interface;
using InventoryManagementSystem.InventoryMSAPIInfrastructure.Context;
using InventoryManagementSystem.InventoryMSAPIInfrastructure.Repository;
using InventoryManagementSystem.InventoryMSAPIServices.IServises;
using InventoryManagementSystem.InventoryMSAPIServices.Servises;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace InventoryManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services
                .AddControllers();

            builder.Services
                .AddDbContext<DataBaseContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services
                .AddIdentity<ApplicationUser, IdentityRole<int>>(option =>
                    {
                        option.Password.RequireDigit = false;
                        option.Password.RequireNonAlphanumeric = false;
                    })
                .AddEntityFrameworkStores<DataBaseContext>()
                .AddDefaultTokenProviders();

            builder.Services
                .AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services
                .AddScoped<IProductServises, ProductServises>();
            builder.Services
                .AddScoped<IWarehouseServises, WarehouseServises>();
            builder.Services
                .AddScoped<ITransactionServices, TransactionServices>();

    /*---------------------------------------------------------------------------------------*/

            builder.Services.AddAuthentication()
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                    };
                });


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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
