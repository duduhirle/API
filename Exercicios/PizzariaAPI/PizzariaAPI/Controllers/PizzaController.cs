using PizzariaAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzariaAPI.Models;

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

        [HttpPost]
        public IActionResult Cadastrar(Pizza pizza)
        {
            _pizzaRepository.Cadastrar(pizza);
            return Created(); //201
        }


        //****************************************************

        //novo!!! 


        //Atualizar.
        // api/curso/30

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Pizza pizza)
        {
            //consulta se o ID existe no BD antes de atualizar.
            if (_pizzaRepository.BuscarPorId(id) == null)
            {
                return NotFound(); //404
            }

            _pizzaRepository.Atualizar(id, pizza);


            return NoContent(); //204

        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            //consulta se o ID existe no BD antes de atualizar.
            if (_pizzaRepository.BuscarPorId(id) == null)
            {
                return NotFound(); //404
            }

            _pizzaRepository.Deletar(id);
            return NoContent(); //204

        }


        //GET 
        //api/pizza/19

        [HttpGet("{id}")]
        public IActionResult BuscarPorID(int id)
        {
            Pizza? pizza = _pizzaRepository.BuscarPorId(id);

            if (pizza == null)
                return NotFound();

            return Ok(pizza);
        }
    }
}