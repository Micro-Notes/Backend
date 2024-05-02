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
}