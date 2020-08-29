using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivrariaTest.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaTest.Controllers
{
    public class ContaController : Controller
    {
        private readonly UserManager<IdentityUser> manipularUsuario;
        private readonly SignInManager<IdentityUser> manipularCadastro;
        public ContaController(UserManager<IdentityUser> manipularUsuario,
            SignInManager<IdentityUser> manipularCadastro)
        {
            this.manipularUsuario = manipularUsuario;
            this.manipularCadastro = manipularCadastro;
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(RegistroUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Copia os dados do RegisterViewModel para o IdentityUser
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };
                // Armazena os dados do usuário na tabela AspNetUsers
                var result = await manipularUsuario.CreateAsync(user, model.Senha);
                // Se o usuário foi criado com sucesso, faz o login do usuário
                // usando o serviço SignInManager e redireciona para o Método Action Index
                if (result.Succeeded)
                {
                    await manipularCadastro.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }
                // Se houver erros então inclui no ModelState
                // que será exibido pela tag helper summary na validação
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }
    }
}
