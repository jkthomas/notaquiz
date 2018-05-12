using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.ObjectsViewModels;

namespace ViewModel.PanelViewModels
{
    public class ButtonGroupViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public ButtonViewModel buttonA;
        public ButtonViewModel buttonB;
        public ButtonViewModel buttonC;
        public ButtonViewModel buttonD;

        public ButtonGroupViewModel(/* xaml? */)
        {
            this.buttonA.Content = "A";
            this.buttonB.Content = "B";
            this.buttonC.Content = "C";
            this.buttonD.Content = "D";
        }
    }
}
