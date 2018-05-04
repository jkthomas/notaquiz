using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Helpers.Commands
{
    public class ParameterCommand : ICommand
    {
        private Action<object> _action;
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public ParameterCommand(Action<object> action)
        {
            this._action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }
    }
}
