using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RPCAuthenticationModule.viewModels;

namespace RPCAuthenticationModule.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RPCAuthenticationModule.Models.AuthDBContext _context;

        [BindProperty]
        public User Model { get; set; }

        public RegisterModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
            RPCAuthenticationModule.Models.AuthDBContext _context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this._context = _context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = Model.UserName,
                };

                var result = await userManager.CreateAsync(user, Model.Password);

                if (result.Succeeded)
                {
                    _context.User.Add(Model);
                    await _context.SaveChangesAsync();
                    await signInManager.SignInAsync(user, false);

                    return RedirectToPage("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return Page();
        }
    }
}
