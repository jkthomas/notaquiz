using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ObjectsViewModels
{
    public class ButtonViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        #region Private fields
        private bool _isEnabled;
        private string _content;
        #endregion

        #region Properties
        public bool IsEnabled
        {
            get { return this._isEnabled; }
            set
            {
                if (this._isEnabled == value)
                    return;

                this._isEnabled = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(IsEnabled)));
            }
        }
        public string Content
        {
            get { return this._content; }
            set
            {
                if (this._content == value)
                    return;

                this._content = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Content)));
            }
        }
        #endregion

        public ButtonViewModel(string content)
        {

        }
    }
}
