using Microsoft.AspNetCore.Mvc.Testing;
using XTrackIntegrationTest;

namespace MovieManagement.Testing.Controllers;

public class MoviesTest: IClassFixture<MovieManagementWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly MovieManagementWebApplicationFactory<Program> _factory;

    public MoviesTest(MovieManagementWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });
    }

    [Fact]
    public async Task GetMoviesMustReturnCurrentValues()
    {
        // Arrange

        // Act
        var response = await _client.GetAsync("/api/Movies");

        // Assert
        response.EnsureSuccessStatusCode(); 
        //var content = await response.Content.ReadAsStringAsync();
    }
}