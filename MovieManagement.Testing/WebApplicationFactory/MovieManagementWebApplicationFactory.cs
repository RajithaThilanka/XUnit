using System.Data.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieManagement.Infrastructure.Context;
using Npgsql;


namespace XTrackIntegrationTest
{
    public class MovieManagementWebApplicationFactory<TProgram>
        : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(context.HostingEnvironment.ContentRootPath)
                    .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true)
                    .Build();
                
                var connectionString = configuration.GetConnectionString("RP_MovieDb");

                var dbContextDescriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<MovieManagementDbContext>));

                services.Remove(dbContextDescriptor);

                var dbConnectionDescriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbConnection));

                services.Remove(dbConnectionDescriptor);
                
                services.AddSingleton<DbConnection>(container =>
                {
                    var connection = new NpgsqlConnection(connectionString);
                    connection.Open();

                    return connection;
                });

                services.AddDbContext<MovieManagementDbContext>((container, options) =>
                {
                    var connection = container.GetRequiredService<DbConnection>();
                    options.UseNpgsql(connection);
                });
            });

            builder.UseEnvironment("Development");
        }
    }
}