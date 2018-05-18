using Helpers.Readers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Entities;
using System.Xml;

namespace Helpers.Mappers
{
    public class QuestionMapper
    {
        public List<QuestionEntity> QuestionEntities { get; set; }
        public IOwnXmlReader Reader { get; set; }

        public QuestionMapper(string filename)
        {
            this.QuestionEntities = new List<QuestionEntity>();
            this.Reader = new OwnXmlReader(filename);
        }

        public List<QuestionEntity> GetQuestionEntities()
        {
            foreach (XmlNode question in Reader.GetQuestionNodes())
            {
                AppendQuestion(question);
            }
            return this.QuestionEntities;
        }

        public void AppendQuestion(XmlNode question)
        {
            QuestionEntity questionEntity = new QuestionEntity() { };
            List<AnswerEntity> answerEntities = new List<AnswerEntity>() { };

            foreach (XmlNode answer in Reader.GetAnswerNodes(question))
            {
                answerEntities.Add(new AnswerEntity()
                {
                    Content = Reader.GetAnswerContent(answer),
                    IsCorrect = Reader.GetAnswerStatus(answer)
                });
            }

            questionEntity.Content = Reader.GetQuestionContent(question);
            questionEntity.Answers = answerEntities;
            this.QuestionEntities.Add(questionEntity); 
        }
    }
}
