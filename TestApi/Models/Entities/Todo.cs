namespace TestApi.Models.Entities
{
    public class Todo
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public bool Done { get; set; }

        public Todo(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
