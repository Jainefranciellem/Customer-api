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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(string id)
        {
            var costumer = await _customerCollection.Find<Customer>(c => c.Id == id).FirstOrDefaultAsync();
            return costumer is not null ? (IActionResult)Ok(costumer) : NotFound();
        }
    }
}