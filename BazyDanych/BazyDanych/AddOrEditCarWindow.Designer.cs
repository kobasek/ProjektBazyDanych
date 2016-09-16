using System.Collections;
using System.Collections.Generic;

namespace BazyDanych
{
	partial class AddOrEditCarWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		private MainWindow main;

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
			this.buttonDodajPojazd = new System.Windows.Forms.Button();
			this.buttonZapiszSzablon = new System.Windows.Forms.Button();
			this.buttonWczytajSzablon = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxVIN = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxPojemnosc = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.comboBoxMarka = new System.Windows.Forms.ComboBox();
			this.comboBoxModel = new System.Windows.Forms.ComboBox();
			this.comboBoxKlimatyzacja = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.comboBoxSzyby = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.comboBoxWspomaganie = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.comboBoxSkrzynia = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.label11 = new System.Windows.Forms.Label();
			this.textBoxKoszt = new System.Windows.Forms.TextBox();
			this.comboBoxPaliwo = new System.Windows.Forms.ComboBox();
			this.label12 = new System.Windows.Forms.Label();
			this.panelSzczegoly = new System.Windows.Forms.Panel();
			this.comboBoxTypNadwozia = new System.Windows.Forms.ComboBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.buttonZatwierdzZmiany = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label15 = new System.Windows.Forms.Label();
			this.panelSzczegoly.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonDodajPojazd
			// 
			this.buttonDodajPojazd.Location = new System.Drawing.Point(400, 272);
			this.buttonDodajPojazd.Name = "buttonDodajPojazd";
			this.buttonDodajPojazd.Size = new System.Drawing.Size(75, 39);
			this.buttonDodajPojazd.TabIndex = 0;
			this.buttonDodajPojazd.Text = "Dodaj";
			this.buttonDodajPojazd.UseVisualStyleBackColor = true;
			this.buttonDodajPojazd.Click += new System.EventHandler(this.buttonDodajPojazd_Click);
			// 
			// buttonZapiszSzablon
			// 
			this.buttonZapiszSzablon.Location = new System.Drawing.Point(400, 21);
			this.buttonZapiszSzablon.Name = "buttonZapiszSzablon";
			this.buttonZapiszSzablon.Size = new System.Drawing.Size(75, 39);
			this.buttonZapiszSzablon.TabIndex = 1;
			this.buttonZapiszSzablon.Text = "Wczytaj szablon";
			this.buttonZapiszSzablon.UseVisualStyleBackColor = true;
			// 
			// buttonWczytajSzablon
			// 
			this.buttonWczytajSzablon.Location = new System.Drawing.Point(400, 66);
			this.buttonWczytajSzablon.Name = "buttonWczytajSzablon";
			this.buttonWczytajSzablon.Size = new System.Drawing.Size(75, 39);
			this.buttonWczytajSzablon.TabIndex = 2;
			this.buttonWczytajSzablon.Text = "Zapisz szablon";
			this.buttonWczytajSzablon.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(126, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(37, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Marka";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(127, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(36, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Model";
			// 
			// textBoxVIN
			// 
			this.textBoxVIN.Location = new System.Drawing.Point(169, 72);
			this.textBoxVIN.Name = "textBoxVIN";
			this.textBoxVIN.Size = new System.Drawing.Size(100, 20);
			this.textBoxVIN.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(138, 75);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(25, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "VIN";
			// 
			// textBoxPojemnosc
			// 
			this.textBoxPojemnosc.Location = new System.Drawing.Point(165, 37);
			this.textBoxPojemnosc.Name = "textBoxPojemnosc";
			this.textBoxPojemnosc.Size = new System.Drawing.Size(100, 20);
			this.textBoxPojemnosc.TabIndex = 9;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(68, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(91, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "Pojemność silnika";
			// 
			// comboBoxMarka
			// 
			this.comboBoxMarka.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxMarka.FormattingEnabled = true;
			this.comboBoxMarka.Location = new System.Drawing.Point(169, 21);
			this.comboBoxMarka.Name = "comboBoxMarka";
			this.comboBoxMarka.Size = new System.Drawing.Size(121, 21);
			this.comboBoxMarka.TabIndex = 11;
			this.comboBoxMarka.SelectedIndexChanged += new System.EventHandler(this.comboBoxMarka_SelectedIndexChanged);
			// 
			// comboBoxModel
			// 
			this.comboBoxModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxModel.FormattingEnabled = true;
			this.comboBoxModel.Location = new System.Drawing.Point(169, 45);
			this.comboBoxModel.Name = "comboBoxModel";
			this.comboBoxModel.Size = new System.Drawing.Size(121, 21);
			this.comboBoxModel.TabIndex = 12;
			// 
			// comboBoxKlimatyzacja
			// 
			this.comboBoxKlimatyzacja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxKlimatyzacja.FormattingEnabled = true;
			this.comboBoxKlimatyzacja.Items.AddRange(new object[] {
            "TAK",
            "NIE"});
			this.comboBoxKlimatyzacja.Location = new System.Drawing.Point(165, 144);
			this.comboBoxKlimatyzacja.Name = "comboBoxKlimatyzacja";
			this.comboBoxKlimatyzacja.Size = new System.Drawing.Size(121, 21);
			this.comboBoxKlimatyzacja.TabIndex = 13;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(94, 147);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(65, 13);
			this.label5.TabIndex = 14;
			this.label5.Text = "Klimatyzacja";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(64, 99);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(99, 13);
			this.label6.TabIndex = 15;
			this.label6.Text = "Numer rejestracyjny";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(169, 96);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 16;
			// 
			// comboBoxSzyby
			// 
			this.comboBoxSzyby.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSzyby.FormattingEnabled = true;
			this.comboBoxSzyby.Items.AddRange(new object[] {
            "TAK",
            "NIE"});
			this.comboBoxSzyby.Location = new System.Drawing.Point(165, 198);
			this.comboBoxSzyby.Name = "comboBoxSzyby";
			this.comboBoxSzyby.Size = new System.Drawing.Size(121, 21);
			this.comboBoxSzyby.TabIndex = 17;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(68, 201);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(91, 13);
			this.label7.TabIndex = 18;
			this.label7.Text = "Elektryczne szyby";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(31, 174);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(128, 13);
			this.label8.TabIndex = 19;
			this.label8.Text = "Wspomaganie kierownicy";
			// 
			// comboBoxWspomaganie
			// 
			this.comboBoxWspomaganie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxWspomaganie.FormattingEnabled = true;
			this.comboBoxWspomaganie.Items.AddRange(new object[] {
            "TAK",
            "NIE"});
			this.comboBoxWspomaganie.Location = new System.Drawing.Point(165, 171);
			this.comboBoxWspomaganie.Name = "comboBoxWspomaganie";
			this.comboBoxWspomaganie.Size = new System.Drawing.Size(121, 21);
			this.comboBoxWspomaganie.TabIndex = 20;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(7, 120);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(152, 13);
			this.label9.TabIndex = 21;
			this.label9.Text = "Automatyczna skrzynia biegów";
			// 
			// comboBoxSkrzynia
			// 
			this.comboBoxSkrzynia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSkrzynia.FormattingEnabled = true;
			this.comboBoxSkrzynia.Items.AddRange(new object[] {
            "TAK",
            "NIE"});
			this.comboBoxSkrzynia.Location = new System.Drawing.Point(165, 117);
			this.comboBoxSkrzynia.Name = "comboBoxSkrzynia";
			this.comboBoxSkrzynia.Size = new System.Drawing.Size(121, 21);
			this.comboBoxSkrzynia.TabIndex = 22;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(96, 151);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(68, 13);
			this.label10.TabIndex = 23;
			this.label10.Text = "Data zakupu";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(169, 148);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
			this.dateTimePicker1.TabIndex = 24;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(92, 125);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(71, 13);
			this.label11.TabIndex = 25;
			this.label11.Text = "Koszt zakupu";
			// 
			// textBoxKoszt
			// 
			this.textBoxKoszt.Location = new System.Drawing.Point(169, 122);
			this.textBoxKoszt.Name = "textBoxKoszt";
			this.textBoxKoszt.Size = new System.Drawing.Size(100, 20);
			this.textBoxKoszt.TabIndex = 26;
			// 
			// comboBoxPaliwo
			// 
			this.comboBoxPaliwo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxPaliwo.FormattingEnabled = true;
			this.comboBoxPaliwo.Items.AddRange(new object[] {
            "ROPA",
            "BENZYNA",
            "LPG",
            "BENZYNA + LPG",
            "ENERGIA ELEKTRYCZNA",
            "HYBRYDA"});
			this.comboBoxPaliwo.Location = new System.Drawing.Point(165, 90);
			this.comboBoxPaliwo.Name = "comboBoxPaliwo";
			this.comboBoxPaliwo.Size = new System.Drawing.Size(121, 21);
			this.comboBoxPaliwo.TabIndex = 27;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(86, 95);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(73, 13);
			this.label12.TabIndex = 28;
			this.label12.Text = "Rodzaj paliwa";
			// 
			// panelSzczegoly
			// 
			this.panelSzczegoly.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelSzczegoly.Controls.Add(this.comboBoxTypNadwozia);
			this.panelSzczegoly.Controls.Add(this.label14);
			this.panelSzczegoly.Controls.Add(this.label13);
			this.panelSzczegoly.Controls.Add(this.label12);
			this.panelSzczegoly.Controls.Add(this.label4);
			this.panelSzczegoly.Controls.Add(this.comboBoxPaliwo);
			this.panelSzczegoly.Controls.Add(this.textBoxPojemnosc);
			this.panelSzczegoly.Controls.Add(this.label7);
			this.panelSzczegoly.Controls.Add(this.label8);
			this.panelSzczegoly.Controls.Add(this.comboBoxSzyby);
			this.panelSzczegoly.Controls.Add(this.comboBoxWspomaganie);
			this.panelSzczegoly.Controls.Add(this.label9);
			this.panelSzczegoly.Controls.Add(this.comboBoxSkrzynia);
			this.panelSzczegoly.Controls.Add(this.comboBoxKlimatyzacja);
			this.panelSzczegoly.Controls.Add(this.label5);
			this.panelSzczegoly.Location = new System.Drawing.Point(67, 201);
			this.panelSzczegoly.Name = "panelSzczegoly";
			this.panelSzczegoly.Size = new System.Drawing.Size(302, 224);
			this.panelSzczegoly.TabIndex = 29;
			// 
			// comboBoxTypNadwozia
			// 
			this.comboBoxTypNadwozia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxTypNadwozia.FormattingEnabled = true;
			this.comboBoxTypNadwozia.Items.AddRange(new object[] {
			"SEDAN",
			"KOMBI",
			"COUPE",
			"SUV",
			"FASTBACK",
			"HATCHBACK",
			"KABRIOLET",
			"LIMUZYNA",
			"PICK-UP",
			"VAN",
			"MINIVAN",
			"ROADSTER"});
			this.comboBoxTypNadwozia.Location = new System.Drawing.Point(165, 63);
			this.comboBoxTypNadwozia.Name = "comboBoxTypNadwozia";
			this.comboBoxTypNadwozia.Size = new System.Drawing.Size(121, 21);
			this.comboBoxTypNadwozia.TabIndex = 30;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(86, 66);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(73, 13);
			this.label14.TabIndex = 29;
			this.label14.Text = "Typ nadwozia";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(126, 16);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(60, 13);
			this.label13.TabIndex = 0;
			this.label13.Text = "Szczegóły:";
			// 
			// buttonZatwierdzZmiany
			// 
			this.buttonZatwierdzZmiany.Location = new System.Drawing.Point(400, 316);
			this.buttonZatwierdzZmiany.Name = "buttonZatwierdzZmiany";
			this.buttonZatwierdzZmiany.Size = new System.Drawing.Size(75, 39);
			this.buttonZatwierdzZmiany.TabIndex = 32;
			this.buttonZatwierdzZmiany.Text = "Zatwierdź zmiany";
			this.buttonZatwierdzZmiany.UseVisualStyleBackColor = true;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(169, 174);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 33;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(116, 177);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(47, 13);
			this.label15.TabIndex = 34;
			this.label15.Text = "Opiekun";
			// 
			// AddOrEditCarWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(534, 437);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.buttonZatwierdzZmiany);
			this.Controls.Add(this.panelSzczegoly);
			this.Controls.Add(this.textBoxKoszt);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.comboBoxModel);
			this.Controls.Add(this.comboBoxMarka);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBoxVIN);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonWczytajSzablon);
			this.Controls.Add(this.buttonZapiszSzablon);
			this.Controls.Add(this.buttonDodajPojazd);
			this.Name = "AddOrEditCarWindow";
			this.Text = "Menadżer Floty - Dodaj pojazd";
			this.panelSzczegoly.ResumeLayout(false);
			this.panelSzczegoly.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.Button buttonDodajPojazd;
		public System.Windows.Forms.Button buttonZapiszSzablon;
		public System.Windows.Forms.Button buttonWczytajSzablon;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxVIN;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxPojemnosc;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboBoxMarka;
		private System.Windows.Forms.ComboBox comboBoxModel;
		private System.Windows.Forms.ComboBox comboBoxKlimatyzacja;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ComboBox comboBoxSzyby;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox comboBoxWspomaganie;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox comboBoxSkrzynia;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox textBoxKoszt;
		private System.Windows.Forms.ComboBox comboBoxPaliwo;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Panel panelSzczegoly;
		private System.Windows.Forms.Label label13;
		public System.Windows.Forms.Button buttonZatwierdzZmiany;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.ComboBox comboBoxTypNadwozia;
		private System.Windows.Forms.Label label14;
	}
}