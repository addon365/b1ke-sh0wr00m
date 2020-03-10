using addon365.Chit.ViewModel;
using GalaSoft.MvvmLight.Ioc;

namespace addon365.Chit.WpfView
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            
            SimpleIoc.Default.Register<ChitSubscriberViewModel>();
        }
        public ChitSubscriberViewModel Subscriber
        {
            get
            {
                return SimpleIoc.Default.GetInstance<ChitSubscriberViewModel>();
            }
        }
    }
}
