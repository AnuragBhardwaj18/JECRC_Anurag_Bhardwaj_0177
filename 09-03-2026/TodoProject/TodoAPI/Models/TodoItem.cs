namespace TodoAPI.Models
{
    public class TodoItem
    {
        public int Id { get; set; }

        public string Task { get; set; } = "";

        public bool IsCompleted { get; set; }

        public string Priority { get; set; } = "Normal";
    }
}