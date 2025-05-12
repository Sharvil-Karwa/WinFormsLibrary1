using System;

namespace TaskManagerLib
{
    [Serializable]
    public class TaskItem
    {
        public int Id { get; set; }
        public string Description { get; set; } = "";
        public DateTime Deadline { get; set; }
        public bool IsCompleted { get; set; }

        [NonSerialized] public bool Reminded1Hr;
        [NonSerialized] public bool Reminded5Min;
        [NonSerialized] public bool RemindedDue;
    }
}
