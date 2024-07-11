using System;
using System.Net.Quic;
using System.Runtime.CompilerServices;

class Ali
{
    public static void Main()
    {
        Console.WriteLine("This program prints details of the costumer provided in the list.");
        Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------");
        Costumer C1 = new Costumer();
        C1.ID = 101;
        C1.Name = "John Lorusso";
        C1.Salary = 5000;
        C1.Gender = "Male";

        Costumer C2 = new Costumer();
        C2.ID = 102;
        C2.Name = "Ibrahim Arabaki";
        C2.Salary = 6000;
        C2.Gender = "Male";

        Costumer C3 = new Costumer();
        C3.ID = 103;
        C3.Name = "Mary Luisse";
        C3.Salary = 7000;
        C3.Gender = "Female";

        List<Costumer> LC = new List<Costumer>();
        LC.Add(C1);
        LC.Add(C2);
        LC.Add(C3);

        bool continueSearching = true;

        while (continueSearching)
        {
            Console.WriteLine("Enter ID, Name, Salary, or Gender to find Customer details:");
            string choice = Console.ReadLine().ToUpper();

            Predicate<Costumer> predicate = c => CostumerFinder(c, choice);
            Costumer customer = LC.Find(predicate);

            if (customer != null)
            {
                Console.WriteLine("ID: {0}", customer.ID);
                Console.WriteLine("Name: {0}", customer.Name);
                Console.WriteLine("Salary: {0}", customer.Salary);
                Console.WriteLine("Gender: {0}", customer.Gender);
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------");
                continueSearching = false;
            }
            else
            {
                Console.WriteLine("Customer not found in our list. Please try again!");
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------");
            }
        }
    }

    static bool CostumerFinder(Costumer customer, string choice)
    {
        return customer.ID.ToString() == choice || customer.Name.ToUpper().Contains(choice) || customer.Gender.ToUpper() == choice || customer.Salary.ToString() == choice;
    }
}

public class Costumer
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Salary { get; set; }
    public string Gender { get; set; }
}