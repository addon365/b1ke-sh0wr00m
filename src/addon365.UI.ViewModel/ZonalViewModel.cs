using addon365.Database.Entity;
using System.Collections.Generic;
using addon365.IService;
using Microsoft.Extensions.DependencyInjection;

namespace addon365.UI.ViewModel
{
    public class ZonalViewModel:ViewModelBase
    {
        private readonly IZonalService _repositoryZonal;
        private MarketingZone _marketingZone;

        public ZonalViewModel()
        {
            var Scope = Startup.Instance.provider.CreateScope();
            _marketingZone = new MarketingZone();
            _repositoryZonal = Scope.ServiceProvider.GetRequiredService<IZonalService>();
            marketingZones = _repositoryZonal.GetAllActive();
            WireCommands();
        }
        private void WireCommands()
        {

            InsertCommand = new RelayCommand(AddZonal);
            DeleteCommand = new RelayCommand(DeleteZonal);
        }
        public RelayCommand InsertCommand
        {
            get;
            private set;
        }
        public RelayCommand DeleteCommand
        {
            get;
            private set;
        }
        public IEnumerable<MarketingZone> marketingZones { get; set; }
        public MarketingZone CurrentMarketingZone
        {
            get
            {
                return _marketingZone;
            }

            set
            {

                _marketingZone = value;
                OnPropertyChanged("CurrentMarketingZone");
                InsertCommand.IsEnabled = true;


            }
        }
        public void AddZonal()
        {
            _repositoryZonal.Insert(CurrentMarketingZone);
        }
        public void DeleteZonal()
        {
            MarketingZone m = CurrentMarketingZone;
            _repositoryZonal.Delete(m);

        }
    }
}
