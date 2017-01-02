﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemMap.Models.Transform.db;

namespace SystemMap.Ui.Desktop.db
{
    public partial class ConnectionListPanel : UserControl
    {
        public ConnectionListPanel()
        {
            InitializeComponent();
        }

        public void ShowRelationships(List<DataConnection> connList)
        {
            connListBox.DataSource = connList;
        }
    }
}
