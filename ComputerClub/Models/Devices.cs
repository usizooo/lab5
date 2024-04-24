using ComputerClub.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerClub.Models
{
    public enum DeviceType
    {
        Computer,
        VR
    }

    public class Devices : Singleton
    {
        public List<Device> DevicesList { get; set; } = new List<Device>();
        public static Devices Instance => Instance<Devices>();

        private Devices()
        {
            //DevicesList = new List<Device>()
            //{
            //    new Device("Mac Pro", DeviceType.Computer, 14),
            //    new Device("Oculus Rift", DeviceType.VR, 30)
            //};
        }
    }
}
