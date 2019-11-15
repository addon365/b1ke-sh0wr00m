using addon365.Database.Entity.Chit;
using addon365.IService.Chit;
using Microsoft.Extensions.DependencyInjection;

namespace addon365.UI.ViewModel.Chit
{
    public class SchemeViewModel : ViewModelBaseEn<ChitScheme>
    {

        public SchemeViewModel() :base(Startup.Instance.provider.CreateScope().ServiceProvider.GetRequiredService<ISchemeService>())
        {
            Model = new ChitScheme();
        }

        
    }
}
