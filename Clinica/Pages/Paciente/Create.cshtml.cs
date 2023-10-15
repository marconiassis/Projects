using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Clinica;
using Clinica.Models;

namespace Clinica.Pages_Paciente
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
        public tPaciente tPaciente { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.tPaciente == null || tPaciente == null)
            {
                return Page();
            }

            _context.tPaciente.Add(tPaciente);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
