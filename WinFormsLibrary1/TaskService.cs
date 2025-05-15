using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;
using System.Xml.Serialization;

namespace TaskManagerLib
{
    public class TaskService
    {
        private List<TaskItem> tasks = new();
        private string filePath = "tasks.xml";
        private System.Timers.Timer reminderTimer;
        private System.Timers.Timer cleanupTimer;
        private int nextId = 1;

        public TaskService()
        {
            LoadTasks();
            StartReminderTimer();
            StartCleanupTimer();
        }

        public List<TaskItem> GetTasks() => tasks;

        public void AddTask(string description, DateTime deadline)
        {
            var task = new TaskItem
            {
                Id = nextId++,
                Description = description,
                Deadline = deadline,
                IsCompleted = false
            };
            tasks.Add(task);
            SaveTasks();
        }

        public void UpdateTask(TaskItem selectedTask, string description, DateTime? deadline, bool? isCompleted)
        {
            if (selectedTask == null) return;

            if (!string.IsNullOrWhiteSpace(description)) selectedTask.Description = description;
            if (deadline.HasValue) selectedTask.Deadline = deadline.Value;

            if (isCompleted.HasValue && isCompleted.Value != selectedTask.IsCompleted)
            {
                selectedTask.IsCompleted = isCompleted.Value;
                selectedTask.CompletedAt = isCompleted.Value ? DateTime.Now : null;
            }

            SaveTasks();
        }

        public void DeleteTask(TaskItem task)
        {
            if (task != null)
            {
                tasks.Remove(task);
                SaveTasks();
            }
        }

        private void LoadTasks()
        {
            if (File.Exists(filePath))
            {
                var serializer = new XmlSerializer(typeof(List<TaskItem>));
                using var reader = new StreamReader(filePath);
                tasks = (List<TaskItem>)serializer.Deserialize(reader);
                if (tasks.Any())
                    nextId = tasks.Max(t => t.Id) + 1;
            }
        }

        private void SaveTasks()
        {
            var serializer = new XmlSerializer(typeof(List<TaskItem>));
            using var writer = new StreamWriter(filePath);
            serializer.Serialize(writer, tasks);
        }

        private void StartReminderTimer()
        {
            reminderTimer = new System.Timers.Timer(30000);
            reminderTimer.Elapsed += (sender, e) =>
            {
                foreach (var task in tasks.Where(t => !t.IsCompleted))
                {
                    var timeLeft = task.Deadline - DateTime.Now;
                    if (timeLeft.TotalMinutes <= 60 && !task.Reminded1Hr)
                    {
                        Console.WriteLine($"Reminder: 1 hour left for task {task.Description}");
                        task.Reminded1Hr = true;
                    }
                    if (timeLeft.TotalMinutes <= 5 && !task.Reminded5Min)
                    {
                        Console.WriteLine($"Reminder: 5 minutes left for task {task.Description}");
                        task.Reminded5Min = true;
                    }
                    if (timeLeft.TotalSeconds <= 0 && !task.RemindedDue)
                    {
                        Console.WriteLine($"Task {task.Description} is due now!");
                        task.RemindedDue = true;
                    }
                }
            };
            reminderTimer.Start();
        }

        private void StartCleanupTimer()
        {
            cleanupTimer = new System.Timers.Timer(60000);
            cleanupTimer.Elapsed += (sender, e) =>
            {
                var old = tasks.Where(t => t.IsCompleted && t.CompletedAt != null && (DateTime.Now - t.CompletedAt.Value).TotalHours > 1).ToList();
                foreach (var task in old)
                    tasks.Remove(task);

                if (old.Any()) SaveTasks();
            };
            cleanupTimer.Start();
        }
    }
}
