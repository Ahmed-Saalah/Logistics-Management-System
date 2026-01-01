using LogisticsManagementSystem.Extensions;
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
