using System;

namespace TaskManagerLib
{
    [Serializable]
    public class TaskItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedAt { get; set; }
        public bool Reminded1Hr { get; set; }
        public bool Reminded5Min { get; set; }
        public bool RemindedDue { get; set; }


    }
}
