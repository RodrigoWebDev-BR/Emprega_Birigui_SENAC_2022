﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Emprega.Models;

namespace Emprega.Pages.Cidade
{
    public class IndexModel : PageModel
    {
        private readonly Emprega.Models.ApplicationDbContext _context;

        public IndexModel(Emprega.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.Cidade> Cidade { get;set; }

        public async Task OnGetAsync()
        {
            Cidade = await _context.Cidade.ToListAsync();
        }
    }
}
