using CustomerService.Data.Context;
using CustomerService.Data.Repository;
using CustomerService.Grpc.Services;
using Microsoft.EntityFrameworkCore;
using CustomerService.Grpc.Extension;
var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

// Add services to the container.
builder.Services.AddGrpc();

builder.Services.AddDbContext<CustomerContext>(
    options => options.UseSqlServer(builder.Configuration["ConnectionStrings:CustomerDb"]));


var app = builder.Build();

app.CreateDb();
// Configure the HTTP request pipeline.
//app.MapGrpcService<GreeterService>();
app.MapGrpcService<CustomerService.Grpc.Services.CustomerService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
