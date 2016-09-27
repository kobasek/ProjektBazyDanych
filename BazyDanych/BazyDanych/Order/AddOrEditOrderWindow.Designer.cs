namespace BazyDanych
{
    partial class AddOrEditOrderWindow
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.startDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.actualStartDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.actualEndDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.costNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.orderTypeComboBox = new System.Windows.Forms.ComboBox();
            this.counterStartStateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.counterEndDateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.orderStateComboBox = new System.Windows.Forms.ComboBox();
            this.startCommentsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.endCommentsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.cancellationReasonRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.careComboBox = new System.Windows.Forms.ComboBox();
            this.acceptButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.driverComboBox = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.servicesDataGridView = new System.Windows.Forms.DataGridView();
            this.addServiceButton = new System.Windows.Forms.Button();
            this.deleteServiceButton = new System.Windows.Forms.Button();
            this.servicesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.servicePlaceIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Details = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.costNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.counterStartStateNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.counterEndDateNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Data zakończenia";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Data rozpoczęcia";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(343, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Data faktycznego zakończenia";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(346, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Data faktycznego rozpoczęcia";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(104, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Koszt";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 463);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Powód anulowania";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(55, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Rodzaj zlecenia";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 223);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Stan licznika początkowy";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(233, 223);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Stan licznika końcowy";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(66, 265);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Stan zlecenia";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(39, 310);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Uwagi początkowe";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(53, 375);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Uwagi końcowe";
            // 
            // startDateDateTimePicker
            // 
            this.startDateDateTimePicker.Location = new System.Drawing.Point(137, 66);
            this.startDateDateTimePicker.Name = "startDateDateTimePicker";
            this.startDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.startDateDateTimePicker.TabIndex = 13;
            // 
            // endDateDateTimePicker
            // 
            this.endDateDateTimePicker.Location = new System.Drawing.Point(137, 92);
            this.endDateDateTimePicker.Name = "endDateDateTimePicker";
            this.endDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.endDateDateTimePicker.TabIndex = 14;
            // 
            // actualStartDateDateTimePicker
            // 
            this.actualStartDateDateTimePicker.Location = new System.Drawing.Point(497, 68);
            this.actualStartDateDateTimePicker.Name = "actualStartDateDateTimePicker";
            this.actualStartDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.actualStartDateDateTimePicker.TabIndex = 15;
            // 
            // actualEndDateDateTimePicker
            // 
            this.actualEndDateDateTimePicker.Location = new System.Drawing.Point(497, 97);
            this.actualEndDateDateTimePicker.Name = "actualEndDateDateTimePicker";
            this.actualEndDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.actualEndDateDateTimePicker.TabIndex = 16;
            // 
            // costNumericUpDown
            // 
            this.costNumericUpDown.Location = new System.Drawing.Point(137, 135);
            this.costNumericUpDown.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.costNumericUpDown.Name = "costNumericUpDown";
            this.costNumericUpDown.Size = new System.Drawing.Size(76, 20);
            this.costNumericUpDown.TabIndex = 17;
            // 
            // orderTypeComboBox
            // 
            this.orderTypeComboBox.FormattingEnabled = true;
            this.orderTypeComboBox.Location = new System.Drawing.Point(137, 178);
            this.orderTypeComboBox.Name = "orderTypeComboBox";
            this.orderTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.orderTypeComboBox.TabIndex = 19;
            // 
            // counterStartStateNumericUpDown
            // 
            this.counterStartStateNumericUpDown.Location = new System.Drawing.Point(137, 221);
            this.counterStartStateNumericUpDown.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.counterStartStateNumericUpDown.Name = "counterStartStateNumericUpDown";
            this.counterStartStateNumericUpDown.Size = new System.Drawing.Size(76, 20);
            this.counterStartStateNumericUpDown.TabIndex = 20;
            // 
            // counterEndDateNumericUpDown
            // 
            this.counterEndDateNumericUpDown.Location = new System.Drawing.Point(346, 223);
            this.counterEndDateNumericUpDown.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.counterEndDateNumericUpDown.Name = "counterEndDateNumericUpDown";
            this.counterEndDateNumericUpDown.Size = new System.Drawing.Size(76, 20);
            this.counterEndDateNumericUpDown.TabIndex = 21;
            // 
            // orderStateComboBox
            // 
            this.orderStateComboBox.FormattingEnabled = true;
            this.orderStateComboBox.Location = new System.Drawing.Point(137, 265);
            this.orderStateComboBox.Name = "orderStateComboBox";
            this.orderStateComboBox.Size = new System.Drawing.Size(121, 21);
            this.orderStateComboBox.TabIndex = 22;
            // 
            // startCommentsRichTextBox
            // 
            this.startCommentsRichTextBox.Location = new System.Drawing.Point(137, 310);
            this.startCommentsRichTextBox.Name = "startCommentsRichTextBox";
            this.startCommentsRichTextBox.Size = new System.Drawing.Size(333, 59);
            this.startCommentsRichTextBox.TabIndex = 23;
            this.startCommentsRichTextBox.Text = "";
            // 
            // endCommentsRichTextBox
            // 
            this.endCommentsRichTextBox.Location = new System.Drawing.Point(137, 375);
            this.endCommentsRichTextBox.Name = "endCommentsRichTextBox";
            this.endCommentsRichTextBox.Size = new System.Drawing.Size(333, 59);
            this.endCommentsRichTextBox.TabIndex = 24;
            this.endCommentsRichTextBox.Text = "";
            // 
            // cancellationReasonRichTextBox
            // 
            this.cancellationReasonRichTextBox.Location = new System.Drawing.Point(137, 463);
            this.cancellationReasonRichTextBox.Name = "cancellationReasonRichTextBox";
            this.cancellationReasonRichTextBox.Size = new System.Drawing.Size(333, 59);
            this.cancellationReasonRichTextBox.TabIndex = 25;
            this.cancellationReasonRichTextBox.Text = "";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(79, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 26;
            this.label13.Text = "Opieka";
            // 
            // careComboBox
            // 
            this.careComboBox.FormattingEnabled = true;
            this.careComboBox.Location = new System.Drawing.Point(137, 22);
            this.careComboBox.Name = "careComboBox";
            this.careComboBox.Size = new System.Drawing.Size(121, 21);
            this.careComboBox.TabIndex = 27;
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(1036, 477);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(95, 45);
            this.acceptButton.TabIndex = 28;
            this.acceptButton.Text = "Zatwierdź";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(1137, 477);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(95, 45);
            this.addButton.TabIndex = 29;
            this.addButton.Text = "Dodaj zlecenie";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // driverComboBox
            // 
            this.driverComboBox.FormattingEnabled = true;
            this.driverComboBox.Location = new System.Drawing.Point(360, 22);
            this.driverComboBox.Name = "driverComboBox";
            this.driverComboBox.Size = new System.Drawing.Size(121, 21);
            this.driverComboBox.TabIndex = 31;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(302, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 13);
            this.label14.TabIndex = 30;
            this.label14.Text = "Kierowca";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(700, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 13);
            this.label15.TabIndex = 32;
            this.label15.Text = "Serwisy";
            // 
            // servicesDataGridView
            // 
            this.servicesDataGridView.AutoGenerateColumns = false;
            this.servicesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.servicesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.costDataGridViewTextBoxColumn,
            this.serviceDateDataGridViewTextBoxColumn,
            this.commentDataGridViewTextBoxColumn,
            this.servicePlaceIdDataGridViewTextBoxColumn,
            this.orderIdDataGridViewTextBoxColumn,
            this.Details,
            this.Edit});
            this.servicesDataGridView.DataSource = this.servicesBindingSource;
            this.servicesDataGridView.Location = new System.Drawing.Point(703, 38);
            this.servicesDataGridView.Name = "servicesDataGridView";
            this.servicesDataGridView.Size = new System.Drawing.Size(529, 396);
            this.servicesDataGridView.TabIndex = 33;
            // 
            // addServiceButton
            // 
            this.addServiceButton.Location = new System.Drawing.Point(703, 440);
            this.addServiceButton.Name = "addServiceButton";
            this.addServiceButton.Size = new System.Drawing.Size(75, 23);
            this.addServiceButton.TabIndex = 34;
            this.addServiceButton.Text = "Dodaj";
            this.addServiceButton.UseVisualStyleBackColor = true;
            this.addServiceButton.Click += new System.EventHandler(this.addServiceButton_Click);
            // 
            // deleteServiceButton
            // 
            this.deleteServiceButton.Location = new System.Drawing.Point(784, 440);
            this.deleteServiceButton.Name = "deleteServiceButton";
            this.deleteServiceButton.Size = new System.Drawing.Size(75, 23);
            this.deleteServiceButton.TabIndex = 35;
            this.deleteServiceButton.Text = "Usuń";
            this.deleteServiceButton.UseVisualStyleBackColor = true;
            // 
            // servicesBindingSource
            // 
            this.servicesBindingSource.DataSource = typeof(BazyDanych.ServiceTableElement);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // costDataGridViewTextBoxColumn
            // 
            this.costDataGridViewTextBoxColumn.DataPropertyName = "Cost";
            this.costDataGridViewTextBoxColumn.HeaderText = "Cost";
            this.costDataGridViewTextBoxColumn.Name = "costDataGridViewTextBoxColumn";
            // 
            // serviceDateDataGridViewTextBoxColumn
            // 
            this.serviceDateDataGridViewTextBoxColumn.DataPropertyName = "ServiceDate";
            this.serviceDateDataGridViewTextBoxColumn.HeaderText = "ServiceDate";
            this.serviceDateDataGridViewTextBoxColumn.Name = "serviceDateDataGridViewTextBoxColumn";
            // 
            // commentDataGridViewTextBoxColumn
            // 
            this.commentDataGridViewTextBoxColumn.DataPropertyName = "Comment";
            this.commentDataGridViewTextBoxColumn.HeaderText = "Comment";
            this.commentDataGridViewTextBoxColumn.Name = "commentDataGridViewTextBoxColumn";
            // 
            // servicePlaceIdDataGridViewTextBoxColumn
            // 
            this.servicePlaceIdDataGridViewTextBoxColumn.DataPropertyName = "ServicePlaceId";
            this.servicePlaceIdDataGridViewTextBoxColumn.HeaderText = "ServicePlaceId";
            this.servicePlaceIdDataGridViewTextBoxColumn.Name = "servicePlaceIdDataGridViewTextBoxColumn";
            // 
            // orderIdDataGridViewTextBoxColumn
            // 
            this.orderIdDataGridViewTextBoxColumn.DataPropertyName = "OrderId";
            this.orderIdDataGridViewTextBoxColumn.HeaderText = "OrderId";
            this.orderIdDataGridViewTextBoxColumn.Name = "orderIdDataGridViewTextBoxColumn";
            // 
            // Details
            // 
            this.Details.HeaderText = "Szczegóły";
            this.Details.Name = "Details";
            // 
            // Edit
            // 
            this.Edit.HeaderText = "Edytuj";
            this.Edit.Name = "Edit";
            // 
            // AddOrEditOrderWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 541);
            this.Controls.Add(this.deleteServiceButton);
            this.Controls.Add(this.addServiceButton);
            this.Controls.Add(this.servicesDataGridView);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.driverComboBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.careComboBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cancellationReasonRichTextBox);
            this.Controls.Add(this.endCommentsRichTextBox);
            this.Controls.Add(this.startCommentsRichTextBox);
            this.Controls.Add(this.orderStateComboBox);
            this.Controls.Add(this.counterEndDateNumericUpDown);
            this.Controls.Add(this.counterStartStateNumericUpDown);
            this.Controls.Add(this.orderTypeComboBox);
            this.Controls.Add(this.costNumericUpDown);
            this.Controls.Add(this.actualEndDateDateTimePicker);
            this.Controls.Add(this.actualStartDateDateTimePicker);
            this.Controls.Add(this.endDateDateTimePicker);
            this.Controls.Add(this.startDateDateTimePicker);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "AddOrEditOrderWindow";
            this.Text = "Menadżer Floty - Dodaj zlecenie";
            ((System.ComponentModel.ISupportInitialize)(this.costNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.counterStartStateNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.counterEndDateNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker startDateDateTimePicker;
        private System.Windows.Forms.DateTimePicker endDateDateTimePicker;
        private System.Windows.Forms.DateTimePicker actualStartDateDateTimePicker;
        private System.Windows.Forms.DateTimePicker actualEndDateDateTimePicker;
        private System.Windows.Forms.NumericUpDown costNumericUpDown;
        private System.Windows.Forms.ComboBox orderTypeComboBox;
        private System.Windows.Forms.NumericUpDown counterStartStateNumericUpDown;
        private System.Windows.Forms.NumericUpDown counterEndDateNumericUpDown;
        private System.Windows.Forms.ComboBox orderStateComboBox;
        private System.Windows.Forms.RichTextBox startCommentsRichTextBox;
        private System.Windows.Forms.RichTextBox endCommentsRichTextBox;
        private System.Windows.Forms.RichTextBox cancellationReasonRichTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox careComboBox;
        public System.Windows.Forms.Button acceptButton;
        public System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ComboBox driverComboBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView servicesDataGridView;
        private System.Windows.Forms.Button addServiceButton;
        private System.Windows.Forms.Button deleteServiceButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn servicePlaceIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Details;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
        private System.Windows.Forms.BindingSource servicesBindingSource;
    }
}