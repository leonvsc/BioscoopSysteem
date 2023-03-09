using BioscoopSysteemWeb;
using BioscoopSysteemWeb.Service;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using BioscoopSysteemWeb.Service.Contracts;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5059/") });
builder.Services.AddScoped<IMovieService, MovieService>();

builder.Services
    .AddBlazorise( options =>
    {
        options.Immediate = true;
    } )
    .AddBootstrap5Providers()
    .AddFontAwesomeIcons();

builder.Services.AddSingleton<GetTicketInfoService>();
builder.Services.AddScoped<BiosLanguageNotifier>();
builder.Services.AddScoped(typeof(IStringLocalizer<>), typeof(StringLocalizer<>));
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.AddSupportedCultures(new[] { "en", "nl" });
    options.AddSupportedUICultures(new[] { "en", "nl" });
    options.RequestCultureProviders = new List<IRequestCultureProvider>()
        {
            new CultureProvider("nl")
        };
});





await builder.Build().RunAsync();
