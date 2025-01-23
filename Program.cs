using LogisticsManagementSystem.Models;
using LogisticsManagementSystem.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Stripe;
using LogisticsManagementSystem.Services;

namespace LogisticsManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Register repositories
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<Services.CustomerService>();
            builder.Services.AddScoped<IRepository<Models.Customer>, Repository<Models.Customer>>();

            builder.Services.AddScoped<IShipmentRepository, ShipmentRepository>();
            builder.Services.AddScoped<IRepository<Shipment>, Repository<Shipment>>();

            builder.Services.AddScoped<IShipmentMethodRepository, ShipmentMethodRepository>();
            builder.Services.AddScoped<IRepository<ShipmentMethod>, Repository<ShipmentMethod>>();

            builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
            builder.Services.AddScoped<IRepository<Payment>, Repository<Payment>>();

            builder.Services.AddScoped<StripePaymentService>(); 
            builder.Services.AddScoped<ShipmentService>();

            builder.Services.AddScoped<Models.StripeOptions>();
            builder.Services.AddScoped<Services.PaymentService>();
            builder.Services.AddScoped<ShipmentMethodService>();
            #endregion

           
            builder.Services.AddOptions<StripeOptions>()
                .Bind(builder.Configuration.GetSection("Stripe"));

            // Register Controllers
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
                });

            // Database setup
            builder.Services.AddDbContext<LogisticsManagementContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"))
            );


            #region Identity and JWT
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<LogisticsManagementContext>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(op =>
            {
                op.SaveToken = true;
                op.RequireHttpsMetadata = false;
                op.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["JWT:IssuerIP"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWT:AudienceIP"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecurityKey"]))
                };
            });

            #endregion

            // Cors Services
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy", policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
                options.AddDefaultPolicy(op => {
                    op.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            // Swagger/OpenAPI Setup
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("MyPolicy");
            app.UseAuthorization();

            app.UseStaticFiles();
            app.MapControllers();

            app.Run();
        }
    }
}
