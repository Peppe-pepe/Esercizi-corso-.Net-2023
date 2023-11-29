using ProxyExercise.Classes;
using System;
using System.Collections.Generic;

namespace ProxyExercise
{
    internal class Program
    {
            static void Main(string[] args)
            {
                int NInstance = 3;// numero di istanze al proxy
                int NCall = 4;// numero di chiamate per istanza
                string[,] calls = new string[NInstance, NCall];
                for (int i = 0; i < NInstance; i++)
                {
                    SingletonProxy proxy = SingletonProxy.Instance;

                    for (int j = 0; j < NCall; j++)
                    {
                        calls[i,j]=proxy.ServerRequest(j);
                        Console.WriteLine($"Proxy {i + 1}, Chiamata {j + 1}: {calls[i,j]}");
                        if (i > 0 && calls[i - 1, j] == calls[i, j])
                            Console.WriteLine("proxy is ok");
                    }

                }
            }
    }
}
