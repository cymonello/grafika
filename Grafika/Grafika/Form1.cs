﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafika
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            VectorField v = new VectorField(new Funkcja());
            v.paint(this.panel1);
        }
    }
}
