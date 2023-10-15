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
    public class IndexModel : PageModel
    {
        private readonly Clinica.MyDbContext _context;

        public IndexModel(Clinica.MyDbContext context)
        {
            _context = context;
        }

        public IList<tPaciente> tPaciente { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.tPaciente != null)
            {
                tPaciente = await _context.tPaciente.ToListAsync();
            }
        }
    }
}
