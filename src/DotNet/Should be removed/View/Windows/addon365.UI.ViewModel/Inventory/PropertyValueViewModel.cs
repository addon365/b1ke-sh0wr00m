using addon365.Database.Entity.Inventory.Purchases;
using System.Collections.Generic;

namespace addon365.UI.ViewModel.Inventory
{
    public class PropertyValueViewModel : ViewModelBase
    {
        public ICollection<PurchaseItemPropertyValue> lstPropertyValues { get; set; }
        public PropertyValueViewModel(ICollection<PurchaseItemPropertyValue> PropertyValues)
        {
            lstPropertyValues = PropertyValues;
        }
    }
  
}
