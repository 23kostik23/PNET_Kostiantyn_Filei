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
    public class IndexModel : PageModel
    {
        private readonly lab_1_2.ApplicationDbContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(lab_1_2.ApplicationDbContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IList<Good> Good { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Good = await _context.Goods.ToListAsync();
            _logger.LogInformation("Менеджер переглянув список товарів о {Time}", DateTime.Now);
        }
    }
}
