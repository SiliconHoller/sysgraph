namespace SystemMap.Ui.DbExplorer
{
    partial class DbExtractionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.exploreButton = new System.Windows.Forms.Button();
            this.dbComboBox = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.loginControl = new SystemMap.Ui.Desktop.db.SqlServerAuthControl();
            this.nodeListPanel = new SystemMap.Ui.Desktop.db.NodeListPanel();
            this.connListPanel = new SystemMap.Ui.Desktop.db.ConnectionListPanel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.connectButton);
            this.groupBox1.Controls.Add(this.loginControl);
            this.groupBox1.Location = new System.Drawing.Point(5, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(551, 182);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login Credentials";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(474, 154);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 27);
            this.connectButton.TabIndex = 1;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.exploreButton);
            this.groupBox2.Controls.Add(this.dbComboBox);
            this.groupBox2.Location = new System.Drawing.Point(6, 214);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(550, 62);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Databases";
            // 
            // exploreButton
            // 
            this.exploreButton.Location = new System.Drawing.Point(363, 22);
            this.exploreButton.Name = "exploreButton";
            this.exploreButton.Size = new System.Drawing.Size(181, 24);
            this.exploreButton.TabIndex = 1;
            this.exploreButton.Text = "Extract Data";
            this.exploreButton.UseVisualStyleBackColor = true;
            this.exploreButton.Click += new System.EventHandler(this.exploreButton_Click);
            // 
            // dbComboBox
            // 
            this.dbComboBox.FormattingEnabled = true;
            this.dbComboBox.Location = new System.Drawing.Point(6, 22);
            this.dbComboBox.Name = "dbComboBox";
            this.dbComboBox.Size = new System.Drawing.Size(278, 21);
            this.dbComboBox.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(5, 285);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(621, 408);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.nodeListPanel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(613, 382);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Objects";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.connListPanel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(613, 382);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Relationships";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(638, 279);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.saveButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 699);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(638, 30);
            this.panel2.TabIndex = 4;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(522, 3);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(95, 26);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // loginControl
            // 
            this.loginControl.Location = new System.Drawing.Point(6, 19);
            this.loginControl.Name = "loginControl";
            this.loginControl.Size = new System.Drawing.Size(337, 153);
            this.loginControl.TabIndex = 0;
            // 
            // nodeListPanel
            // 
            this.nodeListPanel.AutoSize = true;
            this.nodeListPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.nodeListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nodeListPanel.Location = new System.Drawing.Point(3, 3);
            this.nodeListPanel.Name = "nodeListPanel";
            this.nodeListPanel.Size = new System.Drawing.Size(607, 376);
            this.nodeListPanel.TabIndex = 0;
            // 
            // connListPanel
            // 
            this.connListPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.connListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connListPanel.Location = new System.Drawing.Point(3, 3);
            this.connListPanel.Name = "connListPanel";
            this.connListPanel.Size = new System.Drawing.Size(607, 376);
            this.connListPanel.TabIndex = 0;
            // 
            // DbExtractionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 729);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Name = "DbExtractionForm";
            this.Text = "Sysgraph DB Import";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Desktop.db.SqlServerAuthControl loginControl;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button exploreButton;
        private System.Windows.Forms.ComboBox dbComboBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Desktop.db.NodeListPanel nodeListPanel;
        private Desktop.db.ConnectionListPanel connListPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button saveButton;
    }
}

