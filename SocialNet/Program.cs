using SocialNet.Infrastructure.Persistence;
using SocialNet.Core.Application;
using SocialNet.Core.Application.Helpers;
using SocialNet.Core.Application.Interfaces;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddAplicationLayer(builder.Configuration);

builder.Services.AddTransient<UploadFiles<IEntity>, UploadFiles<IEntity>>();

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
    pattern: "{controller=User}/{action=Index}/{id?}");

app.Run();
