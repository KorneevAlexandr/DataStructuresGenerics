using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructuresGenerics;

namespace GenericsTest
{
	/// <summary>
	/// Testing node (root) binary tree
	/// </summary>
	[TestClass]
	public class TestRootTree
	{
		/// <summary>
		/// Comparision two same node
		/// </summary>
		[TestMethod]
		public void CreateRootNullChildren()
		{
			var binaryTree = new BinaryTree<int, string>();
			binaryTree.Add(8, "Александр", "ООП", "20.07.2020", 7);

			var binaryNode = new BinaryTreeNode<int, string>(8, "Александр", "ООП", "20.07.2020", 7);

			var expect = true;
			var actual = binaryTree.RootNode.Equals(binaryNode);

			Assert.AreEqual(binaryTree.RootNode, binaryNode);
			Assert.AreEqual(expect, actual);
			Assert.AreEqual(binaryTree.RootNode.ToString(), binaryNode.ToString());
			Assert.AreEqual(binaryTree.RootNode.GetHashCode(), binaryNode.GetHashCode());
		}

		/// <summary>
		/// Testing convert in strok
		/// </summary>
		[TestMethod]
		public void CheckToString()
		{
			var binaryNode = new BinaryTreeNode<int, string>(8, "Александр", "ООП", "20.07.2020", 7);

			var expect = "8  Александр  ООП  20.07.2020  7";
			var actual = binaryNode.ToString();

			Assert.AreEqual(expect, actual);
		}

		/// <summary>
		/// Testing on children
		/// </summary>
		[TestMethod]
		public void CheckChildrenSimpleNode()
		{
			var binaryNode = new BinaryTreeNode<int, string>(8, "Александр", "ООП", "20.07.2020", 7);

			Assert.IsNull(binaryNode.ParentNode);
			Assert.IsNull(binaryNode.RightNode);
			Assert.IsNull(binaryNode.LeftNode);
		}

	}
}
