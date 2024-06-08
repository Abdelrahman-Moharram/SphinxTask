using Microsoft.EntityFrameworkCore;
using SpinxTask.Core.DTOs.ClientProdutcs;
using SpinxTask.Core.Interfaces;
using SpinxTask.Core.IServices;
using SpinxTask.Infrastructure.Data;
using SpinxTask.Infrastructure.Mappers;
using SpinxTask.Infrastructure.Presistence;
using SpinxTask.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{

    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
}
);


// Add services to the container.
builder.Services.AddRazorPages(options =>
{
});







builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IClientServices, ClientServices>();


builder.Services.AddAutoMapper(typeof(ProductProfile));
builder.Services.AddAutoMapper(typeof(ClientProfile));
builder.Services.AddAutoMapper(typeof(ClientProductsProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
