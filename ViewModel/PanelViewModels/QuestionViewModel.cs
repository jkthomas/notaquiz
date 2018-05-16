using Helpers.Commands;
using Helpers.Mappers;
using Helpers.Parsers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
        private QuestionMapper _questionMapper;
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
        #endregion

        public QuestionViewModel()
        {
            //TODO: Mapper maps same question and answers - check for yield return in XmlReader class
            this._questionMapper = new QuestionMapper("quiz.xml");
            this._questionEntities = this._questionMapper.GetQuestionEntities();
            this.CheckAnswerCommand = new ParameterCommand(this.CheckAnswer);
            this.SelectButtonCommand = new ParameterCommand(this.SelectButton);

            this.Question = this._questionEntities.First().Content;
            this.PropAnswer = this._questionEntities.First().Answers.Find(answer => answer.IsCorrect == true).Content;
            this.Buttons = new ObservableCollection<ButtonViewModel>();
            foreach (var answer in _questionEntities.First().Answers)
            {
                this.Buttons.Add(new ButtonViewModel(answer.Content));
            }
        }

        public void CheckAnswer(object param)
        {
            string userAnswer = param as string;
            if (userAnswer == this.PropAnswer)
            {
                //NextQuestion()
            }
        }

        public void SelectButton(object param)
        {

        }

        public void NextQuestion()
        {

        }
    }
}
