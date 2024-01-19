using Food_Delivery.Classes.Enum;
using Food_Delivery.Classes.FoodClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Delivery.Factories.Food
{
    internal class MealProviderFactory
    {
        private readonly List<FoodProvider> _foodProviders;

        public MealProviderFactory(List<FoodProvider> foodProviders)
        {
            _foodProviders = foodProviders;
        }

        public List<FoodProvider> FindProvidersByMealType(MealType mealType)
        {
            return _foodProviders.Where(provider => provider.Menu.Any(product => product.MealType == mealType)).ToList();
        }
    }
}
