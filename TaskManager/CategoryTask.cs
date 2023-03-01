using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager
{
    public class CategoryTask
    {
        public int Id { get; set; }
        [NotMapped]
        public List<TaskList> TasksLists { get; set; }
    }
}
