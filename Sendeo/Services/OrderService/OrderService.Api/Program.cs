using Microsoft.EntityFrameworkCore;
using OrderService.Business.Business;
using OrderService.Data.Context;
using OrderService.Data.Repository;
using OrderService.Api.Extension;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IOrderService, OrderService.Business.Business.OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.Config(builder.Configuration);
//builder.Services.ConfigureCnsl(builder.Configuration);

builder.Services.AddDbContext<OrderContext>(
    options => options.UseSqlServer(builder.Configuration["ConnectionStrings:OrderDb"]));


builder.Services.AddGrpcClient<CategoryService.Grpc.Category.CategoryClient>(o => o.Address = new Uri(builder.Configuration["Grpc:Category"]));
builder.Services.AddGrpcClient<CustomerService.Grpc.Customer.CustomerClient>(o => o.Address = new Uri(builder.Configuration["Grpc:Customer"]));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.CreateDb();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
//app.RegisterCnsl(app.Lifetime);
app.Run();
