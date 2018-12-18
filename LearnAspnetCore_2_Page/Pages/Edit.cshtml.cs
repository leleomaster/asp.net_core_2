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
    public class EditModel : PageModel
    {
        [BindProperty]
        public Customer Customer { get; set; }

        private readonly AppDbContext _db;

        public EditModel(AppDbContext db)
        {
            _db = db;
        }
        
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Customer c = await _db.Customers.FindAsync(id);

            if(c == null)
            {
                return RedirectToPage("/Index");
            }

            Customer = c;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            _db.Attach(Customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {

                throw new Exception($"Customer {Customer.Id} not found");
            }
            return RedirectToPage("/Index");
        }
    }
}