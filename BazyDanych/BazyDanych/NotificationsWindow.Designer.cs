namespace BazyDanych
{
    partial class NotificationsWindow
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.klasaTestowaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.editButtonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.markaPojazduDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.klasaTestowaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.editButtonDataGridViewTextBoxColumn,
            this.markaPojazduDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.klasaTestowaBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(400, 445);
            this.dataGridView1.TabIndex = 0;
            // 
            // klasaTestowaBindingSource
            // 
            this.klasaTestowaBindingSource.DataSource = typeof(BazyDanych.Car);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ShowCalendar";
            this.Column1.HeaderText = "Zaznacz";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 55;
            // 
            // editButtonDataGridViewTextBoxColumn
            // 
            this.editButtonDataGridViewTextBoxColumn.DataPropertyName = "EditButton";
            this.editButtonDataGridViewTextBoxColumn.HeaderText = "Temat";
            this.editButtonDataGridViewTextBoxColumn.Name = "editButtonDataGridViewTextBoxColumn";
            this.editButtonDataGridViewTextBoxColumn.ReadOnly = true;
            this.editButtonDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.editButtonDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.editButtonDataGridViewTextBoxColumn.Width = 200;
            // 
            // markaPojazduDataGridViewTextBoxColumn
            // 
            this.markaPojazduDataGridViewTextBoxColumn.DataPropertyName = "MarkaPojazdu";
            this.markaPojazduDataGridViewTextBoxColumn.HeaderText = "Data";
            this.markaPojazduDataGridViewTextBoxColumn.Name = "markaPojazduDataGridViewTextBoxColumn";
            // 
            // NotificationsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 445);
            this.Controls.Add(this.dataGridView1);
            this.Name = "NotificationsWindow";
            this.Text = "Powiadomienia";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.klasaTestowaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource klasaTestowaBindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewButtonColumn editButtonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn markaPojazduDataGridViewTextBoxColumn;
    }
}