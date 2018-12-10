using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeShowRoom.WPF.Settings
{
    interface IConfigProvider
    {
        
        void Save();
        void Load();
    }
}
