﻿//Raphael,Elvis,Aiana 2024-10-10
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.ProblemDomain
{
    public class Refrigerator : Appliance
    {
        int numOfDoors;
        double height;
        double width;

        public int NumOfDoors { get => numOfDoors; set => numOfDoors = value; }
        public double Height { get => height; set => height = value; }
        public double Width { get => width; set => width = value; }

        public Refrigerator()
        {
            
        }

        public Refrigerator(long itemNumber, string brand, int quantity, double wattage, string color, double price, int doors, double height, double width) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.NumOfDoors = doors;
            this.Height = height;
            this.Width = width;
        }
        // This method is used to correctly format the data to be written to file.
        public override string FileForFormat()
        {
            return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price};{NumOfDoors};{Height};{Width}";
        }
        public override string ToString()
        {
            return $"Item Number: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\nWattage: {Wattage}\nColor: {Color}\nPrice: {Price}\nNumber of Doors: {NumOfDoors}\nHeight: {Height}\nWidth: {Width}\n";
        }
    }
}
