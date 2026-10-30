using System.Globalization;
using OrderHub.Services;

var builder = WebApplication.CreateBuilder(args);

var usCulture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
usCulture.NumberFormat.CurrencySymbol = "$";
CultureInfo.DefaultThreadCurrentCulture = usCulture;
CultureInfo.DefaultThreadCurrentUICulture = usCulture;

builder.Services.AddRazorPages();
// One shared store for the whole app: Dashboard, Orders and Payments all read/write through it.
builder.Services.AddSingleton<DataStore>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();

app.Run();
