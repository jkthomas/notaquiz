using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCreator.Quiz
{
    public class Quiz
    {
        private string name;
        private List<Question> questions;

        public Quiz(string name, List<Question> questions = null)
        {
            this.name = name;
            this.questions = questions ?? new List<Question>() { new Question("", new Answer(""), new Answer("")) };
        }

        public string GetName()
        {
            return this.name;
        }

        public void ChangeName(string newName)
        {
            this.name = newName;
        }

        public void AddQuestion(Question question)
        {
            this.questions.Add(question);
        }

        public List<Question> GetQuestions()
        {
            return this.questions;
        }

    }
}
