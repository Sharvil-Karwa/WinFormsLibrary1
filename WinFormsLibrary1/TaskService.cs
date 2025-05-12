using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Timers;
using System.Xml.Serialization;

namespace TaskManagerLib
{
    public class TaskService
    {
        private List<TaskItem> tasks = new();
        private string filePath = "tasks.xml";
        private System.Timers.Timer reminderTimer;
        private int nextId = 1;

        public TaskService()
        {
            LoadTasks();
            StartReminderTimer();
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

        public void UpdateTask(int id, string description, DateTime? deadline, bool? isCompleted)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return;

            if (!string.IsNullOrWhiteSpace(description)) task.Description = description;
            if (deadline.HasValue && deadline > DateTime.Now) task.Deadline = deadline.Value;
            if (isCompleted.HasValue) task.IsCompleted = isCompleted.Value;

            SaveTasks();
        }

        public void DeleteTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
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
                    var left = task.Deadline - DateTime.Now;

                    if (left.TotalMinutes <= 60 && left.TotalMinutes > 55 && !task.Reminded1Hr)
                    {
                        task.Reminded1Hr = true;
                    }

                    if (left.TotalMinutes <= 5 && left.TotalMinutes > 0 && !task.Reminded5Min)
                    {
                        task.Reminded5Min = true;
                    }

                    if (left.TotalSeconds <= 0 && !task.RemindedDue)
                    {
                        task.RemindedDue = true;

                        var input = string.Empty;
                        var inputThread = new Thread(() => input = Console.ReadLine());
                        inputThread.Start();

                        var success = inputThread.Join(15000);
                        if (success && DateTime.TryParse(input, out var newDeadline) && newDeadline > DateTime.Now)
                        {
                            task.Deadline = newDeadline;
                            task.Reminded1Hr = false;
                            task.Reminded5Min = false;
                            task.RemindedDue = false;
                        }
                        else
                        {
                            task.Deadline = DateTime.Now.AddHours(1);
                            task.Reminded1Hr = false;
                            task.Reminded5Min = false;
                            task.RemindedDue = false;
                        }
                    }
                }

                SaveTasks();
            };

            reminderTimer.AutoReset = true;
            reminderTimer.Start();
        }
    }
}
