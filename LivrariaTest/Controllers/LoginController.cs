using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LivrariaTest.Context;
using LivrariaTest.Log;
using LivrariaTest.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaTest.Controllers
{
    public class LoginController : Controller
    {
        private readonly ContextDataBase _context;
        [HttpGet]
        public ActionResult UsuarioLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UsuarioLogin([Bind] Usuario _usuario)
        {
            var usuario = new Usuario();
            if (usuario.GetUsuarios().Any(u => u.Login == _usuario.Login && u.Senha == _usuario.Senha))
            {
                var userClaims = new List<Claim>()
                {
                    //define o cookie
                    new Claim(ClaimTypes.Name, _usuario.Login),
                };
                var minhaIdentity = new ClaimsIdentity(userClaims, "Usuario");
                var userPrincipal = new ClaimsPrincipal(new[] { minhaIdentity });
                //cria o cookie
                HttpContext.SignInAsync(userPrincipal);
                return RedirectToAction("Index", "Livro");
            }
            else if((_usuario.Login != null) && (_usuario.Senha != null))
            {
                ViewBag.Message = "Credenciais inválidas.";
            }

            return View(_usuario);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
