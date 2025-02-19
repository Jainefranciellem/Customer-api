using Data;
using Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace CustomerCrudApi.Controllers

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
            return await _customerCollection.Find(c => true).ToListAsync();
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
            try
            {
                await _customerCollection.InsertOneAsync(customer);
                return CreatedAtAction(nameof(GetByID), new { id = customer.Id }, customer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
                }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Customer customer)
        {
            var result = await _customerCollection.ReplaceOneAsync(c => c.Id == id, customer);
            
            if (result.MatchedCount == 0)
            {
                return NotFound();
            }
            
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var costumer = await _customerCollection.Find<Customer>(c => c.Id == id).FirstOrDefaultAsync();
            if (costumer is null)
            {
                return NotFound();
            }
            await _customerCollection.DeleteOneAsync(c => c.Id == id);
            return Ok();
        }
    }
}