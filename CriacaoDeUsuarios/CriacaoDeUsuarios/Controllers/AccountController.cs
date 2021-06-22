using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CriacaoDeUsuarios.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CriacaoDeUsuarios.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<IdentityUser> userManager;

        public AccountController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(RegisterViewModel cadastro)
        {
            if (ModelState.IsValid)
            {
                var usuarios = new IdentityUser
                {
                    UserName = cadastro.Email,
                    Email = cadastro.Email
                };
                var confirma = await userManager.CreateAsync(usuarios, cadastro.Password);
                return RedirectToAction(nameof(Cadastrar));
            }
            return View(cadastro);
        }

    }
}
