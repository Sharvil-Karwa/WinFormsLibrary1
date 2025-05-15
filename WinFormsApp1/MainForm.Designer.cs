namespace TaskReminderApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ListBox reminderListBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.TextBox hhTextBox;
        private System.Windows.Forms.TextBox mmTextBox;
        private System.Windows.Forms.CheckBox completedCheckBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label hhLabel;
        private System.Windows.Forms.Label mmLabel;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.reminderListBox = new System.Windows.Forms.ListBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.hhTextBox = new System.Windows.Forms.TextBox();
            this.mmTextBox = new System.Windows.Forms.TextBox();
            this.completedCheckBox = new System.Windows.Forms.CheckBox();
            this.addButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.messageLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.hhLabel = new System.Windows.Forms.Label();
            this.mmLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // 
            // reminderListBox
            // 
            this.reminderListBox.FormattingEnabled = true;
            this.reminderListBox.ItemHeight = 16;
            this.reminderListBox.Location = new System.Drawing.Point(12, 12);
            this.reminderListBox.Name = "reminderListBox";
            this.reminderListBox.Size = new System.Drawing.Size(380, 340);
            this.reminderListBox.TabIndex = 0;
            this.reminderListBox.SelectedIndexChanged += new System.EventHandler(this.reminderListBox_SelectedIndexChanged);

            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(410, 20);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(79, 17);
            this.descriptionLabel.TabIndex = 1;
            this.descriptionLabel.Text = "Description";

            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(410, 40);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(250, 22);
            this.descriptionTextBox.TabIndex = 2;

            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(410, 75);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(38, 17);
            this.dateLabel.TabIndex = 3;
            this.dateLabel.Text = "Date";

            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(410, 95);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(250, 22);
            this.dateTimePicker.TabIndex = 4;
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(410, 130);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(41, 17);
            this.timeLabel.TabIndex = 5;
            this.timeLabel.Text = "Time";

            // 
            // hhLabel
            // 
            this.hhLabel.AutoSize = true;
            this.hhLabel.Location = new System.Drawing.Point(410, 150);
            this.hhLabel.Name = "hhLabel";
            this.hhLabel.Size = new System.Drawing.Size(25, 17);
            this.hhLabel.TabIndex = 6;
            this.hhLabel.Text = "HH";

            // 
            // hhTextBox
            // 
            this.hhTextBox.Location = new System.Drawing.Point(440, 147);
            this.hhTextBox.MaxLength = 2;
            this.hhTextBox.Name = "hhTextBox";
            this.hhTextBox.Size = new System.Drawing.Size(40, 22);
            this.hhTextBox.TabIndex = 7;

            // 
            // mmLabel
            // 
            this.mmLabel.AutoSize = true;
            this.mmLabel.Location = new System.Drawing.Point(490, 150);
            this.mmLabel.Name = "mmLabel";
            this.mmLabel.Size = new System.Drawing.Size(27, 17);
            this.mmLabel.TabIndex = 8;
            this.mmLabel.Text = "MM";

            // 
            // mmTextBox
            // 
            this.mmTextBox.Location = new System.Drawing.Point(520, 147);
            this.mmTextBox.MaxLength = 2;
            this.mmTextBox.Name = "mmTextBox";
            this.mmTextBox.Size = new System.Drawing.Size(40, 22);
            this.mmTextBox.TabIndex = 9;

            // 
            // completedCheckBox
            // 
            this.completedCheckBox.AutoSize = true;
            this.completedCheckBox.Location = new System.Drawing.Point(410, 185);
            this.completedCheckBox.Name = "completedCheckBox";
            this.completedCheckBox.Size = new System.Drawing.Size(98, 21);
            this.completedCheckBox.TabIndex = 10;
            this.completedCheckBox.Text = "Completed";
            this.completedCheckBox.UseVisualStyleBackColor = true;

            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(410, 220);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(80, 30);
            this.addButton.TabIndex = 11;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);

            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(500, 220);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(80, 30);
            this.updateButton.TabIndex = 12;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);

            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(590, 220);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(80, 30);
            this.deleteButton.TabIndex = 13;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);

            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.messageLabel.Location = new System.Drawing.Point(12, 360);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(0, 17);
            this.messageLabel.TabIndex = 14;

            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(700, 400);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.completedCheckBox);
            this.Controls.Add(this.mmTextBox);
            this.Controls.Add(this.mmLabel);
            this.Controls.Add(this.hhTextBox);
            this.Controls.Add(this.hhLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.reminderListBox);
            this.Name = "MainForm";
            this.Text = "Task Reminder App";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
