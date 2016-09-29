namespace BazyDanych
{
    partial class OrderDetailsWindow
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
            this.servicesDataGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.servicePlaceNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Details = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.servicesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.driverComboBox = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.careComboBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cancellationReasonRichTextBox = new System.Windows.Forms.RichTextBox();
            this.endCommentsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.startCommentsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.orderStateComboBox = new System.Windows.Forms.ComboBox();
            this.counterEndDateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.counterStartStateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.orderTypeComboBox = new System.Windows.Forms.ComboBox();
            this.costNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.actualEndDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.actualStartDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.startDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.servicesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.counterEndDateNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.counterStartStateNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costNumericUpDown)).BeginInit();
            this.SuspendLayout();
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
            this.servicePlaceNameDataGridViewTextBoxColumn,
            this.Details,
            this.EditColumn,
            this.Edit});
            this.servicesDataGridView.DataSource = this.servicesBindingSource;
            this.servicesDataGridView.Location = new System.Drawing.Point(464, 149);
            this.servicesDataGridView.Name = "servicesDataGridView";
            this.servicesDataGridView.Size = new System.Drawing.Size(733, 396);
            this.servicesDataGridView.TabIndex = 67;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Numer";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // costDataGridViewTextBoxColumn
            // 
            this.costDataGridViewTextBoxColumn.DataPropertyName = "Cost";
            this.costDataGridViewTextBoxColumn.HeaderText = "Koszt";
            this.costDataGridViewTextBoxColumn.Name = "costDataGridViewTextBoxColumn";
            // 
            // serviceDateDataGridViewTextBoxColumn
            // 
            this.serviceDateDataGridViewTextBoxColumn.DataPropertyName = "ServiceDate";
            this.serviceDateDataGridViewTextBoxColumn.HeaderText = "Data";
            this.serviceDateDataGridViewTextBoxColumn.Name = "serviceDateDataGridViewTextBoxColumn";
            // 
            // commentDataGridViewTextBoxColumn
            // 
            this.commentDataGridViewTextBoxColumn.DataPropertyName = "Comment";
            this.commentDataGridViewTextBoxColumn.HeaderText = "Komentarz";
            this.commentDataGridViewTextBoxColumn.Name = "commentDataGridViewTextBoxColumn";
            // 
            // servicePlaceNameDataGridViewTextBoxColumn
            // 
            this.servicePlaceNameDataGridViewTextBoxColumn.DataPropertyName = "ServicePlaceName";
            this.servicePlaceNameDataGridViewTextBoxColumn.HeaderText = "Miejsce serwisu";
            this.servicePlaceNameDataGridViewTextBoxColumn.Name = "servicePlaceNameDataGridViewTextBoxColumn";
            // 
            // Details
            // 
            this.Details.HeaderText = "Szczegóły";
            this.Details.Name = "Details";
            // 
            // EditColumn
            // 
            this.EditColumn.HeaderText = "Szczegóły";
            this.EditColumn.Name = "EditColumn";
            // 
            // Edit
            // 
            this.Edit.HeaderText = "Edytuj";
            this.Edit.Name = "Edit";
            // 
            // servicesBindingSource
            // 
            this.servicesBindingSource.DataSource = typeof(BazyDanych.ServiceTableElement);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(470, 133);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 13);
            this.label15.TabIndex = 66;
            this.label15.Text = "Serwisy";
            // 
            // driverComboBox
            // 
            this.driverComboBox.FormattingEnabled = true;
            this.driverComboBox.Location = new System.Drawing.Point(327, 21);
            this.driverComboBox.Name = "driverComboBox";
            this.driverComboBox.Size = new System.Drawing.Size(121, 21);
            this.driverComboBox.TabIndex = 65;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(269, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 13);
            this.label14.TabIndex = 64;
            this.label14.Text = "Kierowca";
            // 
            // careComboBox
            // 
            this.careComboBox.FormattingEnabled = true;
            this.careComboBox.Location = new System.Drawing.Point(104, 21);
            this.careComboBox.Name = "careComboBox";
            this.careComboBox.Size = new System.Drawing.Size(121, 21);
            this.careComboBox.TabIndex = 61;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(46, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 60;
            this.label13.Text = "Opieka";
            // 
            // cancellationReasonRichTextBox
            // 
            this.cancellationReasonRichTextBox.Location = new System.Drawing.Point(104, 462);
            this.cancellationReasonRichTextBox.Name = "cancellationReasonRichTextBox";
            this.cancellationReasonRichTextBox.Size = new System.Drawing.Size(333, 59);
            this.cancellationReasonRichTextBox.TabIndex = 59;
            this.cancellationReasonRichTextBox.Text = "";
            // 
            // endCommentsRichTextBox
            // 
            this.endCommentsRichTextBox.Location = new System.Drawing.Point(104, 374);
            this.endCommentsRichTextBox.Name = "endCommentsRichTextBox";
            this.endCommentsRichTextBox.Size = new System.Drawing.Size(333, 59);
            this.endCommentsRichTextBox.TabIndex = 58;
            this.endCommentsRichTextBox.Text = "";
            // 
            // startCommentsRichTextBox
            // 
            this.startCommentsRichTextBox.Location = new System.Drawing.Point(104, 309);
            this.startCommentsRichTextBox.Name = "startCommentsRichTextBox";
            this.startCommentsRichTextBox.Size = new System.Drawing.Size(333, 59);
            this.startCommentsRichTextBox.TabIndex = 57;
            this.startCommentsRichTextBox.Text = "";
            // 
            // orderStateComboBox
            // 
            this.orderStateComboBox.FormattingEnabled = true;
            this.orderStateComboBox.Location = new System.Drawing.Point(104, 264);
            this.orderStateComboBox.Name = "orderStateComboBox";
            this.orderStateComboBox.Size = new System.Drawing.Size(121, 21);
            this.orderStateComboBox.TabIndex = 56;
            // 
            // counterEndDateNumericUpDown
            // 
            this.counterEndDateNumericUpDown.Location = new System.Drawing.Point(313, 222);
            this.counterEndDateNumericUpDown.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.counterEndDateNumericUpDown.Name = "counterEndDateNumericUpDown";
            this.counterEndDateNumericUpDown.Size = new System.Drawing.Size(76, 20);
            this.counterEndDateNumericUpDown.TabIndex = 55;
            // 
            // counterStartStateNumericUpDown
            // 
            this.counterStartStateNumericUpDown.Location = new System.Drawing.Point(104, 220);
            this.counterStartStateNumericUpDown.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.counterStartStateNumericUpDown.Name = "counterStartStateNumericUpDown";
            this.counterStartStateNumericUpDown.Size = new System.Drawing.Size(76, 20);
            this.counterStartStateNumericUpDown.TabIndex = 54;
            // 
            // orderTypeComboBox
            // 
            this.orderTypeComboBox.FormattingEnabled = true;
            this.orderTypeComboBox.Location = new System.Drawing.Point(104, 177);
            this.orderTypeComboBox.Name = "orderTypeComboBox";
            this.orderTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.orderTypeComboBox.TabIndex = 53;
            // 
            // costNumericUpDown
            // 
            this.costNumericUpDown.Location = new System.Drawing.Point(104, 134);
            this.costNumericUpDown.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.costNumericUpDown.Name = "costNumericUpDown";
            this.costNumericUpDown.Size = new System.Drawing.Size(76, 20);
            this.costNumericUpDown.TabIndex = 52;
            // 
            // actualEndDateDateTimePicker
            // 
            this.actualEndDateDateTimePicker.Location = new System.Drawing.Point(464, 96);
            this.actualEndDateDateTimePicker.Name = "actualEndDateDateTimePicker";
            this.actualEndDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.actualEndDateDateTimePicker.TabIndex = 51;
            // 
            // actualStartDateDateTimePicker
            // 
            this.actualStartDateDateTimePicker.Location = new System.Drawing.Point(464, 67);
            this.actualStartDateDateTimePicker.Name = "actualStartDateDateTimePicker";
            this.actualStartDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.actualStartDateDateTimePicker.TabIndex = 50;
            // 
            // endDateDateTimePicker
            // 
            this.endDateDateTimePicker.Location = new System.Drawing.Point(104, 91);
            this.endDateDateTimePicker.Name = "endDateDateTimePicker";
            this.endDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.endDateDateTimePicker.TabIndex = 49;
            // 
            // startDateDateTimePicker
            // 
            this.startDateDateTimePicker.Location = new System.Drawing.Point(104, 65);
            this.startDateDateTimePicker.Name = "startDateDateTimePicker";
            this.startDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.startDateDateTimePicker.TabIndex = 48;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 374);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 13);
            this.label12.TabIndex = 47;
            this.label12.Text = "Uwagi końcowe";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 309);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 13);
            this.label11.TabIndex = 46;
            this.label11.Text = "Uwagi początkowe";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(33, 264);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 45;
            this.label10.Text = "Stan zlecenia";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(200, 222);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 13);
            this.label9.TabIndex = 44;
            this.label9.Text = "Stan licznika końcowy";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(-23, 222);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "Stan licznika początkowy";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 42;
            this.label7.Text = "Rodzaj zlecenia";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 462);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "Powód anulowania";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Koszt";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(313, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Data faktycznego rozpoczęcia";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(310, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Data faktycznego zakończenia";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Data rozpoczęcia";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Data zakończenia";
            // 
            // OrderDetailsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 565);
            this.Controls.Add(this.servicesDataGridView);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.driverComboBox);
            this.Controls.Add(this.label14);
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
            this.Name = "OrderDetailsWindow";
            this.Text = "OrderDetailsWindow";
            ((System.ComponentModel.ISupportInitialize)(this.servicesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.counterEndDateNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.counterStartStateNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView servicesDataGridView;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox driverComboBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox careComboBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RichTextBox cancellationReasonRichTextBox;
        private System.Windows.Forms.RichTextBox endCommentsRichTextBox;
        private System.Windows.Forms.RichTextBox startCommentsRichTextBox;
        private System.Windows.Forms.ComboBox orderStateComboBox;
        private System.Windows.Forms.NumericUpDown counterEndDateNumericUpDown;
        private System.Windows.Forms.NumericUpDown counterStartStateNumericUpDown;
        private System.Windows.Forms.ComboBox orderTypeComboBox;
        private System.Windows.Forms.NumericUpDown costNumericUpDown;
        private System.Windows.Forms.DateTimePicker actualEndDateDateTimePicker;
        private System.Windows.Forms.DateTimePicker actualStartDateDateTimePicker;
        private System.Windows.Forms.DateTimePicker endDateDateTimePicker;
        private System.Windows.Forms.DateTimePicker startDateDateTimePicker;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn servicePlaceNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Details;
        private System.Windows.Forms.DataGridViewButtonColumn EditColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
        private System.Windows.Forms.BindingSource servicesBindingSource;
    }
}