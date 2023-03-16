using BioscoopSysteemWeb;
using BioscoopSysteemWeb.Service;
using BioscoopSysteemWeb.Service.Contracts;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WeatherStation.Client.Shared;
using BioscoopSysteemWeb.Service.LanguageService;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7083") });
builder.Services.AddScoped<IMovieService, MovieService>();

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Auth0", options.ProviderOptions);
    options.ProviderOptions.ResponseType = "code";
}).AddAccountClaimsPrincipalFactory<ArrayClaimsPrincipalFactory<RemoteUserAccount>>();

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
builder.Services.AddLocalization(options => options.ResourcesPath = "Language");
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.AddSupportedCultures(new[] { "nl","en" });
    options.AddSupportedUICultures(new[] { "nl","en" });
    options.RequestCultureProviders = new List<IRequestCultureProvider>()
        {
            new CultureProvider("nl")
        };
});





await builder.Build().RunAsync();