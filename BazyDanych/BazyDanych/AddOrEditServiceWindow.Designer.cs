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
            ((System.ComponentModel.ISupportInitialize)(this.serviceCostNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Koszt";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Data Serwisu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 113);
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
            this.serviceCostNumericUpDown.Location = new System.Drawing.Point(103, 81);
            this.serviceCostNumericUpDown.Name = "serviceCostNumericUpDown";
            this.serviceCostNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.serviceCostNumericUpDown.TabIndex = 4;
            // 
            // serviceDateDateTimePicker
            // 
            this.serviceDateDateTimePicker.Location = new System.Drawing.Point(103, 47);
            this.serviceDateDateTimePicker.Name = "serviceDateDateTimePicker";
            this.serviceDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.serviceDateDateTimePicker.TabIndex = 5;
            // 
            // commentRichTextBox
            // 
            this.commentRichTextBox.Location = new System.Drawing.Point(103, 110);
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
            this.addButton.Location = new System.Drawing.Point(122, 213);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 8;
            this.addButton.Text = "Dodaj";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(122, 242);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 9;
            this.acceptButton.Text = "Zatwierdź";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // AddOrEditServiceWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 291);
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
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button acceptButton;
    }
}