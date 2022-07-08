using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BooksStore.Data;
using BooksStore.Models;

namespace BooksStore.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly BooksStore.Data.BooksStoreContext _context;

        public DeleteModel(BooksStore.Data.BooksStoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Category Category { get; set; }

        public IActionResult OnGet(int id)
        {
            Category = _context.Category.FirstOrDefault(c=> c.CategoryID==id);

            if (Category is null)
            {
                return BadRequest();
            }

            else
            {
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            _context.Category.Remove(Category);
            _context.SaveChanges();

            return RedirectToPage("./index");
            
        }

        #region not needed

        //public async Task<IActionResult> OnGetAsync(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    Category = await _context.Category.FirstOrDefaultAsync(m => m.CategoryID == id);

        //    if (Category == null)
        //    {
        //        return NotFound();
        //    }
        //    return Page();
        //}

        //public async Task<IActionResult> OnPostAsync(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    Category = await _context.Category.FindAsync(id);

        //    if (Category != null)
        //    {
        //        _context.Category.Remove(Category);
        //        await _context.SaveChangesAsync();
        //    }

        //    return RedirectToPage("./Index");
        //}
        #endregion
    }
}
