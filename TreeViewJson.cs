using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace rtssh
{
    public partial class TreeViewJson : Form
    {
        #region Constructor
        
        public TreeViewJson(string path)
        {
            InitializeComponent();

            try
            {
                using (var reader = new StreamReader(path))
                using (var jsonReader = new JsonTextReader(reader))
                {
                    var root = JToken.Load(jsonReader);
                    DisplayTreeView(root, Path.GetFileNameWithoutExtension(path));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        
        #endregion

        #region Events
        
        private void jsonTreeView_DoubleClick(object sender, EventArgs e)
        {
            // Get temp's json path
            if (jsonTreeView.SelectedNode.FirstNode != null ||
                jsonTreeView.SelectedNode.ForeColor != Color.Green) return;
            
            var jsonPath = JsonPathFormatter(jsonTreeView.SelectedNode.FullPath);
            LaunchForm.MainForm.SetJsonPathTextBox(jsonPath);
            Close();
        }
        
        #endregion

        #region Methods
        
        private static string JsonPathFormatter(string jsonPath)
        {
            // Remove characters before first comma and after last comma
            jsonPath = jsonPath.Substring(jsonPath.IndexOf(',') + 1);
            jsonPath = jsonPath.Substring(0, jsonPath.LastIndexOf(','));
            return jsonPath;
        }
        
        private void DisplayTreeView(JToken root, string rootName)
        {
            jsonTreeView.BeginUpdate();
            try
            {
                jsonTreeView.Nodes.Clear();
                var tNode = jsonTreeView.Nodes[jsonTreeView.Nodes.Add(new TreeNode(rootName))];
                tNode.Tag = root;

                AddNode(root, tNode);

                jsonTreeView.ExpandAll();
            }
            finally
            {
                jsonTreeView.EndUpdate();
            }
        }

        private void AddNode(JToken token, TreeNode inTreeNode)
        {
            switch (token)
            {
                case null:
                    MessageBox.Show(@"Something went wrong upon constructing JSON");
                    Close();
                    return;
                case JValue _:
                {
                    var childNode = inTreeNode.Nodes[inTreeNode.Nodes.Add(new TreeNode(token.ToString()))];
                    childNode.Tag = token;
                    
                    // Turn temp values to green
                    var errorCounter = Regex.Matches(childNode.Text,@"[a-zA-Z]").Count;
                    if (errorCounter <= 0)
                    {
                        childNode.ForeColor = Color.Green;
                    }
                    break;
                }
                case JObject jObject:
                {
                    foreach (var property in jObject.Properties())
                    {
                        var childNode = inTreeNode.Nodes[inTreeNode.Nodes.Add(new TreeNode(property.Name))];
                        childNode.Tag = property;
                        AddNode(property.Value, childNode);
                    }

                    break;
                }
                default:
                    MessageBox.Show(@"Something went wrong upon constructing JSON");
                    Close();
                    return;
            }
        }
        
        #endregion
    }
}