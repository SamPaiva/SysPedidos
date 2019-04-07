using Microsoft.AspNetCore.Mvc;
using SysPedidos.Model.IRepository;

namespace SysPedidos.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _repository;

        public ClienteController(IClienteRepository repository)
        {
            _repository = repository;
        }

        public IActionResult ListarClientes()
        {
            return View(_repository.ListarClientes());
        }
    }
}