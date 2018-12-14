using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnAspnetCore_2_Page.Data;
using LearnAspnetCore_2_Page.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LearnAspnetCore_2_Page.Pages
{
    public class CadastroModel : PageModel
    {
        private readonly AppDbContext _db;

        public CadastroModel(AppDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Customer Customer{ get; set; }
        
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            _db.Customer.Add(Customer);
            await _db.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}