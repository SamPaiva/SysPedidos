using Microsoft.AspNetCore.Mvc;
using SysPedidos.Api.ViewModels;
using SysPedidos.Model;
using SysPedidos.Model.IRepository;

namespace SysPedidos.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Cardapio")]
    public class CardapioController : Controller
    {
        private readonly ICardapioRepository _repository;

        public CardapioController(ICardapioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult ListarCardapio()
        {
            return Ok(_repository.CardapioList());
        }

        [HttpPost]
        public IActionResult AdicionarItemCardapio([FromBody]CardapioViewModel vm)
        {
            if (vm == null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                Cardapio cardapio = new Cardapio();

                cardapio.DescItem = vm.DescItem;
                cardapio.ItemCardapio = vm.ItemCardapio;

                _repository.AddItemCardapio(cardapio);
                return CreatedAtRoute("ListarCardapio", cardapio);
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCardapio(long CardapioId, CardapioViewModel vm)
        {
            if (CardapioId == null)
                return NotFound();

            Cardapio cardapio = new Cardapio();
            cardapio.DescItem = vm.DescItem;
            cardapio.ItemCardapio = vm.ItemCardapio;

            if (ModelState.IsValid) ;
            _repository.EditCardapio(cardapio);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCardapio(long Id)
        {
            if (Id == null)
                return NotFound();

            _repository.DeleteCardapio(Id);

            return NoContent();
        }
    }
}