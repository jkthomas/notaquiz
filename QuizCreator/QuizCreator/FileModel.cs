using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QuizCreator
{
    public interface FileModelInterface
    {
        XmlDocument GetXmlDocument(string filePath);
        void SaveXmlDocument(XmlDocument xmlDocument, string filePath);
        XmlDocument GetEmptyXmlDocument();
    }

    public class FileModel : FileModelInterface
    {
        public XmlDocument GetXmlDocument(string filePath)
        {
            var document = new XmlDocument();
            document.Load(filePath);

            return document;
        }

        public void SaveXmlDocument(XmlDocument xmlDocument, string filePath)
        {
            StreamWriter outStream = File.CreateText(filePath);

            xmlDocument.Save(outStream);
            outStream.Close();
        }

        public XmlDocument GetEmptyXmlDocument()
        {
            XmlDocument xmlDocument = new XmlDocument();

            return xmlDocument;
        }
    }
}
