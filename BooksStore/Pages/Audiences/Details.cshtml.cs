using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BooksStore.Data;
using BooksStore.Models;

namespace BooksStore.Pages.Audiences
{
    public class DetailsModel : PageModel
    {
        private readonly BooksStore.Data.BooksStoreContext _context;

        public DetailsModel(BooksStore.Data.BooksStoreContext context)
        {
            _context = context;
        }

        public Audience Audience { get; set; }


        public IActionResult OnGet(int? id)
        {
            Audience = _context.Audience.Where(c => c.AudienceID.Equals(id)).FirstOrDefault();
                if (Audience is null)
            {
                return NotFound();
            }

                else
            {
                return Page();
            }
         }
       
    }
}
