namespace TaskManagerApi.Models
{
    public class TaskMgmt
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModified {  get; set; }
        public bool Completed { get; set; } = false;
    }
}
