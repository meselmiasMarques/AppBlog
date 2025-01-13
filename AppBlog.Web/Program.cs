using AppBlog.Web.Components;
using AppBlog.Web.Services;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddScoped<IUserService, UserService>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

    

var baseUrl = "http://localhost:5135";

builder.Services.AddScoped(p => new HttpClient
{
    BaseAddress = new Uri(baseUrl)
});
builder.Services.AddScoped<ILogger, Logger<UserService>>();

builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.Run();