using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BooksStore.Data;
using BooksStore.Models;

namespace BooksStore.Pages.Countries
{
    public class CreateModel : PageModel
    {
        private readonly BooksStore.Data.BooksStoreContext _context;

        public CreateModel(BooksStore.Data.BooksStoreContext context)
        {
            _context = context;
        }

        // retrieves view page of create 
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Country Country { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _context.Country.Add(Country);
        //    await _context.SaveChangesAsync();

        //    return RedirectToPage("./Index");
        //}

        public IActionResult OnPost(Country country)
        {
            _context.Country.Add(country);
            _context.SaveChanges();

            return RedirectToPage("./Index");

        }

    }
}
