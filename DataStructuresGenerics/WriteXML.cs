using System;
using System.Xml;

namespace DataStructuresGenerics
{
	/// <summary>
	/// Write xml file
	/// </summary>
	public class WriteXML
	{
		/// <summary>
		/// Name file for write
		/// </summary>
		private string filename;

		/// <summary>
		/// Empty constructor 
		/// </summary>
		public WriteXML()
		{
			filename = "NewStudents.xml";

		}

		/// <summary>
		/// Constryctor with name file
		/// </summary>
		/// <param name="file">name file</param>
		public WriteXML(string file)
		{
			filename = file;
		}

		/// <summary>
		/// Write in file
		/// </summary>
		/// <param name="masValue">Array with arrays for write</param>
		public void WriteInFile(string[][] masValue)
		{
			XmlWriter xmlWriter = XmlWriter.Create(filename);

			xmlWriter.WriteStartDocument();
			xmlWriter.WriteStartElement("ListStudents");

			for (int i = 0; i < masValue.Length - 1; i++)
			{
				xmlWriter.WriteStartElement("Student");
				xmlWriter.WriteAttributeString("Key", masValue[i][0]);
				xmlWriter.WriteAttributeString("Name", masValue[i][1]);
				xmlWriter.WriteAttributeString("NameTest", masValue[i][2]);
				xmlWriter.WriteAttributeString("Date", masValue[i][3]);
				xmlWriter.WriteAttributeString("Mark", masValue[i][4]);
				xmlWriter.WriteEndElement();
			}

			xmlWriter.WriteEndDocument();
			xmlWriter.Close();
		}

		/// <summary>
		/// Write in file (for user)
		/// </summary>
		/// <param name="value">Strok array</param>
		public void WriteInFile(string[] value)
		{
			string[][] masValue = new string[value.Length][];
			for (int i = 0; i < value.Length; i++)
				masValue[i] = value[i].Trim().Split(new string[1] { "  " }, StringSplitOptions.None);
			WriteInFile(masValue);
		}

	}
}


