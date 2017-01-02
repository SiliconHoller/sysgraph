using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemMap.Models.Transform.db;
using SystemMap.Models.Transform.db.utils;

namespace SystemMap.Ui.DbExplorer
{
    public partial class DbExtractionForm : Form
    {
        private SqlConnectionStringBuilder sqlConnBuilder;
        private DbInspector inspector;
        private DataServerStructure serverStructure;

        public DbExtractionForm()
        {
            InitializeComponent();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            sqlConnBuilder = loginControl.GetConnectionStringBuilder();
            inspector = DbInspector.GetInstance(sqlConnBuilder);
            try
            {
                serverStructure = inspector.InitStructure();
                inspector.LoadData();
                dbComboBox.DataSource = serverStructure.Databases;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void exploreButton_Click(object sender, EventArgs e)
        {
            try 
            {
                DataSourceStructure dbstruct = (DataSourceStructure)dbComboBox.SelectedValue;
                inspector.LoadDataSource(dbstruct);
                nodeListPanel.ShowNodes(dbstruct.Nodes);
                connListPanel.ShowRelationships(dbstruct.Relationships);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataSourceStructure dbstruct = (DataSourceStructure)dbComboBox.SelectedValue;
                inspector.PersistMap(dbstruct);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
