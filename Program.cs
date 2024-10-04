using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Inheritance.ProblemDomain;
using System.Runtime.InteropServices;

namespace Inheritance
{
    internal class Program
    {
        static List<Appliance> appliances = new List<Appliance>();
        static void Main(string[] args)
        {

            LoadFile();

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine($"Welcome to Modern Appliances!\nHow may we assist you?\n1 - Check out appliances\n2 - Find appliances by brand\n3 - Display appliances by type\n4 - Produce random appliance list\n5 - Save and exit");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        PurchaseAppliance();
                        break;
                    case "2":
                        //FindAppliance();
                        break;
                    case "3":
                        //DisplayApplianceByType();
                        break;
                    case "4":
                        //ProduceRandomApplianceList();
                        break;
                    case "5":
                        exit = true;
                        break;

                }

            }
        }

        public static void PurchaseAppliance()
        {
            Console.WriteLine("Enter the item number of an appliance:");

            long userItemNum = long.Parse(Console.ReadLine());

            foreach (Appliance appliance in appliances)
            {
                if (appliance.ItemNumber == userItemNum)
                {
                    if (appliance.IsAvailable())
                    {
                        appliance.Quantity--;
                        appliance.Checkout();
                    }
                } else
                {
                    Console.WriteLine("Appliance not found.");
                    break;
                }
                
            }
        }

        public static void LoadFile()
        {
            string path = "..\\..\\res\\appliances.txt";

            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                string[] fields = line.Split(';');

                string itemNum = fields[0];
                string brand = fields[1];
                int quantity = int.Parse(fields[2]);
                double wattage = double.Parse(fields[3]);
                string color = fields[4];
                double price = double.Parse(fields[5]);

                if (itemNum[0] == '1')
                {
                    int numOfDoors = int.Parse(fields[6]);
                    double height = double.Parse(fields[7]);
                    double width = double.Parse(fields[8]);

                    appliances.Add(new Refrigerator(long.Parse(itemNum), brand, quantity, wattage, color, price, numOfDoors, height, width));
                }
                else if (itemNum[0] == '2')
                {
                    string grade = fields[6];
                    double voltage = double.Parse(fields[7]);

                    //appliances.Add(new Vacuum(long.Parse(itemNum), brand, quantity, wattage, color, price, grade,  voltage));
                }
                else if (itemNum[0] == '3')
                {
                    double capacity = double.Parse(fields[6]);
                    char roomType = char.Parse(fields[7]);

                    //appliances.Add(new Microwave(long.Parse(itemNum), brand, quantity, wattage, color, price, capacity, roomType));
                }
                else if (itemNum[0] == '4' && itemNum[0] == '5')
                {
                    string feature = fields[6];
                    string soundRating = fields[7];

                    appliances.Add(new Dishwasher(long.Parse(itemNum), brand, quantity, wattage, color, price, feature, soundRating));
                }
            }
        }
    }
}
