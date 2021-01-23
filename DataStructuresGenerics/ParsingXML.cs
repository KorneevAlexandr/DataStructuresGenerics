using System;
using System.Collections.Generic;
using System.Xml;

namespace DataStructuresGenerics
{
	/// <summary>
	/// Read xml file
	/// </summary>
	public class ParsingXML
	{
		/// <summary>
		/// Name file for read
		/// </summary>
		private static string filename;

		/// <summary>
		/// Empty constructor 
		/// </summary>
		public ParsingXML()
		{
			filename = "Students.xml";
		}

		/// <summary>
		/// Constryctor with name file
		/// </summary>
		/// <param name="file">name file</param>
		public ParsingXML(string file)
		{
			filename = file;
		}

		/// <summary>
		/// Static constructor
		/// </summary>
		static ParsingXML()
		{
			filename = "Students.xml";
		}

		/// <summary>
		/// Read xml file
		/// </summary>
		/// <returns>Collections strok</returns>
		private static List<string> ReadXML()
		{
			List<string> Students = new List<string>();
			XmlReader xmlReader = null;
			try
			{
				xmlReader = XmlReader.Create(filename);
			}
			catch
			{
				throw new Exception("The specified file was not found");
			}

			while (xmlReader.Read())
			{
				if (Students.Count > 0 && xmlReader.Name == "ListStudents")
					break;

				if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "Student"))
					if (xmlReader.HasAttributes)
						Students.Add(String.Concat(
							xmlReader.GetAttribute("Key"), "  ",
							xmlReader.GetAttribute("Name"), "  ",
							xmlReader.GetAttribute("NameTest"), "  ",
							xmlReader.GetAttribute("Date"), "  ",
							xmlReader.GetAttribute("Mark")));
			}

			return Students;
		}

		/// <summary>
		/// Get string array with arrays for create binary tree
		/// </summary>
		/// <returns>Array with arrays</returns>
		public static string[][] GetMasValue()
		{
			List<string> Students = ReadXML();
			string[][] mas = new string[Students.Count][];

			for (int i = 0; i < Students.Count; i++)
				mas[i] = Students[i].Split(new string[1] { "  " }, StringSplitOptions.None);

			return mas;
		}

	}
}


