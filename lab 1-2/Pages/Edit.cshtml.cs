using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lab_1_2;
using lab_1_2.Models;

namespace lab_1_2.Pages
{
    public class EditModel : PageModel
    {
        private readonly lab_1_2.ApplicationDbContext _context;

        public EditModel(lab_1_2.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Good Good { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var good =  await _context.Goods.FirstOrDefaultAsync(m => m.Good_id == id);
            if (good == null)
            {
                return NotFound();
            }
            Good = good;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Good).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoodExists(Good.Good_id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GoodExists(int id)
        {
            return _context.Goods.Any(e => e.Good_id == id);
        }
    }
}
