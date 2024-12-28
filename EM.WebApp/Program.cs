 
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
 
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EM.UseCases;
using EM_UseCases;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContextFactory<EMContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EventManagement")));



builder.Services.AddRazorComponents();



builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("GuestPolicy", policy => policy.RequireClaim("role", "Guest"));
    options.AddPolicy("ParticipantPolicy", policy => policy.RequireClaim("role", "Participant"));
    options.AddPolicy("OrganizerPolicy", policy => policy.RequireClaim("role", "Organizer"));
    options.AddPolicy("AdminPolicy", policy => policy.RequireClaim("role", "Admin"));
});
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












 
  
   // Реєструємо репозиторії для SQL Server
    builder.Services.AddTransient<IEventRepository, EventEFCoreRepository>();






builder.Services.AddRazorComponents();
 
builder.Services.AddTransient<IViewEventsByNameUseCase, ViewEventsByNameUseCase>();
builder.Services.AddTransient<IEditEventUseCase, EditEventUseCase>();
builder.Services.AddTransient<IAddEventsUseCase, AddEventsUseCase>();
builder.Services.AddTransient<IViewEventByIdUseCase, ViewEventByIdUseCase>();
builder.Services.AddTransient<IDeleteEventUseCase, DeleteEventUseCase>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddTransient<IRemoveUserEventsUseCase, RemoveUserEventsUseCase>();
builder.Services.AddTransient<IAddReviewUseCase, AddReviewUseCase>();
builder.Services.AddTransient<IGetReviewsByEventIdUseCase, GetReviewsByEventIdUseCase>(); 
builder.Services.AddScoped<RegisterUserToEventUseCase>();
builder.Services.AddScoped<GetUsersByEventIdUseCase>();
builder.Services.AddTransient<IUnregisterUserFromEventUseCase, UnregisterUserFromEventUseCase>();
builder.Services.AddTransient<IDeleteReviewUseCase, DeleteReviewUseCase>();
builder.Services.AddTransient<IReviewRepository, ReviewRepository>();

builder.Services.AddScoped<IUserEventRepository, UserEventEFCoreRepository>();
builder.Services.AddScoped<IGetUsersByEventIdUseCase, GetUsersByEventIdUseCase>();


builder.Services.AddScoped<RegisterUserToEventUseCase>();
 


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
