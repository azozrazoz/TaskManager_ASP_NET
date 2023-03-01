namespace TaskManager
{
    public class TaskList
    {
        public int Id { get; set; }
        public List<UserTask> Tasks { get; set; }
        public CategoryTask Category { get; set; }
    }
}
