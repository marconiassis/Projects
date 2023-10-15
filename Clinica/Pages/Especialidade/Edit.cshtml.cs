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

namespace Clinica.Pages_Especialidade
{
    public class EditModel : PageModel
    {
        private readonly Clinica.MyDbContext _context;

        public EditModel(Clinica.MyDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public tEspecialidade tEspecialidade { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.tEspecialidade == null)
            {
                return NotFound();
            }

            var tespecialidade =  await _context.tEspecialidade.FirstOrDefaultAsync(m => m.idEspecialidade == id);
            if (tespecialidade == null)
            {
                return NotFound();
            }
            tEspecialidade = tespecialidade;
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

            _context.Attach(tEspecialidade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tEspecialidadeExists(tEspecialidade.idEspecialidade))
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

        private bool tEspecialidadeExists(int id)
        {
          return (_context.tEspecialidade?.Any(e => e.idEspecialidade == id)).GetValueOrDefault();
        }
    }
}
