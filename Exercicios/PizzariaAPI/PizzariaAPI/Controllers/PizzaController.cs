using PizzariaAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// O controller é o garçom: recebe o pedido do cliente (HTTP) e entrega para a cozinha (Repository).

namespace PizzariaAPI.Controllers
{
    [Route("api/[controller]")]   // rota: api/pizza
    [ApiController]
    public class PizzaController : ControllerBase
    {
        // O garçom guarda o cardápio (o acesso à cozinha).
        private readonly IPizzaRepository _pizzaRepository;

        // Injeção de dependência: a API entrega o PizzaRepository
        // (por causa do AddScoped do passo 11).
        public PizzaController(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        // GET api/pizza
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_pizzaRepository.ListarTodos());   // 200 + lista em JSON
        }
    }
}