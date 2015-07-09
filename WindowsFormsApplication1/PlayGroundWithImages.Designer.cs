namespace WinFormUI
{
    partial class PlayGroundWithImages
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label8;
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.player2Death = new System.Windows.Forms.Label();
            this.player2Gold = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.player1Death = new System.Windows.Forms.Label();
            this.player1Gold = new System.Windows.Forms.Label();
            this.player1GoldContain = new System.Windows.Forms.Label();
            this.player2GoldContain = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(8, 37);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(56, 17);
            label1.TabIndex = 0;
            label1.Text = "Золото";
            label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(8, 70);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(57, 17);
            label2.TabIndex = 1;
            label2.Text = "Смерти";
            label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(8, 38);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(56, 17);
            label3.TabIndex = 2;
            label3.Text = "Золото";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(8, 68);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(57, 17);
            label4.TabIndex = 3;
            label4.Text = "Смерти";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1077, 770);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyPress);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1484, 770);
            this.splitContainer1.SplitterDistance = 1077;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(225, 479);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.player2GoldContain);
            this.groupBox3.Controls.Add(this.player2Death);
            this.groupBox3.Controls.Add(label8);
            this.groupBox3.Controls.Add(this.player2Gold);
            this.groupBox3.Controls.Add(label3);
            this.groupBox3.Controls.Add(label4);
            this.groupBox3.Location = new System.Drawing.Point(12, 268);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(201, 203);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Игрок 2";
            // 
            // player2Death
            // 
            this.player2Death.AutoSize = true;
            this.player2Death.Location = new System.Drawing.Point(161, 68);
            this.player2Death.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.player2Death.Name = "player2Death";
            this.player2Death.Size = new System.Drawing.Size(16, 17);
            this.player2Death.TabIndex = 5;
            this.player2Death.Text = "0";
            // 
            // player2Gold
            // 
            this.player2Gold.AutoSize = true;
            this.player2Gold.Location = new System.Drawing.Point(161, 38);
            this.player2Gold.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.player2Gold.Name = "player2Gold";
            this.player2Gold.Size = new System.Drawing.Size(16, 17);
            this.player2Gold.TabIndex = 4;
            this.player2Gold.Text = "0";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.player1GoldContain);
            this.groupBox2.Controls.Add(label6);
            this.groupBox2.Controls.Add(this.player1Death);
            this.groupBox2.Controls.Add(this.player1Gold);
            this.groupBox2.Controls.Add(label1);
            this.groupBox2.Controls.Add(label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 23);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(201, 238);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Игрок 1";
            // 
            // player1Death
            // 
            this.player1Death.AutoSize = true;
            this.player1Death.Location = new System.Drawing.Point(161, 70);
            this.player1Death.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.player1Death.Name = "player1Death";
            this.player1Death.Size = new System.Drawing.Size(16, 17);
            this.player1Death.TabIndex = 3;
            this.player1Death.Text = "0";
            // 
            // player1Gold
            // 
            this.player1Gold.AutoSize = true;
            this.player1Gold.Location = new System.Drawing.Point(161, 37);
            this.player1Gold.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.player1Gold.Name = "player1Gold";
            this.player1Gold.Size = new System.Drawing.Size(16, 17);
            this.player1Gold.TabIndex = 2;
            this.player1Gold.Text = "0";
            // 
            // player1GoldContain
            // 
            this.player1GoldContain.AutoSize = true;
            this.player1GoldContain.Location = new System.Drawing.Point(161, 105);
            this.player1GoldContain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.player1GoldContain.Name = "player1GoldContain";
            this.player1GoldContain.Size = new System.Drawing.Size(33, 17);
            this.player1GoldContain.TabIndex = 5;
            this.player1GoldContain.Text = "Нет";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(8, 105);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(123, 17);
            label6.TabIndex = 4;
            label6.Text = "Содержит золото";
            // 
            // player2GoldContain
            // 
            this.player2GoldContain.AutoSize = true;
            this.player2GoldContain.Location = new System.Drawing.Point(161, 96);
            this.player2GoldContain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.player2GoldContain.Name = "player2GoldContain";
            this.player2GoldContain.Size = new System.Drawing.Size(33, 17);
            this.player2GoldContain.TabIndex = 7;
            this.player2GoldContain.Text = "Нет";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(8, 96);
            label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(123, 17);
            label8.TabIndex = 6;
            label8.Text = "Содержит золото";
            // 
            // PlayGroundCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 770);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PlayGroundCopy";
            this.Text = "Jackal";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label player2Death;
        private System.Windows.Forms.Label player2Gold;
        private System.Windows.Forms.Label player1Death;
        private System.Windows.Forms.Label player1Gold;
        private System.Windows.Forms.Label player2GoldContain;
        private System.Windows.Forms.Label player1GoldContain;
    }
}