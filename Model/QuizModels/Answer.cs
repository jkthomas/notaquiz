using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.QuizModels
{
    public class Answer
    {
        public string Body { get; set; }
        public bool IsCorrect { get; set; }
        public Answer(string body, bool correct = false)
        {
            this.Body = body;
            this.IsCorrect = correct;
        }
    }
}
