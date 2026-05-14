using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab_1_2;
using lab_1_2.Models;

namespace lab_1_2.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly lab_1_2.ApplicationDbContext _context;

        public DetailsModel(lab_1_2.ApplicationDbContext context)
        {
            _context = context;
        }

        public Good Good { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var good = await _context.Goods.FirstOrDefaultAsync(m => m.Good_id == id);
            if (good == null)
            {
                return NotFound();
            }
            else
            {
                Good = good;
            }
            return Page();
        }
    }
}
