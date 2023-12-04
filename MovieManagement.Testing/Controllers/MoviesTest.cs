using Microsoft.AspNetCore.Mvc.Testing;
using XTrackIntegrationTest;
using FluentAssertions;

namespace MovieManagement.Testing.Controllers;

public class MoviesTest: IClassFixture<MovieManagementWebApplicationFactory<MovieManagementAPI.Program>>
{
    private readonly HttpClient _client;
    private readonly MovieManagementWebApplicationFactory<MovieManagementAPI.Program> _factory;

    public MoviesTest(MovieManagementWebApplicationFactory<MovieManagementAPI.Program> factory)
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
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        //var content = await response.Content.ReadAsStringAsync();
    }
}