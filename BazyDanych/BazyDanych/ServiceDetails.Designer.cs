namespace BazyDanych
{
    partial class ServiceDetails
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
            this.label5 = new System.Windows.Forms.Label();
            this.placeTextBox = new System.Windows.Forms.TextBox();
            this.costTextBox = new System.Windows.Forms.TextBox();
            this.commentRichTextBox = new System.Windows.Forms.RichTextBox();
            this.serviceActionsDataGridView = new System.Windows.Forms.DataGridView();
            this.CatalogName = new System.Windows.Forms.DataGridViewLinkColumn();
            this.DateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceActionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.serviceActionsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceActionsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Miejsce serwisu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Data";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Koszt";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Komentarz";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Czynności serwisowe";
            // 
            // placeTextBox
            // 
            this.placeTextBox.Location = new System.Drawing.Point(135, 21);
            this.placeTextBox.Name = "placeTextBox";
            this.placeTextBox.ReadOnly = true;
            this.placeTextBox.Size = new System.Drawing.Size(312, 20);
            this.placeTextBox.TabIndex = 5;
            // 
            // costTextBox
            // 
            this.costTextBox.Location = new System.Drawing.Point(135, 101);
            this.costTextBox.Name = "costTextBox";
            this.costTextBox.ReadOnly = true;
            this.costTextBox.Size = new System.Drawing.Size(200, 20);
            this.costTextBox.TabIndex = 7;
            // 
            // commentRichTextBox
            // 
            this.commentRichTextBox.Location = new System.Drawing.Point(135, 139);
            this.commentRichTextBox.Name = "commentRichTextBox";
            this.commentRichTextBox.ReadOnly = true;
            this.commentRichTextBox.Size = new System.Drawing.Size(312, 96);
            this.commentRichTextBox.TabIndex = 8;
            this.commentRichTextBox.Text = "";
            // 
            // serviceActionsDataGridView
            // 
            this.serviceActionsDataGridView.AutoGenerateColumns = false;
            this.serviceActionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.serviceActionsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.costDataGridViewTextBoxColumn,
            this.CatalogName});
            this.serviceActionsDataGridView.DataSource = this.serviceActionsBindingSource;
            this.serviceActionsDataGridView.Location = new System.Drawing.Point(24, 268);
            this.serviceActionsDataGridView.Name = "serviceActionsDataGridView";
            this.serviceActionsDataGridView.Size = new System.Drawing.Size(670, 170);
            this.serviceActionsDataGridView.TabIndex = 9;
            this.serviceActionsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.serviceActionsDataGridView_CellContentClick);
            // 
            // CatalogName
            // 
            this.CatalogName.DataPropertyName = "CatalogName";
            this.CatalogName.HeaderText = "Katalog";
            this.CatalogName.Name = "CatalogName";
            // 
            // DateDateTimePicker
            // 
            this.DateDateTimePicker.Enabled = false;
            this.DateDateTimePicker.Location = new System.Drawing.Point(135, 65);
            this.DateDateTimePicker.Name = "DateDateTimePicker";
            this.DateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.DateDateTimePicker.TabIndex = 10;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Numer";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Nazwa";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // costDataGridViewTextBoxColumn
            // 
            this.costDataGridViewTextBoxColumn.DataPropertyName = "Cost";
            this.costDataGridViewTextBoxColumn.HeaderText = "Koszt";
            this.costDataGridViewTextBoxColumn.Name = "costDataGridViewTextBoxColumn";
            // 
            // serviceActionsBindingSource
            // 
            this.serviceActionsBindingSource.DataSource = typeof(BazyDanych.ServiceActionTableElement);
            // 
            // ServiceDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 471);
            this.Controls.Add(this.DateDateTimePicker);
            this.Controls.Add(this.serviceActionsDataGridView);
            this.Controls.Add(this.commentRichTextBox);
            this.Controls.Add(this.costTextBox);
            this.Controls.Add(this.placeTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ServiceDetails";
            this.Text = "ServiceDetails";
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
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox placeTextBox;
        public System.Windows.Forms.TextBox costTextBox;
        public System.Windows.Forms.RichTextBox commentRichTextBox;
        public System.Windows.Forms.DataGridView serviceActionsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn CatalogName;
        public System.Windows.Forms.BindingSource serviceActionsBindingSource;
        public System.Windows.Forms.DateTimePicker DateDateTimePicker;
    }
}