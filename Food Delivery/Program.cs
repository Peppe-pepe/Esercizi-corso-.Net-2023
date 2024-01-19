using Food_Delivery.Classes.Enum;
using Food_Delivery.Classes.FoodClasses;
using Food_Delivery.Classes.TranslationClasses;
using Food_Delivery.Classes;
using Food_Delivery.Factories.Translation;
using Food_Delivery.Services;
using System;
using System.Collections.Generic;
using Food_Delivery.Menu;

namespace Food_Delivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            user.Name = "Giuseppe";
            user.Type = UserType.OfficeManager;

            List<FoodProvider> providers = new List<FoodProvider>();
            List<Bucket> buckets = new List<Bucket>();
            List<FoodItem> Colazione = new List<FoodItem>
            {
                new FoodItem("Caffè",1,MealType.Breakfast,1),
                new FoodItem("Cornetto",2,MealType.Breakfast,2)
            };
            List<FoodItem> Pranzo = new List<FoodItem>{

                new FoodItem("Carbonara",1,MealType.Lunch,12),
                new FoodItem("Bistecca",2,MealType.Lunch,42)

            };
            List<FoodItem> Cena = new List<FoodItem>()
            {
                new FoodItem("Pizza",1,MealType.Dinner,35),
                new FoodItem("Hamburger",2,MealType.Dinner,20)
            };

            FoodProvider foodProvider = new FoodProvider();
            foodProvider.Menu = Colazione;
            foodProvider.Name = "La Meridiana";
            foodProvider.Opening = new TimeSpan(7, 0, 0);
            foodProvider.Closed = new TimeSpan(11, 0, 0);

            FoodProvider foodProvider1 = new FoodProvider();
            foodProvider1.Menu = Pranzo;
            foodProvider1.Name = "Giorgio VI";
            foodProvider1.Opening = new TimeSpan(11, 30, 0);
            foodProvider1.Closed = new TimeSpan(16, 0, 0);

            FoodProvider foodProvider2 = new FoodProvider();
            foodProvider2.Menu = Cena;
            foodProvider2.Name = "Delicious";
            foodProvider2.Opening = new TimeSpan(17, 30, 0);
            foodProvider2.Closed = new TimeSpan(22, 0, 0);

            providers.Add(foodProvider1);
            providers.Add(foodProvider2);
            providers.Add(foodProvider);

            List<Translator> translators = new List<Translator>();
            Translator t1 = new Translator();
            t1.Name = "Italo";
            t1.Language = "Tedesco";
            var t2 = new Translator();
            t2.Name = "Carlo";
            t2.Language = "Inglese";
            var t3 = new Translator();
            t3.Name = "Gabriele";
            t3.Language = "Polacco";

            translators.Add(t1);
            translators.Add(t2);
            translators.Add(t3);

            FoodDeliveryServices foodDeliveryServices = new FoodDeliveryServices(providers, buckets);
            var tranlatorsFactory = new TranslationFactory();
            TranslationService translationService = new TranslationService(tranlatorsFactory, translators);
            AppService appService = new AppService(foodDeliveryServices, translationService);
            UIClass ui = new UIClass(appService);

            ui.Run(user);

        }
    }
}
