using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ClassLibrary;
using Microsoft.VisualBasic.FileIO;

namespace CustomerApp
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Up and running!");

            try
            {

                while (true)
                {
                    Console.Write("Please choose an option\n1) GET ALL\n2) GET ONE\n3) POST \n4) PUSH \n5) DELETE \n  > ");
                    int option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            Console.Clear();
                            IList<Customer> Customers = await GenericService<Customer>.GetAll("https://localhost:44307/Customer");

                            Console.WriteLine("List of customers:");
                            foreach (var c in Customers)
                            {
                                Console.WriteLine($"\t-  {c.FirstName}");
                            }

                            Console.ReadLine();
                            break;

                        case 2:
                            Console.Clear();
                            Console.Write("Customer ID: ");
                            int custID = Convert.ToInt32(Console.ReadLine());
                            Customer customer = await GenericService<Customer>.GetOne("https://localhost:44307/Customer", custID);
                            Console.WriteLine($"\nThe customer is:  " +
                                              $"\n\t\tID: {customer.Id}" +
                                              $"\n\t\t{customer.FirstName} {customer.LastName}" +
                                              $"\n\t\tJoined: {customer.YearOfRegistration}");
                            Console.ReadLine();

                            break;


                        case 5:
                            Console.Clear();
                            Console.Write("Customer ID: ");
                            custID = Convert.ToInt32(Console.ReadLine()); 
                            HttpResponseMessage message = await GenericService<Customer>.Delete("https://localhost:44307/Customer", custID);
                            Console.WriteLine("Successful delete: " + message.IsSuccessStatusCode);
                            Console.ReadLine();

                            break;
                            

                    }
                    Console.Clear();
                }




  

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static async void GetOne()
        {
            Customer customer = await GenericService<Customer>.GetOne("https://localhost:44307/Customer", 2);
            Console.WriteLine("\nThe customer with id: 2 \n\t- " + customer.FirstName + "\n");
        }

        private static async void GetList(IList<Customer> Customers)
        {
            Console.WriteLine("List new of customers:");
            foreach (var c in Customers)
            {
                Console.WriteLine($"\t-  {c.FirstName}");
            }
        }

        private static async void Delete()
        {
            Console.WriteLine("Kimon was a bad kiddo, therefore we delete him from the system :c");
            HttpResponseMessage message = await GenericService<Customer>.Delete("https://localhost:44307/Customer", 2);
            Console.WriteLine("\nResponse from server: " + message + "\n\n");


        }

    }
}
