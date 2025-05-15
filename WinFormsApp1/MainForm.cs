using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TaskManagerLib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TaskReminderApp
{
    public partial class MainForm : Form
    {
        private TaskService taskService;
        private TaskItem selectedTask;

        public MainForm()
        {
            InitializeComponent();
            taskService = new TaskService();
            SetupControls();
            LoadTasksToListBox();

        }

        private void SetupControls()
        {
            // Initialize your controls here (if not using designer)
            // For example, set max length, input ranges, etc.
            hhTextBox.MaxLength = 2;
            mmTextBox.MaxLength = 2;
        }

        private void LoadTasksToListBox()
        {
            reminderListBox.Items.Clear();

            var tasks = taskService.GetTasks();

            // Sort: incomplete by nearest deadline first, completed at bottom
            var sortedTasks = tasks
                .OrderBy(t => t.IsCompleted)
                .ThenBy(t => t.Deadline)
                .ToList();

            foreach (var task in sortedTasks)
            {
                string display = task.Description + " - " + task.Deadline.ToString("g");
                if (task.IsCompleted)
                    display += " [COMPLETED]";
                else if (task.Deadline < DateTime.Now)
                    display += " [MISSED DEADLINE]";

                reminderListBox.Items.Add(new ListBoxItem(task, display));
            }
        }

        private void reminderListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (reminderListBox.SelectedItem is ListBoxItem item)
            {
                selectedTask = item.Task;
                descriptionTextBox.Text = selectedTask.Description;
                dateTimePicker.Value = selectedTask.Deadline.Date;
                hhTextBox.Text = selectedTask.Deadline.Hour.ToString("D2");
                mmTextBox.Text = selectedTask.Deadline.Minute.ToString("D2");
                completedCheckBox.Checked = selectedTask.IsCompleted;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(out DateTime deadline)) return;

            try
            {
                taskService.AddTask(descriptionTextBox.Text.Trim(), deadline);
                ShowMessage("Task added successfully.");
                ClearInputs();
                LoadTasksToListBox();
            }
            catch (Exception ex)
            {
                ShowMessage("Error adding task: " + ex.Message);
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (selectedTask == null)
            {
                ShowMessage("Select a task to update.");
                return;
            }

            if (!ValidateInputs(out DateTime deadline)) return;

            try
            {
                taskService.UpdateTask(selectedTask, descriptionTextBox.Text.Trim(), deadline, completedCheckBox.Checked);
                ShowMessage("Task updated successfully.");
                ClearInputs();
                LoadTasksToListBox();
                selectedTask = null;
            }
            catch (Exception ex)
            {
                ShowMessage("Error updating task: " + ex.Message);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (selectedTask == null)
            {
                ShowMessage("Select a task to delete.");
                return;
            }

            try
            {
                taskService.DeleteTask(selectedTask);
                ShowMessage("Task deleted successfully.");
                ClearInputs();
                LoadTasksToListBox();
                selectedTask = null;
            }
            catch (Exception ex)
            {
                ShowMessage("Error deleting task: " + ex.Message);
            }
        }

        private bool ValidateInputs(out DateTime deadline)
        {
            deadline = DateTime.MinValue;

            string description = descriptionTextBox.Text.Trim();
            if (string.IsNullOrEmpty(description))
            {
                ShowMessage("Task description cannot be empty.");
                return false;
            }

            if (!int.TryParse(hhTextBox.Text, out int hh) || hh < 0 || hh > 23)
            {
                ShowMessage("Hours must be a number between 00 and 23.");
                return false;
            }

            if (!int.TryParse(mmTextBox.Text, out int mm) || mm < 0 || mm > 59)
            {
                ShowMessage("Minutes must be a number between 00 and 59.");
                return false;
            }

            DateTime date = dateTimePicker.Value.Date;
            deadline = date.AddHours(hh).AddMinutes(mm);

            if (deadline < DateTime.Now)
            {
                ShowMessage("Deadline must be in the future.");
                return false;
            }

            return true;
        }

        private void ClearInputs()
        {
            descriptionTextBox.Clear();
            hhTextBox.Clear();
            mmTextBox.Clear();
            completedCheckBox.Checked = false;
            selectedTask = null;
            dateTimePicker.Value = DateTime.Now;
        }

        private void ShowMessage(string message)
        {
            messageLabel.Text = message;
        }
    }

    // Helper class to hold TaskItem and display text in ListBox
    public class ListBoxItem
    {
        public TaskItem Task { get; }
        public string DisplayText { get; }

        public ListBoxItem(TaskItem task, string displayText)
        {
            Task = task;
            DisplayText = displayText;
        }

        public override string ToString() => DisplayText;
    }
}
