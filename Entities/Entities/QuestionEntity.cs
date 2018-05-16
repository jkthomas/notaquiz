using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Entities
{
    public class QuestionEntity
    {
        public string Content { get; set; }
        public List<AnswerEntity> Answers { get; set; }
    }
}
