namespace SystemMap.Ui.Desktop.db
{
    partial class ConnectionListPanel
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
            this.connListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // connListBox
            // 
            this.connListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connListBox.FormattingEnabled = true;
            this.connListBox.Location = new System.Drawing.Point(0, 0);
            this.connListBox.Name = "connListBox";
            this.connListBox.Size = new System.Drawing.Size(629, 699);
            this.connListBox.TabIndex = 0;
            // 
            // ConnectionListPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.connListBox);
            this.Name = "ConnectionListPanel";
            this.Size = new System.Drawing.Size(629, 699);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox connListBox;
    }
}
