using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clinica;
using Clinica.Models;

namespace Clinica.Pages_Funcionarios
{
    public class EditModel : PageModel
    {
        private readonly Clinica.MyDbContext _context;

        public EditModel(Clinica.MyDbContext context)
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

            var tfuncionarios =  await _context.tFuncionarios.FirstOrDefaultAsync(m => m.IdFuncionarios == id);
            if (tfuncionarios == null)
            {
                return NotFound();
            }
            tFuncionarios = tfuncionarios;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(tFuncionarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tFuncionariosExists(tFuncionarios.IdFuncionarios))
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

        private bool tFuncionariosExists(int id)
        {
          return (_context.tFuncionarios?.Any(e => e.IdFuncionarios == id)).GetValueOrDefault();
        }
    }
}
