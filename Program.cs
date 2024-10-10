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
    public class Program
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
                        FindAppliance();
                        break;
                    case "3":
                        DisplayApplianceByType();
                        break;
                    case "4":
                        ProduceRandomApplianceList(appliances);
                        break;
                    case "5":
                        SaveListToFile(appliances);
                        exit = true;
                        break;

                }

            }
        }

        public static void PurchaseAppliance()
        {
            Console.WriteLine("Enter the item number of an appliance:");

            long userItemNum = long.Parse(Console.ReadLine());

            bool itemFound = false;

            foreach (Appliance appliance in appliances)
            {
                if (appliance.ItemNumber == userItemNum)
                {
                    if (appliance.IsAvailable() == true)
                    {
                        itemFound = true;
                        appliance.Quantity--;
                        appliance.Checkout();
                    }
                    else if (appliance.IsAvailable() == false)
                    {
                        itemFound = true;
                        Console.WriteLine("The appliance is not available to be checked out\n");
                    }

                    break;
                }
            }

            if (!itemFound)
            {
                Console.WriteLine("No appliances found with that number\n");
            }
        }

        public static void FindAppliance()
        {
            Console.WriteLine("Enter brand to search for:");

            string userBrandInput = Console.ReadLine().ToLower();

            Console.WriteLine("Matching Appliances:");

            foreach (Appliance appliance in appliances)
            {
                if (appliance.Brand.ToLower() == userBrandInput)
                {

                    Console.WriteLine(appliance.ToString());
                    Console.WriteLine("\n");
                }
            }
        }

        public static void DisplayApplianceByType()
        {
            Console.WriteLine("Appliance Types\n1 - Refrigerators\n2 - Vacuums\n3 - Microwaves\n4 - Dishwashers");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Enter number of doors: 2 (double door), 3 (three doors), 4 (four doors): ");
                    int doorsInput = int.Parse(Console.ReadLine());

                    Console.WriteLine("Matching refrigerators:\n");

                    foreach (Appliance appliance in appliances)
                    {
                        if (appliance is Refrigerator refrigerator)
                        {
                            if (doorsInput == refrigerator.NumOfDoors)
                            {
                                Console.WriteLine(appliance.ToString());
                                Console.WriteLine("\n");
                            }
                        }
                    }
                    break;
                case "2":
                    Console.WriteLine("Enter battery voltage value. 18 V (low) or 24 V (high)");
                    string voltageInput = Console.ReadLine();

                    Console.WriteLine("Matching vacuums:\n");

                    foreach (Appliance appliance in appliances)
                    {
                        if (appliance is Vacuum vacuum)
                        {
                            if (voltageInput == "18" && vacuum.Voltage == "Low")
                            {
                                Console.WriteLine(vacuum.ToString());
                                Console.WriteLine("\n");
                            }
                            else if (voltageInput == "24" && vacuum.Voltage == "High")
                            {
                                Console.WriteLine(vacuum.ToString());
                                Console.WriteLine("\n");
                            }
                        }
                    }
                    break;
                case "3":
                    Console.WriteLine("Room where the microwave will be installed: K (kitchen) or W (work site):");
                    char roomInput = char.Parse(Console.ReadLine());

                    Console.WriteLine("Matching microwaves:\n");

                    foreach (Appliance appliance in appliances)
                    {
                        if (appliance is Microwave microwave)
                        {
                            if (roomInput == 'K' && microwave.RoomType == "Kitchen")
                            {
                                Console.WriteLine(microwave.ToString());
                                Console.WriteLine("\n");
                            }
                            else if (roomInput == 'W' && microwave.RoomType == "Work Site")
                            {
                                Console.WriteLine(microwave.ToString());
                                Console.WriteLine("\n");
                            }
                        }
                    }
                    break;
                case "4":
                    Console.WriteLine("Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate):");
                    string soundInput = Console.ReadLine();

                    Console.WriteLine("Matching dishwashers:\n");

                    foreach (Appliance appliance in appliances)
                    {
                        if (appliance is Dishwasher dishwasher)
                        {
                            if (soundInput == "Qt" && dishwasher.SoundRating == "Quietest")
                            {
                                Console.WriteLine(dishwasher.ToString());
                                Console.WriteLine("\n");
                            }
                            else if (soundInput == "Qr" && dishwasher.SoundRating == "Quieter")
                            {
                                Console.WriteLine(dishwasher.ToString());
                                Console.WriteLine("\n");
                            }
                            else if (soundInput == "Qu" && dishwasher.SoundRating == "Quiet")
                            {
                                Console.WriteLine(dishwasher.ToString());
                                Console.WriteLine("\n");
                            }
                            else if (soundInput == "M" && dishwasher.SoundRating == "Moderate")
                            {
                                Console.WriteLine(dishwasher.ToString());
                                Console.WriteLine("\n");
                            }
                        }
                    }
                    break;
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
                    string voltage = fields[7];

                    if (voltage == "18")
                    {
                        voltage = "Low";
                    }
                    else if (voltage == "24")
                    {
                        voltage = "High";
                    }

                    appliances.Add(new Vacuum(long.Parse(itemNum), brand, quantity, wattage, color, price, grade, voltage));
                }
                else if (itemNum[0] == '3')
                {
                    double capacity = double.Parse(fields[6]);
                    string roomType = fields[7];

                    if (roomType == "K")
                    {
                        roomType = "Kitchen";
                    }
                    else if (roomType == "W")
                    {
                        roomType = "Work Site";
                    }

                    appliances.Add(new Microwave(long.Parse(itemNum), brand, quantity, wattage, color, price, capacity, roomType));
                }
                else if (itemNum[0] == '4' || itemNum[0] == '5')
                {
                    string feature = fields[6];
                    string soundRating = fields[7];

                    if (soundRating == "Qt")
                    {
                        soundRating = "Quietest";
                    }
                    else if (soundRating == "Qr")
                    {
                        soundRating = "Quieter";
                    }
                    else if (soundRating == "Qu")
                    {
                        soundRating = "Quiet";
                    }
                    else if (soundRating == "M")
                    {
                        soundRating = "Moderate";
                    }

                    appliances.Add(new Dishwasher(long.Parse(itemNum), brand, quantity, wattage, color, price, feature, soundRating));
                }
            }
        }

        public static void ProduceRandomApplianceList(List<Appliance> appliance)
        {
            Random randomNum = new Random();
            List<Appliance> shuffledAppliance = new List<Appliance>(appliance.OrderBy(x => randomNum.Next()).ToList());  //orders list by a random number to produce a random order of appliances everytime method gets called
            Console.WriteLine("Enter number of appliances:");
            int numAppliance = int.Parse(Console.ReadLine());
            Console.WriteLine("Random Appliances:\n");
            for(int i = 0; i < numAppliance; i++)
            {
                Console.WriteLine(shuffledAppliance[i].ToString());
            }
        }

        public static void SaveListToFile(List<Appliance> appliance)  //deletes existing file and writes new list to file
        {
            string path = "..\\..\\res\\appliancestest.txt";
            File.Delete(path);
            foreach (Appliance item in appliance)
            {
                File.AppendAllText(path, $"{item.FileForFormat()}\n");
            }

        }
    }
}
