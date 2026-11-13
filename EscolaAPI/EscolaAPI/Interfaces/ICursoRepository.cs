using EscolaAPI.Models;
namespace EscolaAPI.Interfaces


{
    public interface ICursoRepository
    {

        // Public interface -- É um contrato, só diz que existe sem implementar

        //R - read - devolve todos os cursos.
        List<Curso> ListarTodos(); // Criando uma string de ListarTodos que vai devolver uma lista de cursos. 

        // Create - cadastrar um novo curso

        void Cadastrar(Curso curso); // Para CADASTRAR precisa acessar Curso para gerar um curso 




    }
}
