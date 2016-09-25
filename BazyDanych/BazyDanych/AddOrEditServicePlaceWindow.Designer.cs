namespace BazyDanych
{
    partial class AddOrEditServicePlaceWindow
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
            this.companyNameTextBox = new System.Windows.Forms.TextBox();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.approveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // companyNameTextBox
            // 
            this.companyNameTextBox.Location = new System.Drawing.Point(82, 22);
            this.companyNameTextBox.Name = "companyNameTextBox";
            this.companyNameTextBox.Size = new System.Drawing.Size(314, 20);
            this.companyNameTextBox.TabIndex = 0;
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(82, 71);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(314, 20);
            this.addressTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nazwa firmy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Adres";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(163, 117);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "Dodaj";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // approveButton
            // 
            this.approveButton.Location = new System.Drawing.Point(163, 146);
            this.approveButton.Name = "approveButton";
            this.approveButton.Size = new System.Drawing.Size(75, 23);
            this.approveButton.TabIndex = 5;
            this.approveButton.Text = "Zatwierdź";
            this.approveButton.UseVisualStyleBackColor = true;
            this.approveButton.Click += new System.EventHandler(this.approveButton_Click);
            // 
            // AddOrEditServicePlaceWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 179);
            this.Controls.Add(this.approveButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.companyNameTextBox);
            this.Name = "AddOrEditServicePlaceWindow";
            this.Text = "Menedżer Floty - Dodaj miejsce serwisowe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox companyNameTextBox;
        public System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button addButton;
        public System.Windows.Forms.Button approveButton;
    }
}