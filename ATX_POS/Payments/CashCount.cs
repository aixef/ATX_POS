﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATX_POS
{
    public partial class CashCount : UserControl
    {
        public CashCount()
        {
            InitializeComponent();
        }
        public void Total(string val)
        {
            FondoCajaTexto.Text = val;
        }
    }
}