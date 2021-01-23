using System;
using System.Reflection;
using System.Text;

namespace DataStructuresGenerics
{
    /// <summary>
    /// Binary tree
    /// </summary>
    /// <typeparam name="T">type for key</typeparam>
    /// <typeparam name="U">type for data</typeparam>
    public class BinaryTree<T, U> where T : IComparable
    {
        /// <summary>
        /// Root binary tree
        /// </summary>
        public BinaryTreeNode<T, U> RootNode { get; set; }


        /// <summary>
        /// Add new node in tree
        /// </summary>
        /// <param name="node">new node</param>
        /// <param name="currentNode">this node</param>
        /// <returns>node</returns>
        private BinaryTreeNode<T, U> Add(BinaryTreeNode<T, U> node, BinaryTreeNode<T, U> currentNode = null)
        {
            if (RootNode == null)
            {
                node.ParentNode = null;
                return RootNode = node;
            }

            currentNode = currentNode ?? RootNode;
            node.ParentNode = currentNode;

            if (node.Key.CompareTo(currentNode.Key) == 0)
                return currentNode;
            else if (node.Key.CompareTo(currentNode.Key) < 0)
            {
                if (currentNode.LeftNode == null)
                    return currentNode.LeftNode = node;
                else
                    return Add(node, currentNode.LeftNode);
            }
            else
            {
                if (currentNode.RightNode == null)
                    return currentNode.RightNode = node;
                else
                    return Add(node, currentNode.RightNode);
            }
        }

        /// <summary>
        /// Add new node in tree
        /// </summary>
        /// <param name="key">Key node</param>
        /// <param name="name">Name student</param>
        /// <param name="nameTest">Name test</param>
        /// <param name="date">Date test</param>
        /// <param name="mark">Mark student</param>
        /// <returns>Node</returns>
        public BinaryTreeNode<T, U> Add(T key, U name, U nameTest, U date, T mark)
        {
            return Add(new BinaryTreeNode<T, U>(key, name, nameTest, date, mark));
        }

        /// <summary>
        /// Search node by key
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="startWithNode">Begin node</param>
        /// <returns>Node with key</returns>
        public BinaryTreeNode<T, U> FindNode(T key, BinaryTreeNode<T, U> startWithNode = null)
        {
            startWithNode = startWithNode ?? RootNode;

            if (key.CompareTo(startWithNode.Key) == 0)
                return startWithNode;
            else if (key.CompareTo(startWithNode.Key) < 0)
            {
                if (startWithNode.LeftNode == null)
                    return null;
                else
                    return FindNode(key, startWithNode.LeftNode);
            }
            else
            {
                if (startWithNode.RightNode == null)
                    return null;
                else
                    return FindNode(key, startWithNode.RightNode);
            }
        }

        /// <summary>
        /// Delete node tree
        /// </summary>
        /// <param name="key">Key node</param>
        public void Remove(T key)
        {
            var foundNode = FindNode(key);
            Remove(foundNode);
        }

        /// <summary>
        /// Delete node tree
        /// </summary>
        /// <param name="node">Node for delete</param>
        public void Remove(BinaryTreeNode<T, U> node)
        {
            if (node == null)
                return;

            Side? currentNodeSide = node.NodeSide();
            // if node haven't childrens
            if (node.LeftNode == null && node.RightNode == null)
            {
                if (currentNodeSide == Side.Left)
                    node.ParentNode.LeftNode = null;
                else
                    node.ParentNode.RightNode = null;
            }
            // if node haven't left children, rigth -> removable node
            else if (node.LeftNode == null)
            {
                if (currentNodeSide == Side.Left)
                    node.ParentNode.LeftNode = node.RightNode;
                else
                    node.ParentNode.RightNode = node.RightNode;

                node.RightNode.ParentNode = node.ParentNode;
            }
            // if node haven't right children, left -> removable node
            else if (node.RightNode == null)
            {
                if (currentNodeSide == Side.Left)
                    node.ParentNode.LeftNode = node.LeftNode;
                else
                    node.ParentNode.RightNode = node.LeftNode;

                node.LeftNode.ParentNode = node.ParentNode;
            }
            // if node have two children, right -> removable node, left -> right node
            else 
                RightToUp_LeftToRight(node, currentNodeSide);
        }

