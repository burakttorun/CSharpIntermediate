﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using(ETradeContext context = new ETradeContext()) 
            {
                dgwProducts.DataSource = context.Products.ToList(); //veri tabanındaki tabloda yer alan veriler forma aktarılır.

            }
        }
    }
}
