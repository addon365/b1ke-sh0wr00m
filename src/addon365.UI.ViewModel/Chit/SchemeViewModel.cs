using addon365.WebClient.Service.WebService.Chit;
using addon365.Database.Entity.Chit;

namespace addon365.UI.ViewModel.Chit
{
    public class SchemeViewModel : ViewModelBaseEn<ChitScheme>
    {

        public SchemeViewModel() :base(new SchemeService())
        {
            Model = new ChitScheme();
        }

        
    }
}
