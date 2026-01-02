using System.Text.Json.Serialization;
using LogisticsManagementSystem.DbContext;
using LogisticsManagementSystem.Repository.Implementations;
using LogisticsManagementSystem.Repository.Interfaces;
using LogisticsManagementSystem.Services.Implementations;
using LogisticsManagementSystem.Services.Interfaces;
using LogisticsManagementSystem.Settings;
using Microsoft.EntityFrameworkCore;

namespace LogisticsManagementSystem.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration config
        )
        {
            // 1. Database Setup
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("ConnectionString"))
            );

            // 2. Stripe Configuration
            services.AddOptions<StripeOptions>().Bind(config.GetSection("Stripe"));
            services.AddSingleton(resolver =>
                resolver
                    .GetRequiredService<Microsoft.Extensions.Options.IOptions<StripeOptions>>()
                    .Value
            );
            services.AddScoped<IStripePaymentService, StripePaymentService>();

            // 3. Repositories
            services.AddScoped<IShipmentRepository, ShipmentRepository>();
            services.AddScoped<IShipmentMethodRepository, ShipmentMethodRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();

            // 4. Domain Services
            services.AddScoped<IShipmentService, ShipmentService>();
            services.AddScoped<IShipmentMethodService, ShipmentMethodService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPricingService, PricingService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenManagement, TokenManagement>();
            services.AddScoped<IUserManagement, UserManagement>();

            // 5. Controllers & JSON Options
            services
                .AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                });

            // 6. CORS & Swagger
            services.AddCors(options =>
            {
                options.AddPolicy(
                    "MyPolicy",
                    policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                );
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}
