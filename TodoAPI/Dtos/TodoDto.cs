namespace TodoAPI.Dtos
{
    public class TodoDto
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public bool IsComplete { get; set; }
    }
}
