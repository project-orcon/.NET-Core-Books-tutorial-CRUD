using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using bookRazor.Model;
using Microsoft.EntityFrameworkCore;

namespace bookRazor.Pages.Booklist
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _db;

        [TempData]
        public string Message { get; set; }

        public  IndexModel(ApplicationDbContext dbContext){

            _db=dbContext;
            
        }
        
        public IEnumerable<Book> Books {get;set;}

        

        public async Task OnGet()
        {
            Books = await _db.Books.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = _db.Books.Find(id);
            _db.Books.Remove(book);
            await _db.SaveChangesAsync();

            Message = "Book Deleted Successfully!";

            return RedirectToPage();
        }

       
    }
}