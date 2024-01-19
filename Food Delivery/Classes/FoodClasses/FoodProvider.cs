using Food_Delivery.Classes.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Delivery.Classes.FoodClasses
{
    internal class FoodProvider
    {
        public TimeSpan Opening { get; set; }
        public TimeSpan Closed { get; set; }
        public List<FoodItem> Menu { get; set; }
        public string Name { get; set; }
        public Queue<Order> Orders { get; set; } = new Queue<Order>();
        public Queue<FoodItem> ProductsInPrep { get; set; } = new Queue<FoodItem>();
        public int ProductsInPrepCount => ProductsInPrep.Count;

        public FoodProvider()
        {
            Orders = new Queue<Order>();
        }

        public bool CanAcceptOder()
        {
            lock (ProductsInPrep)
            {
                return ProductsInPrepCount < 4;
            }
        }

        private async Task<bool> ProcessProduct(FoodItem product)
        {
            await Task.Delay(product.preparationTime * 5);

            lock (ProductsInPrep)
            {
                if (ProductsInPrepCount < 4)
                {
                    ProductsInPrep.Enqueue(product);
                    return true;
                }
                else
                {
                    Console.WriteLine("Limite di prodotti in preparazione raggiunto.");
                    Task.Delay(1000);
                    return false;
                }
            }
        }


        public async Task<bool> ProcessOrders()
        {
            List<Order> ordersToProcess;

            lock (Orders)
            {
                ordersToProcess = Orders.ToList();
                Orders.Clear();
            }

            foreach (Order order in ordersToProcess)
            {
                if (!order.IsProcessed)
                {
                    foreach (FoodItem product in order.Products)
                    {
                        if (!await ProcessProduct(product))
                        {
                            Console.WriteLine("Tutti i nostri dipendenti sono occupati, sarai servito non appena possibile");
                            return false;
                        }
                    }
                    order.IsProcessed = true;
                }
            }

            return true;
        }

    }
}
