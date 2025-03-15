using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            int t = textBox1.Text.Length;
            if(t>0)
            {
                textBox1.Text = textBox1.Text.Substring(0, t-1);                  
            }
            textBox1.Focus();

            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0; 
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            currentExpression += "7"; 
            textBox1.Text = currentExpression;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            currentExpression += "8"; 
            textBox1.Text = currentExpression;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            currentExpression += "9"; 
            textBox1.Text = currentExpression;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            currentExpression += "4"; 
            textBox1.Text = currentExpression;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            currentExpression += "5"; 
            textBox1.Text = currentExpression;
        }
        private void btn6_Click(object sender, EventArgs e)
        {
            currentExpression += "6"; 
            textBox1.Text = currentExpression;
        }
        
        private string currentExpression = "";
        
        private void btn1_Click(object sender, EventArgs e)
        {
            currentExpression += "1";
            textBox1.Text = currentExpression;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            currentExpression += "2"; 
            textBox1.Text = currentExpression;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            currentExpression += "3"; 
            textBox1.Text = currentExpression;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            currentExpression += "0"; 
            textBox1.Text = currentExpression;
        }

       
        private void btn_plus_Click(object sender, EventArgs e)
        {
            currentExpression += " + ";
            textBox1.Text = currentExpression;

        }
        
        private void btn_equal_Click(object sender, EventArgs e)
        {
            try
            {
               string expressionToEvaluate = currentExpression.Replace(" x ", " * ");

                if (expressionToEvaluate.Contains("/ 0"))
                {
                     MessageBox.Show("Division by zero is not allowed.");
                        currentExpression = "";
                        textBox1.Text = "";
                        return; 
                }

        
                var result = new DataTable().Compute(expressionToEvaluate, null);

                textBox1.Text = result.ToString();

                currentExpression = result.ToString();
            }

        catch (Exception ex)
         {
            MessageBox.Show("Invalid expression. Please check your input.");
            currentExpression = "";
            textBox1.Text = "";
            }


        }

        private void btn_sub_Click(object sender, EventArgs e)
        {
            currentExpression += " - ";
            textBox1.Text = currentExpression;
        }

        private void btn_multi_Click(object sender, EventArgs e)
        {
            currentExpression += " * ";
            textBox1.Text = currentExpression;
        }

        private void btn_div_Click(object sender, EventArgs e)
        {
            currentExpression += " / "; 
            textBox1.Text = currentExpression;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            currentExpression = ""; 
            textBox1.Text = ""; 
        }

        private void btn_dot_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains('.'))
            {

            }
            else {
                textBox1.Text = textBox1.Text + ".";
            }
        }

        private void btnsquare_Click(object sender, EventArgs e)
        {
            double fn;
            if (double.TryParse(textBox1.Text, out fn))
            {
                double result = Math.Pow(fn, 2);
                textBox1.Text = result.ToString();
            }
            else
             {
                MessageBox.Show("Invalid input. Please enter a valid number.");
             }

        }

        private void btn_log_Click(object sender, EventArgs e)
        {
            double fn;
            if (double.TryParse(textBox1.Text, out fn) && fn > 0) 
            {
                double result = Math.Log(fn);
                textBox1.Text = Convert.ToString(result);
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter a positive number."); 
            }
        }

        private void btn_sin_Click(object sender, EventArgs e)
        {
            double fn;
            if (double.TryParse(textBox1.Text, out fn)) 
            {
                if (deg.Checked == true)
                 {
                    double result = Math.Sin(fn * Math.PI / 180); 
                    textBox1.Text = Convert.ToString(result);
                 }
                else
                 {
                    double result = Math.Sin(fn);
                    textBox1.Text = Convert.ToString(result);
                 }
            }
            else
            {
                 MessageBox.Show("Invalid input. Please enter a valid number.");
            }
         }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_cos_Click(object sender, EventArgs e)
        {
            double fn;
            if (double.TryParse(textBox1.Text, out fn))
            {
                if (deg.Checked == true)
                {
                    double result = Math.Cos(fn * Math.PI / 180);
                    textBox1.Text = Convert.ToString(result);
                }
                else
                {
                    double result = Math.Cos(fn);
                    textBox1.Text = Convert.ToString(result);
                }
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter a valid number.");
            }
        }

        private void btn_tan_Click(object sender, EventArgs e)
        {
            double fn;
            if (double.TryParse(textBox1.Text, out fn))
            {
                if (deg.Checked == true)
                {
                    double result = Math.Tan(fn * Math.PI / 180);
                    textBox1.Text = Convert.ToString(result);
                }
                else
                {
                    double result = Math.Tan(fn);
                    textBox1.Text = Convert.ToString(result);
                }
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter a valid number.");
            }
        }
    }
}
