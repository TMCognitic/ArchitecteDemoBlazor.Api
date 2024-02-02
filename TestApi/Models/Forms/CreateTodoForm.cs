using System.ComponentModel.DataAnnotations;

namespace TestApi.Models.Forms
{
    public class CreateTodoForm
    {
        [Required]
        public string Title { get; set; } = default!;
    }
}
