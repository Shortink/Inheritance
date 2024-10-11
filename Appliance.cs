//Raphael,Elvis,Aiana 2024-10-10
//Parent class for dishwasher, microwave, refrigerator, and vacum classes.
//contains Abstract filefor format method to format data to be written to file in all child classes.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public abstract class Appliance
    {
        long itemNumber;
        string brand;
        int quantity;
        double wattage;
        string color;
        double price;

        public long ItemNumber { get => itemNumber; set => itemNumber = value; }
        public string Brand { get => brand; set => brand = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double Wattage { get => wattage; set => wattage = value; }
        public string Color { get => color; set => color = value; }
        public double Price { get => price; set => price = value; }

        public Appliance()
        {
            
        }

        public Appliance(long itemNumber, string brand, int quantity, double wattage, string color, double price)
        {
            this.ItemNumber = itemNumber;
            this.Brand = brand;
            this.Quantity = quantity;
            this.Wattage = wattage;
            this.Color = color;
            this.Price = price;
        }

        public bool IsAvailable()
        {
            if (Quantity >= 1)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public void Checkout()
        {
            Console.WriteLine($"Appliance {ItemNumber} has been checked out\n");
        }

        public abstract string FileForFormat();

        public override string ToString()
        {
            return $"Appliance Information\nItem Number: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\nWattage: {Wattage}\nPrice: {Price}";
        }
    }
}
