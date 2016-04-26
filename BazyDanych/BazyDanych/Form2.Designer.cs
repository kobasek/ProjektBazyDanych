namespace BazyDanych
{
    partial class Form2
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
            this.tabMControl = new System.Windows.Forms.TabControl();
            this.tabMPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.deleteButton = new System.Windows.Forms.Button();
            this.tabMPage2 = new System.Windows.Forms.TabPage();
            this.profilMLabel = new System.Windows.Forms.LinkLabel();
            this.powiadomieniaMLabel = new System.Windows.Forms.LinkLabel();
            this.wylogujMLabel = new System.Windows.Forms.LinkLabel();
            this.panelM = new System.Windows.Forms.Panel();
            this.panelO = new System.Windows.Forms.Panel();
            this.wylogujOLabel = new System.Windows.Forms.LinkLabel();
            this.powiadomieniaOLabel = new System.Windows.Forms.LinkLabel();
            this.profilOLabel = new System.Windows.Forms.LinkLabel();
            this.tabOControl = new System.Windows.Forms.TabControl();
            this.tabOPage1 = new System.Windows.Forms.TabPage();
            this.tabOPage2 = new System.Windows.Forms.TabPage();
            this.panelK = new System.Windows.Forms.Panel();
            this.tabKControl = new System.Windows.Forms.TabControl();
            this.tabKPage1 = new System.Windows.Forms.TabPage();
            this.tabKPage2 = new System.Windows.Forms.TabPage();
            this.profilKLabel = new System.Windows.Forms.LinkLabel();
            this.powiadomieniaKLabel = new System.Windows.Forms.LinkLabel();
            this.wylogujKLabel = new System.Windows.Forms.LinkLabel();
            this.panelS = new System.Windows.Forms.Panel();
            this.zalogujSLabel = new System.Windows.Forms.LinkLabel();
            this.nrPojazduDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.markaPojazduDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelPojazduDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.opiekunPojazduDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.klasaTestowaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabMControl.SuspendLayout();
            this.tabMPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelM.SuspendLayout();
            this.panelO.SuspendLayout();
            this.tabOControl.SuspendLayout();
            this.panelK.SuspendLayout();
            this.tabKControl.SuspendLayout();
            this.panelS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.klasaTestowaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMControl
            // 
            this.tabMControl.Controls.Add(this.tabMPage1);
            this.tabMControl.Controls.Add(this.tabMPage2);
            this.tabMControl.Location = new System.Drawing.Point(12, 12);
            this.tabMControl.Name = "tabMControl";
            this.tabMControl.SelectedIndex = 0;
            this.tabMControl.Size = new System.Drawing.Size(860, 400);
            this.tabMControl.TabIndex = 0;
            // 
            // tabMPage1
            // 
            this.tabMPage1.Controls.Add(this.button1);
            this.tabMPage1.Controls.Add(this.dataGridView1);
            this.tabMPage1.Controls.Add(this.deleteButton);
            this.tabMPage1.Location = new System.Drawing.Point(4, 22);
            this.tabMPage1.Name = "tabMPage1";
            this.tabMPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabMPage1.Size = new System.Drawing.Size(852, 374);
            this.tabMPage1.TabIndex = 0;
            this.tabMPage1.Text = "Opieka nad pojazdami";
            this.tabMPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(771, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Dodaj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.nrPojazduDataGridViewTextBoxColumn,
            this.markaPojazduDataGridViewTextBoxColumn,
            this.modelPojazduDataGridViewTextBoxColumn,
            this.opiekunPojazduDataGridViewTextBoxColumn,
            this.Column5,
            this.Edit});
            this.dataGridView1.DataSource = this.klasaTestowaBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(6, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(744, 341);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Zaznacz pojazd";
            this.Column6.Name = "Column6";
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "ShowCalendar";
            this.Column5.HeaderText = "Terminarz";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column5.Text = "Wyświetl terminarz";
            // 
            // Edit
            // 
            this.Edit.DataPropertyName = "EditButton";
            this.Edit.HeaderText = "Edycja pojazdu";
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Edit.Text = "Edytuj";
            // 
            // deleteButton
            // 
            this.deleteButton.Enabled = false;
            this.deleteButton.Location = new System.Drawing.Point(771, 38);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Usuń";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // tabMPage2
            // 
            this.tabMPage2.Location = new System.Drawing.Point(4, 22);
            this.tabMPage2.Name = "tabMPage2";
            this.tabMPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabMPage2.Size = new System.Drawing.Size(852, 374);
            this.tabMPage2.TabIndex = 1;
            this.tabMPage2.Text = "Zarządzanie pojazdami";
            this.tabMPage2.UseVisualStyleBackColor = true;
            // 
            // profilMLabel
            // 
            this.profilMLabel.AutoSize = true;
            this.profilMLabel.Location = new System.Drawing.Point(707, 9);
            this.profilMLabel.Name = "profilMLabel";
            this.profilMLabel.Size = new System.Drawing.Size(30, 13);
            this.profilMLabel.TabIndex = 1;
            this.profilMLabel.TabStop = true;
            this.profilMLabel.Text = "Profil";
            this.profilMLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.profilMLabel_LinkClicked);
            // 
            // powiadomieniaMLabel
            // 
            this.powiadomieniaMLabel.AutoSize = true;
            this.powiadomieniaMLabel.Location = new System.Drawing.Point(743, 9);
            this.powiadomieniaMLabel.Name = "powiadomieniaMLabel";
            this.powiadomieniaMLabel.Size = new System.Drawing.Size(78, 13);
            this.powiadomieniaMLabel.TabIndex = 2;
            this.powiadomieniaMLabel.TabStop = true;
            this.powiadomieniaMLabel.Text = "Powiadomienia";
            this.powiadomieniaMLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.powiadomieniaMLabel_LinkClicked);
            // 
            // wylogujMLabel
            // 
            this.wylogujMLabel.AutoSize = true;
            this.wylogujMLabel.Location = new System.Drawing.Point(827, 9);
            this.wylogujMLabel.Name = "wylogujMLabel";
            this.wylogujMLabel.Size = new System.Drawing.Size(45, 13);
            this.wylogujMLabel.TabIndex = 3;
            this.wylogujMLabel.TabStop = true;
            this.wylogujMLabel.Text = "Wyloguj";
            this.wylogujMLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.wylogujMLabel_LinkClicked);
            // 
            // panelM
            // 
            this.panelM.Controls.Add(this.wylogujMLabel);
            this.panelM.Controls.Add(this.profilMLabel);
            this.panelM.Controls.Add(this.powiadomieniaMLabel);
            this.panelM.Controls.Add(this.tabMControl);
            this.panelM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelM.Location = new System.Drawing.Point(0, 0);
            this.panelM.Name = "panelM";
            this.panelM.Size = new System.Drawing.Size(884, 461);
            this.panelM.TabIndex = 4;
            // 
            // panelO
            // 
            this.panelO.Controls.Add(this.wylogujOLabel);
            this.panelO.Controls.Add(this.powiadomieniaOLabel);
            this.panelO.Controls.Add(this.profilOLabel);
            this.panelO.Controls.Add(this.tabOControl);
            this.panelO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelO.Location = new System.Drawing.Point(0, 0);
            this.panelO.Name = "panelO";
            this.panelO.Size = new System.Drawing.Size(884, 461);
            this.panelO.TabIndex = 4;
            // 
            // wylogujOLabel
            // 
            this.wylogujOLabel.AutoSize = true;
            this.wylogujOLabel.Location = new System.Drawing.Point(827, 9);
            this.wylogujOLabel.Name = "wylogujOLabel";
            this.wylogujOLabel.Size = new System.Drawing.Size(45, 13);
            this.wylogujOLabel.TabIndex = 3;
            this.wylogujOLabel.TabStop = true;
            this.wylogujOLabel.Text = "Wyloguj";
            this.wylogujOLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.wylogujOLabel_LinkClicked);
            // 
            // powiadomieniaOLabel
            // 
            this.powiadomieniaOLabel.AutoSize = true;
            this.powiadomieniaOLabel.Location = new System.Drawing.Point(743, 9);
            this.powiadomieniaOLabel.Name = "powiadomieniaOLabel";
            this.powiadomieniaOLabel.Size = new System.Drawing.Size(78, 13);
            this.powiadomieniaOLabel.TabIndex = 2;
            this.powiadomieniaOLabel.TabStop = true;
            this.powiadomieniaOLabel.Text = "Powiadomienia";
            this.powiadomieniaOLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.powiadomieniaOLabel_LinkClicked);
            // 
            // profilOLabel
            // 
            this.profilOLabel.AutoSize = true;
            this.profilOLabel.Location = new System.Drawing.Point(707, 9);
            this.profilOLabel.Name = "profilOLabel";
            this.profilOLabel.Size = new System.Drawing.Size(30, 13);
            this.profilOLabel.TabIndex = 1;
            this.profilOLabel.TabStop = true;
            this.profilOLabel.Text = "Profil";
            this.profilOLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.profilOLabel_LinkClicked);
            // 
            // tabOControl
            // 
            this.tabOControl.Controls.Add(this.tabOPage1);
            this.tabOControl.Controls.Add(this.tabOPage2);
            this.tabOControl.Location = new System.Drawing.Point(12, 43);
            this.tabOControl.Name = "tabOControl";
            this.tabOControl.SelectedIndex = 0;
            this.tabOControl.Size = new System.Drawing.Size(860, 400);
            this.tabOControl.TabIndex = 0;
            // 
            // tabOPage1
            // 
            this.tabOPage1.Location = new System.Drawing.Point(4, 22);
            this.tabOPage1.Name = "tabOPage1";
            this.tabOPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabOPage1.Size = new System.Drawing.Size(852, 374);
            this.tabOPage1.TabIndex = 0;
            this.tabOPage1.Text = "Zlecenia";
            this.tabOPage1.UseVisualStyleBackColor = true;
            // 
            // tabOPage2
            // 
            this.tabOPage2.Location = new System.Drawing.Point(4, 22);
            this.tabOPage2.Name = "tabOPage2";
            this.tabOPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabOPage2.Size = new System.Drawing.Size(852, 374);
            this.tabOPage2.TabIndex = 1;
            this.tabOPage2.Text = "Opieka";
            this.tabOPage2.UseVisualStyleBackColor = true;
            // 
            // panelK
            // 
            this.panelK.Controls.Add(this.tabKControl);
            this.panelK.Controls.Add(this.profilKLabel);
            this.panelK.Controls.Add(this.powiadomieniaKLabel);
            this.panelK.Controls.Add(this.wylogujKLabel);
            this.panelK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelK.Location = new System.Drawing.Point(0, 0);
            this.panelK.Name = "panelK";
            this.panelK.Size = new System.Drawing.Size(884, 461);
            this.panelK.TabIndex = 4;
            // 
            // tabKControl
            // 
            this.tabKControl.Controls.Add(this.tabKPage1);
            this.tabKControl.Controls.Add(this.tabKPage2);
            this.tabKControl.Location = new System.Drawing.Point(12, 43);
            this.tabKControl.Name = "tabKControl";
            this.tabKControl.SelectedIndex = 0;
            this.tabKControl.Size = new System.Drawing.Size(860, 400);
            this.tabKControl.TabIndex = 3;
            // 
            // tabKPage1
            // 
            this.tabKPage1.Location = new System.Drawing.Point(4, 22);
            this.tabKPage1.Name = "tabKPage1";
            this.tabKPage1.Size = new System.Drawing.Size(852, 374);
            this.tabKPage1.TabIndex = 0;
            this.tabKPage1.Text = "Zlecenia";
            // 
            // tabKPage2
            // 
            this.tabKPage2.Location = new System.Drawing.Point(4, 22);
            this.tabKPage2.Name = "tabKPage2";
            this.tabKPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabKPage2.Size = new System.Drawing.Size(852, 374);
            this.tabKPage2.TabIndex = 1;
            this.tabKPage2.Text = "Rezerwuj";
            this.tabKPage2.UseVisualStyleBackColor = true;
            // 
            // profilKLabel
            // 
            this.profilKLabel.AutoSize = true;
            this.profilKLabel.Location = new System.Drawing.Point(707, 9);
            this.profilKLabel.Name = "profilKLabel";
            this.profilKLabel.Size = new System.Drawing.Size(30, 13);
            this.profilKLabel.TabIndex = 2;
            this.profilKLabel.TabStop = true;
            this.profilKLabel.Text = "Profil";
            this.profilKLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.profilKLabel_LinkClicked);
            // 
            // powiadomieniaKLabel
            // 
            this.powiadomieniaKLabel.AutoSize = true;
            this.powiadomieniaKLabel.Location = new System.Drawing.Point(743, 9);
            this.powiadomieniaKLabel.Name = "powiadomieniaKLabel";
            this.powiadomieniaKLabel.Size = new System.Drawing.Size(78, 13);
            this.powiadomieniaKLabel.TabIndex = 1;
            this.powiadomieniaKLabel.TabStop = true;
            this.powiadomieniaKLabel.Text = "Powiadomienia";
            this.powiadomieniaKLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.powiadomieniaKLabel_LinkClicked);
            // 
            // wylogujKLabel
            // 
            this.wylogujKLabel.AutoSize = true;
            this.wylogujKLabel.Location = new System.Drawing.Point(827, 9);
            this.wylogujKLabel.Name = "wylogujKLabel";
            this.wylogujKLabel.Size = new System.Drawing.Size(45, 13);
            this.wylogujKLabel.TabIndex = 0;
            this.wylogujKLabel.TabStop = true;
            this.wylogujKLabel.Text = "Wyloguj";
            this.wylogujKLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.wylogujKLabel_LinkClicked);
            // 
            // panelS
            // 
            this.panelS.Controls.Add(this.zalogujSLabel);
            this.panelS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelS.Location = new System.Drawing.Point(0, 0);
            this.panelS.Name = "panelS";
            this.panelS.Size = new System.Drawing.Size(884, 461);
            this.panelS.TabIndex = 4;
            // 
            // zalogujSLabel
            // 
            this.zalogujSLabel.AutoSize = true;
            this.zalogujSLabel.Location = new System.Drawing.Point(830, 9);
            this.zalogujSLabel.Name = "zalogujSLabel";
            this.zalogujSLabel.Size = new System.Drawing.Size(42, 13);
            this.zalogujSLabel.TabIndex = 0;
            this.zalogujSLabel.TabStop = true;
            this.zalogujSLabel.Text = "Zaloguj";
            this.zalogujSLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.zalogujSLabel_LinkClicked);
            // 
            // nrPojazduDataGridViewTextBoxColumn
            // 
            this.nrPojazduDataGridViewTextBoxColumn.DataPropertyName = "NrPojazdu";
            this.nrPojazduDataGridViewTextBoxColumn.HeaderText = "Numer pojazdu";
            this.nrPojazduDataGridViewTextBoxColumn.Name = "nrPojazduDataGridViewTextBoxColumn";
            this.nrPojazduDataGridViewTextBoxColumn.ReadOnly = true;
            this.nrPojazduDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // markaPojazduDataGridViewTextBoxColumn
            // 
            this.markaPojazduDataGridViewTextBoxColumn.DataPropertyName = "MarkaPojazdu";
            this.markaPojazduDataGridViewTextBoxColumn.HeaderText = "Marka pojazdu";
            this.markaPojazduDataGridViewTextBoxColumn.Name = "markaPojazduDataGridViewTextBoxColumn";
            this.markaPojazduDataGridViewTextBoxColumn.ReadOnly = true;
            this.markaPojazduDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // modelPojazduDataGridViewTextBoxColumn
            // 
            this.modelPojazduDataGridViewTextBoxColumn.DataPropertyName = "ModelPojazdu";
            this.modelPojazduDataGridViewTextBoxColumn.HeaderText = "Model pojazdu";
            this.modelPojazduDataGridViewTextBoxColumn.Name = "modelPojazduDataGridViewTextBoxColumn";
            this.modelPojazduDataGridViewTextBoxColumn.ReadOnly = true;
            this.modelPojazduDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // opiekunPojazduDataGridViewTextBoxColumn
            // 
            this.opiekunPojazduDataGridViewTextBoxColumn.DataPropertyName = "OpiekunPojazdu";
            this.opiekunPojazduDataGridViewTextBoxColumn.HeaderText = "Opiekun pojazdu";
            this.opiekunPojazduDataGridViewTextBoxColumn.Name = "opiekunPojazduDataGridViewTextBoxColumn";
            this.opiekunPojazduDataGridViewTextBoxColumn.ReadOnly = true;
            this.opiekunPojazduDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // klasaTestowaBindingSource
            // 
            this.klasaTestowaBindingSource.DataSource = typeof(BazyDanych.KlasaTestowa);
            this.klasaTestowaBindingSource.CurrentChanged += new System.EventHandler(this.klasaTestowaBindingSource_CurrentChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.panelO);
            this.Controls.Add(this.panelM);
            this.Controls.Add(this.panelS);
            this.Controls.Add(this.panelK);
            this.Name = "Form2";
            this.Text = "Menedżer Floty";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.tabMControl.ResumeLayout(false);
            this.tabMPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelM.ResumeLayout(false);
            this.panelM.PerformLayout();
            this.panelO.ResumeLayout(false);
            this.panelO.PerformLayout();
            this.tabOControl.ResumeLayout(false);
            this.panelK.ResumeLayout(false);
            this.panelK.PerformLayout();
            this.tabKControl.ResumeLayout(false);
            this.panelS.ResumeLayout(false);
            this.panelS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.klasaTestowaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        

        #endregion

        private System.Windows.Forms.TabControl tabMControl;
        private System.Windows.Forms.TabPage tabMPage1;
        private System.Windows.Forms.TabPage tabMPage2;
        public System.Windows.Forms.LinkLabel profilMLabel;
        public System.Windows.Forms.LinkLabel powiadomieniaMLabel;
        public System.Windows.Forms.LinkLabel wylogujMLabel;
        private System.Windows.Forms.Panel panelM;
        private System.Windows.Forms.Panel panelO;
        private System.Windows.Forms.TabControl tabOControl;
        private System.Windows.Forms.TabPage tabOPage1;
        private System.Windows.Forms.TabPage tabOPage2;
        private System.Windows.Forms.LinkLabel wylogujOLabel;
        private System.Windows.Forms.LinkLabel powiadomieniaOLabel;
        private System.Windows.Forms.LinkLabel profilOLabel;
        private System.Windows.Forms.Panel panelK;
        private System.Windows.Forms.TabControl tabKControl;
        private System.Windows.Forms.TabPage tabKPage1;
        private System.Windows.Forms.TabPage tabKPage2;
        private System.Windows.Forms.LinkLabel profilKLabel;
        private System.Windows.Forms.LinkLabel powiadomieniaKLabel;
        private System.Windows.Forms.LinkLabel wylogujKLabel;
        private System.Windows.Forms.Panel panelS;
        private System.Windows.Forms.LinkLabel zalogujSLabel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource klasaTestowaBindingSource;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrPojazduDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn markaPojazduDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelPojazduDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn opiekunPojazduDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn Column5;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
        private System.Windows.Forms.Button button1;
    }
}