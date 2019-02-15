using Api.Database.Entity.Inventory.Purchases;
using System.Collections.Generic;

namespace ViewModel.Inventory
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
