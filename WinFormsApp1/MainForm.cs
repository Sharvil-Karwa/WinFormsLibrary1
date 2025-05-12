using System;
using System.Linq;
using System.Windows.Forms;
using TaskManagerLib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TaskManagerWinForms
{
    public partial class MainForm : Form
    {
        private TaskService taskService = new();

        public MainForm()
        {
            InitializeComponent();
            LoadTasks();
        }

        private void LoadTasks()
        {
            taskListBox.Items.Clear();
            foreach (var task in taskService.GetTasks())
            {
                taskListBox.Items.Add($"{task.Id}: {task.Description} | {task.Deadline} | {(task.IsCompleted ? "Done" : "Pending")}");
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var description = descriptionTextBox.Text;
            var deadline = deadlinePicker.Value;
            taskService.AddTask(description, deadline);
            LoadTasks();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(idTextBox.Text, out int id))
            {
                var desc = descriptionTextBox.Text;
                var deadline = deadlinePicker.Value;
                var completed = completedCheckBox.Checked;
                taskService.UpdateTask(id, desc, deadline, completed);
                LoadTasks();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(idTextBox.Text, out int id))
            {
                taskService.DeleteTask(id);
                LoadTasks();
            }
        }
    }
}
