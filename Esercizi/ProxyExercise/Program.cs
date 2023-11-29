using ProxyExercise.Classes;
using System;

namespace ProxyExercise
{
    internal class Program
    {
            static void Main(string[] args)
            {
                int NInstance = 3;// numero di istanze al proxy
                int CCall = 2;// numero di chiamate per istanza

                for (int i = 0; i < NInstance; i++)
                {
                    SingletonProxy proxy = SingletonProxy.Instance;

                    for (int j = 0; j < CCall; j++)
                    {
                        string IndirizzoIP = proxy.ServerRequest();
                        Console.WriteLine($"Proxy {i + 1}, Chiamata {j + 1}: {IndirizzoIP}");

                    }

                }
            }
    }
}
