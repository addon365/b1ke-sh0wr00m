using addon.BikeShowRoomService.WebService.Chit;
using Api.Database.Entity.Chit;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Chit
{
    public class SchemeViewModel : ViewModelBaseEn<ChitScheme>
    {

        public SchemeViewModel( ):base(new SchemeService())
        {
        }

        public override void Find()
        {
            throw new NotImplementedException();
        }

        public override void FindAll()
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            
            Service.Save(Model);
        }
    }
}
