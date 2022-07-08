using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BooksStore.Data;
using BooksStore.Models;

namespace BooksStore.Pages.Countries
{
    public class EditModel : PageModel
    {
        private readonly BooksStore.Data.BooksStoreContext _context;
       
        
        public EditModel(BooksStore.Data.BooksStoreContext context)
        {
           
            _context = context;
        }

        [BindProperty]
        public Country Country { get; set; }
       

        // get country model to load to edit page
        
        public IActionResult Onget(int id)
        {
            Country = _context.Country.Where(c => c.CountryID==id).FirstOrDefault();

            if (CountryExists(id)==false)
            {
                return BadRequest();
            }
           
            else
                return Page();

        }

        public IActionResult OnPost()
        {


            _context.Country.Update(Country);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }

        private bool CountryExists(int id)
        {
            return _context.Country.Any(e => e.CountryID == id);
        }



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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _context.Attach(Country).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CountryExists(Country.CountryID))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return RedirectToPage("./Index");
        //}


    }
}
