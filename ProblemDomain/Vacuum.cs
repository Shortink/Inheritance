//Raphael,Elvis,Aiana 2024-10-10
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.ProblemDomain
{
    public class Vacuum : Appliance
    {
        string grade;
        string voltage;

        public string Grade { get => grade; set => grade = value; }
        public string Voltage { get => voltage; set => voltage = value; }

        public Vacuum()
        {

        }

        public Vacuum(long itemNumber, string brand, int quantity, double wattage, string color, double price, string grade, string voltage) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.Grade = grade;
            this.Voltage = voltage;
        }

        // This method is used to correctly format the data to be written to file.
        public override string FileForFormat()
        {
            return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price};{Grade};{Voltage};";
        }

        public override string ToString()
        {
            return $"Item Number: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\nWattage: {Wattage}\nColor: {Color}\nPrice: {Price}\nGrade: {Grade}\nVoltage: {Voltage}";
        }


    }
}
