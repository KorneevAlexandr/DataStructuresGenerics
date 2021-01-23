using System;
using System.Reflection;

namespace DataStructuresGenerics
{

    /// <summary>
    /// Location of the node relative to the parent
    /// </summary>
    public enum Side
    {
        Left,
        Right
    }

   /// <summary>
   /// Node binary tree
   /// </summary>
   /// <typeparam name="T">type for key</typeparam>
   /// <typeparam name="U">type for value</typeparam>
    public class BinaryTreeNode<T, U> where T : IComparable // where U : IComparable
    {
        /// <summary>
        /// Constructor for node initialization
        /// </summary>
        /// <param name="key">key for add in tree</param>
        /// <param name="name">name student</param>
        /// <param name="nameTest">name test</param>
        /// <param name="date">date test</param>
        /// <param name="mark">mark student</param>
        public BinaryTreeNode(T key, U name, U nameTest, U date, T mark)
        {
            Key = key;
            Name = name;
            NameTest = nameTest;
            Date = date;
            Mark = mark;
        }

        /// <summary>
        /// Key for add in tree
        /// </summary>
        public T Key { get; set; }

        /// <summary>
        /// Date test
        /// </summary>
        public U Date { get; set; }
        /// <summary>
        /// Name student
        /// </summary>
        public U Name { get; set; }
        /// <summary>
        /// Name test
        /// </summary>
        public U NameTest { get; set; }
        /// <summary>
        /// Mark student
        /// </summary>
        public T Mark { get; set; }

        /// <summary>
        /// Left node
        /// </summary>
        public BinaryTreeNode<T, U> LeftNode { get; set; }

        /// <summary>
        /// Right node
        /// </summary>
        public BinaryTreeNode<T, U> RightNode { get; set; }

        /// <summary>
        /// Parent this node
        /// </summary>
        public BinaryTreeNode<T, U> ParentNode { get; set; }

        /// <summary>
        /// Location of a node relative to its parent
        /// </summary>
        public Side? NodeSide()
        {
            if (ParentNode == null)
                return null;
            else
            {
                if (ParentNode.LeftNode == this)
                    return Side.Left;
                else
                    return Side.Right;
            }

        }

        /// <summary>
        /// Convert object to string
        /// </summary>
        /// <returns>Data about student (node)</returns>
        public override string ToString() => String.Concat(Key.ToString(), "  ", Name.ToString(), "  ",
            NameTest.ToString(), "  ", Date.ToString(), "  ", Mark.ToString());

        /// <summary>
        /// comparison of two objects
        /// </summary>
        /// <param name="obj">objects for comparison</param>
        /// <returns>true or false</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            BinaryTreeNode<T, U> Btr = (BinaryTreeNode<T, U>)obj;
            if (Btr.ToString() == ToString() && ParentNode == Btr.ParentNode
                && LeftNode == Btr.LeftNode && RightNode == Btr.RightNode
                && NodeSide() == Btr.NodeSide())
                return true;
            return false;
        }

        /// <summary>
        /// Hash-method
        /// </summary>
        /// <returns>Numerous properties</returns>
        public override int GetHashCode()
        {
            PropertyInfo[] props = GetType().GetProperties();
            return props.Length;
        }

    }
}



