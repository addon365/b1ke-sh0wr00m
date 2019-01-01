using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ViewModel
{
    public class RelayCommand : ICommand
    {
        private readonly Action _handler;
        private bool _isEnabled;

        public RelayCommand(Action handler)
        {
            _handler = handler;
        }
       
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                if (value != _isEnabled)
                {
                    _isEnabled = value;
                    if (CanExecuteChanged != null)
                    {
                        CanExecuteChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        public bool CanExecute(object parameter)
        {
            return IsEnabled;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _handler();
        }
    }
    
    public class OtherRelayCommand : ICommand
    {
        private readonly Action<object> _handler;
        private Func<object, bool> _isEnabled;

      
        public OtherRelayCommand(Action<object> handler, Func<object, bool> canExec)
        {
            _handler = handler;
            _isEnabled = canExec;
        }
       

        public bool CanExecute(object parameter)
        {
            return _isEnabled(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _handler(parameter);
        }
    }
}

