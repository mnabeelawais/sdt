﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double preCGPA = Convert.ToDouble(textBox1.Text);
            double preCr = Convert.ToDouble(textBox4.Text);
            double newSGPA = Convert.ToDouble(textBox3.Text);
            double newCr = Convert.ToDouble(textBox2.Text);

            textBox5.Text = (((preCGPA * preCr) + (newSGPA * newCr)) / (preCr + newCr)).ToString();



        }
    }
}
