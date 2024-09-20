namespace CustomerCrudApi.Test;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Hosting;
using CustomerCrudApi.Controllers;
using Entities;
using System.Net.Http.Json;


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

    [Fact(DisplayName = "Testando a rota /POST Customer")]
    public async Task TestCreateCustomer()
    {
        var customer = new Customer
        {
            Id = "",
            FirstName = "John",
            LastName = "Doe",
            Email = "johndoe@example.com",
            Phone = "1234567890"
        };

        var response = await _clientTest.PostAsJsonAsync("/api/Customer", customer);
        Assert.Equal(System.Net.HttpStatusCode.Created, response?.StatusCode);
    }

      [Fact(DisplayName = "Testando a rota /PUT Customer")]
    public async Task TestUpdateCustomer()
    {
        // Mudar o id a cada teste, pois não está sendo mockado
        var customer = new Customer  {
            Id = "6508e2f5e4b12d8e91e4f8c2",
            FirstName = "John",
            LastName = "Doe",
            Email = "johndoe@example.com",
            Phone = "1234567890"
        };;
        
        var postResponse = await _clientTest.PostAsJsonAsync("/api/Customer", customer);
        postResponse.EnsureSuccessStatusCode();

        customer.FirstName = "John Updated";
        var putResponse = await _clientTest.PutAsJsonAsync($"/api/Customer/{customer.Id}", customer);
        Assert.Equal(System.Net.HttpStatusCode.OK, putResponse?.StatusCode);
    }

    [Theory(DisplayName = "Testando a rota /DELETE Customer")]
    [InlineData("/api/Customer/{id}")]
    public async Task TestDeleteCustomer(string url)
    {
        // Mudar o id a cada teste, pois não está sendo mockado
        var customer = new Customer {
            Id = "6508e2f2e4b08d4e01e2f1c2",
            FirstName = "John",
            LastName = "Doe",
            Email = "johndoe@example.com",
            Phone = "1234567890"
         };
        var postResponse = await _clientTest.PostAsJsonAsync("/api/Customer", customer);
        postResponse.EnsureSuccessStatusCode();

        var response = await _clientTest.DeleteAsync(url.Replace("{id}", customer.Id));
        Assert.Equal(System.Net.HttpStatusCode.OK, response?.StatusCode);
    }
}