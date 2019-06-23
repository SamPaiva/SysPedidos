using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysPedidos.Api.ViewModels;
using SysPedidos.Model;
using SysPedidos.Model.IRepository;

namespace SysPedidos.Api.Controllers
{
    
    [Produces("application/json")]
    [Route("api/Login")]
    public class LoginController : Controller
    {
        private ILoginRepository _repository;

        public LoginController(ILoginRepository repository)
        {
            _repository = repository;
        }


        [HttpPost]
        public IActionResult SignIn([FromBody]LoginViewModel vm)
        {
            if (ModelState.IsValid && vm != null)
            {
                Login login = new Login();
                //login.LoginId = vm.LoginId;
                login.Usuario = vm.Usuario;
                login.Senha = vm.Senha;


                bool sucess = _repository.SignIn(login);

                if (sucess == true)
                {
                    return Ok(login);
                }
                else
                {
                    return BadRequest();
                }
            }

            return NotFound();
        }
    }
}