using Helpers.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel.PanelViewModels
{
    public class QuestionViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        public ICommand CheckAnswerCommand { get; set; }
        public ICommand SelectButtonCommand { get; set; }

        //private ObservableCollection<string> _observableCollection;
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
        #region Answers Fields
        private string _answerA;
        private string _answerB;
        private string _answerC;
        private string _answerD;
        private string _propAnswer;

        public string AnswerA
        {
            get { return this._answerA; }
            set
            {
                if (this._answerA == value)
                    return;

                this._answerA = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(AnswerA)));
            }
        }
        public string AnswerB
        {
            get { return this._answerB; }
            set
            {
                if (this._answerB == value)
                    return;

                this._answerB = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(AnswerB)));
            }
        }
        public string AnswerC
        {
            get { return this._answerC; }
            set
            {
                if (this._answerC == value)
                    return;

                this._answerC = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(AnswerC)));
            }
        }
        public string AnswerD
        {
            get { return this._answerD; }
            set
            {
                if (this._answerD == value)
                    return;

                this._answerD = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(AnswerD)));
            }
        }
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
        #endregion

        public QuestionViewModel()
        {
            this.CheckAnswerCommand = new RelayCommand(this.CheckAnswer);
            this.SelectButtonCommand = new ParameterCommand(this.SelectButton);
            //TODO: Add first or default question on creation
            this.Question = "What is 2 + 2 ?";
            this.AnswerA = "2";
            this.AnswerB = "4";
            this.AnswerC = "5";
            this.AnswerD = "6";
            this.PropAnswer = "4";
        }

        public void CheckAnswer()
        {

        }

        public void SelectButton(object param)
        {
            string userAnswer = param as string;
            if(userAnswer == this.PropAnswer)
            {
                //NextQuestion()
            }
        }

        public void NextQuestion()
        {

        }
    }
}
