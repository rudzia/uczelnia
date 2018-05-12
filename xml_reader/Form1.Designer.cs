namespace xml_reader
{
    partial class Form1
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
            this.button_readXML = new System.Windows.Forms.Button();
            this.dane_tab = new System.Windows.Forms.TabControl();
            this.tab_dane = new System.Windows.Forms.TabPage();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tab_szkodliwe = new System.Windows.Forms.TabPage();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.szkodliwy_czynnik_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wyniki_pomiarow_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NDS_NSN_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uwagi_A_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tab_badania = new System.Windows.Forms.TabPage();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.badanie_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.czestotliwosc_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uwagi_B_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_validatesave = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.button_NowyPlik = new System.Windows.Forms.Button();
            this.dane_tab.SuspendLayout();
            this.tab_dane.SuspendLayout();
            this.tab_szkodliwe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tab_badania.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_readXML
            // 
            this.button_readXML.Location = new System.Drawing.Point(31, 446);
            this.button_readXML.Name = "button_readXML";
            this.button_readXML.Size = new System.Drawing.Size(108, 23);
            this.button_readXML.TabIndex = 0;
            this.button_readXML.Text = "wczytaj plik xml";
            this.button_readXML.UseVisualStyleBackColor = true;
            this.button_readXML.Click += new System.EventHandler(this.button1_Click);
            // 
            // dane_tab
            // 
            this.dane_tab.Controls.Add(this.tab_dane);
            this.dane_tab.Controls.Add(this.tab_szkodliwe);
            this.dane_tab.Controls.Add(this.tab_badania);
            this.dane_tab.Location = new System.Drawing.Point(12, 12);
            this.dane_tab.Name = "dane_tab";
            this.dane_tab.SelectedIndex = 0;
            this.dane_tab.Size = new System.Drawing.Size(846, 414);
            this.dane_tab.TabIndex = 1;
            // 
            // tab_dane
            // 
            this.tab_dane.Controls.Add(this.maskedTextBox1);
            this.tab_dane.Controls.Add(this.dateTimePicker1);
            this.tab_dane.Controls.Add(this.label18);
            this.tab_dane.Controls.Add(this.textBox15);
            this.tab_dane.Controls.Add(this.textBox5);
            this.tab_dane.Controls.Add(this.label17);
            this.tab_dane.Controls.Add(this.label16);
            this.tab_dane.Controls.Add(this.label11);
            this.tab_dane.Controls.Add(this.label7);
            this.tab_dane.Controls.Add(this.textBox14);
            this.tab_dane.Controls.Add(this.label15);
            this.tab_dane.Controls.Add(this.comboBox1);
            this.tab_dane.Controls.Add(this.label10);
            this.tab_dane.Controls.Add(this.textBox9);
            this.tab_dane.Controls.Add(this.label9);
            this.tab_dane.Controls.Add(this.textBox8);
            this.tab_dane.Controls.Add(this.label8);
            this.tab_dane.Controls.Add(this.textBox7);
            this.tab_dane.Controls.Add(this.textBox6);
            this.tab_dane.Controls.Add(this.label6);
            this.tab_dane.Controls.Add(this.label5);
            this.tab_dane.Controls.Add(this.textBox4);
            this.tab_dane.Controls.Add(this.label4);
            this.tab_dane.Controls.Add(this.label3);
            this.tab_dane.Controls.Add(this.label2);
            this.tab_dane.Controls.Add(this.label1);
            this.tab_dane.Controls.Add(this.textBox3);
            this.tab_dane.Controls.Add(this.textBox2);
            this.tab_dane.Controls.Add(this.textBox1);
            this.tab_dane.Location = new System.Drawing.Point(4, 22);
            this.tab_dane.Name = "tab_dane";
            this.tab_dane.Padding = new System.Windows.Forms.Padding(3);
            this.tab_dane.Size = new System.Drawing.Size(838, 388);
            this.tab_dane.TabIndex = 0;
            this.tab_dane.Text = "Dane";
            this.tab_dane.UseVisualStyleBackColor = true;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(15, 255);
            this.maskedTextBox1.Mask = "00-000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(61, 20);
            this.maskedTextBox1.TabIndex = 33;
            this.maskedTextBox1.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox1_MaskInputRejected);
            this.maskedTextBox1.Validating += new System.ComponentModel.CancelEventHandler(this.maskedTextBox1_Validating);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(313, 252);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(263, 20);
            this.dateTimePicker1.TabIndex = 32;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(310, 236);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(30, 13);
            this.label18.TabIndex = 31;
            this.label18.Text = "Data";
            this.label18.Click += new System.EventHandler(this.label18_Click);
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(88, 255);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(183, 20);
            this.textBox15.TabIndex = 30;
            this.textBox15.TextChanged += new System.EventHandler(this.textBox15_TextChanged);
            this.textBox15.Validating += new System.ComponentModel.CancelEventHandler(this.textBox15_Validating);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(15, 216);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(256, 20);
            this.textBox5.TabIndex = 28;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            this.textBox5.Validating += new System.ComponentModel.CancelEventHandler(this.textBox5_Validating);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(12, 168);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(81, 13);
            this.label17.TabIndex = 27;
            this.label17.Text = "Adres pacjenta:";
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 239);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 13);
            this.label16.TabIndex = 26;
            this.label16.Text = "Kod pocztowy";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(85, 239);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Miasto";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Ulica";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(313, 302);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(263, 20);
            this.textBox14.TabIndex = 23;
            this.textBox14.TextChanged += new System.EventHandler(this.textBox14_TextChanged);
            this.textBox14.Validating += new System.ComponentModel.CancelEventHandler(this.textBox14_Validating);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(310, 286);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 13);
            this.label15.TabIndex = 22;
            this.label15.Text = "Zlecający badania";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "wstępne",
            "okresowe",
            "kontrolne",
            "końcowe",
            "zmiana stanowiska pracy"});
            this.comboBox1.Location = new System.Drawing.Point(15, 315);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 19;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.Validating += new System.ComponentModel.CancelEventHandler(this.comboBox1_Validating);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 299);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Rodzaj badania";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(313, 118);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(263, 20);
            this.textBox9.TabIndex = 17;
            this.textBox9.TextChanged += new System.EventHandler(this.textBox9_TextChanged);
            this.textBox9.Validating += new System.ComponentModel.CancelEventHandler(this.textBox9_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(310, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Obecne stanowisko pracy";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(313, 157);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(263, 20);
            this.textBox8.TabIndex = 15;
            this.textBox8.TextChanged += new System.EventHandler(this.textBox8_TextChanged);
            this.textBox8.Validating += new System.ComponentModel.CancelEventHandler(this.textBox8_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(310, 141);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Zatrudniony na stanowisko";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(13, 118);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(127, 20);
            this.textBox7.TabIndex = 12;
            this.textBox7.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            this.textBox7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox7_KeyPress);
            this.textBox7.Validating += new System.ComponentModel.CancelEventHandler(this.textBox7_Validating);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(313, 79);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(127, 20);
            this.textBox6.TabIndex = 11;
            this.textBox6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            this.textBox6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox6_KeyPress);
            this.textBox6.Validating += new System.ComponentModel.CancelEventHandler(this.textBox6_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "PESEL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(310, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "REGON";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(313, 196);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(127, 20);
            this.textBox4.TabIndex = 7;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            this.textBox4.Validating += new System.ComponentModel.CancelEventHandler(this.textBox4_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(310, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Czas zatrudnienia";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nazwisko pacjenta";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Imię pacjenta";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(310, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nazwa zakładu pracy";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(13, 79);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(258, 20);
            this.textBox3.TabIndex = 2;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            this.textBox3.Validating += new System.ComponentModel.CancelEventHandler(this.textBox3_Validating);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(13, 40);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(258, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            this.textBox2.Validating += new System.ComponentModel.CancelEventHandler(this.textBox2_Validating);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(313, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(263, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
            // 
            // tab_szkodliwe
            // 
            this.tab_szkodliwe.Controls.Add(this.textBox11);
            this.tab_szkodliwe.Controls.Add(this.label12);
            this.tab_szkodliwe.Controls.Add(this.dataGridView1);
            this.tab_szkodliwe.Location = new System.Drawing.Point(4, 22);
            this.tab_szkodliwe.Name = "tab_szkodliwe";
            this.tab_szkodliwe.Padding = new System.Windows.Forms.Padding(3);
            this.tab_szkodliwe.Size = new System.Drawing.Size(838, 388);
            this.tab_szkodliwe.TabIndex = 1;
            this.tab_szkodliwe.Text = "Czynniki szkodliwe";
            this.tab_szkodliwe.UseVisualStyleBackColor = true;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(17, 297);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(587, 20);
            this.textBox11.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 280);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Dodatkowe uwagi:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.szkodliwy_czynnik_column,
            this.wyniki_pomiarow_column,
            this.NDS_NSN_column,
            this.uwagi_A_column});
            this.dataGridView1.Location = new System.Drawing.Point(17, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(587, 242);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowValidated);
            this.dataGridView1.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_UserDeletedRow);
            // 
            // szkodliwy_czynnik_column
            // 
            this.szkodliwy_czynnik_column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.szkodliwy_czynnik_column.HeaderText = "Rodzaj szkodliwości i uciążliwości na stanowisku pracy";
            this.szkodliwy_czynnik_column.MinimumWidth = 10;
            this.szkodliwy_czynnik_column.Name = "szkodliwy_czynnik_column";
            this.szkodliwy_czynnik_column.Width = 148;
            // 
            // wyniki_pomiarow_column
            // 
            this.wyniki_pomiarow_column.HeaderText = "Wyniki pomiarów";
            this.wyniki_pomiarow_column.Name = "wyniki_pomiarow_column";
            // 
            // NDS_NSN_column
            // 
            this.NDS_NSN_column.HeaderText = "NDS NDN";
            this.NDS_NSN_column.Name = "NDS_NSN_column";
            // 
            // uwagi_A_column
            // 
            this.uwagi_A_column.HeaderText = "Uwagi";
            this.uwagi_A_column.Name = "uwagi_A_column";
            // 
            // tab_badania
            // 
            this.tab_badania.Controls.Add(this.textBox13);
            this.tab_badania.Controls.Add(this.label14);
            this.tab_badania.Controls.Add(this.textBox12);
            this.tab_badania.Controls.Add(this.label13);
            this.tab_badania.Controls.Add(this.dataGridView2);
            this.tab_badania.Location = new System.Drawing.Point(4, 22);
            this.tab_badania.Name = "tab_badania";
            this.tab_badania.Padding = new System.Windows.Forms.Padding(3);
            this.tab_badania.Size = new System.Drawing.Size(838, 388);
            this.tab_badania.TabIndex = 2;
            this.tab_badania.Text = "Badania";
            this.tab_badania.UseVisualStyleBackColor = true;
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(316, 353);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(229, 20);
            this.textBox13.TabIndex = 4;
            this.textBox13.TextChanged += new System.EventHandler(this.textBox13_TextChanged);
            this.textBox13.Validating += new System.ComponentModel.CancelEventHandler(this.textBox13_Validating);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(313, 337);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(115, 13);
            this.label14.TabIndex = 3;
            this.label14.Text = "Imię i nazwisko lekarza";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(23, 300);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(522, 20);
            this.textBox12.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 284);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Dodatkowe uwagi:";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.badanie_column,
            this.czestotliwosc_column,
            this.uwagi_B_column});
            this.dataGridView2.Location = new System.Drawing.Point(20, 25);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(590, 232);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            this.dataGridView2.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_RowValidated);
            this.dataGridView2.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView2_UserDeletedRow);
            // 
            // badanie_column
            // 
            this.badanie_column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.badanie_column.HeaderText = "Rodzaj badania lekarskiego lub konsultacji";
            this.badanie_column.Name = "badanie_column";
            this.badanie_column.Width = 167;
            // 
            // czestotliwosc_column
            // 
            this.czestotliwosc_column.HeaderText = "Częstotliwość";
            this.czestotliwosc_column.Name = "czestotliwosc_column";
            // 
            // uwagi_B_column
            // 
            this.uwagi_B_column.HeaderText = "Uwagi";
            this.uwagi_B_column.Name = "uwagi_B_column";
            // 
            // button_validatesave
            // 
            this.button_validatesave.Location = new System.Drawing.Point(266, 446);
            this.button_validatesave.Name = "button_validatesave";
            this.button_validatesave.Size = new System.Drawing.Size(154, 23);
            this.button_validatesave.TabIndex = 2;
            this.button_validatesave.Text = "waliduj i zapisz jako XML";
            this.button_validatesave.UseVisualStyleBackColor = true;
            this.button_validatesave.Click += new System.EventHandler(this.button_validatesave_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 486);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(638, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(433, 446);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "waliduj i zapisz jako PDF";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button_NowyPlik
            // 
            this.button_NowyPlik.Location = new System.Drawing.Point(146, 445);
            this.button_NowyPlik.Name = "button_NowyPlik";
            this.button_NowyPlik.Size = new System.Drawing.Size(75, 23);
            this.button_NowyPlik.TabIndex = 5;
            this.button_NowyPlik.Text = "nowy plik";
            this.button_NowyPlik.UseVisualStyleBackColor = true;
            this.button_NowyPlik.Click += new System.EventHandler(this.button_NowyPlik_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 508);
            this.Controls.Add(this.button_NowyPlik);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button_validatesave);
            this.Controls.Add(this.dane_tab);
            this.Controls.Add(this.button_readXML);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.dane_tab.ResumeLayout(false);
            this.tab_dane.ResumeLayout(false);
            this.tab_dane.PerformLayout();
            this.tab_szkodliwe.ResumeLayout(false);
            this.tab_szkodliwe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tab_badania.ResumeLayout(false);
            this.tab_badania.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_readXML;
        private System.Windows.Forms.TabControl dane_tab;
        private System.Windows.Forms.TabPage tab_dane;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabPage tab_szkodliwe;
        private System.Windows.Forms.TabPage tab_badania;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button_validatesave;
        private System.Windows.Forms.DataGridView dataGridView1;


        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.StatusStrip statusStrip1;

        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_NowyPlik;
        private System.Windows.Forms.DataGridViewTextBoxColumn szkodliwy_czynnik_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn wyniki_pomiarow_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn NDS_NSN_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn uwagi_A_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn badanie_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn czestotliwosc_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn uwagi_B_column;
    }
}

