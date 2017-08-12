namespace Proiect_PSBD
{
    partial class FormAdaugaPontaj
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonAdaugaPontaj = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBoxOraStop = new System.Windows.Forms.ComboBox();
            this.comboBoxOraStart = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxProiect = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(68)))), ((int)(((byte)(75)))));
            this.panel3.BackgroundImage = global::Proiect_PSBD.Properties.Resources.banner_bgk;
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(624, 344);
            this.panel3.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.buttonAdaugaPontaj);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.comboBoxOraStop);
            this.panel1.Controls.Add(this.comboBoxOraStart);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboBoxProiect);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 286);
            this.panel1.TabIndex = 3;
            // 
            // buttonAdaugaPontaj
            // 
            this.buttonAdaugaPontaj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(68)))), ((int)(((byte)(75)))));
            this.buttonAdaugaPontaj.FlatAppearance.BorderSize = 0;
            this.buttonAdaugaPontaj.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.buttonAdaugaPontaj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdaugaPontaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdaugaPontaj.ForeColor = System.Drawing.Color.White;
            this.buttonAdaugaPontaj.Location = new System.Drawing.Point(494, 112);
            this.buttonAdaugaPontaj.Name = "buttonAdaugaPontaj";
            this.buttonAdaugaPontaj.Size = new System.Drawing.Size(75, 29);
            this.buttonAdaugaPontaj.TabIndex = 9;
            this.buttonAdaugaPontaj.Text = "Adauga";
            this.buttonAdaugaPontaj.UseVisualStyleBackColor = false;
            this.buttonAdaugaPontaj.Click += new System.EventHandler(this.buttonAdaugaPontaj_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(437, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 250);
            this.panel2.TabIndex = 8;
            // 
            // comboBoxOraStop
            // 
            this.comboBoxOraStop.FormattingEnabled = true;
            this.comboBoxOraStop.Location = new System.Drawing.Point(142, 200);
            this.comboBoxOraStop.Name = "comboBoxOraStop";
            this.comboBoxOraStop.Size = new System.Drawing.Size(57, 21);
            this.comboBoxOraStop.TabIndex = 7;
            // 
            // comboBoxOraStart
            // 
            this.comboBoxOraStart.FormattingEnabled = true;
            this.comboBoxOraStart.Location = new System.Drawing.Point(142, 155);
            this.comboBoxOraStart.Name = "comboBoxOraStart";
            this.comboBoxOraStart.Size = new System.Drawing.Size(57, 21);
            this.comboBoxOraStart.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(46, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 18);
            this.label5.TabIndex = 5;
            this.label5.Text = "Ora Stop";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(45, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ora Start";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(142, 99);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 3;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(79, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Data";
            // 
            // comboBoxProiect
            // 
            this.comboBoxProiect.FormattingEnabled = true;
            this.comboBoxProiect.Location = new System.Drawing.Point(142, 49);
            this.comboBoxProiect.Name = "comboBoxProiect";
            this.comboBoxProiect.Size = new System.Drawing.Size(200, 21);
            this.comboBoxProiect.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(60, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Proiect";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(32, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Adauga Pontaj";
            // 
            // FormAdaugaPontaj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 344);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormAdaugaPontaj";
            this.Text = "Adauga Pontaj";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxProiect;
        private System.Windows.Forms.ComboBox comboBoxOraStop;
        private System.Windows.Forms.ComboBox comboBoxOraStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonAdaugaPontaj;
    }
}