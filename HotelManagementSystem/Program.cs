using HotelManagementSystem.Core.Application.Interfaces;
using HotelManagementSystem.Core.Application.Services;
using HotelManagementSystem.Core.Domain.Repositories;
using HotelManagementSystem.Infrastructure.DataAccess.Factories;
using HotelManagementSystem.Infrastructure.DataAccess.Repositories;
using HotelManagementSystem.Infrastructure.Services.Identity;

namespace HotelManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<AuthTokenOptions>(
                builder.Configuration.GetSection(AuthTokenOptions.Jwt));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connStr = builder.Configuration["connectionString"];
            builder.Services.AddSingleton(new SqlConnectionFactory(connStr));

            var accountSid = builder.Configuration["accountSid"];
            var authToken = builder.Configuration["authToken"];
            var verificationServiceSid = builder.Configuration["verificationServiceSid"];
            builder.Services.AddSingleton(new TwilioResourceFactory(accountSid, authToken, verificationServiceSid));

            builder.Services.AddScoped<IRoomRepository, RoomRepository>();
            builder.Services.AddScoped<IGuestRepository, GuestRepository>();
            builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
            builder.Services.AddScoped<IVerificationService, VerificationService>();

            builder.Services.AddScoped<ReservationService>();
            builder.Services.AddScoped<LoginService>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.UseStaticFiles();

            app.Run();
        }
    }
}