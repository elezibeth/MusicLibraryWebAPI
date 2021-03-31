using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicLibraryWebApi.Data;
using MusicLibraryWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicLibraryWebApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private ApplicationDbContext _context;

        public SongController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<SongController>
        [HttpGet]
        public IEnumerable<Song> GetSongs()
        {
            var songs = _context.Songs.ToList();
            return songs;
        }

        // GET api/<SongController>/5
   
        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetSong(int id)
        {
            var song = await _context.Songs.FindAsync(id);
            return song;
        }
     

        [HttpPost]
        public IActionResult PostSong(Song song)
        {
            _context.Songs.Add(song);
            _context.SaveChanges();

            return CreatedAtAction("GetSong", new { id = song.Id }, song);
        }


        // PUT api/<SongController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Song song)
        {

            var songToEdit = _context.Songs.Where(s => s.Id == id).FirstOrDefault();
            songToEdit = song;
            _context.Update(songToEdit);
            _context.SaveChanges();
            return Ok(songToEdit);

        }

        // DELETE api/<SongController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var song = _context.Songs.Where(s => s.Id == id).FirstOrDefault();
            _context.Songs.Remove(song);
            _context.SaveChangesAsync();

            return Ok(song);
        }
    }
}
