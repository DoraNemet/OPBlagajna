namespace Blagajna
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
            this.racunGV = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.primljenoTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ukupnoLabel = new System.Windows.Forms.Label();
            this.searchTB = new System.Windows.Forms.TextBox();
            this.proizvodiGV = new System.Windows.Forms.DataGridView();
            this.addBtn = new System.Windows.Forms.Button();
            this.kolicinaTB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.brojRB = new System.Windows.Forms.RadioButton();
            this.nazivRB = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.selectedTB = new System.Windows.Forms.TextBox();
            this.kolicinaLbl = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.potrebnoPoljeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.racunGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proizvodiGV)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // racunGV
            // 
            this.racunGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.racunGV.Location = new System.Drawing.Point(591, 41);
            this.racunGV.Name = "racunGV";
            this.racunGV.Size = new System.Drawing.Size(523, 381);
            this.racunGV.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(958, 457);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ukupno:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1039, 533);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // primljenoTB
            // 
            this.primljenoTB.Location = new System.Drawing.Point(1028, 492);
            this.primljenoTB.Name = "primljenoTB";
            this.primljenoTB.Size = new System.Drawing.Size(86, 20);
            this.primljenoTB.TabIndex = 5;
            this.primljenoTB.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(958, 495);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Primljeno: ";
            // 
            // ukupnoLabel
            // 
            this.ukupnoLabel.AutoSize = true;
            this.ukupnoLabel.Location = new System.Drawing.Point(1025, 457);
            this.ukupnoLabel.Name = "ukupnoLabel";
            this.ukupnoLabel.Size = new System.Drawing.Size(13, 13);
            this.ukupnoLabel.TabIndex = 7;
            this.ukupnoLabel.Text = "0";
            // 
            // searchTB
            // 
            this.searchTB.Location = new System.Drawing.Point(44, 415);
            this.searchTB.Name = "searchTB";
            this.searchTB.Size = new System.Drawing.Size(136, 20);
            this.searchTB.TabIndex = 9;
            this.searchTB.TextChanged += new System.EventHandler(this.searchTB_TextChanged);
            // 
            // proizvodiGV
            // 
            this.proizvodiGV.AccessibleName = "";
            this.proizvodiGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.proizvodiGV.Location = new System.Drawing.Point(44, 41);
            this.proizvodiGV.Name = "proizvodiGV";
            this.proizvodiGV.ReadOnly = true;
            this.proizvodiGV.Size = new System.Drawing.Size(481, 268);
            this.proizvodiGV.TabIndex = 10;
            this.proizvodiGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.proizvodiGV_CellClick);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(299, 408);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 11;
            this.addBtn.Text = "Dodaj";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // kolicinaTB
            // 
            this.kolicinaTB.Location = new System.Drawing.Point(347, 373);
            this.kolicinaTB.Name = "kolicinaTB";
            this.kolicinaTB.Size = new System.Drawing.Size(27, 20);
            this.kolicinaTB.TabIndex = 12;
            this.kolicinaTB.Text = "1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(41, 331);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Pretraga:";
            // 
            // brojRB
            // 
            this.brojRB.AutoSize = true;
            this.brojRB.Checked = true;
            this.brojRB.Location = new System.Drawing.Point(6, 21);
            this.brojRB.Name = "brojRB";
            this.brojRB.Size = new System.Drawing.Size(42, 17);
            this.brojRB.TabIndex = 15;
            this.brojRB.TabStop = true;
            this.brojRB.Text = "broj";
            this.brojRB.UseVisualStyleBackColor = true;
            // 
            // nazivRB
            // 
            this.nazivRB.AutoSize = true;
            this.nazivRB.Location = new System.Drawing.Point(6, 44);
            this.nazivRB.Name = "nazivRB";
            this.nazivRB.Size = new System.Drawing.Size(50, 17);
            this.nazivRB.TabIndex = 16;
            this.nazivRB.TabStop = true;
            this.nazivRB.Text = "naziv";
            this.nazivRB.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.brojRB);
            this.groupBox1.Controls.Add(this.nazivRB);
            this.groupBox1.Location = new System.Drawing.Point(73, 347);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(107, 62);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "pretraga po:";
            // 
            // selectedTB
            // 
            this.selectedTB.Location = new System.Drawing.Point(203, 347);
            this.selectedTB.Name = "selectedTB";
            this.selectedTB.ReadOnly = true;
            this.selectedTB.Size = new System.Drawing.Size(171, 20);
            this.selectedTB.TabIndex = 21;
            // 
            // kolicinaLbl
            // 
            this.kolicinaLbl.AutoSize = true;
            this.kolicinaLbl.Location = new System.Drawing.Point(281, 376);
            this.kolicinaLbl.Name = "kolicinaLbl";
            this.kolicinaLbl.Size = new System.Drawing.Size(47, 13);
            this.kolicinaLbl.TabIndex = 13;
            this.kolicinaLbl.Text = "Kolicina:";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            // 
            // potrebnoPoljeLabel
            // 
            this.potrebnoPoljeLabel.AutoSize = true;
            this.potrebnoPoljeLabel.ForeColor = System.Drawing.Color.Red;
            this.potrebnoPoljeLabel.Location = new System.Drawing.Point(381, 379);
            this.potrebnoPoljeLabel.Name = "potrebnoPoljeLabel";
            this.potrebnoPoljeLabel.Size = new System.Drawing.Size(0, 13);
            this.potrebnoPoljeLabel.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 598);
            this.Controls.Add(this.potrebnoPoljeLabel);
            this.Controls.Add(this.selectedTB);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.kolicinaLbl);
            this.Controls.Add(this.kolicinaTB);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.proizvodiGV);
            this.Controls.Add(this.searchTB);
            this.Controls.Add(this.ukupnoLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.primljenoTB);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.racunGV);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.racunGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proizvodiGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView racunGV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox primljenoTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label ukupnoLabel;
        private System.Windows.Forms.TextBox searchTB;
        private System.Windows.Forms.DataGridView proizvodiGV;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.TextBox kolicinaTB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton brojRB;
        private System.Windows.Forms.RadioButton nazivRB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox selectedTB;
        private System.Windows.Forms.Label kolicinaLbl;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label potrebnoPoljeLabel;
    }
}

