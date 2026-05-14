using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using lab_1_2;
using lab_1_2.Models;

namespace lab_1_2.Pages
{
    public class CreateModel : PageModel
    {
        private readonly lab_1_2.ApplicationDbContext _context;

        public CreateModel(lab_1_2.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Good Good { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Goods.Add(Good);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
