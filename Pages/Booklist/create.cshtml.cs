using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using bookRazor.Model;



namespace bookRazor.Pages.Booklist
{
    public class CreateModel : PageModel
    {
 
        private ApplicationDbContext _db;

        [TempData]
        public string Message { get; set; }
        public CreateModel(ApplicationDbContext db){
            _db=db;

        }
 
 [BindProperty]
        public Book Book {get;set;}
        public async Task<ActionResult> OnPost()
        {
           if(!ModelState.IsValid){
               return Page();
           }
           _db.Books.Add(Book);
           await _db.SaveChangesAsync();
            Message="Successfully saved new book.";
           return RedirectToPage("Index");
        }


    }
}