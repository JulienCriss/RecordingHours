namespace Proiect_PSBD
{
    partial class FormAdmin
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
            this.dataGridAngajati = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nume_prenume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salariu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_anagajarii = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_parasirii = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status_angajat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonInfoAngajat = new System.Windows.Forms.Button();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.buttonStadiuProiect = new System.Windows.Forms.Button();
            this.labelCopyRight = new System.Windows.Forms.Label();
            this.buttonEditObject = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.buttonDeleteObject = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.buttonInsertNewObject = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.labelCounterObjects = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelUserName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAngajati)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridAngajati
            // 
            this.dataGridAngajati.AllowUserToAddRows = false;
            this.dataGridAngajati.AllowUserToDeleteRows = false;
            this.dataGridAngajati.BackgroundColor = System.Drawing.Color.White;
            this.dataGridAngajati.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAngajati.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.nume_prenume,
            this.salariu,
            this.data_anagajarii,
            this.data_parasirii,
            this.Status,
            this.status_angajat});
            this.dataGridAngajati.GridColor = System.Drawing.Color.White;
            this.dataGridAngajati.Location = new System.Drawing.Point(292, 254);
            this.dataGridAngajati.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridAngajati.MultiSelect = false;
            this.dataGridAngajati.Name = "dataGridAngajati";
            this.dataGridAngajati.ReadOnly = true;
            this.dataGridAngajati.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridAngajati.Size = new System.Drawing.Size(1125, 564);
            this.dataGridAngajati.TabIndex = 1;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // nume_prenume
            // 
            this.nume_prenume.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nume_prenume.HeaderText = "Nume/Prenume";
            this.nume_prenume.Name = "nume_prenume";
            this.nume_prenume.ReadOnly = true;
            // 
            // salariu
            // 
            this.salariu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.salariu.HeaderText = "Salariu";
            this.salariu.Name = "salariu";
            this.salariu.ReadOnly = true;
            // 
            // data_anagajarii
            // 
            this.data_anagajarii.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.data_anagajarii.HeaderText = "Data Angajarii";
            this.data_anagajarii.Name = "data_anagajarii";
            this.data_anagajarii.ReadOnly = true;
            // 
            // data_parasirii
            // 
            this.data_parasirii.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.data_parasirii.HeaderText = "Data Parasire";
            this.data_parasirii.Name = "data_parasirii";
            this.data_parasirii.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Status.HeaderText = "Departament";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // status_angajat
            // 
            this.status_angajat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.status_angajat.HeaderText = "Status Angajat";
            this.status_angajat.Name = "status_angajat";
            this.status_angajat.ReadOnly = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(68)))), ((int)(((byte)(75)))));
            this.panel4.Controls.Add(this.buttonInfoAngajat);
            this.panel4.Controls.Add(this.panel13);
            this.panel4.Controls.Add(this.panel11);
            this.panel4.Controls.Add(this.panel9);
            this.panel4.Controls.Add(this.buttonStadiuProiect);
            this.panel4.Controls.Add(this.labelCopyRight);
            this.panel4.Controls.Add(this.buttonEditObject);
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.buttonDeleteObject);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.buttonInsertNewObject);
            this.panel4.Location = new System.Drawing.Point(0, 252);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(292, 598);
            this.panel4.TabIndex = 2;
            // 
            // buttonInfoAngajat
            // 
            this.buttonInfoAngajat.BackColor = System.Drawing.Color.Transparent;
            this.buttonInfoAngajat.FlatAppearance.BorderSize = 0;
            this.buttonInfoAngajat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonInfoAngajat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.buttonInfoAngajat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInfoAngajat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInfoAngajat.ForeColor = System.Drawing.Color.White;
            this.buttonInfoAngajat.Image = global::Proiect_PSBD.Properties.Resources.info;
            this.buttonInfoAngajat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonInfoAngajat.Location = new System.Drawing.Point(20, 169);
            this.buttonInfoAngajat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonInfoAngajat.Name = "buttonInfoAngajat";
            this.buttonInfoAngajat.Size = new System.Drawing.Size(248, 46);
            this.buttonInfoAngajat.TabIndex = 15;
            this.buttonInfoAngajat.Text = "Info Angajat               ";
            this.buttonInfoAngajat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonInfoAngajat.UseVisualStyleBackColor = false;
            this.buttonInfoAngajat.Click += new System.EventHandler(this.buttonInfoAngajat_Click);
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.White;
            this.panel13.Controls.Add(this.panel14);
            this.panel13.Location = new System.Drawing.Point(5, 358);
            this.panel13.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(280, 1);
            this.panel13.TabIndex = 14;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.White;
            this.panel14.Location = new System.Drawing.Point(0, 11);
            this.panel14.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(280, 1);
            this.panel14.TabIndex = 13;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.White;
            this.panel11.Controls.Add(this.panel12);
            this.panel11.Location = new System.Drawing.Point(7, 294);
            this.panel11.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(280, 1);
            this.panel11.TabIndex = 13;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.White;
            this.panel12.Location = new System.Drawing.Point(0, 11);
            this.panel12.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(280, 1);
            this.panel12.TabIndex = 13;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Location = new System.Drawing.Point(5, 226);
            this.panel9.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(280, 1);
            this.panel9.TabIndex = 12;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.White;
            this.panel10.Location = new System.Drawing.Point(0, 11);
            this.panel10.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(280, 1);
            this.panel10.TabIndex = 13;
            // 
            // buttonStadiuProiect
            // 
            this.buttonStadiuProiect.BackColor = System.Drawing.Color.Transparent;
            this.buttonStadiuProiect.FlatAppearance.BorderSize = 0;
            this.buttonStadiuProiect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonStadiuProiect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.buttonStadiuProiect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStadiuProiect.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStadiuProiect.ForeColor = System.Drawing.Color.White;
            this.buttonStadiuProiect.Image = global::Proiect_PSBD.Properties.Resources.project;
            this.buttonStadiuProiect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonStadiuProiect.Location = new System.Drawing.Point(20, 304);
            this.buttonStadiuProiect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonStadiuProiect.Name = "buttonStadiuProiect";
            this.buttonStadiuProiect.Size = new System.Drawing.Size(248, 46);
            this.buttonStadiuProiect.TabIndex = 11;
            this.buttonStadiuProiect.Text = "Stadiu Proiecte         ";
            this.buttonStadiuProiect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonStadiuProiect.UseVisualStyleBackColor = false;
            this.buttonStadiuProiect.Click += new System.EventHandler(this.buttonStadiuProiect_Click);
            // 
            // labelCopyRight
            // 
            this.labelCopyRight.AutoSize = true;
            this.labelCopyRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCopyRight.ForeColor = System.Drawing.Color.White;
            this.labelCopyRight.Location = new System.Drawing.Point(9, 556);
            this.labelCopyRight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCopyRight.Name = "labelCopyRight";
            this.labelCopyRight.Size = new System.Drawing.Size(248, 18);
            this.labelCopyRight.TabIndex = 10;
            this.labelCopyRight.Text = "Copyright © Recording Hours - 2016";
            // 
            // buttonEditObject
            // 
            this.buttonEditObject.BackColor = System.Drawing.Color.Transparent;
            this.buttonEditObject.FlatAppearance.BorderSize = 0;
            this.buttonEditObject.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonEditObject.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.buttonEditObject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditObject.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditObject.ForeColor = System.Drawing.Color.White;
            this.buttonEditObject.Image = global::Proiect_PSBD.Properties.Resources.edit;
            this.buttonEditObject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEditObject.Location = new System.Drawing.Point(20, 95);
            this.buttonEditObject.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonEditObject.Name = "buttonEditObject";
            this.buttonEditObject.Size = new System.Drawing.Size(248, 46);
            this.buttonEditObject.TabIndex = 9;
            this.buttonEditObject.Text = "Editeaza Angajat       ";
            this.buttonEditObject.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEditObject.UseVisualStyleBackColor = false;
            this.buttonEditObject.Click += new System.EventHandler(this.buttonEditObject_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Location = new System.Drawing.Point(5, 155);
            this.panel7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(280, 1);
            this.panel7.TabIndex = 8;
            // 
            // buttonDeleteObject
            // 
            this.buttonDeleteObject.BackColor = System.Drawing.Color.Transparent;
            this.buttonDeleteObject.FlatAppearance.BorderSize = 0;
            this.buttonDeleteObject.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonDeleteObject.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.buttonDeleteObject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteObject.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteObject.ForeColor = System.Drawing.Color.White;
            this.buttonDeleteObject.Image = global::Proiect_PSBD.Properties.Resources.delete;
            this.buttonDeleteObject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDeleteObject.Location = new System.Drawing.Point(20, 238);
            this.buttonDeleteObject.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDeleteObject.Name = "buttonDeleteObject";
            this.buttonDeleteObject.Size = new System.Drawing.Size(248, 46);
            this.buttonDeleteObject.TabIndex = 7;
            this.buttonDeleteObject.Text = "Sterge Angajat          ";
            this.buttonDeleteObject.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonDeleteObject.UseVisualStyleBackColor = false;
            this.buttonDeleteObject.Click += new System.EventHandler(this.buttonDeleteObject_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Location = new System.Drawing.Point(5, 79);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(280, 1);
            this.panel5.TabIndex = 6;
            // 
            // buttonInsertNewObject
            // 
            this.buttonInsertNewObject.BackColor = System.Drawing.Color.Transparent;
            this.buttonInsertNewObject.FlatAppearance.BorderSize = 0;
            this.buttonInsertNewObject.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonInsertNewObject.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.buttonInsertNewObject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInsertNewObject.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInsertNewObject.ForeColor = System.Drawing.Color.White;
            this.buttonInsertNewObject.Image = global::Proiect_PSBD.Properties.Resources.add_user;
            this.buttonInsertNewObject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonInsertNewObject.Location = new System.Drawing.Point(20, 17);
            this.buttonInsertNewObject.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonInsertNewObject.Name = "buttonInsertNewObject";
            this.buttonInsertNewObject.Size = new System.Drawing.Size(248, 46);
            this.buttonInsertNewObject.TabIndex = 0;
            this.buttonInsertNewObject.Text = "Adauga Angajat         ";
            this.buttonInsertNewObject.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonInsertNewObject.UseVisualStyleBackColor = false;
            this.buttonInsertNewObject.Click += new System.EventHandler(this.buttonInsertNewObject_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Location = new System.Drawing.Point(-1, 218);
            this.panel6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1419, 36);
            this.panel6.TabIndex = 3;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.labelCounterObjects);
            this.panel8.Controls.Add(this.label2);
            this.panel8.Location = new System.Drawing.Point(292, 812);
            this.panel8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1127, 36);
            this.panel8.TabIndex = 7;
            // 
            // labelCounterObjects
            // 
            this.labelCounterObjects.AutoSize = true;
            this.labelCounterObjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCounterObjects.ForeColor = System.Drawing.Color.White;
            this.labelCounterObjects.Location = new System.Drawing.Point(1019, 6);
            this.labelCounterObjects.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCounterObjects.Name = "labelCounterObjects";
            this.labelCounterObjects.Size = new System.Drawing.Size(20, 24);
            this.labelCounterObjects.TabIndex = 1;
            this.labelCounterObjects.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(871, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total Angajati: ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(68)))), ((int)(((byte)(75)))));
            this.panel1.BackgroundImage = global::Proiect_PSBD.Properties.Resources.banner_bgk;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.labelUserName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.buttonLogout);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(-1, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1419, 221);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(1119, 175);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 25);
            this.panel3.TabIndex = 5;
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.BackColor = System.Drawing.Color.Transparent;
            this.labelUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserName.ForeColor = System.Drawing.Color.White;
            this.labelUserName.Location = new System.Drawing.Point(1005, 175);
            this.labelUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(89, 24);
            this.labelUserName.TabIndex = 4;
            this.labelUserName.Text = "admin_rh";
            this.labelUserName.Click += new System.EventHandler(this.labelUserName_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(913, 175);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bun venit, ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(1255, 175);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 25);
            this.panel2.TabIndex = 2;
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.Transparent;
            this.buttonLogout.FlatAppearance.BorderSize = 0;
            this.buttonLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogout.ForeColor = System.Drawing.Color.White;
            this.buttonLogout.Image = global::Proiect_PSBD.Properties.Resources.logout;
            this.buttonLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLogout.Location = new System.Drawing.Point(1132, 170);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(113, 33);
            this.buttonLogout.TabIndex = 1;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::Proiect_PSBD.Properties.Resources.banner;
            this.pictureBox2.Location = new System.Drawing.Point(959, -1);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(460, 180);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Proiect_PSBD.Properties.Resources.logo_PSBD;
            this.pictureBox1.Location = new System.Drawing.Point(60, 17);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 151);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1419, 849);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.dataGridAngajati);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormAdmin";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recording Hours [Administrare]";
            this.Load += new System.EventHandler(this.FormAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAngajati)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridAngajati;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button buttonInsertNewObject;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button buttonDeleteObject;
        private System.Windows.Forms.Button buttonEditObject;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label labelCopyRight;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label labelCounterObjects;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button buttonStadiuProiect;
        private System.Windows.Forms.Button buttonInfoAngajat;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn nume_prenume;
        private System.Windows.Forms.DataGridViewTextBoxColumn salariu;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_anagajarii;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_parasirii;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn status_angajat;
    }
}

