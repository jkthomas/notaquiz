using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Helpers.Readers
{
    public interface IOwnXmlReader
    {
        XmlNode GetQuestionsRootNode();
        IEnumerable<XmlNode> GetQuestionNodes();
        IEnumerable<XmlNode> GetAnswerNodes(XmlNode node);
        string GetQuestionContent(XmlNode node);
        string GetAnswerContent(XmlNode node);
        bool GetAnswerStatus(XmlNode node);
    }
}
