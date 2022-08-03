using CategoryService.Data.Context;
using CategoryService.Data.Repository;
using CategoryService.Grpc.Services;
using Microsoft.EntityFrameworkCore;
using CategoryService.Grpc.Extension;
var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();


// Add services to the container.
builder.Services.AddGrpc();


builder.Services.AddDbContext<CategoryContext>(
    options => options.UseSqlServer(builder.Configuration["ConnectionStrings:CategoryDb"]));


var app = builder.Build();
app.CreateDb();
// Configure the HTTP request pipeline.
app.MapGrpcService<CategoryService.Grpc.Services.CategoryService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
