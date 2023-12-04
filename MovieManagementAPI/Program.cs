 using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Graph.Models.ExternalConnectors;
using Microsoft.Identity.Web;
 using System.Text.Json.Serialization;
using MovieManagement.Application.Services;
using MovieManagement.Domain.IRepositories;
using MovieManagement.Domain.IServices;
using MovieManagement.Infrastructure.Context;
using MovieManagement.Infrastructure.Persistence.Repositories;

 namespace MovieManagement.Testing;
 public class Program
 {
     public static void Main(string[] args)
     {
         var builder = WebApplication.CreateBuilder(args);
         // Add services to the container.

         builder.Services.AddControllers();
         builder.Services.AddEndpointsApiExplorer();
         builder.Services.AddSwaggerGen();

//Add Database Service
         builder.Services.AddDbContext<MovieManagementDbContext>(o =>
             o.UseNpgsql(builder.Configuration.GetConnectionString("RP_MovieDb"),
                 npgsqlOptions => npgsqlOptions.MigrationsAssembly("MovieManagement.Infrastructure")));

//Azure AD Register
// builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
//     .AddMicrosoftIdentityWebApp(Configuration.GetSection("AzureAd"))
//     .EnableTokenAcquisitionToCallDownstreamApi(new string[] { "user.read" })
//     .AddInMemoryTokenCaches();


         builder.Services.AddMvc().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//Domain Services
         builder.Services.AddScoped<IMovieService, MovieService>();

//Implement Infrasture DependencyInjection Container
//builder.Services.InfrastureServices(builder.Configuration); 


         builder.Services.AddTransient<IMovieRepository, MovieRepository>();
         builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

         var app = builder.Build();                   

// Configure the HTTP request pipeline.
         if (app.Environment.IsDevelopment())
         {
             app.UseSwagger();
             app.UseSwaggerUI();
         }

         app.UseHttpsRedirection();

         app.UseAuthorization();

         app.MapControllers();

         app.Run();

     }
 }

