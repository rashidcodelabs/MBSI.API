using MBSI.BL.IServices;
using MBSI.BL.Services;
using MBSI.DAL;
using MBSI.DAL.Interface;
using MBSI.DAL.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Donot forgot to add ConnectionStrings as "dbConnection" to the appsetting.json file
builder.Services.AddDbContext<DatabaseContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
// Adding Jwt Bearer  
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt_MBSI:Audience"],
        ValidIssuer = builder.Configuration["Jwt_MBSI:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt_MBSI:Key"]))
    };
});

//Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("*",
        builder =>
        {
            builder.WithOrigins("*")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

//BL :: Dependencies Start
builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddTransient<IVehicleInspectionRegisterService, VehicleInspectionRegisterService>();
//..BL :: Dependencies End

//DAL::Dependencies Start
builder.Services.AddTransient<ILoginRepository, LoginRepository>();
//..DAL::Dependencies End

//For HttpContext
builder.Services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "DMG Web API V1");
        c.RoutePrefix = "swagger"; // To configure Swagger UI root URL
    });
}

app.UseCors("*"); // Apply the CORS policy here

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

/// Get the IWebHostEnvironment from the app object
//var hostingEnvironment = app.Services.GetRequiredService<IWebHostEnvironment>();

//// Create a scoped lifetime for DocumentService and pass the IWebHostEnvironment
//using (var scope = app.Services.CreateScope())
//{
//    var documentService = scope.ServiceProvider.GetRequiredService<IDocumentService>() as DocumentService;
//    if (documentService != null)
//    {
//        documentService.HostingEnvironment = hostingEnvironment;
//    }
//}
app.Run();
