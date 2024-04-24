using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerClub.Models
{
    public class Device
    {
        public string Name { get; private set; }
        public DeviceType Type { get; private set; }
        public int PricePerMinute { get; private set; }

        public Device(string name, DeviceType type, int pricePerMinute)
        {
            Name = name;
            Type = type;
            PricePerMinute = pricePerMinute;
        }

        public int GetPricePerMinute(int rentTimeInMinute) => rentTimeInMinute * PricePerMinute; 
    }
}
