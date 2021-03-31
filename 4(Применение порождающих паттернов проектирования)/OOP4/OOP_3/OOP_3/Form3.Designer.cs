namespace OOP_3
{
    partial class Form3
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NSL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Course = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Avg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Birth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SEX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeight = 50;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NSL,
            this.Course,
            this.Group,
            this.PROF,
            this.Avg,
            this.Birth,
            this.Age,
            this.SEX,
            this.Adr});
            this.dataGridView1.Location = new System.Drawing.Point(14, 12);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1153, 400);
            this.dataGridView1.TabIndex = 33;
            // 
            // NSL
            // 
            this.NSL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NSL.HeaderText = "ФИО";
            this.NSL.MaxInputLength = 100;
            this.NSL.MinimumWidth = 200;
            this.NSL.Name = "NSL";
            this.NSL.ReadOnly = true;
            // 
            // Course
            // 
            this.Course.HeaderText = "Курс";
            this.Course.MaxInputLength = 1;
            this.Course.MinimumWidth = 6;
            this.Course.Name = "Course";
            this.Course.ReadOnly = true;
            this.Course.Width = 68;
            // 
            // Group
            // 
            this.Group.HeaderText = "Группа";
            this.Group.MaxInputLength = 2;
            this.Group.MinimumWidth = 6;
            this.Group.Name = "Group";
            this.Group.ReadOnly = true;
            this.Group.Width = 84;
            // 
            // PROF
            // 
            this.PROF.HeaderText = "Специальность";
            this.PROF.MaxInputLength = 10;
            this.PROF.MinimumWidth = 6;
            this.PROF.Name = "PROF";
            this.PROF.ReadOnly = true;
            this.PROF.Width = 138;
            // 
            // Avg
            // 
            this.Avg.HeaderText = "Средняя оценка";
            this.Avg.MaxInputLength = 3;
            this.Avg.MinimumWidth = 6;
            this.Avg.Name = "Avg";
            this.Avg.ReadOnly = true;
            this.Avg.Width = 133;
            // 
            // Birth
            // 
            this.Birth.HeaderText = "Дата рождения";
            this.Birth.MaxInputLength = 10;
            this.Birth.MinimumWidth = 6;
            this.Birth.Name = "Birth";
            this.Birth.ReadOnly = true;
            this.Birth.Width = 128;
            // 
            // Age
            // 
            this.Age.HeaderText = "Возраст";
            this.Age.MaxInputLength = 3;
            this.Age.MinimumWidth = 6;
            this.Age.Name = "Age";
            this.Age.ReadOnly = true;
            this.Age.Width = 91;
            // 
            // SEX
            // 
            this.SEX.HeaderText = "Пол";
            this.SEX.MaxInputLength = 1;
            this.SEX.MinimumWidth = 6;
            this.SEX.Name = "SEX";
            this.SEX.ReadOnly = true;
            this.SEX.Width = 63;
            // 
            // Adr
            // 
            this.Adr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Adr.HeaderText = "Адрес";
            this.Adr.MaxInputLength = 500;
            this.Adr.MinimumWidth = 400;
            this.Adr.Name = "Adr";
            this.Adr.ReadOnly = true;
            this.Adr.Width = 400;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 423);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form3";
            this.Text = "Результат поиска";
            this.Shown += new System.EventHandler(this.Form3_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NSL;
        private System.Windows.Forms.DataGridViewTextBoxColumn Course;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROF;
        private System.Windows.Forms.DataGridViewTextBoxColumn Avg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Birth;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEX;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adr;
    }
}