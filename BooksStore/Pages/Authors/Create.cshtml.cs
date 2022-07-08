using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BooksStore.Data;
using BooksStore.Models;

namespace BooksStore
{
    public class CreateModel : PageModel
    {
        private readonly BooksStore.Data.BooksStoreContext _context;

        public CreateModel(BooksStore.Data.BooksStoreContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            // get all countries
            var countries = _context.Country.ToList();

            // store country ID & country Names in a list to be populated to the view
            var selectedCountries = countries.Select( c=> new SelectListItem {Value= c.CountryID.ToString(),
                Text=c.countryName }).ToList();

            ViewData.Add("countries",selectedCountries);

            return Page();
        }

        [BindProperty]
        public Author Author { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Author.Add(Author);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
