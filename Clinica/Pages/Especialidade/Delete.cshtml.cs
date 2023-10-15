using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Clinica;
using Clinica.Models;

namespace Clinica.Pages_Especialidade
{
    public class DeleteModel : PageModel
    {
        private readonly Clinica.MyDbContext _context;

        public DeleteModel(Clinica.MyDbContext context)
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

            var tespecialidade = await _context.tEspecialidade.FirstOrDefaultAsync(m => m.idEspecialidade == id);

            if (tespecialidade == null)
            {
                return NotFound();
            }
            else 
            {
                tEspecialidade = tespecialidade;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.tEspecialidade == null)
            {
                return NotFound();
            }
            var tespecialidade = await _context.tEspecialidade.FindAsync(id);

            if (tespecialidade != null)
            {
                tEspecialidade = tespecialidade;
                _context.tEspecialidade.Remove(tEspecialidade);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
