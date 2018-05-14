using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizCreator
{
    public interface ViewInterface
    {
        void LoadQuiz(Quiz.Quiz quiz);
        void Restart();
        void loadQuestion(Quiz.Question question);
        void ShowModal(string msg);
    }

    struct AnswerBox
    {
        public AnswerBox(TextBox answerBox, CheckBox isCorrectBox) { this.answerBox = answerBox; this.isCorrectBox = isCorrectBox; }
        public TextBox answerBox;
        public CheckBox isCorrectBox;
    }

    struct ViewMap
    {
        public TextBox titleBox;
        public TextBox quiestionBox;
        public List<AnswerBox> answerBoxes;

        public void ResetAnswerBoxes()
        {
            foreach (AnswerBox answerBox in this.answerBoxes)
            {
                answerBox.answerBox.Text = "";
                answerBox.isCorrectBox.Checked = false;
            }
        }

        public void ResetBoxes()
        {
            this.ResetAnswerBoxes();
            this.titleBox.Text = "";
            this.quiestionBox.Text = "";
        }
    }

    public partial class Form1 : Form, ViewInterface
    {
        private ViewMap viewMap = new ViewMap();
        private PresenterInterface presenter;

        public Form1(PresenterInterface presenter)
        {
            this.presenter = presenter;

            InitializeComponent();
            InitializeViewMap();
        }

        public void LoadQuiz(Quiz.Quiz quiz)        
        {
            this.viewMap.ResetBoxes();
            this.viewMap.titleBox.Text = quiz.GetName();

            List<Quiz.Question> questions = quiz.GetQuestions();

            if (questions.Count() > 0)
            {
                this.loadQuestion(questions[0]);
            }
        }
        
        public void loadQuestion(Quiz.Question question)
        {
            this.viewMap.ResetAnswerBoxes();

            this.viewMap.quiestionBox.Text = question.getQuestionContent();
            this.viewMap.answerBoxes.GetEnumerator().MoveNext();

            var boxesEnumerator = this.viewMap.answerBoxes.GetEnumerator();
            foreach (Quiz.Answer answer in question.GetAnswers())
            {
                if (boxesEnumerator.MoveNext())
                {
                    boxesEnumerator.Current.answerBox.Text = answer.GetAnswerContent();
                    boxesEnumerator.Current.isCorrectBox.Checked = answer.isAnswerCorrect();
                }
                else
                {
                    throw new Exception("Too many answers in question, current view cannot handle it");
                }
            }
        }

        public void Restart()
        {
            this.presenter.NewQuiz();
        }

        public void ShowModal(string msg)
        {
            MessageBox.Show(msg);
        }        

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void nextQuestionBtn_click(object sender, EventArgs e)
        {
            this.presenter.SaveQuestionState(this.GetCurrentQuestionState());
            this.presenter.NextQuestion();
        }

        private Quiz.Question GetCurrentQuestionState()
        {
            List<Quiz.Answer> additionalAnswers = new List<Quiz.Answer>();
            if (this.viewMap.answerBoxes[2].answerBox.Text != "")
            {
                additionalAnswers.Add(new Quiz.Answer(
                    this.viewMap.answerBoxes[2].answerBox.Text,
                    this.viewMap.answerBoxes[2].isCorrectBox.Checked
                ));
            }

            if (this.viewMap.answerBoxes[3].answerBox.Text != "")
            {
                additionalAnswers.Add(new Quiz.Answer(
                    this.viewMap.answerBoxes[3].answerBox.Text,
                    this.viewMap.answerBoxes[3].isCorrectBox.Checked
                ));
            }

            Quiz.Question questionState = new Quiz.Question(
                    this.viewMap.quiestionBox.Text,
                    new Quiz.Answer(
                        this.viewMap.answerBoxes[0].answerBox.Text,
                        this.viewMap.answerBoxes[0].isCorrectBox.Checked
                    ),
                    new Quiz.Answer(
                        this.viewMap.answerBoxes[1].answerBox.Text,
                        this.viewMap.answerBoxes[1].isCorrectBox.Checked
                    ),
                    additionalAnswers
            );

            return questionState;
        }

        private void prevQuestionBtn_click(object sender, EventArgs e)
        {
            this.presenter.SaveQuestionState(this.GetCurrentQuestionState());
            this.presenter.PreviousQuestion();
        }

        private void Export(object sender, EventArgs e)
        {
            this.presenter.ChangeQuizName(this.viewMap.titleBox.Text);
            this.presenter.SaveQuestionState(this.GetCurrentQuestionState());

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Pliki XML (*.xml)|*.xml";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.presenter.ExportToFile(saveFileDialog1.FileName);
            }
        }

        private void Import(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Pliki XML (*.xml)|*.xml";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK )
            {
                this.presenter.ImprtFromFile(openFileDialog1.FileName);
            }
        }

        private void Restart(object sender, EventArgs e)
        {
            this.Restart();
        }

        private void InitializeViewMap()
        {
            this.viewMap.titleBox = this.quizName;
            this.viewMap.quiestionBox = this.question;
            this.viewMap.answerBoxes = new List<AnswerBox>()
            {
                new AnswerBox(this.answerA, this.answerACheckbox),
                new AnswerBox(this.answerB, this.answerBCheckbox),
                new AnswerBox(this.answerC, this.answerCCheckbox),
                new AnswerBox(this.answerD, this.answerDCheckbox)
            };
        }
    }
}
