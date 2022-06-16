using CbmDevelopments.MVC.Attributes;
using Domain;
using Domain.Email;
using Domain.Email.Services;
using Domain.Recaptcha;
using Domain.Recaptcha.Services;
using Domain.Serialisation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net;
using System.Net.Http;

namespace CbmDevelopments
{
	public class Startup
	{
		private readonly IConfiguration _configuration;
		private readonly IHostEnvironment _hostEnvironment;

		public Startup(IConfiguration configuration, IHostEnvironment env)
		{
			_hostEnvironment = env;
			_configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			ConfigureAppServices(services);
			services.AddControllersWithViews();
		}

		private void ConfigureAppServices(IServiceCollection services)
		{
			services.AddSingleton(_configuration);
			services.AddSingleton<IEmailConfiguration>(_configuration.GetSection(AccountConstants.Settings.EmailSettings).Get<EmailConfiguration>());
			services.AddSingleton<IRecaptchaConfiguration>(_configuration.GetSection(AccountConstants.Settings.RecaptchaSettings).Get<RecaptchaConfiguration>());

			services.AddSingleton<IJsonSerialisationService, JsonSerialisationService>();

			// do something about this in local mode -> same applies to sendgridservice, but less so.
			services.AddHttpClient<IRecaptchaService, RecaptchaService>().ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
			{
				Proxy = new WebProxy("http://winproxy.server.lan:3128", true)
			});
			services.AddScoped<RecaptchaAttribute>();

			if (_hostEnvironment.IsDevelopment()) services.AddSingleton<ISendGridEmailService, TestEmailService>();
			else services.AddSingleton<ISendGridEmailService, SendGridEmailService>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
