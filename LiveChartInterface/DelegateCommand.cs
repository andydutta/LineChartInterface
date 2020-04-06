using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LiveChartInterface
{
    public class DelegateCommand : ICommand
    {
        private Action _delegate;

        public DelegateCommand(Action @delegate)
        {
            _delegate = @delegate;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _delegate.Invoke();
        }

        public event EventHandler CanExecuteChanged;
    }
}
