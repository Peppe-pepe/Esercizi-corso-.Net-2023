using FIleSystemExercise.Classes;
using System;
using System.Collections.Generic;
using System.IO;

namespace FIleSystemExercise
{
    internal class Program
    {
            static void Main(string[] args)
            {

                List<Account> accounts = new List<Account> { new Account("01", 0), new Account("02", 10) };
                List<Customer> customers = new List<Customer> { new Customer("Valentino Rossi", 44), new Customer("Max Verstappen", 26) };

                WriteListToFile("Output.txt", accounts);
                WriteListToFile("Output.txt", customers);

            }

            static void WriteListToFile(string fileName, List<Account> list)
            {
                try
                {
                    string projectDirectory = Directory.GetCurrentDirectory();
                    string filePath = Path.Combine(projectDirectory, fileName);

                    using (StreamWriter sw = new StreamWriter(filePath,true))
                    {
                        foreach (Account item in list)
                        {
                            sw.WriteLine(item.ToString());
                        }
                    }

                    Console.WriteLine($"Il contenuto della lista è stato scritto nel file '{filePath}' con successo.");
                }
                catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine($"Accesso al file non autorizzato: {ex.Message}");
                }
                catch (DirectoryNotFoundException ex)
                {
                    Console.WriteLine($"Directory non trovata: {ex.Message}");
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Errore di I/O: {ex.Message}");
                }
                 catch (ArgumentNullException ex)
                {
                Console.WriteLine($"Errore nei parametri: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Si è verificato un errore durante la scrittura del file '{fileName}': {ex.Message}");
                }

            }
        static void WriteListToFile(string fileName, List<Customer> list)
        {
            try
            {
                string projectDirectory = Directory.GetCurrentDirectory();
                string filePath = Path.Combine(projectDirectory, fileName);

                using (StreamWriter sw = new StreamWriter(filePath,true))
                {
                    foreach (Customer item in list)
                    {
                        sw.WriteLine(item.ToString());
                    }
                }

                Console.WriteLine($"Il contenuto della lista è stato scritto nel file '{filePath}' con successo.");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Accesso al file non autorizzato: {ex.Message}");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine($"Directory non trovata: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Errore di I/O: {ex.Message}");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Errore nei parametri: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Si è verificato un errore durante la scrittura del file '{fileName}': {ex.Message}");
            }

        }
    }
}
