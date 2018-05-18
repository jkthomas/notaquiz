using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Helpers.Readers
{
    public class OwnXmlReader : OwnXmlReaderBase, IOwnXmlReader
    {
        private string _filename;
        public OwnXmlReader(string filename) : base (filename)
        {
            this._filename = filename;
        }

        public XmlNode GetQuestionsRootNode()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(this._filename);
            XmlNode node = doc.DocumentElement.SelectSingleNode("/quiz/questions");

            return node;
        }

        public IEnumerable<XmlNode> GetQuestionNodes()
        {
            foreach (XmlNode question in this.GetQuestionsRootNode().ChildNodes)
            {
                yield return question;
            }
        }

        public IEnumerable<XmlNode> GetAnswerNodes(XmlNode node)
        {
            //XmlNode answers = node.SelectSingleNode("//answers");
            XmlNode answers = node.LastChild;
            foreach (XmlNode answer in answers.ChildNodes)
            {
                yield return answer;
            }
        }

        public string GetQuestionContent(XmlNode node)
        {
            //XmlNode content = node.SelectSingleNode("//content");
            XmlNode content = node.FirstChild;
            return content.InnerText;
        }

        public string GetAnswerContent(XmlNode node)
        {
            //Dla poniższego pobiera 'content' z tagu wyżej
            //XmlNode content = node.SelectSingleNode("//content");
            XmlNode content = node.ChildNodes[1];
            return content.InnerText;
        }

        public bool GetAnswerStatus(XmlNode node)
        {
            //XmlNode content = node.SelectSingleNode("//is_correct");
            XmlNode content = node.LastChild;
            if (content.InnerText.Equals("True"))
                return true;
            else
                return false;
        }
    }
}
