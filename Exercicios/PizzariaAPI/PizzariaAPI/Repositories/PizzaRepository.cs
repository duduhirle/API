using PizzariaAPI.Contexts;
using PizzariaAPI.Interfaces;
using PizzariaAPI.Models;
using static PizzariaAPI.Repositories.PizzaRepository;

// Repository é a cozinha: recebe o pedido do garçom (Controller) e entrega o prato pronto (Model).

namespace PizzariaAPI.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        // Responsável por se comunicar diretamente com o banco.
        // ": IPizzaRepository" -> promete cumprir o contrato da Interface.
        
        
            /*
                Injetar o Context: uma cozinha precisa do fogão (EscolaContext)
                para fazer os pratos. Em vez de criar o Context sozinha,
                ela pede no construtor e a API entrega pronto.
                Isso se chama Injeção de Dependência.

                _context - convenção do C# para campo privado da classe.
            */
            private readonly PizzariaContext _context;

            // Injeção de dependência: a API entrega o PizzariaContext pronto.
            public PizzaRepository(PizzariaContext context)
            {
                _context = context;
            }

            // INSERT INTO Pizza
            public void Cadastrar(Pizza pizza)
            {
                _context.Pizza.Add(pizza);   // coloca na fila (marca para inserir)
                _context.SaveChanges();      // grava no banco
            }

            // SELECT * FROM Pizza
            public List<Pizza> ListarTodos()
            {
                return _context.Pizza.ToList();   // ToList() -> busca todos os registros
            }

            // SELECT * FROM Pizza WHERE IdPizza = @id
            public Pizza? BuscarPorId(int id)
            {
                return _context.Pizza.Find(id);   // Find() -> busca pela chave primária (ou null)
            }

        object? IPizzaRepository.ListarTodos()
        {
            return ListarTodos();
        }
    }
}
