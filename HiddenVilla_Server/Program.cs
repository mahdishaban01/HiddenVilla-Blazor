using AutoMapper;
using Business.Mapper;
using DataAccess.Context;
using HiddenVilla_Server;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region ConfigureServices

#region DatabaseContext

builder.Services.AddDbContext<HiddenVillaContext>(options =>
{

    options.UseSqlServer(builder.Configuration.GetConnectionString("HiddenVillaConnection"));
});

#endregion

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

DependencyInjection.InjectDependencies(builder.Services);

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

#region Middlewares

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

#endregion

app.Run();