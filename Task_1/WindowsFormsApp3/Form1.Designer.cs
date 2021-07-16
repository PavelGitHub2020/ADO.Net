
namespace WindowsFormsApp3
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
            this.LoadPicture = new System.Windows.Forms.Button();
            this.ShowOne = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ShowAll = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadPicture
            // 
            this.LoadPicture.Location = new System.Drawing.Point(12, 12);
            this.LoadPicture.Name = "LoadPicture";
            this.LoadPicture.Size = new System.Drawing.Size(87, 35);
            this.LoadPicture.TabIndex = 0;
            this.LoadPicture.Text = "LoadPicture";
            this.LoadPicture.UseVisualStyleBackColor = true;
            this.LoadPicture.Click += new System.EventHandler(this.LoadPicture_Click);
            // 
            // ShowOne
            // 
            this.ShowOne.Location = new System.Drawing.Point(115, 13);
            this.ShowOne.Name = "ShowOne";
            this.ShowOne.Size = new System.Drawing.Size(93, 34);
            this.ShowOne.TabIndex = 1;
            this.ShowOne.Text = "ShowOne";
            this.ShowOne.UseVisualStyleBackColor = true;
            this.ShowOne.Click += new System.EventHandler(this.ShowOne_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(223, 14);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 33);
            this.textBox1.TabIndex = 2;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // ShowAll
            // 
            this.ShowAll.Location = new System.Drawing.Point(345, 15);
            this.ShowAll.Name = "ShowAll";
            this.ShowAll.Size = new System.Drawing.Size(93, 32);
            this.ShowAll.TabIndex = 3;
            this.ShowAll.Text = "ShowAll";
            this.ShowAll.UseVisualStyleBackColor = true;
            this.ShowAll.Click += new System.EventHandler(this.ShowAll_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(426, 283);
            this.dataGridView1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(444, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(344, 276);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 341);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ShowAll);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ShowOne);
            this.Controls.Add(this.LoadPicture);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoadPicture;
        private System.Windows.Forms.Button ShowOne;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ShowAll;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

