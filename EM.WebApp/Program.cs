 
using Elfie.Serialization;
using EM.Plugins.EFCoreSQL;
using EM.Plugins.EFCoreSQLServer;
using EM.Plugins.InMemory;
using EM.WebApp.Components;
using EM_UseCases.Events;
using EM.WebApp.Components.Account;
using EM.WebApp.Data;

using EM_UseCases.Events.interfaces;
using EM_UseCases.PluginInterfaces;
using EM_UseCases.Users;
using EM_UseCases.Users.EM_UseCases.Users;
using EM_UseCases.Users.interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
 



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContextFactory<EMContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EventManagement")));



builder.Services.AddRazorComponents();



builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("EMaccounts") ?? throw new InvalidOperationException("Connection string 'EMaccounts' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();














if (builder.Environment.IsEnvironment("Testing"))
{
    // Реєструємо in-memory репозиторії для тестів
    builder.Services.AddSingleton<IEventRepository, EventRepository>();
    builder.Services.AddSingleton<IUserRepository, UserRepository>();
}
else
{
    // Реєструємо репозиторії для SQL Server
    builder.Services.AddTransient<IEventRepository, EventEFCoreRepository>();
    builder.Services.AddTransient<IUserRepository, UserEFCoreRepository>();
     
    
}
 

builder.Services.AddRazorComponents();
 
builder.Services.AddTransient<IViewEventsByNameUseCase, ViewEventsByNameUseCase>();
builder.Services.AddTransient<IEditEventUseCase, EditEventUseCase>();
builder.Services.AddTransient<IAddEventsUseCase, AddEventsUseCase>();
builder.Services.AddTransient<IViewEventByIdUseCase, ViewEventByIdUseCase>();
builder.Services.AddTransient<IDeleteEventUseCase, DeleteEventUseCase>();
builder.Services.AddTransient<IViewUsersByNameUseCase, ViewUsersByNameUseCase>();
builder.Services.AddTransient<ISearchUsersUseCase, SearchUsersUseCase>();




builder.Services.AddScoped<IUserEventRepository, UserEventEFCoreRepository>();
builder.Services.AddScoped<IEventUseCase, EventUseCase>();
 
builder.Services.AddScoped<IUserRepository, UserEFCoreRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

 

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>();
app.MapAdditionalIdentityEndpoints();

app.Run();
