namespace BazyDanych
{
    partial class CatalogDetailsWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.serviceTemplatesDataGridView = new System.Windows.Forms.DataGridView();
            this.serviceActionsDataGridView = new System.Windows.Forms.DataGridView();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catalogIdDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceActionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kilometresDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.periodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catalogIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.templateIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceTemplatesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.serviceTemplatesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceActionsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceActionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceTemplatesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nazwa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Szablonowe serwisy";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Czynności serwisowe";
            // 
            // serviceTemplatesDataGridView
            // 
            this.serviceTemplatesDataGridView.AutoGenerateColumns = false;
            this.serviceTemplatesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.serviceTemplatesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.kilometresDataGridViewTextBoxColumn,
            this.periodDataGridViewTextBoxColumn,
            this.catalogIdDataGridViewTextBoxColumn,
            this.templateIdDataGridViewTextBoxColumn});
            this.serviceTemplatesDataGridView.DataSource = this.serviceTemplatesBindingSource;
            this.serviceTemplatesDataGridView.Location = new System.Drawing.Point(15, 81);
            this.serviceTemplatesDataGridView.Name = "serviceTemplatesDataGridView";
            this.serviceTemplatesDataGridView.Size = new System.Drawing.Size(771, 187);
            this.serviceTemplatesDataGridView.TabIndex = 3;
            // 
            // serviceActionsDataGridView
            // 
            this.serviceActionsDataGridView.AutoGenerateColumns = false;
            this.serviceActionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.serviceActionsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.nameDataGridViewTextBoxColumn1,
            this.costDataGridViewTextBoxColumn,
            this.catalogIdDataGridViewTextBoxColumn1,
            this.serviceIdDataGridViewTextBoxColumn});
            this.serviceActionsDataGridView.DataSource = this.serviceActionsBindingSource;
            this.serviceActionsDataGridView.Location = new System.Drawing.Point(15, 287);
            this.serviceActionsDataGridView.Name = "serviceActionsDataGridView";
            this.serviceActionsDataGridView.Size = new System.Drawing.Size(771, 187);
            this.serviceActionsDataGridView.TabIndex = 4;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(58, 21);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.ReadOnly = true;
            this.nameTextBox.Size = new System.Drawing.Size(231, 20);
            this.nameTextBox.TabIndex = 5;
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            // 
            // costDataGridViewTextBoxColumn
            // 
            this.costDataGridViewTextBoxColumn.DataPropertyName = "Cost";
            this.costDataGridViewTextBoxColumn.HeaderText = "Cost";
            this.costDataGridViewTextBoxColumn.Name = "costDataGridViewTextBoxColumn";
            // 
            // catalogIdDataGridViewTextBoxColumn1
            // 
            this.catalogIdDataGridViewTextBoxColumn1.DataPropertyName = "CatalogId";
            this.catalogIdDataGridViewTextBoxColumn1.HeaderText = "CatalogId";
            this.catalogIdDataGridViewTextBoxColumn1.Name = "catalogIdDataGridViewTextBoxColumn1";
            // 
            // serviceIdDataGridViewTextBoxColumn
            // 
            this.serviceIdDataGridViewTextBoxColumn.DataPropertyName = "ServiceId";
            this.serviceIdDataGridViewTextBoxColumn.HeaderText = "ServiceId";
            this.serviceIdDataGridViewTextBoxColumn.Name = "serviceIdDataGridViewTextBoxColumn";
            // 
            // serviceActionsBindingSource
            // 
            this.serviceActionsBindingSource.DataSource = typeof(BazyDanych.ServiceActionTableElement);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // kilometresDataGridViewTextBoxColumn
            // 
            this.kilometresDataGridViewTextBoxColumn.DataPropertyName = "Kilometres";
            this.kilometresDataGridViewTextBoxColumn.HeaderText = "Kilometres";
            this.kilometresDataGridViewTextBoxColumn.Name = "kilometresDataGridViewTextBoxColumn";
            // 
            // periodDataGridViewTextBoxColumn
            // 
            this.periodDataGridViewTextBoxColumn.DataPropertyName = "Period";
            this.periodDataGridViewTextBoxColumn.HeaderText = "Period";
            this.periodDataGridViewTextBoxColumn.Name = "periodDataGridViewTextBoxColumn";
            // 
            // catalogIdDataGridViewTextBoxColumn
            // 
            this.catalogIdDataGridViewTextBoxColumn.DataPropertyName = "CatalogId";
            this.catalogIdDataGridViewTextBoxColumn.HeaderText = "CatalogId";
            this.catalogIdDataGridViewTextBoxColumn.Name = "catalogIdDataGridViewTextBoxColumn";
            // 
            // templateIdDataGridViewTextBoxColumn
            // 
            this.templateIdDataGridViewTextBoxColumn.DataPropertyName = "TemplateId";
            this.templateIdDataGridViewTextBoxColumn.HeaderText = "TemplateId";
            this.templateIdDataGridViewTextBoxColumn.Name = "templateIdDataGridViewTextBoxColumn";
            // 
            // serviceTemplatesBindingSource
            // 
            this.serviceTemplatesBindingSource.DataSource = typeof(BazyDanych.ServiceTemplateTableElement);
            // 
            // CatalogDetailsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 501);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.serviceActionsDataGridView);
            this.Controls.Add(this.serviceTemplatesDataGridView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CatalogDetailsWindow";
            this.Text = "CatalogDetailsWindow";
            ((System.ComponentModel.ISupportInitialize)(this.serviceTemplatesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceActionsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceActionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceTemplatesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView serviceTemplatesDataGridView;
        private System.Windows.Forms.DataGridView serviceActionsDataGridView;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kilometresDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn periodDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn catalogIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn templateIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource serviceTemplatesBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn costDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn catalogIdDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource serviceActionsBindingSource;
    }
}