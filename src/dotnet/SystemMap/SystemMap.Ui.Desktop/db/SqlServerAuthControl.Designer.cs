namespace SystemMap.Ui.Desktop.db
{
    partial class SqlServerAuthControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.winAuthCheckbox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.userBox = new System.Windows.Forms.TextBox();
            this.passBox = new System.Windows.Forms.TextBox();
            this.serverBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.59819F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.40181F));
            this.tableLayoutPanel1.Controls.Add(this.winAuthCheckbox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.userBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.passBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.serverBox, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(332, 144);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sql Server Instance:  ";
            // 
            // winAuthCheckbox
            // 
            this.winAuthCheckbox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.winAuthCheckbox.AutoSize = true;
            this.winAuthCheckbox.Location = new System.Drawing.Point(144, 36);
            this.winAuthCheckbox.Name = "winAuthCheckbox";
            this.winAuthCheckbox.Size = new System.Drawing.Size(141, 17);
            this.winAuthCheckbox.TabIndex = 1;
            this.winAuthCheckbox.Text = "Windows Authentication";
            this.winAuthCheckbox.UseVisualStyleBackColor = true;
            this.winAuthCheckbox.CheckedChanged += new System.EventHandler(this.winAuthCheckbox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "User Name:  ";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password:  ";
            // 
            // userBox
            // 
            this.userBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.userBox.Location = new System.Drawing.Point(144, 76);
            this.userBox.Name = "userBox";
            this.userBox.Size = new System.Drawing.Size(185, 20);
            this.userBox.TabIndex = 4;
            this.userBox.UseSystemPasswordChar = true;
            // 
            // passBox
            // 
            this.passBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.passBox.Location = new System.Drawing.Point(144, 116);
            this.passBox.Name = "passBox";
            this.passBox.Size = new System.Drawing.Size(185, 20);
            this.passBox.TabIndex = 5;
            // 
            // serverBox
            // 
            this.serverBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.serverBox.Location = new System.Drawing.Point(144, 3);
            this.serverBox.Name = "serverBox";
            this.serverBox.Size = new System.Drawing.Size(185, 20);
            this.serverBox.TabIndex = 6;
            // 
            // SqlServerAuthControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SqlServerAuthControl";
            this.Size = new System.Drawing.Size(332, 144);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox winAuthCheckbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userBox;
        private System.Windows.Forms.TextBox passBox;
        private System.Windows.Forms.TextBox serverBox;
    }
}
