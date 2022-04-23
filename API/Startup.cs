using API.Helpers;
using API.Middleware;
using Core.CleanerNotificationService;
using Core.Interfaces;
using Core.OrderService;
using Infrastructure.Data;
using Infrastructure.Quartz;
using Infrastructure.Quartz.Jobs;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Quartz;

namespace API
{
	public class Startup
	{
		private readonly IConfiguration _configuration;

		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddAutoMapper(typeof(MappingProfiles));
			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			services.AddScoped<ICleanerRepository, CleanerRepository>();
			services.AddScoped<IOrderService, OrderService>();
			services.AddScoped<ICleanerNotificationService, CleanerNotificationService>();

			services.AddTransient<JobFactory>();
			services.AddScoped<StartOrderJob>();
			services.AddScoped<FinishOrderJob>();
			services.AddScoped<ForcedFinishJob>();

			services.AddCors();

			services.AddDbContext<CleaningContext>(x => x.UseSqlite(_configuration.GetConnectionString("DefaultConnection")));
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cleario API", Version = "v1" });
			});
			services.AddControllers();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseMiddleware<ExceptionMiddleware>();

			if (env.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseCors(builder => builder.AllowAnyOrigin());

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
