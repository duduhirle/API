using PizzariaAPI.Models;
// Interface é um contrato: só diz QUE o método existe, sem implementar (sem corpo { }).
namespace PizzariaAPI.Interfaces
{
    public interface IPizzaRepository
    {
        object? ListarTodos();

        /*
public interface - É um contrato: só diz QUE o método existe,
sem implementar (sem corpo { }).

List<Pizza>      - devolve uma lista de Pizza.
*/
        public interface IPizzaRepository
        {
            // R - Read: devolve todas as pizzas.
            List<Pizza> ListarTodos();

            // R - Read: busca uma pizza pelo Id (ou null se não achar).
            Pizza? BuscarPorId(int id);

            // C - Create: cadastra uma pizza nova.
            void Cadastrar(Pizza pizza);
        }



    }
}
