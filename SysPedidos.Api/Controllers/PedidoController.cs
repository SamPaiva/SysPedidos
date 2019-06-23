using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysPedidos.Api.ViewModels;
using SysPedidos.Data.Repository;
using SysPedidos.Model;
using SysPedidos.Model.IRepository;

namespace SysPedidos.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Pedido")]
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository _repository;

        public PedidoController(IPedidoRepository repository)
        {
            _repository = repository;
        }

        public IActionResult ListarPedidos()
        {
            return Json(_repository.ListarPedidos());
        }

        [HttpPost]
        public IActionResult AdicionarPedido([FromBody]PedidoViewModel pedido)
        {
            if (pedido == null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                Pedido _pedido = new Pedido();

                _pedido.NomeCliente = pedido.Cliente;
                _pedido.DataPedido = DateTime.Now;

                _repository.AdicionarPedido(_pedido);
                return Ok(_pedido);
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarPedido(long pedidoId, PedidoViewModel vm)
        {
            if (pedidoId == null)
                return NotFound();

            Pedido pedido = new Pedido();

            if (ModelState.IsValid)
            _repository.EditarPedido(pedido);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarPedido(long Id)
        {
            if (Id == null)
                return NotFound();

            _repository.DeletarPedido(Id);

            return NoContent();
        }
    }
}