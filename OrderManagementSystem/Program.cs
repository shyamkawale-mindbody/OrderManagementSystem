var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDataAccess<Customer, int>, CustomerDataAccess>();
builder.Services.AddScoped<IDataAccess<Order, int>, OrderDataAccess>();
builder.Services.AddScoped<IDataAccess<Product, int>, ProductDataAccess>();

builder.Services.AddScoped<IServiceRepository<Customer, int>, CustomerRepository>();
builder.Services.AddScoped<IServiceRepository<Order, int>, OrderRepository>();
builder.Services.AddScoped<IServiceRepository<Product, int>, ProductRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
