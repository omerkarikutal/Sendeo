using Consul;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http.Features;

namespace OrderService.Api.Extension
{
    public static class ConsulExt
    {
        public static IServiceCollection ConfigureCnsl(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConsulClient, ConsulClient>(a => new ConsulClient(c =>
            {
                c.Address = new Uri(configuration["ConsulConfig:BaseUrl"]);
            }));
            return services;
        }
        public static IApplicationBuilder RegisterCnsl(this IApplicationBuilder app,IHostApplicationLifetime hostApplicationLifetime)
        {
            var clnt = app.ApplicationServices.GetRequiredService<IConsulClient>();
            var log = app.ApplicationServices.GetRequiredService<ILoggerFactory>();
            var lg = log.CreateLogger<IApplicationBuilder>();

            var ft = app.Properties["server.Features"] as FeatureCollection;
            var add = ft.Get<IServerAddressesFeature>();
            var adress = add.Addresses.First();

            var uri = new Uri(adress);

            var rgs = new AgentServiceRegistration
            {
                ID = "OrderService",
                Name = "OrderService",
                Address = uri.Host,
                Port = uri.Port,
                Tags = new[] { "Order Service" }
            };

            clnt.Agent.ServiceDeregister(rgs.ID).Wait();
            clnt.Agent.ServiceRegister(rgs).Wait();

            hostApplicationLifetime.ApplicationStopping.Register(() =>
            {
                clnt.Agent.ServiceDeregister(rgs.ID).Wait();
            });
            return app;
        }
    }
}
