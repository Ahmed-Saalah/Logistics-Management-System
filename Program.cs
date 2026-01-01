using System.Text;
using LogisticsManagementSystem.DbContext;
using LogisticsManagementSystem.Extensions;
using LogisticsManagementSystem.Models;
using LogisticsManagementSystem.Repository.Implementations;
using LogisticsManagementSystem.Repository.Interfaces;
using LogisticsManagementSystem.Services.Implementations;
using LogisticsManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Stripe;

namespace LogisticsManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register Auth/Identity
            builder.Services.AddIdentityServices(builder.Configuration);

            // Register App Services (DB, Repos, Stripe, Controllers)
            builder.Services.AddApplicationServices(builder.Configuration);

            var app = builder.Build();

            StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("MyPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();
            app.MapControllers();

            app.Run();
        }
    }
}
