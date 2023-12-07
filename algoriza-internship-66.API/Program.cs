
using Core.Domains;
using Core.IRepositories;
using Core.Repositories;
using Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service;

namespace algoriza_internship_66.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>
(builder => builder.UseSqlServer("server=.;database=Vezeeta;integrated security=true;trust server certificate=true"));

            builder.Services.AddIdentity<User, IdentityRole>(options => {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            builder.Services.AddTransient<ICouponRepository, CouponRepository>();

            builder.Services.AddTransient<ICouponService, CouponService>();

            builder.Services.AddTransient<IAccountService, AccountService>();



            //----------------------------------------------------
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