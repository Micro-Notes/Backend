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
}