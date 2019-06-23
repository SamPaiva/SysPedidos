using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SysPedidos.Api.ViewModels;
using SysPedidos.Model;
using SysPedidos.Model.IRepository;

namespace SysPedidos.Api.Controllers
{
    
    [Produces("application/json")]
    [Route("api/Cliente")]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _repository;

        public ClienteController(IClienteRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public IActionResult ListarClientes()
        {
            return Ok(_repository.ListarClientes());
        }

        [HttpPost]
        public IActionResult AdicionarCliente([FromBody]ClienteViewModel cliente)
        {
            if (cliente == null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                Cliente _cliente = new Cliente();

                //_cliente.ClienteId = cliente.ClienteId;
                _cliente.NomeCliente = cliente.NomeCliente;
                _cliente.Telefone = cliente.Telefone;
                _cliente.Endereco = cliente.Endereco;
                _cliente.DataCriacao = DateTime.Now;

                _repository.AdicionarCliente(_cliente);
                return CreatedAtRoute("ListarClientes", _cliente);
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCliente(long ClienteId, ClienteViewModel vm)
        {
            if (ClienteId == null)
                return NotFound();

            Cliente cliente = new Cliente();
            cliente.NomeCliente = vm.NomeCliente;
            cliente.Telefone = vm.Telefone;
            cliente.Endereco = vm.Endereco;

            if (ModelState.IsValid);
                _repository.EditarCliente(cliente);    

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCliente(long Id)
        {
            if (Id == null)
                return NotFound();

            _repository.DeletarCliente(Id);

            return NoContent();
        }
    }
}