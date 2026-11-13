using EscolaAPI.Contexts;
using EscolaAPI.Interfaces;
using EscolaAPI.Models;

namespace EscolaAPI.Repositories
{
    public class CursoRepository : ICursoRepository
    {

        // Responsavel com se comunicar diretamente com o BD

        // Campo

        // Injetar o context -  Uma cozinha precisa do fogão (EscolaContext)
        // Para fazer os pratos. Em vez de criar a classe Context sozinha, ela pede no construtor da API para entregar pronto.
        // Isso se chama Injecao de Dependencia.
        // _context - Convencao do C# para campo privado da classe.
        private readonly EscolaContext _context;

        // Injeção de dependencia > a API entrega o EscolaContext pronto
        public CursoRepository(EscolaContext context) 
        {
            _context = context; 
        }


        // Insert into Curso
        public void Cadastrar(Curso curso)
        {
            _context.Curso.Add(curso); // Coloca na fita -> marca para inserir
            _context.SaveChanges(); // Grava no banco

        }


        // Select * from Curso
        // |->
        public List<Curso> ListarTodos()
        {
            return _context.Curso.ToList(); // ToList() -> Busca todos os registros.
        }
    }
}
