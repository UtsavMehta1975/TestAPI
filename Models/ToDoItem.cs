// Models/ToDoItem.cs
namespace ToDoApi.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string? Title { get; set; } // Make the property nullable
        public bool IsCompleted { get; set; }
    }
}
