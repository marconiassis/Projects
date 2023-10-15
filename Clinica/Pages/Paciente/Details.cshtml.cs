using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Clinica;
using Clinica.Models;

namespace Clinica.Pages_Paciente
{
    public class DetailsModel : PageModel
    {
        private readonly Clinica.MyDbContext _context;

        public DetailsModel(Clinica.MyDbContext context)
        {
            _context = context;
        }

      public tPaciente tPaciente { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.tPaciente == null)
            {
                return NotFound();
            }

            var tpaciente = await _context.tPaciente.FirstOrDefaultAsync(m => m.IDPACIENTE == id);
            if (tpaciente == null)
            {
                return NotFound();
            }
            else 
            {
                tPaciente = tpaciente;
            }
            return Page();
        }
    }
}
