using Food_Delivery.Classes;
using Food_Delivery.Classes.Enum;
using Food_Delivery.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Food_Delivery.Factories.Food.FoodFactory;

namespace Food_Delivery.Factories.Food
{
    internal class FoodFactory : IFoodFactory
    {
        public Order CreateOrder()
            {
                return new Order { Status = OrderStatus.InPreparation };
            }
    }
}
