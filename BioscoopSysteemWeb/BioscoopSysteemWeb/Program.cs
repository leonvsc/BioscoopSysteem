using BioscoopSysteemWeb;
using BioscoopSysteemWeb.Service;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using BioscoopSysteemWeb.Service.Contracts;
using BioscoopSysteemWeb.Service.LanguageService;
using Microsoft.Extensions.Localization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7083/") });
// builder.Services.AddBlazoredModal();
//builder.Services.AddScoped<HttpService, HttpService>();
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

await builder.Build().RunAsync();
