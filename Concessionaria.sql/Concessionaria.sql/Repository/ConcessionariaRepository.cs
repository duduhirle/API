using Concessionaria.sql.Contexts;
using Concessionaria.Interfaces;
using Concessionaria.sql.Models;

namespace Concessionaria.sql.Repositories
{
    // Responsável por se comunicar diretamente com o banco.
    // ": ICursoRepository" -> promete cumprir o contrato da Interface.
    public class CursoRepository : ICursoRepository
    {
        /*
            Injetar o Context: uma cozinha precisa do fogão (ConcessionariaContext)
            para fazer os pratos. Em vez de criar o Context sozinha,
            ela pede no construtor e a API entrega pronto.
            Isso se chama Injeção de Dependência.

            _context - convenção do C# para campo privado da classe.
        */
        private readonly ConcessionariaContext _context;

        // Injeção de dependência: a API entrega o ConcessionariaContext pronto.
        public CursoRepository(ConcessionariaContext context)
        {
            _context = context;
        }

        // INSERT INTO Marca
        public void Cadastrar(Marca marca)
        {
            _context.Marca.Add(marca);   // coloca na fila (marca para inserir)
            _context.SaveChanges();      // grava no banco
        }

        // SELECT * FROM Marca
        public List<Marca> ListarTodos()
        {
            return _context.Marca.ToList();   // ToList() -> busca todos os registros
        }

        // SELECT * FROM Marca WHERE IdMarca = @id
        public Marca? BuscarPorId(int id)
        {
            return _context.Marca.Find(id);   // Find() -> busca pela chave primária (ou null)
        }

        object? ICursoRepository.ListarTodos()
        {
            return ListarTodos();
        }
    }

    public interface ICursoRepository
    {
        object? ListarTodos();
    }
}