using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bookApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<BooksController> _logger;

        public BooksController(AppDbContext context, ILogger<BooksController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet(Name ="GetBooks")]
        public async Task<IActionResult> GetAll()
        {
            var books = await _context.Book.ToListAsync();
            return Ok(books);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            _context.Book.Add(book);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { id = book.Id }, book);
        }

    }
}

