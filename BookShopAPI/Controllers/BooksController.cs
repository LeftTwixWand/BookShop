using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookShopAPI.Data;
using BookShopAPI.Models;
using System;
using BookShopAPI.Filters;

namespace BookShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookShopContext _context;

        public BooksController(BookShopContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks() => await _context.Books.ToListAsync();

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // GET: api/Books/filter
        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<Book>>> GetFilteredBooks([FromQuery] BookFilter bookFilter)
        {
            var queryable = _context.Books.AsQueryable();

            if (bookFilter.Id > 0)
            {
                queryable = queryable.Where(book => book.Id == bookFilter.Id);
            }

            if (!String.IsNullOrEmpty(bookFilter.Author))
            {
                queryable = queryable.Where(book => book.Author == bookFilter.Author);
            }

            if (!String.IsNullOrEmpty(bookFilter.Title))
            {
                queryable = queryable.Where(book => book.Title == bookFilter.Title);
            }

            if (bookFilter.Publication != null)
            {
                queryable = queryable.Where(book => book.Publication == bookFilter.Publication);
            }

            if (bookFilter.Cover != Cover.All)
            {
                queryable = queryable.Where(book => book.Cover == bookFilter.Cover);
            }

            if (bookFilter.AgeCategory != AgeCategory.All)
            {
                queryable = queryable.Where(book => book.AgeCategory == bookFilter.AgeCategory);
            }

            if (bookFilter.Genre != Genre.All)
            {
                queryable = queryable.Where(book => book.Genre == bookFilter.Genre);
            }

            return await queryable.ToListAsync();
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook([FromBody] Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Check, if record with specific id contains in database
        /// </summary>
        /// <param name="id">Record id</param>
        /// <returns>True if contains</returns>
        private bool BookExists(int id) => _context.Books.Any(e => e.Id == id);
    }
}