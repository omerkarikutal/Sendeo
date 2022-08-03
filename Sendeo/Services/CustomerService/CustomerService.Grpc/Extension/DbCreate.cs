using CustomerService.Data.Context;

namespace CustomerService.Grpc.Extension
{
    public static class Db
    {
        public static void CreateDb(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<CustomerContext>();
                context.Database.EnsureCreated();
            }
        }

    }
}
