namespace BazyDanych
{
    partial class AddOrEditServiceWindow
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
            this.label4 = new System.Windows.Forms.Label();
            this.serviceCostNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.serviceDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.commentRichTextBox = new System.Windows.Forms.RichTextBox();
            this.servicePlaceComboBox = new System.Windows.Forms.ComboBox();
            this.addButton = new System.Windows.Forms.Button();
            this.acceptButton = new System.Windows.Forms.Button();
            this.orderComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.serviceActionsDataGridView = new System.Windows.Forms.DataGridView();
            this.addServiceActionButton = new System.Windows.Forms.Button();
            this.deleteServiceActionButton = new System.Windows.Forms.Button();
            this.serviceActionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catalogIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.serviceCostNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceActionsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceActionsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Koszt";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Data Serwisu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Komentarz";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Miejsce serwisu";
            // 
            // serviceCostNumericUpDown
            // 
            this.serviceCostNumericUpDown.Location = new System.Drawing.Point(103, 136);
            this.serviceCostNumericUpDown.Name = "serviceCostNumericUpDown";
            this.serviceCostNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.serviceCostNumericUpDown.TabIndex = 4;
            // 
            // serviceDateDateTimePicker
            // 
            this.serviceDateDateTimePicker.Location = new System.Drawing.Point(103, 102);
            this.serviceDateDateTimePicker.Name = "serviceDateDateTimePicker";
            this.serviceDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.serviceDateDateTimePicker.TabIndex = 5;
            // 
            // commentRichTextBox
            // 
            this.commentRichTextBox.Location = new System.Drawing.Point(103, 165);
            this.commentRichTextBox.Name = "commentRichTextBox";
            this.commentRichTextBox.Size = new System.Drawing.Size(200, 86);
            this.commentRichTextBox.TabIndex = 6;
            this.commentRichTextBox.Text = "";
            // 
            // servicePlaceComboBox
            // 
            this.servicePlaceComboBox.FormattingEnabled = true;
            this.servicePlaceComboBox.Location = new System.Drawing.Point(103, 17);
            this.servicePlaceComboBox.Name = "servicePlaceComboBox";
            this.servicePlaceComboBox.Size = new System.Drawing.Size(200, 21);
            this.servicePlaceComboBox.TabIndex = 7;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(641, 327);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 8;
            this.addButton.Text = "Dodaj";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(722, 327);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 9;
            this.acceptButton.Text = "Zatwierdź";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // orderComboBox
            // 
            this.orderComboBox.FormattingEnabled = true;
            this.orderComboBox.Location = new System.Drawing.Point(103, 58);
            this.orderComboBox.Name = "orderComboBox";
            this.orderComboBox.Size = new System.Drawing.Size(200, 21);
            this.orderComboBox.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Zlecenie";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(327, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Czynności serwisowe";
            // 
            // serviceActionsDataGridView
            // 
            this.serviceActionsDataGridView.AutoGenerateColumns = false;
            this.serviceActionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.serviceActionsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.costDataGridViewTextBoxColumn,
            this.catalogIdDataGridViewTextBoxColumn,
            this.serviceIdDataGridViewTextBoxColumn});
            this.serviceActionsDataGridView.DataSource = this.serviceActionsBindingSource;
            this.serviceActionsDataGridView.Location = new System.Drawing.Point(330, 36);
            this.serviceActionsDataGridView.Name = "serviceActionsDataGridView";
            this.serviceActionsDataGridView.Size = new System.Drawing.Size(564, 215);
            this.serviceActionsDataGridView.TabIndex = 13;
            // 
            // addServiceActionButton
            // 
            this.addServiceActionButton.Location = new System.Drawing.Point(330, 257);
            this.addServiceActionButton.Name = "addServiceActionButton";
            this.addServiceActionButton.Size = new System.Drawing.Size(75, 23);
            this.addServiceActionButton.TabIndex = 14;
            this.addServiceActionButton.Text = "Dodaj";
            this.addServiceActionButton.UseVisualStyleBackColor = true;
            this.addServiceActionButton.Click += new System.EventHandler(this.addServiceActionButton_Click);
            // 
            // deleteServiceActionButton
            // 
            this.deleteServiceActionButton.Location = new System.Drawing.Point(411, 257);
            this.deleteServiceActionButton.Name = "deleteServiceActionButton";
            this.deleteServiceActionButton.Size = new System.Drawing.Size(75, 23);
            this.deleteServiceActionButton.TabIndex = 15;
            this.deleteServiceActionButton.Text = "Usuń";
            this.deleteServiceActionButton.UseVisualStyleBackColor = true;
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
            // costDataGridViewTextBoxColumn
            // 
            this.costDataGridViewTextBoxColumn.DataPropertyName = "Cost";
            this.costDataGridViewTextBoxColumn.HeaderText = "Cost";
            this.costDataGridViewTextBoxColumn.Name = "costDataGridViewTextBoxColumn";
            // 
            // catalogIdDataGridViewTextBoxColumn
            // 
            this.catalogIdDataGridViewTextBoxColumn.DataPropertyName = "CatalogId";
            this.catalogIdDataGridViewTextBoxColumn.HeaderText = "CatalogId";
            this.catalogIdDataGridViewTextBoxColumn.Name = "catalogIdDataGridViewTextBoxColumn";
            // 
            // serviceIdDataGridViewTextBoxColumn
            // 
            this.serviceIdDataGridViewTextBoxColumn.DataPropertyName = "ServiceId";
            this.serviceIdDataGridViewTextBoxColumn.HeaderText = "ServiceId";
            this.serviceIdDataGridViewTextBoxColumn.Name = "serviceIdDataGridViewTextBoxColumn";
            // 
            // AddOrEditServiceWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 362);
            this.Controls.Add(this.deleteServiceActionButton);
            this.Controls.Add(this.addServiceActionButton);
            this.Controls.Add(this.serviceActionsDataGridView);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.orderComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.servicePlaceComboBox);
            this.Controls.Add(this.commentRichTextBox);
            this.Controls.Add(this.serviceDateDateTimePicker);
            this.Controls.Add(this.serviceCostNumericUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddOrEditServiceWindow";
            this.Text = "AddOrEditServiceWindow";
            ((System.ComponentModel.ISupportInitialize)(this.serviceCostNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceActionsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceActionsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown serviceCostNumericUpDown;
        private System.Windows.Forms.DateTimePicker serviceDateDateTimePicker;
        private System.Windows.Forms.RichTextBox commentRichTextBox;
        private System.Windows.Forms.ComboBox servicePlaceComboBox;
        public System.Windows.Forms.Button addButton;
        public System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.ComboBox orderComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView serviceActionsDataGridView;
        private System.Windows.Forms.Button addServiceActionButton;
        private System.Windows.Forms.Button deleteServiceActionButton;
        private System.Windows.Forms.BindingSource serviceActionsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn catalogIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceIdDataGridViewTextBoxColumn;
    }
}