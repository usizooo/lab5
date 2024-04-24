using ComputerClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ComputerClub.View_Models
{

    public class DevicesController : Singleton
    {
        private string jsonPath = "json/devices.json";
        public static DevicesController Instance => Instance<DevicesController>();
        private DevicesController()
        {
            GlobalApplicationSystem.Instance.OnApplicationLoading += DevicesController_OnApplicationLoading;
            GlobalApplicationSystem.Instance.OnApplicationClosing += DevicesController_OnApplicationClosing;
        }

        private void DevicesController_OnApplicationClosing(object? sender, EventArgs e)
        {
            GlobalApplicationSystem.Instance.Serialization(jsonPath, Devices.Instance.DevicesList);
        }

        private void DevicesController_OnApplicationLoading(object? sender, EventArgs e)
        {
            Devices.Instance.DevicesList = 
                GlobalApplicationSystem.Instance.Deserialization(jsonPath, Devices.Instance.DevicesList);
        }

        public bool TryAddNewDevice(Device device, out string warningInfo)
        {
            if (Devices.Instance.DevicesList.Where(x => x.Name == device.Name).Any()) 
            {
                warningInfo = "Девайс с таким именем уже есть в базе.";
                return false;
            }
            Devices.Instance.DevicesList.Add(device);
            warningInfo = string.Empty;
            return true;
        }

        public List<Device> GetDeviceList() => Devices.Instance.DevicesList;

        public DeviceType[] GetDeviceTypes() => (DeviceType[])Enum.GetValues(typeof(DeviceType));

        public int GetTotalAmount(string deviceName, int rentTimeInMinute) 
        {
            var device = Devices.Instance.DevicesList
                .Where(x => x.Name == deviceName)
                .FirstOrDefault();
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }
            return device.GetPricePerMinute(rentTimeInMinute);
        }
    }
}
