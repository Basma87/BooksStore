using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BooksStore.Data;
using BooksStore.Models;

namespace BooksStore.Pages.Countries
{
    public class DeleteModel : PageModel
    {
        private readonly BooksStore.Data.BooksStoreContext _context;

        public DeleteModel(BooksStore.Data.BooksStoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Country Country { get; set; }

        // return country o be deleted
        public IActionResult OnGet(int id)
        {
            Country = _context.Country.Where(c => c.CountryID==id).FirstOrDefault();

            if (Country == null)
            {
                return BadRequest();
            }

            else
                return Page();
        }


        public IActionResult Onpost()
        {
            _context.Country.Remove(Country);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }

        #region not needed
        //public async Task<IActionResult> OnGetAsync(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    Country = await _context.Country.FirstOrDefaultAsync(m => m.CountryID == id);

        //    if (Country == null)
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

        //    Country = await _context.Country.FindAsync(id);

        //    if (Country != null)
        //    {
        //        _context.Country.Remove(Country);
        //        await _context.SaveChangesAsync();
        //    }

        //    return RedirectToPage("./Index");
        //}
        #endregion
    }
}
