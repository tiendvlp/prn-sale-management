using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using DataAccess.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Desktop.common;
using Microsoft.Extensions.Hosting;
using Desktop.common.Roles;
using Desktop.Products;
using Desktop.Members;
using Desktop.Orders;

namespace Desktop
{
    static class Program
    {
        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton
                    (configuration.GetSection(nameof(AppSetting)).Get<AppSetting>());
            services.AddTransient<Login>();
            services.AddTransient<MainForm.MainForm>();
            services.AddTransient<FormCreateProduct>();
            services.AddTransient<FormProducts>();
            services.AddTransient<FormUpdateProduct>();
            services.AddTransient<FormCreateMember>();
            services.AddTransient<FormUpdateMember>();
            services.AddTransient<FormCreateOrder>();
            services.AddTransient<FormMembers>();
            services.AddSingleton<UnitOfWorkFactory>();
            services.AddSingleton<AppRoles>();
        }

        [STAThread]
        static void Main()
        {
            var host = Host.CreateDefaultBuilder().ConfigureAppConfiguration((context, builder) =>
            {
                builder.AddJsonFile("appsettings.local.json", optional: true);
            }).ConfigureServices((context, service) => {
                ConfigureServices(service,context.Configuration);
            }).Build();
            
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var servicesProvider = host.Services;
            Application.Run(servicesProvider.GetRequiredService<Login>());
        }
    }
}
