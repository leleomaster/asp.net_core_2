using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnAspnetCore_2_Page.Data;
using LearnAspnetCore_2_Page.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LearnAspnetCore_2_Page.Pages
{
    public class IndexModel : PageModel
    {
        public List<Customer> Customers
        { get; private set; }

        private readonly AppDbContext _db;

        public IndexModel(AppDbContext db)
        {
            _db = db;
        }

        public async Task OnGetAsync()
        {
            Customers = await _db.Customers.AsNoTracking().ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var contact = await _db.Customers.FindAsync(id);

            if(contact != null)
            {
                _db.Customers.Remove(contact);
                await _db.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
