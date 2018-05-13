using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.QuizModels
{
    public class QuestionModel
    {
        public string Question { get; set; }
        public List<Answer> Answers { get; set; }

        public QuestionModel()
        {

        }
    }
}
