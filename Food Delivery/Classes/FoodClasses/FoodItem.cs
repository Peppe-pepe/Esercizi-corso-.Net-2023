using Food_Delivery.Classes.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Delivery.Classes.FoodClasses
{
    internal class FoodItem
    {
        private static readonly Random random = new Random();

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public MealType MealType { get; set; }
        public int preparationTime { get; set; }

        public FoodItem(string name, int price, MealType mealType, int preparationTime)
        {
            Id = random.Next(1, 1000);
            Name = name;
            Price = price;
            MealType = mealType;
            this.preparationTime = preparationTime;
        }
    }
}
