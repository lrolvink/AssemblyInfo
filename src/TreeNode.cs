using System;
using System.Collections.Generic;
using System.Text;

namespace LRolvink.AssemblyInfo
{
    /// <summary>
    /// Represents a node of a tree structure.
    /// </summary>
    /// <typeparam name="TName">The type of the name.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    public class TreeNode<TName, TValue>
    {
        /// <summary>
        /// Gets or sets the name of the node.
        /// </summary>
        public TName Name { get; set; }

        /// <summary>
        /// Gets or sets the value of the node.
        /// </summary>
        public TValue Value { get; set; }

        /// <summary>
        /// Gets or sets the parent node for this node.
        /// </summary>
        public TreeNode<TName, TValue> Parent { get; set; }

        /// <summary>
        /// Gets or sets the children nodes of this node.
        /// </summary>
        public ICollection<TreeNode<TName, TValue>> Children { get; set; }

        /// <summary>
        /// Initializes a new instance of a node with the specified name and value.
        /// </summary>
        /// <param name="name">The object used as name.</param>
        /// <param name="value">The object used as value.</param>
        public TreeNode(TName name, TValue value)
        {
            Name = name;
            Value = value;
            Children = new LinkedList<TreeNode<TName, TValue>>();
        }

        /// <summary>
        /// Addes a child node for this node.
        /// </summary>
        /// <param name="name">The object used as name.</param>
        /// <param name="value">The object used as value.</param>
        public TreeNode<TName, TValue> AddChild(TName name, TValue value)
        {
            TreeNode<TName, TValue> child = new TreeNode<TName, TValue>(name, value);
            child.Parent = this;
            Children.Add(child);
            return child;
        }

        /// <summary>
        /// Has this node children.
        /// </summary>
        /// <returns>Retruns a boolean that indicates if there are children or not.</returns>
        public bool HasChildren
        {
            get
            {
                return Children.Count > 0;
            }
        }

        /// <summary>
        /// Put a treenode structure to a textual representation.
        /// </summary>
        /// <param name="treeNodes">A collection of tree nodes.</param>
        /// <returns>Returns a textual representation of the given tree node collection.</returns>
        public static string TreeToString(ICollection<TreeNode<TName, TValue>> treeNodes)
        {
            return TreeToString(treeNodes, string.Empty);
        }

        private static string TreeToString(ICollection<TreeNode<TName, TValue>> treeNodes, string indent)
        {
            if (treeNodes == null) throw new ArgumentNullException("treeNodes");

            StringBuilder stringBuilder = new StringBuilder();

            foreach (TreeNode<TName, TValue> child in treeNodes)
            {
                stringBuilder.Append(TreeToString(child, indent));
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Put a treenode structure to a textual representation.
        /// </summary>
        /// <param name="treeNodes">A tree node.</param>
        /// <returns>Returns a textual representation of the given tree node.</returns>
        public static string TreeToString(TreeNode<TName, TValue> treeNode)
        {
            return TreeToString(treeNode, string.Empty);
        }

        private static string TreeToString(TreeNode<TName, TValue> treeNode, string indent)
        {
            if (treeNode == null) throw new ArgumentNullException("treeNode");

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(indent + treeNode.Name + " : " + treeNode.Value).AppendLine();

            if (treeNode.HasChildren)
            {
                indent += "\t";
                foreach (TreeNode<TName, TValue> child in treeNode.Children)
                {
                    stringBuilder.Append(TreeToString(child, indent));
                }
            }

            return stringBuilder.ToString();
        }
    }
}
