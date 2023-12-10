namespace EduEngage
{
    partial class Clues2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.clue2_table = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.clue2_table)).BeginInit();
            this.SuspendLayout();
            // 
            // clue2_table
            // 
            this.clue2_table.AllowUserToAddRows = false;
            this.clue2_table.AllowUserToDeleteRows = false;
            this.clue2_table.AllowUserToResizeColumns = false;
            this.clue2_table.AllowUserToResizeRows = false;
            this.clue2_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clue2_table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.clue2_table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clue2_table.Location = new System.Drawing.Point(0, 0);
            this.clue2_table.Name = "clue2_table";
            this.clue2_table.RowHeadersVisible = false;
            this.clue2_table.RowHeadersWidth = 62;
            this.clue2_table.RowTemplate.Height = 33;
            this.clue2_table.Size = new System.Drawing.Size(1080, 638);
            this.clue2_table.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "#";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 35;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Direction";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Clue";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Clues2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 638);
            this.Controls.Add(this.clue2_table);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Clues2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Clues2";
            ((System.ComponentModel.ISupportInitialize)(this.clue2_table)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        public DataGridView clue2_table;
    }
}