using Concessionaria.sql.Repositories;
using Concessionaria.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Concessionaria.sql.Controllers
{
    [Route("api/[controller]")]   // rota: api/curso
    [ApiController]
    public class CursoController : ControllerBase
    {
        // O garçom guarda o cardápio (o acesso à cozinha).
        private readonly ICursoRepository _cursoRepository;

        // Injeção de dependência: a API entrega o CursoRepository
        // (por causa do AddScoped do passo 11).
        public CursoController(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }


        // GET api/curso
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_cursoRepository.ListarTodos());   // 200 + lista em JSON
        }
    }
}