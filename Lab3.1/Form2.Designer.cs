namespace Lab3._1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.universityName = new System.Windows.Forms.TextBox();
            this.cityName = new System.Windows.Forms.TextBox();
            this.universityCode = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nume Universitate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nume Oras";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cod Universitate";
            // 
            // universityName
            // 
            this.universityName.Location = new System.Drawing.Point(174, 39);
            this.universityName.Name = "universityName";
            this.universityName.Size = new System.Drawing.Size(100, 20);
            this.universityName.TabIndex = 3;
            // 
            // cityName
            // 
            this.cityName.Location = new System.Drawing.Point(174, 65);
            this.cityName.Name = "cityName";
            this.cityName.Size = new System.Drawing.Size(100, 20);
            this.cityName.TabIndex = 4;
            // 
            // universityCode
            // 
            this.universityCode.Location = new System.Drawing.Point(174, 94);
            this.universityCode.Name = "universityCode";
            this.universityCode.Size = new System.Drawing.Size(100, 20);
            this.universityCode.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(101, 146);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 31);
            this.button1.TabIndex = 6;
            this.button1.Text = "Adauga";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 206);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.universityCode);
            this.Controls.Add(this.cityName);
            this.Controls.Add(this.universityName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox universityName;
        private System.Windows.Forms.TextBox cityName;
        private System.Windows.Forms.TextBox universityCode;
        private System.Windows.Forms.Button button1;
    }
}