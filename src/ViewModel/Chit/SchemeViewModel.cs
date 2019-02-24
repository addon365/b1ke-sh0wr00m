using addon.BikeShowRoomService.WebService.Chit;
using Api.Database.Entity.Chit;

namespace ViewModel.Chit
{
    public class SchemeViewModel : ViewModelBaseEn<ChitScheme>
    {

        public SchemeViewModel() :base(new SchemeService())
        {
            Model = new ChitScheme();
        }

        
    }
}
