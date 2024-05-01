using Microsoft.AspNetCore.Mvc;
using Backend.Data;

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
}