using ComputerClub.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerClub.View_Models
{
    public class OrdersController : Singleton
    {
        private string jsonPath = "json/orders.json";
        public static OrdersController Instance => Instance<OrdersController>();
        private OrdersController()
        {
            GlobalApplicationSystem.Instance.OnApplicationLoading += OrdersController_OnApplicationLoading;
            GlobalApplicationSystem.Instance.OnApplicationClosing += OrdersController_OnApplicationClosing;
        }

        private void OrdersController_OnApplicationClosing(object? sender, EventArgs e)
        {
            GlobalApplicationSystem.Instance.Serialization(jsonPath, Orders.Instance.OrdersList);
        }

        private void OrdersController_OnApplicationLoading(object? sender, EventArgs e)
        {
            Orders.Instance.OrdersList = 
                GlobalApplicationSystem.Instance.Deserialization(jsonPath, Orders.Instance.OrdersList);
        }

        public bool TryPushNewOrder(string deviceName, int rentTimeInMinute, out string warningInfo)
        {
            try
            {
                var totalAmount = DevicesController.Instance.GetTotalAmount(deviceName, rentTimeInMinute);
                Orders.Instance.OrdersList.Add(new Order(
                    Orders.Instance.OrdersList.Count,
                    deviceName,
                    totalAmount,
                    DateTime.Now));
            }
            catch (Exception ex)
            {
                warningInfo = ex.Message;
                return false;
            }
            warningInfo = string.Empty;
            return true;
        }

        public List<Order> GetOrdersList() => Orders.Instance.OrdersList;
    }
}
