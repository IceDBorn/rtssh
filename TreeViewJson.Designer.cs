using System.ComponentModel;

namespace rtssh
{
    partial class TreeViewJson
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.jsonTreeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // jsonTreeView
            // 
            this.jsonTreeView.Location = new System.Drawing.Point(12, 12);
            this.jsonTreeView.Name = "jsonTreeView";
            this.jsonTreeView.PathSeparator = ",";
            this.jsonTreeView.Size = new System.Drawing.Size(568, 261);
            this.jsonTreeView.TabIndex = 0;
            this.jsonTreeView.DoubleClick += new System.EventHandler(this.jsonTreeView_DoubleClick);
            // 
            // TreeViewJson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 285);
            this.Controls.Add(this.jsonTreeView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TreeViewJson";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Double click green temp value to print";
            this.TopMost = true;
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TreeView jsonTreeView;

        #endregion
    }
}