using ComputerClub.Models;
using ComputerClub.Views;
using Newtonsoft.Json;
using System.IO;

namespace ComputerClub.View_Models
{

    public class AdminsController : Singleton
    {
        public Admin? CurrentAdmin { get; private set; }
        private string jsonPath = "json/admins.json";
        public static AdminsController Instance => Instance<AdminsController>();
        private AdminsController() 
        {
            GlobalApplicationSystem.Instance.OnApplicationLoading += AdminsController_OnApplicationLoading;
            GlobalApplicationSystem.Instance.OnApplicationClosing += AdminsController_OnApplicationClosing;
            AdminWindow.OnAdminWindowClosed += AdminsController_OnAdminWindowClosed;
        }

        private void AdminsController_OnAdminWindowClosed(object? sender, EventArgs e)
        {
            CurrentAdmin = null;
        }

        private void AdminsController_OnApplicationClosing(object? sender, EventArgs e)
        {
            GlobalApplicationSystem.Instance.Serialization(jsonPath, Admins.Instance.AdminsList);
        }

        private void AdminsController_OnApplicationLoading(object? sender, EventArgs e)
        {
            Admins.Instance.AdminsList = 
                GlobalApplicationSystem.Instance.Deserialization(jsonPath, Admins.Instance.AdminsList, new AdminConverter());
        }

        public bool IsSuccessfulLogin(string login, string password)
        {
            CurrentAdmin = Admins.Instance.AdminsList
                .Where(x => x.Login == login && x.Password == Admin.ComputeSHA256Hash(password))
                .FirstOrDefault();
            return CurrentAdmin != null;
        }

        public bool TrySignInNewAdmin(string login, string password, out string warningInfo)
        {
            if (Admins.Instance.AdminsList.Where(x => x.Login == login).Any())
            {
                warningInfo = "Пользователь с таким логином уже есть в базе.";
                return false;
            }
            Admins.Instance.AdminsList.Add(new Admin(login, password));
            warningInfo = string.Empty;
            return true;
        }
    }
}
