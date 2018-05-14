using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QuizCreator
{
    public interface PresenterInterface
    {
        void SetUp(ViewInterface view, FileModelInterface fileModel);
        void SaveQuestionState(Quiz.Question question);
        void ChangeQuizName(string quizName);
        void NextQuestion();
        void PreviousQuestion();
        void NewQuiz();
        void ExportToFile(string filePath);
        void ImprtFromFile(string filePath);
    }

    public class Presenter : PresenterInterface
    {
        private const string NEW_QUIZ_NAME = "new_quiz";

        private Quiz.Quiz quiz;
        private int questionIndex;


        private ViewInterface view;
        private FileModelInterface fileModel;

        public void SetUp(ViewInterface view, FileModelInterface fileModel)
        {
            this.view = view;
            this.fileModel = fileModel;
            this.quiz = this.GetEmptyQuiz();

            this.LoadQuiz(quiz);
        }

        public void SaveQuestionState(Quiz.Question question)
        {
            this.quiz.GetQuestions()[this.questionIndex] = question;
        }

        public void ChangeQuizName(string quizName)
        {
            this.quiz.ChangeName(quizName);
        }

        public void NextQuestion()
        {
            int newIndex = this.questionIndex + 1;
            if (this.quiz.GetQuestions().Count() <= newIndex)
            {
                this.quiz.AddQuestion(new Quiz.Question("", new Quiz.Answer(""), new Quiz.Answer("")));
            }

            this.questionIndex = newIndex;
            this.view.loadQuestion(this.quiz.GetQuestions()[newIndex]);
        }

        public void PreviousQuestion()
        {
            if (this.questionIndex > 0)
            {
                int newIndex = this.questionIndex - 1;

                this.questionIndex = newIndex;
                this.view.loadQuestion(this.quiz.GetQuestions()[newIndex]);
            }
        }

        public void NewQuiz()
        {
            this.quiz = new Quiz.Quiz(NEW_QUIZ_NAME);
            this.LoadQuiz(quiz);
        }

        public void ExportToFile(string filePath)
        {
            // TODO: move to dedicated xml writer
            try
            {
                XmlDocument xmlDocument = this.fileModel.GetEmptyXmlDocument();
                xmlDocument.LoadXml("<?xml version=\"1.0\" encoding=\"UTF - 8\"?><quiz></quiz>");
                XmlElement quizElement = xmlDocument["quiz"];

                // GUID Element
                XmlElement guidElement = xmlDocument.CreateElement("guid");
                guidElement.AppendChild(xmlDocument.CreateTextNode("some-guid-code"));
                quizElement.AppendChild(guidElement);

                // Name element
                XmlElement nameElement = xmlDocument.CreateElement("name");

                XmlElement namePLElement = xmlDocument.CreateElement("pl");
                namePLElement.AppendChild(xmlDocument.CreateTextNode(this.quiz.GetName()));
                nameElement.AppendChild(namePLElement);

                quizElement.AppendChild(nameElement);

                // QUESTIONS element

                XmlElement questionsElement = xmlDocument.CreateElement("questions");
                foreach (Quiz.Question quizQuestion in this.quiz.GetQuestions())
                {
                    XmlElement questionElement = xmlDocument.CreateElement("question");

                    // Question name element
                    XmlElement questionContentElement = xmlDocument.CreateElement("content");

                    XmlElement questionContentPLElement = xmlDocument.CreateElement("pl");
                    questionContentPLElement.AppendChild(xmlDocument.CreateTextNode(quizQuestion.getQuestionContent()));
                    questionContentElement.AppendChild(questionContentPLElement);
                    questionContentElement.AppendChild(questionContentPLElement);

                    questionElement.AppendChild(questionContentElement);

                    XmlElement questionAnswersElement = xmlDocument.CreateElement("answers");
                    int answerIndex = 1;
                    foreach (Quiz.Answer quizAnswer in quizQuestion.GetAnswers())
                    {
                        XmlElement answerElement = xmlDocument.CreateElement("answer");

                        XmlElement idElement = xmlDocument.CreateElement("id");
                        idElement.InnerText = answerIndex.ToString();
                        answerElement.AppendChild(idElement);

                        XmlElement answerContentElement = xmlDocument.CreateElement("content");
                        XmlElement answerContentPLElement = xmlDocument.CreateElement("pl");
                        answerContentPLElement.AppendChild(xmlDocument.CreateTextNode(quizAnswer.GetAnswerContent()));
                        answerContentElement.AppendChild(answerContentPLElement);
                        answerElement.AppendChild(answerContentElement);
                        
                        XmlElement isCorrectElement = xmlDocument.CreateElement("is_correct");
                        isCorrectElement.InnerText = quizAnswer.isAnswerCorrect().ToString();
                        answerElement.AppendChild(isCorrectElement);

                        questionAnswersElement.AppendChild(answerElement);
                        answerIndex++;
                    }
                    questionElement.AppendChild(questionAnswersElement);
                    questionsElement.AppendChild(questionElement);
                }
                quizElement.AppendChild(questionsElement);


                this.fileModel.SaveXmlDocument(xmlDocument, filePath);
            }
            catch(Exception exception)
            {
                this.view.ShowModal(exception.Message);
            }
        }

        public void ImprtFromFile(string filePath)
        {
            try
            {
                XmlDocument xml = this.fileModel.GetXmlDocument(filePath);
                this.quiz = this.ParseXmlToObject(xml);

                this.LoadQuiz(this.quiz);
            }
            catch(Exception exception)
            {
                // xml is not valid or doesnt ex
                this.view.ShowModal(exception.Message);
            }
        }

        public Quiz.Quiz GetEmptyQuiz()
        {            
            Quiz.Quiz quiz = new Quiz.Quiz(NEW_QUIZ_NAME);

            return quiz;
        }

        private Quiz.Quiz ParseXmlToObject(XmlDocument xmlDocument)
        {
            try
            {
                List<Quiz.Question> questions = new List<Quiz.Question>();
                foreach (XmlElement question in xmlDocument["quiz"]["questions"].ChildNodes)
                {
                    if (question["answers"].ChildNodes.Count >= 2)
                    {
                        List<Quiz.Answer> answers = new List<Quiz.Answer>();
                        foreach (XmlElement answer in question["answers"])
                        {
                            answers.Add(
                                new Quiz.Answer(
                                    answer["content"]["pl"].HasChildNodes ? answer["content"]["pl"].FirstChild.Value : "",
                                    Boolean.Parse(answer["is_correct"].FirstChild.Value)
                                    )
                            );
                        }

                        Quiz.Question fileQuestion = new Quiz.Question(
                            question["content"]["pl"].HasChildNodes ? question["content"]["pl"].FirstChild.Value : "",
                            answers[0],
                            answers[1],
                            answers.Skip(2).ToList()
                            );

                        questions.Add(fileQuestion);
                    }
                    else
                    {
                        // not enough answers
                        throw new Exception("File is invalid");
                    }
                }

                Quiz.Quiz parsedQuiz = new Quiz.Quiz(
                    xmlDocument["quiz"]["name"]["pl"].HasChildNodes ? xmlDocument["quiz"]["name"]["pl"].FirstChild.Value : "",
                    questions
                    );

                return parsedQuiz;
            }
            catch (NullReferenceException exception)
            {
                //File has no appropriate fields
                throw new Exception("File is invalid");
            }

        }

        private void LoadQuiz(Quiz.Quiz quiz)
        {
            this.questionIndex = 0;
            this.view.LoadQuiz(quiz);
        }
   
    }
}
