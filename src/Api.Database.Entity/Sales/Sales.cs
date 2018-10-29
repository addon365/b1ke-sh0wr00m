using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Database.Entity.Sales
{
    class Sales:BaseEntity
    {
        public string Identifier { get; set; }
        public Guid CustomerId { get; set; }

    }
}
