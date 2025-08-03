using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(MongoDbService service) : ControllerBase
{
    private readonly IMongoCollection<User>? _users = service.Database()?.GetCollection<User>("user");

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> Get()
    {
        return Ok(await _users.Find(FilterDefinition<User>.Empty).ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User?>> Get(string id)
    {
        var filter = Builders<User>.Filter.Eq(x => x.Id, id);
        var user = await _users.Find(filter).FirstOrDefaultAsync();
        return user is not null ? Ok(user) : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<User>> Create(User user)
    {
        await _users.InsertOneAsync(user);
        return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
    }

    [HttpPut]
    public async Task<ActionResult<User>> Update(User user)
    {
        try
        {
            var filter = Builders<User>.Filter.Eq(x => x.Id, user.Id);

            await _users.ReplaceOneAsync(filter, user);
            return Ok(user);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(string id)
    {
        var filter = Builders<User>.Filter.Eq(x => x.Id, id);
        await _users.DeleteOneAsync(filter);
        return NoContent();
    }
}