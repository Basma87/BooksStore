using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BooksStore.Data;
using BooksStore.Models;

namespace BooksStore.Pages.Formats
{
    public class DetailsModel : PageModel
    {
        private readonly BooksStore.Data.BooksStoreContext _context;

        public DetailsModel(BooksStore.Data.BooksStoreContext context)
        {
            _context = context;
        }

        public Format Format { get; set; }

        public IActionResult OnGet(int? id)
        {

            Format =_context.Format.Where(m => m.formatID.Equals( id)).FirstOrDefault();

            if (Format == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
