using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.ProblemDomain
{
    public class Dishwasher : Appliance
    {
        string feature;
        string soundRating;

        public string Feature { get => feature; set => feature = value; }
        public string SoundRating { get => soundRating; set => soundRating = value; }

        public Dishwasher()
        {

        }

        public Dishwasher(long itemNumber, string brand, int quantity, double wattage, string color, double price, string feature, string soundRating) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.feature = feature;
            this.soundRating = soundRating;
        }

        public override string FileForFormat()
        {
            return $"{ItemNumber},{Brand},{Quantity},{Wattage},{Color},{Price},{Feature},{SoundRating}";
        }

        public override string ToString()
        {
            return $"Dishwasher Information\nItem Number: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\nWattage: {Wattage}\nColor: {Color}\nPrice: {Price}\nFeature: {Feature}\nSoundRating: {SoundRating}\n";
        }
    }
}
