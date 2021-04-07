using Application.Client.Core.SystemNotification.Services;
using Application.Client.Core.SystemNotification.Services.Interfaces;
using Application.Client.Windows.Main;
using Application.Client.Windows.Main.ViewModels;
using Application.Client.Windows.Main.ViewModels.Interfaces;
using Application.Core.Services.Export;
using Application.Core.Services.Export.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Core.Application.Providers
{
    public static class ServiceProviders
    {
        public static IServiceCollection AddScopedServices(this IServiceCollection services)
        {
            services.AddScoped<IJsonExportService, JsonExportService>();

            return services;
        }

        public static IServiceCollection AddSingletonServices(this IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.AddSingleton<IMainWindowViewModel, MainWindowViewModel>();
            services.AddSingleton<ISystemNotificationService, SystemNotificationService>();

            return services;
        }
    }
}
