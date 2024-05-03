using Microsoft.AspNetCore.Mvc;
using Backend.Data;

namespace Backend.Controllers;

public class NotesController : ControllerBase
{
    private readonly BaseContext _context;

    public NotesController(BaseContext context)
    {
        _context = context;
    }
}