        /// <summary>
        /// The method of setting the left node in place of the removed one 
        /// and setting the left in place of the right
        /// </summary>
        /// <param name="node">Node</param>
        /// <param name="currentNodeSide">Location of the node relative to the parent</param>
        private void RightToUp_LeftToRight(BinaryTreeNode<T, U> node, Side? currentNodeSide)
        {
            switch (currentNodeSide)
            {
                case Side.Left:
                    node.ParentNode.LeftNode = node.RightNode;
                    node.RightNode.ParentNode = node.ParentNode;
                    Add(node.LeftNode, node.RightNode);
                    break;
                case Side.Right:
                    node.ParentNode.RightNode = node.RightNode;
                    node.RightNode.ParentNode = node.ParentNode;
                    Add(node.LeftNode, node.RightNode);
                    break;
                default:
                    var bufLeft = node.LeftNode;
                    var bufRightLeft = node.RightNode.LeftNode;
                    var bufRightRight = node.RightNode.RightNode;
                    node.Key = node.RightNode.Key;
                    node.RightNode = bufRightRight;
                    node.LeftNode = bufRightLeft;
                    Add(bufLeft, node);
                    break;
            }
        }

        /// <summary>
        /// Get string array consist of convert to string node
        /// </summary>
        /// <returns>String array</returns>
        public string[] GetStringMas()
        {
            return GetStringMas(new StringBuilder(), RootNode).ToString().Split('\n');
        }

        /// <summary>
        /// Private method for get string array consist of convert to string node
        /// </summary>
        /// <param name="Sb">StringBuilder with text</param>
        /// <param name="startNode">Start node (root)</param>
        /// <returns>StringBuilder with text</returns>
        private StringBuilder GetStringMas(StringBuilder Sb, BinaryTreeNode<T, U> startNode)
        {
            if (startNode != null)
            {
                Sb.Append($"{startNode}");
                Sb.AppendLine();
                //рекурсивный вызов для левой и правой веток
                GetStringMas(Sb, startNode.LeftNode);
                GetStringMas(Sb, startNode.RightNode);
            }
            return Sb;
        }

        /// <summary>
        /// Create binary tree of xml file
        /// </summary>
        public void WriteInXMLFile()
        {
            WriteXML write = new WriteXML();
            write.WriteInFile(GetStringMas());
        }

        /// <summary>
        /// Create binary tree of xml file
        /// </summary>
        /// <param name="file">Name file</param>
        public void WriteInXMLFile(string file)
        {
            WriteXML write = new WriteXML(file);
            write.WriteInFile(GetStringMas());
        }

        /// <summary>
        /// Convertatin each node binary tree in strok
        /// </summary>
        /// <param name="Sb">StringBuilder with text</param>
        /// <param name="startNode">Start node</param>
        /// <param name="indent">Indent of spaces</param>
        /// <param name="side">Location</param>
        /// <returns>StringBuilder with text</returns>
        private string StrokTree(StringBuilder Sb, BinaryTreeNode<T, U> startNode, string indent = "", Side? side = null)
        {
            if (startNode != null)
            {
                var nodeSide = side == null ? "+" : side == Side.Left ? "L" : "R";
                Sb.Append($"{indent} [{nodeSide}] - {startNode}");
                Sb.AppendLine();
                indent += new string(' ', 3);
                //рекурсивный вызов для левой и правой веток
                StrokTree(Sb, startNode.LeftNode, indent, Side.Left);
                StrokTree(Sb, startNode.RightNode, indent, Side.Right);
            }
            return Sb.ToString();
        }

        /// <summary>
        /// Convertatin object (binary tree) in string
        /// </summary>
        /// <returns>Strok</returns>
        public override string ToString()
        {
            return StrokTree(new StringBuilder(), RootNode);
        }

        /// <summary>
        /// Hash-method
        /// </summary>
        /// <returns>Numerous properties</returns>
        public override int GetHashCode()
        {
            Type t = RootNode.GetType();
            PropertyInfo[] props = t.GetProperties();
            return props.Length;
        }

    }
}

