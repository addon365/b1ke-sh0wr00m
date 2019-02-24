using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace addon365.UI.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _isProgressBarVisibile;
        private string _message;
        
        protected virtual void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        public bool IsProgressBarVisible
        {
            get
            {
                return _isProgressBarVisibile;
            }
            set
            {
                if (IsProgressBarVisible != value)
                {
                    _isProgressBarVisibile = value;
                    OnPropertyChanged("IsProgressBarVisible");
                }
            }
        }
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                if (Message != value)
                {
                    _message = value;
                    OnPropertyChanged("Message");
                }
            }
        }
        public IMsgBox MessageBox { get; set; }
    }
}
