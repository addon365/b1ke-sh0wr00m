using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;

namespace addon365.Chit.WpfApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>  
        /// Initializes a new instance of the MainViewModel class.  
        /// </summary>  
        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                Title = "Hello MVVM Light (Design Mode)";
            }
            else
            {
                Title = "Hello MVVM Light";
            }
        }

        public string Title { get; set; }

    }
}
