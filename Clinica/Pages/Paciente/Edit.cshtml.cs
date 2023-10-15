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

namespace Clinica.Pages_Paciente
{
    public class EditModel : PageModel
    {
        private readonly Clinica.MyDbContext _context;

        public EditModel(Clinica.MyDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public tPaciente tPaciente { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.tPaciente == null)
            {
                return NotFound();
            }

            var tpaciente =  await _context.tPaciente.FirstOrDefaultAsync(m => m.IDPACIENTE == id);
            if (tpaciente == null)
            {
                return NotFound();
            }
            tPaciente = tpaciente;
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

            _context.Attach(tPaciente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tPacienteExists(tPaciente.IDPACIENTE))
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

        private bool tPacienteExists(int id)
        {
          return (_context.tPaciente?.Any(e => e.IDPACIENTE == id)).GetValueOrDefault();
        }
    }
}
