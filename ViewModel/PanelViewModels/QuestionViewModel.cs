using Helpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModel.ObjectsViewModels;

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
            this.CheckAnswerCommand = new ParameterCommand(this.CheckAnswer);
            this.SelectButtonCommand = new ParameterCommand(this.SelectButton);
            //TODO: Add first or default question on creation
            this.Question = "What is 2 + 2 ?";
            //this.Question = Parser.parseQuestion();
            this.PropAnswer = "4";
            //this.PropAnswer = -||-
            this.Buttons = new ObservableCollection<ButtonViewModel>(
                //TODO: Initialize with converted List/Enumerable from parser
                );
            this.Buttons.Add(new ButtonViewModel("A"));
            this.Buttons.Add(new ButtonViewModel("B"));
            this.Buttons.Add(new ButtonViewModel("C"));
            this.Buttons.Add(new ButtonViewModel("D"));
            //this.ButtonGroupViewModel =  new ButtonGroupViewModel(Parser.something)
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
