using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food_Delivery.Classes.Enum;
using Food_Delivery.Classes.FoodClasses;
using Food_Delivery.Interfaces;

namespace Food_Delivery.Classes
{
    internal class Order : IFoodOwner
    {
        private static readonly Random random = new Random();

        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public List<FoodItem> Products { get; set; }
        public int TotalPrice => Products.Sum(p => p.Price);
        public int TotalPreparationTime => Products.Sum(p => p.preparationTime);
        public bool IsProcessed { get; set; }

        public Order()
        {
            Id = random.Next(1, 1000);
        }

        public override string ToString()
        {
            return $"{Id} -- {TotalPrice} ";
        }

    }
}
