using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using KouArge.Service.Mapping;
using KouArge.Service.Validations;
using www.kouarge.org.ApiServices;
//using www.kouarge.org.Filters;
using www.kouarge.org.MiddleWares;
using www.kouarge.org.Modules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<DepartmentDtoValidator>());


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new HttpModule());
});

//*************
//builder.Services.AddDbContext<AppIdentityDbContext>(x =>
//{
//    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
//    {});
//});
//*************

builder.Services.AddControllers(options =>
{
    //options.Filters.Add<NotFoundFilter<>>();
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});

//builder.Services.AddSession();
//builder.Services.AddScoped<AppUserService, AppUserServiceImpl>();
//builder.Services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer("Server=sql.athena.domainhizmetleri.com;Initial Catalog=abdullah_dev;User ID=abdullah_dev;Password=Zu06a3r%0"));
//builder.Services.AddIdentity<AppUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount=false)
//    .AddEntityFrameworkStores<AppIdentityDbContext>()
//    .AddDefaultTokenProviders();

//*****
//builder.Services.AddScoped(typeof(NotFoundFilter<>));
builder.Services.AddScoped<TokenService>();
builder.Services.AddAutoMapper(typeof(MapProfile));


//builder.Services.AddHttpClient<DepartmentApiService>(opt =>
//{
//    opt.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
//}).AddHttpMessageHandler<TokenService>();

builder.Services.AddHttpContextAccessor();


builder.Services.AddScoped(sp =>
{
    var clientFac = sp.GetRequiredService<IHttpClientFactory>();
    return clientFac.CreateClient("WebApiClient");
});


builder.Services.AddHttpClient("WebApiClient", opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
}).AddHttpMessageHandler<TokenService>();



//builder.Services.Configure<IdentityOptions>(options =>
//{
//    options.Password.RequireDigit = true;
//    options.Password.RequireLowercase = true;
//    options.Password.RequiredLength = 8;
//    options.Password.RequireNonAlphanumeric = true;
//    options.Password.RequireUppercase = true;

//    options.Lockout.MaxFailedAccessAttempts = 5;
//    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(60);
//    options.Lockout.AllowedForNewUsers = true;

//    options.User.RequireUniqueEmail = true;
//    options.SignIn.RequireConfirmedEmail = false;
//    options.SignIn.RequireConfirmedPhoneNumber = false;
//});

//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.LoginPath = "/Account/Login";
//    options.LogoutPath = "/Home/Index";
//    options.AccessDeniedPath = "/Account/AccesDenied";
//    options.ExpireTimeSpan = TimeSpan.FromHours(1);
//    options.Cookie = new CookieBuilder
//    {
//        HttpOnly = true,
//        Name = "X-Access-Token",
//        SameSite = SameSiteMode.Strict
//    };
//});

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddMvc()
      .AddSessionStateTempDataProvider();
builder.Services.AddSession();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseSession();
app.UseCustomException();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "admin",
    pattern: "{area}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//SeedUser.AddUser(builder.Services.BuildServiceProvider());
app.Run();


