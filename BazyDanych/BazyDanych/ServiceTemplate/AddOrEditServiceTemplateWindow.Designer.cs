namespace BazyDanych
{
    partial class AddOrEditServiceTemplateWindow
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
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.KilometresNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.periodNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.catalogComboBox = new System.Windows.Forms.ComboBox();
            this.templateComboBox = new System.Windows.Forms.ComboBox();
            this.addButton = new System.Windows.Forms.Button();
            this.acceptButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.KilometresNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kilometry";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Okres";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Katalog";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nazwa";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(65, 21);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(216, 20);
            this.nameTextBox.TabIndex = 4;
            // 
            // KilometresNumericUpDown
            // 
            this.KilometresNumericUpDown.Location = new System.Drawing.Point(65, 44);
            this.KilometresNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.KilometresNumericUpDown.Name = "KilometresNumericUpDown";
            this.KilometresNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.KilometresNumericUpDown.TabIndex = 5;
            // 
            // periodNumericUpDown
            // 
            this.periodNumericUpDown.Location = new System.Drawing.Point(65, 74);
            this.periodNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.periodNumericUpDown.Name = "periodNumericUpDown";
            this.periodNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.periodNumericUpDown.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Szablon";
            // 
            // catalogComboBox
            // 
            this.catalogComboBox.FormattingEnabled = true;
            this.catalogComboBox.Location = new System.Drawing.Point(65, 100);
            this.catalogComboBox.Name = "catalogComboBox";
            this.catalogComboBox.Size = new System.Drawing.Size(216, 21);
            this.catalogComboBox.TabIndex = 8;
            // 
            // templateComboBox
            // 
            this.templateComboBox.FormattingEnabled = true;
            this.templateComboBox.Location = new System.Drawing.Point(65, 127);
            this.templateComboBox.Name = "templateComboBox";
            this.templateComboBox.Size = new System.Drawing.Size(216, 21);
            this.templateComboBox.TabIndex = 9;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(124, 165);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 10;
            this.addButton.Text = "Dodaj";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click_1);
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(124, 194);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 11;
            this.acceptButton.Text = "Zatwierdź";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click_1);
            // 
            // AddOrEditServiceTemplateWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 237);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.templateComboBox);
            this.Controls.Add(this.catalogComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.periodNumericUpDown);
            this.Controls.Add(this.KilometresNumericUpDown);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddOrEditServiceTemplateWindow";
            this.Text = "AddOrEditServiceTemplate";
            ((System.ComponentModel.ISupportInitialize)(this.KilometresNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.NumericUpDown KilometresNumericUpDown;
        private System.Windows.Forms.NumericUpDown periodNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox catalogComboBox;
        private System.Windows.Forms.ComboBox templateComboBox;
        public System.Windows.Forms.Button addButton;
        public System.Windows.Forms.Button acceptButton;
    }
}