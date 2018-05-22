using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ViewModel.Entities;

namespace Helpers.Mappers
{
    public interface IQuestionMapper<EntityType, QuestionType>
    {
        List<EntityType> GetQuestionEntities();

        void AppendQuestion(QuestionType question);
    }
}
