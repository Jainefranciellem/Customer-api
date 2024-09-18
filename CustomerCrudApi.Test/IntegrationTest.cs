namespace CustomerCrudApi.Test;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Hosting;
using CustomerCrudApi.Controllers;

public class IntegrationTest: IClassFixture<WebApplicationFactory<Program>>
{
    public HttpClient _clientTest;

    public IntegrationTest(WebApplicationFactory<Program> factory)
    {
        _clientTest = factory.CreateClient();
    }
    

    [Theory(DisplayName = "Testando a rota /GET Customers")]
    [InlineData("/api/Customer")]
    public async Task TestGetCustomers(string url)
    {
        var response = await _clientTest.GetAsync(url);
        Assert.Equal(System.Net.HttpStatusCode.OK, response?.StatusCode);
    }

    [Theory(DisplayName = "Testando a rota /GET Customer/{id}")]
    [InlineData("/api/Customer/{id}")]
    public async Task TestGetCustomerById(string url)
    {
        var testId = "6508e7f5e4b08d4e87e4f1c8";
        var response = await _clientTest.GetAsync(url.Replace("{id}", testId));
        Assert.True(response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.NotFound);
    }
}