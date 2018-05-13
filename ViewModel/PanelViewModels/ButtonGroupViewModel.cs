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

        public List<ButtonViewModel> Buttons { get; set; }

        public ButtonGroupViewModel(List<ButtonViewModel> buttons/* xaml? */)
        {
            this.Buttons = buttons;
        }
    }
}
