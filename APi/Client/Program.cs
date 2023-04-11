using Client.Repositories.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Sesion Wihtout Timespan 
builder.Services.AddSession();

builder.Services.AddScoped<AccountRepository>();

// Configure JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            //Usually, this is application base url
            ValidateAudience = true,   //validasi client nya, audience didapat dari appseting.json, dijadikan true jika ada services nya
            ValidAudience = builder.Configuration["JWT:Audience"],

            //If the JWT is created using web service, then this could be the consumer URL
            ValidateIssuer = true,     //didapat dari appsettings.json 
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
            ValidateLifetime = true,    //
            ClockSkew = TimeSpan.Zero
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseSession();

//Configuration JWT, UNTUK APA ? 
app.Use(async (context, next) =>
{
    var jwtoken = context.Session.GetString("jwtoken");
    if (!string.IsNullOrEmpty(jwtoken))
    {
        context.Request.Headers.Add("Authorization", "Bearer " + jwtoken);
    }
    await next();
});

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
