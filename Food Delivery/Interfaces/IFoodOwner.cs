using Food_Delivery.Classes.FoodClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Delivery.Interfaces
{
    internal interface IFoodOwner
    {
        List<FoodItem> Products { get; }
    }
}
