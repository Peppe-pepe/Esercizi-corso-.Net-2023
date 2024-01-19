using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Delivery.Classes.FoodClasses
{
    internal class Bucket
    {
        public int Id { get; set; }
        public Order Order { get; set; }
    }
}
