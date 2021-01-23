using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructuresGenerics;

namespace GenericsTest
{
	/// <summary>
	/// Testing binaru tree
	/// </summary>
	[TestClass]
	public class TestTree
	{
		/// <summary>
		/// Testing branches binary tree
		/// </summary>
		[TestMethod]
		public void CreateBinaryTreeNullChildren()
		{
			var binaryTree = new BinaryTree<int, string>();
			binaryTree.Add(8, "Александр", "ООП", "20.07.2020", 7);
			binaryTree.Add(3, "Игорь", "ООП", "20.07.2020", 5);
			binaryTree.Add(10, "Виталий", "ООП", "20.07.2020", 8);

			Assert.IsNotNull(binaryTree.RootNode.LeftNode);
		}

		/// <summary>
		/// Testing method add (same node)
		/// </summary>
		[TestMethod]
		public void CreateBinaryTreeSameChildren()
		{
			var binaryTree = new BinaryTree<int, string>();
			binaryTree.Add(8, "Александр", "ООП", "20.07.2020", 7);
			// same keys
			binaryTree.Add(3, "Вася", "ООП", "20.07.2020", 6);
			binaryTree.Add(3, "Игорь", "ООП", "20.07.2020", 5);

			Assert.IsNull(binaryTree.RootNode.RightNode);
		}

		/// <summary>
		/// Testing adding a lot of nodes
		/// </summary>
		[TestMethod]
		public void CreateComplexBinaryTreeNullChildren()
		{
			var binaryTree = new BinaryTree<int, string>();
			binaryTree.Add(8, "Александр", "ООП", "20.07.2020", 7);
			binaryTree.Add(3, "Игорь", "ООП", "220.07.2020", 5);
			binaryTree.Add(10, "Валентин", "ООП", "20.07.2020", 8);
			binaryTree.Add(1, "Григорий", "КС", "20.07.2020", 9);
			binaryTree.Add(6, "Ирина", "КС", "20.07.2020", 8);
			binaryTree.Add(14, "Анастасия", "КС", "20.07.2020", 2);
			binaryTree.Add(4, "Игорь", "ООП", "20.07.2020", 5);
			binaryTree.Add(7, "Константин", "ООП", "20.07.2020", 6);
			binaryTree.Add(13, "Тимофей", "ООП", "20.07.2020", 4);

			BinaryTreeNode<int, string>[] Students = new BinaryTreeNode<int, string>[3];
			Students[0] = new BinaryTreeNode<int, string>(4, "Игорь", "ООП", "20.07.2020", 5);
			Students[1] = new BinaryTreeNode<int, string>(7, "Константин", "ООП", "20.07.2020", 6);
			Students[2] = new BinaryTreeNode<int, string>(13, "Тимофей", "ООП", "20.07.2020", 4);

			BinaryTreeNode<int, string>[] TreeStudents = new BinaryTreeNode<int, string>[3];
			TreeStudents[0] = binaryTree.RootNode.LeftNode.RightNode.LeftNode;
			TreeStudents[1] = binaryTree.RootNode.LeftNode.RightNode.RightNode;
			TreeStudents[2] = binaryTree.RootNode.RightNode.RightNode.LeftNode;

			Assert.AreEqual(Students.ToString(), TreeStudents.ToString());
		}

		/// <summary>
		/// Testing method remove by key
		/// </summary>
		[TestMethod]
		public void RemoveByKey()
		{
			var binaryTree = new BinaryTree<int, string>();
			binaryTree.Add(8, "Александр", "ООП", "20.07.2020", 7);
			binaryTree.Add(3, "Игорь", "ООП", "20.07.2020", 5);
			binaryTree.Add(10, "Виталий", "ООП", "20.07.2020", 8);
			binaryTree.Add(1, "Владимир", "ООП", "20.07.2020", 10);

			binaryTree.Remove(3);
			BinaryTreeNode<int, string> LeftChildren =
				new BinaryTreeNode<int, string>(1, "Владимир", "ООП", "20.07.2020", 10);

			Assert.AreEqual(binaryTree.RootNode.LeftNode.ToString(), LeftChildren.ToString());
		}

		/// <summary>
		/// Testing method remove by key (no key)
		/// </summary>
		[TestMethod]
		public void RemoveByDefunctKey()
		{
			var binaryTree = new BinaryTree<int, string>();
			binaryTree.Add(8, "Александр", "ООП", "20.07.2020", 7);
			binaryTree.Add(3, "Игорь", "ООП", "20.07.2020", 5);
			binaryTree.Add(10, "Виталий", "ООП", "20.07.2020", 8);
			binaryTree.Add(1, "Владимир", "ООП", "20.07.2020", 10);

			string expect = binaryTree.ToString();
			binaryTree.Remove(12);
			string actual = binaryTree.ToString();

			Assert.AreEqual(expect, actual);
		}

		/// <summary>
		/// Testing convertation in strok
		/// </summary>
		[TestMethod]
		public void CheckTreeToString()
		{
			var binaryTree = new BinaryTree<int, string>();
			binaryTree.Add(8, "Александр", "ООП", "20.07.2020", 7);
			binaryTree.Add(3, "Игорь", "ООП", "20.07.2020", 5);
			binaryTree.Add(10, "Виталий", "ООП", "20.07.2020", 8);

			StringBuilder expect = new StringBuilder();
			expect.Append(" [+] - 8  Александр  ООП  20.07.2020  7");
			expect.AppendLine();
			expect.Append("    [L] - 3  Игорь  ООП  20.07.2020  5");
			expect.AppendLine();
			expect.Append("    [R] - 10  Виталий  ООП  20.07.2020  8");
			expect.AppendLine();

			string actual = binaryTree.ToString();

			Assert.AreEqual(expect.ToString(), actual);
		}

		/// <summary>
		/// Testing hash-method
		/// </summary>
		[TestMethod]
		public void CheckTreeGetHashCode()
		{
			var binaryTree = new BinaryTree<int, string>();
			binaryTree.Add(8, "Александр", "ООП", "20.07.2020", 7);
			binaryTree.Add(3, "Игорь", "ООП", "20.07.2020", 5);

			// numerous properties in Node
			var expect = 8;
			var actual = binaryTree.GetHashCode();

			Assert.AreEqual(expect, actual);
		}

	}
}


