namespace TaskManagerWinForms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox taskListBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.DateTimePicker deadlinePicker;
        private System.Windows.Forms.CheckBox completedCheckBox;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button deleteButton;

        private void InitializeComponent()
        {
            this.taskListBox = new System.Windows.Forms.ListBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.deadlinePicker = new System.Windows.Forms.DateTimePicker();
            this.completedCheckBox = new System.Windows.Forms.CheckBox();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.taskListBox.FormattingEnabled = true;
            this.taskListBox.ItemHeight = 15;
            this.taskListBox.Location = new System.Drawing.Point(12, 12);
            this.taskListBox.Size = new System.Drawing.Size(400, 150);

            this.descriptionTextBox.Location = new System.Drawing.Point(12, 180);
            this.descriptionTextBox.Size = new System.Drawing.Size(400, 23);

            this.deadlinePicker.Location = new System.Drawing.Point(12, 210);
            this.deadlinePicker.Size = new System.Drawing.Size(400, 23);

            this.completedCheckBox.Location = new System.Drawing.Point(12, 240);
            this.completedCheckBox.Text = "Completed";

            this.idTextBox.Location = new System.Drawing.Point(12, 270);
            this.idTextBox.Size = new System.Drawing.Size(100, 23);

            this.addButton.Location = new System.Drawing.Point(12, 300);
            this.addButton.Text = "Add";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);

            this.updateButton.Location = new System.Drawing.Point(120, 300);
            this.updateButton.Text = "Update";
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);

            this.deleteButton.Location = new System.Drawing.Point(230, 300);
            this.deleteButton.Text = "Delete";
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);

            this.ClientSize = new System.Drawing.Size(430, 340);
            this.Controls.Add(this.taskListBox);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.deadlinePicker);
            this.Controls.Add(this.completedCheckBox);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.deleteButton);
            this.Text = "Task Manager";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
