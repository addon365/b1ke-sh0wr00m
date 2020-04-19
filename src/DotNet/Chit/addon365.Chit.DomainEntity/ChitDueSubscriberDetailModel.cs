using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.Chit.DomainEntity
{
    public class ChitDueSubscriberDetailModel
    {
        public ChitSubscriberModel Subscriber { get; set; }
        public IList<ChitSubscriberDueListModel> DueDetail { get; set; }
    }
}
