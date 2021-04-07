using Application.BusinessLogicLayer.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Core.Application.Configurations
{
    public static class MediatRConfiguration
    {
        public static IServiceCollection ConfigureMediatR(this IServiceCollection services)
        {
            services.AddMediatR(typeof(IBusinessLogicLayerMarker));

            return services;
        }
    }
}
