using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorWasmApp;
using BlazorDB;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazorDB(options =>
{
    options.Name = "Test";
    options.Version = 1;
    options.StoreSchemas = new List<StoreSchema>()
    {
        new StoreSchema()
        {
            Name = "Person",
            PrimaryKey = "id",
            PrimaryKeyAuto = true,
            UniqueIndexes = new List<string> { "guid" },
            Indexes = new List<string> { "name" }
        }
    };
});
await builder.Build().RunAsync();
