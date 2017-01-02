namespace SystemMap.Ui.Desktop.db
{
    partial class NodeListPanel
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
            this.nodeListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // nodeListBox
            // 
            this.nodeListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nodeListBox.FormattingEnabled = true;
            this.nodeListBox.Location = new System.Drawing.Point(0, 0);
            this.nodeListBox.Name = "nodeListBox";
            this.nodeListBox.Size = new System.Drawing.Size(536, 600);
            this.nodeListBox.TabIndex = 0;
            // 
            // NodeListPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nodeListBox);
            this.Name = "NodeListPanel";
            this.Size = new System.Drawing.Size(536, 600);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox nodeListBox;
    }
}
