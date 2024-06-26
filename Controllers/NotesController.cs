﻿using Microsoft.AspNetCore.Mvc;
using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotesController : ControllerBase
{
    private readonly BaseContext _context;

    public NotesController(BaseContext context)
    {
        _context = context;
    }
    
    // Listado de notas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Note>>> GetNotes()
    {
        return await _context.Notes.ToListAsync();
    }
    
    // Detalles de notas
    [HttpGet("{id}")]
    public async Task<ActionResult<Note>> GetNote(int id)
    {
        var note = await _context.Notes.FindAsync(id);
        if (note == null)
        {
            return NotFound();
        }
        
        return note;
    }
        
    // Creación de notas
    [HttpPost]
    public async Task<ActionResult<Note>> PostNote(Note note)
    {
        _context.Notes.Add(note);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetNote), new {id = note.Id}, note);
    }
    
    // Eliminación de notas
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNote(int id)
    {
        var note = await _context.Notes.FindAsync(id);
        if (note == null)
        {
            return NotFound();
        }
        
        _context.Notes.Remove(note);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
    
    // Actualización de notas
    [HttpPut("{id}")]
    public async Task<IActionResult> PutNote(int id, Note note)
    {
        if (id != note.Id)
        {
            return BadRequest();
        }

        _context.Entry(note).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }
}