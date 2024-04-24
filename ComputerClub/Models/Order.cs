using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerClub.Models
{
    public class Order
    {
        private readonly int id;
        private readonly string deviceName;
        private readonly int totalAmount;
        private readonly DateTime timeOfRegistration;

        public int Id => id;
        public string DeviceName => deviceName;
        public int TotalAmount => totalAmount;
        public DateTime TimeOfRegistration => timeOfRegistration;


        public Order(int id, string deviceName, int totalAmount, DateTime timeOfRegistration)
        {
            this.id = id;
            this.deviceName = deviceName;
            this.totalAmount = totalAmount;
            this.timeOfRegistration = timeOfRegistration;
        }
    }
}
