using Food_Delivery.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Delivery.Event
{
    internal class OrderEventsArgs
    {
        public Order Order { get; set; }

        public OrderEventsArgs(Order order)
        {
            Order = order;
        }
    }
}
