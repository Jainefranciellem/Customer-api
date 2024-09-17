using Data;
using Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMongoCollection<Customer>? _customerCollection;

        public CustomerController(MongoDbService mongoDbService)
        {
            _customerCollection = mongoDbService.Database?.GetCollection<Customer>("Customers");
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await _customerCollection.Find(FilterDefinition<Customer>.Empty).ToListAsync();
        }
    }
}