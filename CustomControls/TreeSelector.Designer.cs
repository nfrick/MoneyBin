namespace CustomControls {
    partial class TreeSelector {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("All");
            this.treeViewItems = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeViewItems
            // 
            this.treeViewItems.CheckBoxes = true;
            this.treeViewItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewItems.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewItems.Location = new System.Drawing.Point(0, 0);
            this.treeViewItems.Name = "treeViewItems";
            treeNode1.Checked = true;
            treeNode1.Name = "nodeRoot";
            treeNode1.Text = "All";
            this.treeViewItems.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeViewItems.Size = new System.Drawing.Size(101, 78);
            this.treeViewItems.TabIndex = 1;
            this.treeViewItems.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewItems_AfterCheck);
            // 
            // TreeSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeViewItems);
            this.Name = "TreeSelector";
            this.Size = new System.Drawing.Size(101, 78);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewItems;
    }
}
