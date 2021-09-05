using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RPCAuthenticationModule.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPCAuthenticationModule.Pages
{
    [Authorize]
    public class ListPageModel : PageModel
    {
        private readonly RPCAuthenticationModule.Models.AuthDBContext _context;

        public ListPageModel(RPCAuthenticationModule.Models.AuthDBContext _context)
        {
            this._context = _context;
        }

        public IList<User> Model { get; set; }

        public async Task OnGetAsync()
        {
            Model = await _context.User.ToListAsync();
        }
    }
}
