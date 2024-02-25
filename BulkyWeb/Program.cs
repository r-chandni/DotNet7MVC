//// 
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();//// this is added because we are using MVC application

var app = builder.Build();

// Configure the HTTP request pipeline.
//// here we can change IsProduction, IsStaging and this can be determined from environment variable of launchsetting.json
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
//// It will configure the wwwroot path and all the static files in that will be accessible to the application
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
//// how the routing should work - if nothing is defined in the route than you should go to the home/index
app.MapControllerRoute(
    name: "default", 
    pattern: "{controller=Home}/{action=Index}/{id?}");
//// that runs the app
app.Run();
