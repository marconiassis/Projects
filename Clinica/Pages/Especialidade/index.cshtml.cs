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
    public class indexModel : PageModel
    {
        private readonly Clinica.MyDbContext _context;

        public indexModel(Clinica.MyDbContext context)
        {
            _context = context;
        }

        public IList<tEspecialidade> tEspecialidade { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.tEspecialidade != null)
            {
                tEspecialidade = await _context.tEspecialidade.ToListAsync();
            }
        }
    }
}
