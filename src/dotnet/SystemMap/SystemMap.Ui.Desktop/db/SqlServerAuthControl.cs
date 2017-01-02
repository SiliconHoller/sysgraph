using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SystemMap.Ui.Desktop.db
{
    public partial class SqlServerAuthControl : UserControl, IDbAuthenticationControl
    {
        public SqlServerAuthControl()
        {
            InitializeComponent();
        }

        public SqlConnectionStringBuilder GetConnectionStringBuilder()
        {
            SqlConnectionStringBuilder cbuilder = new SqlConnectionStringBuilder();
            cbuilder.DataSource = serverBox.Text;
            cbuilder.IntegratedSecurity = winAuthCheckbox.Checked;
            if (!winAuthCheckbox.Checked)
            {
                cbuilder.UserID = userBox.Text;
                cbuilder.Password = passBox.Text;
            }
            return cbuilder;
        }

        private void winAuthCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            userBox.Enabled = !winAuthCheckbox.Checked;
            passBox.Enabled = !winAuthCheckbox.Checked;
        }
    }
}
