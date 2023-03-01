namespace TaskManager
{
    public class UserTask
    {
        public int Id { get; set; }
        public byte Priority { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
        public string State { get; set; }
        public bool IsReady { get; set; }
    }
}
