using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Clinica;
using Clinica.Models;

namespace Clinica.Pages_Funcionarios
{
    public class CreateModel : PageModel
    {
        private readonly Clinica.MyDbContext _context;

        public CreateModel(Clinica.MyDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public tFuncionarios tFuncionarios { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.tFuncionarios == null || tFuncionarios == null)
            {
                return Page();
            }

            _context.tFuncionarios.Add(tFuncionarios);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
