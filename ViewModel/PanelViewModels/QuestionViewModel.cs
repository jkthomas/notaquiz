using Helpers.Commands;
using Helpers.Mappers;
using Helpers.Placeholders;
using Helpers.Readers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml;
using ViewModel.Entities;
using ViewModel.ObjectsViewModels;

namespace ViewModel.PanelViewModels
{
    public class QuestionViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        public ICommand CheckAnswerCommand { get; set; }
        public ICommand SelectButtonCommand { get; set; }


        private List<QuestionEntity> _questionEntities;
        private IQuestionMapper<QuestionEntity, XmlNode> _questionMapper;
        #region Question Field
        private string _question;
        public string Question
        {
            get { return this._question; }
            set
            {
                if (this._question == value)
                    return;

                this._question = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Question)));
            }
        }
        #endregion
        #region Private fields

        private string _propAnswer;
        private ObservableCollection<ButtonViewModel> _buttons;
        private int _questionsAmount;
        private int _questionsProp;
        private int _questionNumber;

        #endregion

        #region Properties
        public string PropAnswer
        {
            get { return this._propAnswer; }
            set
            {
                if (this._propAnswer == value)
                    return;

                this._propAnswer = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(PropAnswer)));
            }
        }

        public ObservableCollection<ButtonViewModel> Buttons
        {
            get { return this._buttons; }
            set
            {
                if (this._buttons == value)
                    return;

                this._buttons = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Buttons)));
            }
        }
        public int QuestionsAmount
        {
            get { return this._questionsAmount; }
            set
            {
                if (this._questionsAmount == value)
                    return;

                this._questionsAmount = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(QuestionsAmount)));
            }
        }
        public int QuestionNumber
        {
            get { return this._questionNumber; }
            set
            {
                if (this._questionNumber == value)
                    return;

                this._questionNumber = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(QuestionNumber)));
            }
        }
        public int QuestionsProp
        {
            get { return this._questionsProp; }
            set
            {
                if (this._questionsProp == value)
                    return;

                this._questionsProp = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(QuestionsProp)));
            }
        }

        #endregion

        public QuestionViewModel()
        {
            this.SelectButtonCommand = new ParameterCommand(this.SelectButton);
            try
            {
                this._questionMapper = new QuestionMapper("quiz.xml");
                this._questionEntities = this._questionMapper.GetQuestionEntities();
            }
            catch (Exception e)
            {
                MessageBox.Show("There was an error opening quiz questions: " + e.Message);
            }


            this.Question = this._questionEntities.First().Content;
            this.PropAnswer = this._questionEntities.First().Answers.Find(answer => answer.IsCorrect == true).Content;


            this.Buttons = new ObservableCollection<ButtonViewModel>();
            foreach (var answer in _questionEntities.First().Answers)
            {
                this.Buttons.Add(new ButtonViewModel(answer.Content));
            }
            this.QuestionsAmount = _questionEntities.Count;
            this.QuestionsProp = 0;
            this.QuestionNumber = 1;
        }

        public void SelectButton(object param)
        {
            string userAnswer = param as string;
            if (userAnswer.Equals(this.PropAnswer))
            {
                MessageBox.Show(Messenger.GoodAnswer());
                this.QuestionsProp += 1;
            }
            else
            {
                MessageBox.Show(Messenger.BadAnswer());
            }
            NextQuestion();
        }

        public void NextQuestion()
        {
            if (QuestionNumber == _questionEntities.Count)
            {
                string endInfo = Messenger.Results(this.QuestionsProp.ToString(), this.QuestionsAmount.ToString());
                MessageBox.Show(endInfo, Messenger.End(), MessageBoxButton.OK);
                Environment.Exit(0);
            }
            int index = QuestionNumber - 1;
            this.QuestionNumber += 1;
            index += 1;
            try
            {
                this.Question = this._questionEntities[index].Content;
                this.PropAnswer = this._questionEntities[index].Answers.Find(answer => answer.IsCorrect == true).Content;
            }
            catch (Exception e)
            {
                MessageBox.Show("There was an error with question/answer entities: " + e.Message);
            }

            this.Buttons = new ObservableCollection<ButtonViewModel>();
            foreach (var answer in _questionEntities[index].Answers)
            {
                this.Buttons.Add(new ButtonViewModel(answer.Content));
            }
        }
    }
}
