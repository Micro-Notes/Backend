using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Backend.Data;
using Backend.Models;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly BaseContext _context;

    public UsersController(BaseContext context)
    {
        _context = context;
    }
    
    // Listado de usuarios
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }
    
    // Detalles de usuarios
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        
        return user;
    }
    
    // Creación de usuarios
    [HttpPost]
    public async Task<ActionResult<User>> PostUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetUser), new {id = user.Id}, user);
    }
    
    // Eliminación de usuarios
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
    
    // Actualización de usuarios
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(int id, User user)
    {
        if (id != user.Id)
        {
            return BadRequest();
        }

        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
}