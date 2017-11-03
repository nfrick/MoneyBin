using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomControls {
    public static class ExtensionMethods {
        public static string Key(this Tuple<string, string> value) {
            return value.Item1 + "-" + value.Item2;
        }
    }

    public partial class TreeSelector : UserControl {
        public string ItemName { get; set; }
        public string SubItemName { get; set; }

        public TreeSelector() {
            InitializeComponent();
        }

        public void LoadData(List<Tuple<string, string>> items) {
            var nodeRoot = treeViewItems.Nodes[0];
            nodeRoot.Nodes.Clear();
            TreeNode nodeGrupo = null;
            foreach (var i in items) {
                if (!nodeRoot.Nodes.ContainsKey(i.Item1)) {
                    nodeGrupo = nodeRoot.Nodes.Add(i.Item1, i.Item1);
                    nodeGrupo.Checked = true;
                }
                if (nodeGrupo == null) continue;
                var nodeCategoria = nodeGrupo.Nodes.Add(i.Key(), i.Item2);
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
                        item = grandchild.FullPath;
                    else if (!item.Equals(grandchild.FullPath))
                        return false;
                }
            }
            return true;
        }

        public string Query => GetQuery();

        private string GetQuery() {
            var nodeRoot = treeViewItems.Nodes[0];
            if (nodeRoot.Checked) return string.Empty;

            var sb = new StringBuilder("", 100);
            var condicoes = new List<string>();

            var rChecked = nodeRoot.Nodes.Cast<TreeNode>().Where(n => n.Checked).ToList();
            var rNotChecked = nodeRoot.Nodes.Cast<TreeNode>().Where(n => !n.Checked).ToList();
            if (rChecked.Any()) {
                if (rChecked.Count > rNotChecked.Count) {
                    sb.Append("NOT ");
                    condicoes.AddRange(rNotChecked.Select(n => n.Text));
                }
                else {
                    condicoes.AddRange(rChecked.Select(n => n.Text));
                }
                sb.Append($"{ItemName} ");
                if (condicoes.Count == 1)
                    sb.Append($"= '{condicoes[0]}'");
                else
                    sb.Append("IN ('").Append(string.Join("','", condicoes)).Append("')");
            }

            foreach (var node in rNotChecked) {
                condicoes.Clear();
                var rChecked2 = node.Nodes.Cast<TreeNode>().Where(n => n.Checked).ToList();
                if (!rChecked2.Any()) continue;

                var rNotChecked2 = node.Nodes.Cast<TreeNode>().Where(n => !n.Checked).ToList();
                if (sb.Length > 0)
                    sb.Append(" OR ");
                sb.Append($"({ItemName} = '{node.Text}' AND ");
                if (rChecked2.Count > rNotChecked2.Count) {
                    sb.Append($"NOT ");
                    condicoes.AddRange(rNotChecked2.Select(n => n.Text));
                }
                else
                    condicoes.AddRange(rChecked2.Select(n => n.Text));
                sb.Append($"{SubItemName} ");

                if (condicoes.Count == 1)
                    sb.Append($"= '{condicoes[0]}')");
                else
                    sb.Append("IN ('").Append(string.Join("','", condicoes)).Append("'))");
            }
            var sql = sb.ToString();
            return sql.Contains(" OR ") ? $"({sql})" : sql;
        }
    }
}
