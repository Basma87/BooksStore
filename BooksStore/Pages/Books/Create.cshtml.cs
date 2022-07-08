using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BooksStore.Data;

namespace BooksStore.Models
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
            //var authors = _context.Author
            //   .Select(c => new { c.authorName, c.AuthorID })
            //   .ToList();

            //var Countries = _context.Country.Select(c => new { c.CountryID, c.countryName }).ToList();

            //var Audiences = _context.Audience.Select(c => new { c.AudienceID, c.audienceName }).ToList();

            //var categories = _context.Category.Select(c => new { c.CategoryID, c.categoryName }).ToList();



            var SelectedCountries =_context.Country.Select(c=> new SelectListItem {Value = c.CountryID.ToString(),
                Text= c.countryName     
            }).ToList();

            var SelectedAudience =_context.Audience.Select(c => new SelectListItem { Value=c.AudienceID.ToString(),
                Text=c.audienceName}).ToList();

            var SelectedCategories = _context.Category.Select(c=>new SelectListItem { Value=c.CategoryID.ToString(),
                Text=c.categoryName}).ToList();

            var SelectedAuthors = _context.Author.Select(c => new SelectListItem
            {
                Value = c.AuthorID.ToString(),
                Text = c.authorName
            }).ToList();

            ViewData.Add("countries",SelectedCountries);
            ViewData.Add("audience",SelectedAudience);
            ViewData.Add("categories",SelectedCategories);
            ViewData.Add("authors", SelectedAuthors) ;
           
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
