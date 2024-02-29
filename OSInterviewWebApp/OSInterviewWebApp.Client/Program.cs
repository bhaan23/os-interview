using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp =>
	new HttpClient
	{
		// setup the base address of the client to point at wherever we're hosted + /api for the route
		BaseAddress = new Uri(new Uri(builder.HostEnvironment.BaseAddress, UriKind.Absolute), "api/")
	});

await builder.Build().RunAsync();
