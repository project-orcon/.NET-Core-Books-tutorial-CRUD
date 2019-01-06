using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using bookRazor.Model;


namespace bookRazor.Pages.Booklist
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        [TempData]
        public string Message { get; set; }


        [BindProperty]
        public Book Book {get;set;}
        public  EditModel(ApplicationDbContext dbContext){

            _db=dbContext;
            
        }
        
        

        public void OnGet(int id){
           Book= _db.Books.Find(id);
           Message="made it into onget";
        }

        

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid){
                var bookInDb=_db.Books.Find(Book.Id);
                bookInDb.Title=Book.Title;
                bookInDb.ISBN=Book.ISBN;
                bookInDb.Author=Book.Author;
                bookInDb.Availability=Book.Availability;
                
                await _db.SaveChangesAsync();
                Message = "Book updated successfuly!";

                return RedirectToPage("Index");
            }
            Message = "Error updating book";
           return RedirectToPage();
        }

       
    }
}