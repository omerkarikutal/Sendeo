using CategoryService.Data.Context;

namespace CategoryService.Grpc.Extension
{
    public static class Db
    {
        public static void CreateDb(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<CategoryContext>();
                context.Database.EnsureCreated();
            }
        }

    }
}
