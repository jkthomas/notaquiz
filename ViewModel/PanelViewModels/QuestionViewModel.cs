using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.PanelViewModels
{
    public class QuestionViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

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
        #endregion

        public QuestionViewModel()
        {
            //TODO: Add first or default question on creation
        }
    }
}
