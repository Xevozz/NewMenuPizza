using NewMenuPizza.Kunder;
using NewMenuPizza.OrdreFolder;
using NewMenuPizza.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//indsætter kundeRepository
builder.Services.AddSingleton<KundeRepository>(new KundeRepository(true));

builder.Services.AddSingleton<PizzaRepository>(new PizzaRepository());

builder.Services.AddSingleton<IngrediensRepository>(new IngrediensRepository(true));

builder.Services.AddSingleton<MenuItemRepository>(new MenuItemRepository());

builder.Services.AddSingleton<OrdreRepository>(new OrdreRepository());

builder.Services.AddSingleton(new Ordre());

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

// Det her har sebastian skrevet

// Hej Sebastian!