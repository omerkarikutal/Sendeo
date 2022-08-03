using OrderService.Data.Context;

namespace OrderService.Api.Extension
{
    public static class Db
    {
        public static void CreateDb(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<OrderContext>();
                context.Database.EnsureCreated();
            }
        }

    }
}
