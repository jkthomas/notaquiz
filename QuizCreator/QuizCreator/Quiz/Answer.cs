using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCreator.Quiz
{
    public class Answer
    {
        private readonly string answer;
        private readonly bool is_Correct;

        public Answer(string answer, bool is_correct = false)
        {
            this.answer = answer;
            is_Correct = is_correct;
        }

        public string GetAnswerContent()
        {
            return this.answer;
        }

        public bool isAnswerCorrect()
        {
            return this.is_Correct;
        }
    }
}
