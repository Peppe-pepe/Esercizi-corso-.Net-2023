﻿using Food_Delivery.Classes.Enum;
using Food_Delivery.Classes.FoodClasses;
using Food_Delivery.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Delivery.Services
{
    internal class AppService
    {
        private readonly FoodDeliveryServices _foodDeliveryServices;
        private readonly TranslationService _translationService;

        public TranslationService TranslationService => _translationService;

        public AppService(FoodDeliveryServices foodDeliveryServices, TranslationService translationService)
        {
            _foodDeliveryServices = foodDeliveryServices;
            _translationService = translationService;
        }

        public async Task<string> GetAllProviderInTime(TimeSpan time)
        {
            try
            {
                var providers = await _foodDeliveryServices.FindFoodProvidersForTime(time);

                if (providers.Any())
                {
                    var prov = providers.Select(provider => provider.Name);
                    return string.Join(Environment.NewLine, prov);
                }
                else
                {
                    return "Nessun food provider disponibile per la fascia oraria selezionata.";
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Errore durante la ricerca dei food provider: {ex.Message}");
                return "Si è verificato un errore durante la ricerca dei food provider.";
            }
        }


        public async Task<string> GetAllProviderForMealType(MealType meal)
        {
            try
            {
                var providers = await _foodDeliveryServices.FindFoodProviderForType(meal);

                if (providers.Any())
                {
                    return string.Join(Environment.NewLine, providers.Select(provider => provider.Name));
                }
                else
                {
                    return "Nessun food provider disponibile per la fascia oraria selezionata.";
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Errore durante la ricerca dei food provider: {ex.Message}");
                return "Si è verificato un errore durante la ricerca dei food provider.";
            }
        }

        public async Task<string> CreateOrder(User user, List<FoodItem> products, FoodProvider provider)
        {
            try
            {
                var order = await _foodDeliveryServices.CreateOrder(user, products, provider);
                return order?.ToString() ?? "Si è verificato un errore durante la creazione dell'ordine.";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return "Si è verificato un errore";
            }
        }


        public async Task<string> Menu(FoodProvider foodProvider)
        {
            try
            {
                await Task.Delay(1000);

                var menu = _foodDeliveryServices.FoodProviderMenu(foodProvider);

                if (menu.Any())
                {
                    var productInfo = menu.Select(p => $"{p.Id} - {p.Name} - {p.Price}$");
                    return string.Join(Environment.NewLine, productInfo);
                }
                else
                {
                    return "Si è verificato un errore";
                }
            }
            catch (Exception ex)
            {

                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task<List<FoodItem>> SelectProductForOrder(FoodProvider foodProvider)
        {
            try
            {
                await Task.Delay(1000);
                return _foodDeliveryServices.SelectProductsFromMenu(foodProvider)?.ToList();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Errore durante la selezione dei prodotti: {ex.Message}");
                throw;
            }
        }

        public FoodProvider GetProvider(string providerName)
        {
            return _foodDeliveryServices.GetFoodProvider(providerName);
        }

        public async Task<string> FindTranslator(string language)
        {
            try
            {
                var translator = await _translationService.FindTransaltor(language);

                if (translator != null)
                {
                    return translator.Name;
                }
                else
                {
                    return "Nessun Traduttore disponibile per la lingua selezionata.";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante la ricerca del traduttore: {ex.Message}");
                return "Si è verificato un errore durante la ricerca del traduttore.";
            }
        }

    }

}
