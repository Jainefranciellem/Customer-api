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

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            await _customerCollection.InsertOneAsync(customer);
            return CreatedAtAction(nameof(GetByID), new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Customer customer)
        {
            var costumer = await _customerCollection.Find<Customer>(c => c.Id == id).FirstOrDefaultAsync();
            if (costumer is null)
            {
                return NotFound();
            }
            await _customerCollection.ReplaceOneAsync(c => c.Id == id, customer);
            return Ok();
        }

        
    }
}