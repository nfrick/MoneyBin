using DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomControls {
    public partial class TreeSelector : UserControl {

        public string ItemName { get; set; }
        public string SubItemName { get; set; }

        public TreeSelector() {
            InitializeComponent();
        }

        public void LoadData(List<Tuple2Levels> items) {
            var nodeRoot = treeViewItems.Nodes[0];
            nodeRoot.Nodes.Clear();
            TreeNode nodeGrupo = null;
            foreach (var i in items) {
                if (!nodeRoot.Nodes.ContainsKey(i.Item)) {
                    nodeGrupo = nodeRoot.Nodes.Add(i.Item, i.Item);
                    nodeGrupo.Checked = true;
                }
                if (nodeGrupo == null) continue;
                var nodeCategoria = nodeGrupo.Nodes.Add(i.Key(), i.SubItem);
                nodeCategoria.Checked = true;
            }
            nodeRoot.Expand();
        }

        private void treeViewItems_AfterCheck(object sender, TreeViewEventArgs e) {
            // The code only executes if the user caused the checked state to change.
            if (e.Action == TreeViewAction.Unknown) return;
            SetChildNodes(e.Node);
            SetParentNodes(e.Node);
        }

        private void SetChildNodes(TreeNode parent) {
            if (parent.Nodes.Count == 0) return;
            foreach (TreeNode child in parent.Nodes) {
                child.Checked = parent.Checked;
                SetChildNodes(child);
            }
        }

        private void SetParentNodes(TreeNode child) {
            while (true) {
                if (child.Parent == null) return;
                child.Parent.Checked = child.Checked && child.Parent.Nodes.Cast<TreeNode>().All(n => n.Checked);
                child = child.Parent;
            }
        }

        private int CountCheckedNodes(TreeNode parent) {
            return parent.Nodes.Cast<TreeNode>().Count(child => child.Checked);
        }

        private TreeNode GetUniquedNode(TreeNode parent, bool status) {
            return parent.Nodes.Cast<TreeNode>().FirstOrDefault(child => child.Checked == status);
        }

        public bool IsSingleLevel(int level) {
            var root = treeViewItems.Nodes[0];
            if (level == 1) {
                var checkedNodes = CountCheckedNodes(root);
                switch (checkedNodes) {
                    case 0:
                        var counter = 0;
                        foreach (TreeNode child in root.Nodes) {
                            if (!child.Nodes.Cast<TreeNode>().Any(grandchild => grandchild.Checked)) continue;
                            counter++;
                            if (counter > 1)
                                return false;
                        }
                        return (counter == 1);
                    case 1:
                        return true;
                    default:
                        return false;
                }
            }
            string item = null;
            foreach (TreeNode child in root.Nodes) {
                foreach (TreeNode grandchild in child.Nodes) {
                    if (!grandchild.Checked) continue;
                    if (item == null)
                        item = grandchild.Text;
                    else if (!item.Equals(grandchild.Text))
                        return false;
                }
            }
            return true;
        }

        public string GetQuery() {
            var nodeRoot = treeViewItems.Nodes[0];
            if (nodeRoot.Checked) return string.Empty;

            var sb = new StringBuilder("", 200);
            var checkedItems = new List<string>();
            foreach (TreeNode nodeItem in nodeRoot.Nodes) {
                if (nodeItem.Checked)
                    checkedItems.Add(nodeItem.Text);
                else {
                    var SubItemsCount = CountCheckedNodes(nodeItem);
                    if (SubItemsCount <= 0) continue;
                    var sb1 = new StringBuilder(200);
                    sb.AppendFormat("({0} = '{1}' AND ", ItemName, nodeItem.Name);
                    if (SubItemsCount == 1)
                        sb1.AppendFormat("{0} = '{1}' ", SubItemName, GetUniquedNode(nodeItem, true).Text);

                    else if (SubItemsCount == nodeItem.Nodes.Count - 1)
                        sb1.AppendFormat("NOT {0} = '{1}' ", SubItemName, GetUniquedNode(nodeItem, false).Text);

                    else {
                        sb1.Append(SubItemName).Append(" ");
                        if (SubItemsCount > nodeItem.Nodes.Count / 2) {
                            sb1.Append("NOT ");
                        }
                        sb1.Append("IN ('")
                            .Append(string.Join("','", 
                                nodeItem.Nodes.Cast<TreeNode>().Where(n => n.Checked).Select(n=>n.Text)))
                            .Append("')");
                    }
                    sb.Append(sb1).Append(") OR ");
                }
            }
            if (sb.Length > 0 && checkedItems.Count == 0)
                sb.Remove(sb.Length - 4, 4);
            if (checkedItems.Count == 1) {
                sb.AppendFormat("{0} = '{1}'", ItemName, checkedItems[0]);
            }
            else if (checkedItems.Count == nodeRoot.Nodes.Count - 1) {
                sb.AppendFormat("NOT {0} = '{1}'", ItemName, GetUniquedNode(nodeRoot, false).Text);
            }
            else if (checkedItems.Count > 1) {
                sb.Append(ItemName).Append(" IN ('")
                    .Append(string.Join("','", checkedItems))
                    .Append("')");
            }
            return sb.ToString();
        }
    }
}
