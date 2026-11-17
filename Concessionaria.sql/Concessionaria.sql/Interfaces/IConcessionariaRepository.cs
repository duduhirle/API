
using Concessionaria.sql.Models;

namespace Concessionaria.Interfaces
{
    public interface IConcessionariaRepository
    {
        /*
          public interface - É um contrato: só diz QUE o método existe,
                             sem implementar (sem corpo { }).

          List<Curso>      - devolve uma lista de Curso.
      */

        // R - Read: devolve todos as Marcas.
        List<Marca> ListarTodos();

            // R - Read: busca uma Marca pelo Id (ou null se não achar).
            Marca? BuscarPorId(int id);

            // C - Create: cadastra uma Marca nova.
            void Cadastrar(Marca marca);
        
    }



}

