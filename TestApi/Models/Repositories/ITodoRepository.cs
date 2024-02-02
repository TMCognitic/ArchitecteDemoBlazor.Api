using TestApi.Models.Entities;

namespace TestApi.Models.Repositories
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> Get();
        Todo Add(string title); //<-- Si CQS recoit une commande
        bool Cloture(int todoId);
        bool Delete(int todoId);
    }
}
