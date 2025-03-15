namespace WindowsFormsApplication3
{
    partial class Calculator
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_cos = new System.Windows.Forms.Button();
            this.btn_sin = new System.Windows.Forms.Button();
            this.btn_log = new System.Windows.Forms.Button();
            this.btnsquare = new System.Windows.Forms.Button();
            this.btn_tan = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_del = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.btn_dot = new System.Windows.Forms.Button();
            this.btn_plus = new System.Windows.Forms.Button();
            this.btn_equal = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn_sub = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn_div = new System.Windows.Forms.Button();
            this.btn_multi = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.deg = new System.Windows.Forms.RadioButton();
            this.rad = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox1.Location = new System.Drawing.Point(12, 20);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(342, 69);
            this.textBox1.TabIndex = 0;
            // 
            // btn_cos
            // 
            this.btn_cos.BackColor = System.Drawing.SystemColors.GrayText;
            this.btn_cos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cos.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_cos.Location = new System.Drawing.Point(255, 106);
            this.btn_cos.Name = "btn_cos";
            this.btn_cos.Size = new System.Drawing.Size(75, 47);
            this.btn_cos.TabIndex = 53;
            this.btn_cos.Text = "cos";
            this.btn_cos.UseVisualStyleBackColor = false;
            this.btn_cos.Click += new System.EventHandler(this.btn_cos_Click);
            // 
            // btn_sin
            // 
            this.btn_sin.BackColor = System.Drawing.SystemColors.GrayText;
            this.btn_sin.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sin.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_sin.Location = new System.Drawing.Point(174, 106);
            this.btn_sin.Name = "btn_sin";
            this.btn_sin.Size = new System.Drawing.Size(75, 47);
            this.btn_sin.TabIndex = 52;
            this.btn_sin.Text = "sin";
            this.btn_sin.UseVisualStyleBackColor = false;
            this.btn_sin.Click += new System.EventHandler(this.btn_sin_Click);
            // 
            // btn_log
            // 
            this.btn_log.BackColor = System.Drawing.SystemColors.GrayText;
            this.btn_log.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_log.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_log.Location = new System.Drawing.Point(93, 173);
            this.btn_log.Name = "btn_log";
            this.btn_log.Size = new System.Drawing.Size(75, 54);
            this.btn_log.TabIndex = 51;
            this.btn_log.Text = "log";
            this.btn_log.UseVisualStyleBackColor = false;
            this.btn_log.Click += new System.EventHandler(this.btn_log_Click);
            // 
            // btnsquare
            // 
            this.btnsquare.BackColor = System.Drawing.SystemColors.GrayText;
            this.btnsquare.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsquare.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnsquare.Location = new System.Drawing.Point(174, 173);
            this.btnsquare.Name = "btnsquare";
            this.btnsquare.Size = new System.Drawing.Size(75, 54);
            this.btnsquare.TabIndex = 50;
            this.btnsquare.Text = "x^2";
            this.btnsquare.UseVisualStyleBackColor = false;
            this.btnsquare.Click += new System.EventHandler(this.btnsquare_Click);
            // 
            // btn_tan
            // 
            this.btn_tan.BackColor = System.Drawing.SystemColors.GrayText;
            this.btn_tan.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_tan.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_tan.Location = new System.Drawing.Point(12, 173);
            this.btn_tan.Name = "btn_tan";
            this.btn_tan.Size = new System.Drawing.Size(75, 54);
            this.btn_tan.TabIndex = 49;
            this.btn_tan.Text = "tan";
            this.btn_tan.UseVisualStyleBackColor = false;
            this.btn_tan.Click += new System.EventHandler(this.btn_tan_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.SystemColors.GrayText;
            this.btn_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_clear.Location = new System.Drawing.Point(93, 106);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 47);
            this.btn_clear.TabIndex = 48;
            this.btn_clear.Text = "C";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_del
            // 
            this.btn_del.BackColor = System.Drawing.SystemColors.GrayText;
            this.btn_del.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_del.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_del.Location = new System.Drawing.Point(12, 106);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(75, 47);
            this.btn_del.TabIndex = 47;
            this.btn_del.Text = "del";
            this.btn_del.UseVisualStyleBackColor = false;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // btn0
            // 
            this.btn0.BackColor = System.Drawing.SystemColors.GrayText;
            this.btn0.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn0.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn0.Location = new System.Drawing.Point(12, 460);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(75, 49);
            this.btn0.TabIndex = 46;
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = false;
            this.btn0.Click += new System.EventHandler(this.btn0_Click);
            // 
            // btn_dot
            // 
            this.btn_dot.BackColor = System.Drawing.SystemColors.GrayText;
            this.btn_dot.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dot.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_dot.Location = new System.Drawing.Point(93, 460);
            this.btn_dot.Name = "btn_dot";
            this.btn_dot.Size = new System.Drawing.Size(75, 49);
            this.btn_dot.TabIndex = 45;
            this.btn_dot.Text = ".";
            this.btn_dot.UseVisualStyleBackColor = false;
            this.btn_dot.Click += new System.EventHandler(this.btn_dot_Click);
            // 
            // btn_plus
            // 
            this.btn_plus.BackColor = System.Drawing.SystemColors.GrayText;
            this.btn_plus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_plus.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_plus.Location = new System.Drawing.Point(255, 387);
            this.btn_plus.Name = "btn_plus";
            this.btn_plus.Size = new System.Drawing.Size(75, 54);
            this.btn_plus.TabIndex = 44;
            this.btn_plus.Text = "+";
            this.btn_plus.UseVisualStyleBackColor = false;
            this.btn_plus.Click += new System.EventHandler(this.btn_plus_Click);
            // 
            // btn_equal
            // 
            this.btn_equal.BackColor = System.Drawing.SystemColors.GrayText;
            this.btn_equal.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_equal.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_equal.Location = new System.Drawing.Point(174, 460);
            this.btn_equal.Name = "btn_equal";
            this.btn_equal.Size = new System.Drawing.Size(156, 49);
            this.btn_equal.TabIndex = 43;
            this.btn_equal.Text = "=";
            this.btn_equal.UseVisualStyleBackColor = false;
            this.btn_equal.Click += new System.EventHandler(this.btn_equal_Click);
            // 
            // btn1
            // 
            this.btn1.BackColor = System.Drawing.SystemColors.GrayText;
            this.btn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn1.Location = new System.Drawing.Point(12, 387);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(75, 54);
            this.btn1.TabIndex = 42;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = false;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn2
            // 
            this.btn2.BackColor = System.Drawing.SystemColors.GrayText;
            this.btn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn2.Location = new System.Drawing.Point(93, 387);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(75, 54);
            this.btn2.TabIndex = 41;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = false;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // btn_sub
            // 
            this.btn_sub.BackColor = System.Drawing.SystemColors.GrayText;
            this.btn_sub.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sub.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_sub.Location = new System.Drawing.Point(255, 317);
            this.btn_sub.Name = "btn_sub";
            this.btn_sub.Size = new System.Drawing.Size(75, 56);
            this.btn_sub.TabIndex = 40;
            this.btn_sub.Text = "-";
            this.btn_sub.UseVisualStyleBackColor = false;
            this.btn_sub.Click += new System.EventHandler(this.btn_sub_Click);
            // 
            // btn3
            // 
            this.btn3.BackColor = System.Drawing.SystemColors.GrayText;
            this.btn3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn3.Location = new System.Drawing.Point(174, 387);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(75, 54);
            this.btn3.TabIndex = 39;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = false;
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            // 
            // btn4
            // 
            this.btn4.BackColor = System.Drawing.SystemColors.GrayText;
            this.btn4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn4.Location = new System.Drawing.Point(12, 317);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(75, 56);
            this.btn4.TabIndex = 38;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = false;
            this.btn4.Click += new System.EventHandler(this.btn4_Click);
            // 
            // btn5
            // 
            this.btn5.BackColor = System.Drawing.SystemColors.GrayText;
            this.btn5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn5.Location = new System.Drawing.Point(93, 317);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(75, 56);
            this.btn5.TabIndex = 37;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = false;
            this.btn5.Click += new System.EventHandler(this.btn5_Click);
            // 
            // btn_div
            // 
            this.btn_div.BackColor = System.Drawing.SystemColors.GrayText;
            this.btn_div.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_div.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_div.Location = new System.Drawing.Point(255, 173);
            this.btn_div.Name = "btn_div";
            this.btn_div.Size = new System.Drawing.Size(75, 54);
            this.btn_div.TabIndex = 36;
            this.btn_div.Text = "/";
            this.btn_div.UseVisualStyleBackColor = false;
            this.btn_div.Click += new System.EventHandler(this.btn_div_Click);
            // 
            // btn_multi
            // 
            this.btn_multi.BackColor = System.Drawing.SystemColors.GrayText;
            this.btn_multi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_multi.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_multi.Location = new System.Drawing.Point(255, 242);
            this.btn_multi.Name = "btn_multi";
            this.btn_multi.Size = new System.Drawing.Size(75, 51);
            this.btn_multi.TabIndex = 35;
            this.btn_multi.Text = "x";
            this.btn_multi.UseVisualStyleBackColor = false;
            this.btn_multi.Click += new System.EventHandler(this.btn_multi_Click);
            // 
            // btn6
            // 
            this.btn6.BackColor = System.Drawing.SystemColors.GrayText;
            this.btn6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn6.Location = new System.Drawing.Point(174, 317);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(75, 56);
            this.btn6.TabIndex = 34;
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = false;
            this.btn6.Click += new System.EventHandler(this.btn6_Click);
            // 
            // btn9
            // 
            this.btn9.BackColor = System.Drawing.SystemColors.GrayText;
            this.btn9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn9.Location = new System.Drawing.Point(174, 242);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(75, 51);
            this.btn9.TabIndex = 33;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = false;
            this.btn9.Click += new System.EventHandler(this.btn9_Click);
            // 
            // btn8
            // 
            this.btn8.BackColor = System.Drawing.SystemColors.GrayText;
            this.btn8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn8.Location = new System.Drawing.Point(93, 242);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(75, 51);
            this.btn8.TabIndex = 32;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = false;
            this.btn8.Click += new System.EventHandler(this.btn8_Click);
            // 
            // btn7
            // 
            this.btn7.BackColor = System.Drawing.SystemColors.GrayText;
            this.btn7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn7.Location = new System.Drawing.Point(12, 242);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(75, 51);
            this.btn7.TabIndex = 31;
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = false;
            this.btn7.Click += new System.EventHandler(this.btn7_Click);
            // 
            // deg
            // 
            this.deg.AutoSize = true;
            this.deg.BackColor = System.Drawing.SystemColors.GrayText;
            this.deg.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deg.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.deg.Location = new System.Drawing.Point(360, 68);
            this.deg.Name = "deg";
            this.deg.Size = new System.Drawing.Size(82, 21);
            this.deg.TabIndex = 54;
            this.deg.TabStop = true;
            this.deg.Text = "Degree";
            this.deg.UseVisualStyleBackColor = false;
            this.deg.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rad
            // 
            this.rad.AutoSize = true;
            this.rad.BackColor = System.Drawing.SystemColors.GrayText;
            this.rad.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.rad.Location = new System.Drawing.Point(360, 119);
            this.rad.Name = "rad";
            this.rad.Size = new System.Drawing.Size(80, 21);
            this.rad.TabIndex = 55;
            this.rad.TabStop = true;
            this.rad.Text = "Radian";
            this.rad.UseVisualStyleBackColor = false;
            // 
            // Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(510, 540);
            this.Controls.Add(this.rad);
            this.Controls.Add(this.deg);
            this.Controls.Add(this.btn_cos);
            this.Controls.Add(this.btn_sin);
            this.Controls.Add(this.btn_log);
            this.Controls.Add(this.btnsquare);
            this.Controls.Add(this.btn_tan);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_del);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btn_dot);
            this.Controls.Add(this.btn_plus);
            this.Controls.Add(this.btn_equal);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn_sub);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn_div);
            this.Controls.Add(this.btn_multi);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.textBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.InfoText;
            this.Name = "Calculator";
            this.Text = "Scientific Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_cos;
        private System.Windows.Forms.Button btn_sin;
        private System.Windows.Forms.Button btn_log;
        private System.Windows.Forms.Button btnsquare;
        private System.Windows.Forms.Button btn_tan;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btn_dot;
        private System.Windows.Forms.Button btn_plus;
        private System.Windows.Forms.Button btn_equal;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn_sub;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn_div;
        private System.Windows.Forms.Button btn_multi;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.RadioButton deg;
        private System.Windows.Forms.RadioButton rad;
    }
}

