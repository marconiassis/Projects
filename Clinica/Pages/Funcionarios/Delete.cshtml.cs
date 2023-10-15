using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Clinica;
using Clinica.Models;

namespace Clinica.Pages_Funcionarios
{
    public class DeleteModel : PageModel
    {
        private readonly Clinica.MyDbContext _context;

        public DeleteModel(Clinica.MyDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public tFuncionarios tFuncionarios { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.tFuncionarios == null)
            {
                return NotFound();
            }

            var tfuncionarios = await _context.tFuncionarios.FirstOrDefaultAsync(m => m.IdFuncionarios == id);

            if (tfuncionarios == null)
            {
                return NotFound();
            }
            else 
            {
                tFuncionarios = tfuncionarios;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.tFuncionarios == null)
            {
                return NotFound();
            }
            var tfuncionarios = await _context.tFuncionarios.FindAsync(id);

            if (tfuncionarios != null)
            {
                tFuncionarios = tfuncionarios;
                _context.tFuncionarios.Remove(tFuncionarios);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
