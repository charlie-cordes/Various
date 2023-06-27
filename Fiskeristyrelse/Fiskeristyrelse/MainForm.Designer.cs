namespace Fiskeristyrelse
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SaveToDatabaseButton = new Button();
            LoadCSVButton = new Button();
            dataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // SaveToDatabaseButton
            // 
            SaveToDatabaseButton.Location = new Point(12, 415);
            SaveToDatabaseButton.Name = "SaveToDatabaseButton";
            SaveToDatabaseButton.Size = new Size(123, 23);
            SaveToDatabaseButton.TabIndex = 0;
            SaveToDatabaseButton.Text = "Save To Database";
            SaveToDatabaseButton.UseVisualStyleBackColor = true;
            // 
            // LoadCSVButton
            // 
            LoadCSVButton.Location = new Point(141, 415);
            LoadCSVButton.Name = "LoadCSVButton";
            LoadCSVButton.Size = new Size(75, 23);
            LoadCSVButton.TabIndex = 1;
            LoadCSVButton.Text = "Load CSV";
            LoadCSVButton.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(12, 12);
            dataGridView.Name = "dataGridView";
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new Size(776, 397);
            dataGridView.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView);
            Controls.Add(LoadCSVButton);
            Controls.Add(SaveToDatabaseButton);
            Name = "MainForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button SaveToDatabaseButton;
        private Button LoadCSVButton;
        private DataGridView dataGridView;
    }
}