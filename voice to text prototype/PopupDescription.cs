﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace voice_to_text_prototype
{
    public partial class PopupDescription : Form
    {
        Event eve = new Event();

        public PopupDescription(Event e)
        {
            InitializeComponent();


        }

    }
}