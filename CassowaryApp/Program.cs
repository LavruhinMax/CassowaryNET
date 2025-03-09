using CassowaryApp.Data;
using CassowaryApp.Service;
using CassowaryApp.ViewModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=Data/UserDB.db"));
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<Encryptor>();
builder.Services.AddScoped<Tariff_ViewModel>();
builder.Services.AddScoped<Equip_ViewModel>();
builder.Services.AddScoped<Login_ViewModel>();
builder.Services.AddScoped<Settings_ViewModel>();
builder.Services.AddScoped<Main_ViewModel>();
builder.Services.AddScoped<FAQ_ViewModel>();
builder.Services.AddScoped<AdminAbonent_ViewModel>();
builder.Services.AddScoped<AdminItem_ViewModel>();
builder.Services.AddScoped<AdminTariff_ViewModel>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
