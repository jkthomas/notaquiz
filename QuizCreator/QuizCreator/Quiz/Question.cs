using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCreator.Quiz
{
    public class Question
    {
        private readonly string question;
        private readonly Answer answerA;
        private readonly Answer answerB;
        private readonly List<Answer> additionalAnswers;

        public Question(string question, Answer answerA, Answer answerB, List<Answer> additionalAnswers = null)
        {
            this.question = question;
            this.answerA = answerA;
            this.answerB = answerB;
            this.additionalAnswers = additionalAnswers ?? new List<Answer>();
        }

        public string getQuestionContent()
        {
            return this.question;
        }

        public List<Answer> GetAnswers()
        {
            List<Answer> answers = new List<Answer>() { this.answerA, this.answerB };

            foreach(Answer additionalAnswer in this.additionalAnswers)
            {
                answers.Add(additionalAnswer);
            }

            return answers;
        }

        public List<Answer> GetCorrectAnswers()
        {
            List<Answer> answers = this.GetAnswers();
            List<Answer> correctAnswers = new List<Answer>();

            foreach (Answer answer in answers)
            {
                if (answer.isAnswerCorrect())
                {
                    correctAnswers.Add(answer);
                }
            }

            return correctAnswers;
        }
    }
}
