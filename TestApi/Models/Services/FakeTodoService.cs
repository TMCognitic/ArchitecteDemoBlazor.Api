namespace TestApi.Models.Services
{
    public class FakeTodoService : ITodoRepository
    {
        private readonly IList<Todo> _items;

        public FakeTodoService(IList<Todo> items)
        {
            _items = items;
        }

        public Todo Add(string title)
        {
            int id = (_items.Count == 0) ? 1 : _items.Max(td => td.Id) + 1;
            Todo newTodo = new Todo(id, title);

            _items.Add(newTodo);
            return newTodo;
        }

        public IEnumerable<Todo> Get()
        {
            return _items;
        }

        public bool Cloture(int todoId)
        {
            Todo? todo = _items.SingleOrDefault(td => td.Id == todoId);

            if (todo is null)
                return false;

            todo.Done = true;

            return true;
        }

        public bool Delete(int todoId)
        {
            Todo? todo = _items.SingleOrDefault(td => td.Id == todoId);

            if (todo is null)
                return false;

            _items.Remove(todo);
            return true;
        }
    }
}
