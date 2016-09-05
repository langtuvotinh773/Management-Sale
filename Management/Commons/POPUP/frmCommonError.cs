﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Management.Commons.Popup
{
    public partial class frmCommonError : Form
    {
        public frmCommonError(string message)
        {
            InitializeComponent();
            txtMessage.Text = message;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
